namespace HtmlTagsTest
{
    using Nancy;

    public class MainModule : NancyModule
    {
        public MainModule()
        {
            Get["/"] = _ => View["Index", new TestModel("Hello!")];
        }
    }
}