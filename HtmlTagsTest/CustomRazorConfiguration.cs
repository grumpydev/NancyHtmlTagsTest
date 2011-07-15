namespace HtmlTagsTest
{
    using System.Collections.Generic;

    using Nancy.ViewEngines.Razor;

    public class CustomRazorConfiguration : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            return new[]
                {
                    "HtmlTagsTest",
                };
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            return new[]
                {
                    "HtmlTagsTest",
                };
        }

        public bool AutoIncludeModelNamespace
        {
            get
            {
                return true;
            }
        }
    }
}