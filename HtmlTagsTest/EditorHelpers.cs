namespace HtmlTagsTest
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web;

    using HtmlTags;

    using Nancy.ViewEngines.Razor;

    public static class EditorHelpers
    {
        public static IHtmlString EditorFor<TModel>(TModel model, Expression<Func<TModel, object>> objectProperty)
        {
            var lambda = objectProperty as LambdaExpression;
            if (lambda == null)
            {
                return null;
            }

            var property = lambda.Body as MemberExpression;
            if (property == null)
            {
                return null;
            }

            var member = property.Member as PropertyInfo;
            if (member == null)
            {
                return null;
            }

            return GenerateEditor(model, member);
        }

        public static IHtmlString EditorFor<TModel>(TModel model, string propertyName)
        {
            var member = typeof(TModel).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if (member == null)
            {
                return null;
            }

            return GenerateEditor(model, member);
        }

        private static IHtmlString GenerateEditor<TModel>(TModel model, PropertyInfo member)
        {
            var modelValue = member.GetValue(model, null);

            if (modelValue == null)
            {
                return null;
            }

            var tag = new TextboxTag(member.Name, modelValue.ToString()).Id(member.Name);

            return new NonEncodedHtmlString(tag.ToString());
        }
    }
}