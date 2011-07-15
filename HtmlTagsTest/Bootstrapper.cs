namespace HtmlTagsTest
{
    using Nancy;
    using Nancy.ViewEngines.Razor;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void InitialiseInternal(TinyIoC.TinyIoCContainer container)
        {
            base.InitialiseInternal(container);

            container.Register<IRazorConfiguration, CustomRazorConfiguration>();
        }
    }
}