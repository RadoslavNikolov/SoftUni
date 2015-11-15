namespace _04_HTML_Dispatcher
{
    public static class HTMLDispatcher
    {

        public static string CreateImage(string source, string alt, string tiitle)
        {
            ElementBuilder image = new ElementBuilder("img");
            image.AddAttribute("src",source);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title",tiitle);
            return image.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder urlElement = new ElementBuilder("a");
            urlElement.AddAttribute("href",url);
            urlElement.AddAttribute("title",title);
            urlElement.AddContent(text);
            return urlElement.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder inputElelement = new ElementBuilder("input");
            inputElelement.AddAttribute("type",type);
            inputElelement.AddAttribute("name", name);
            inputElelement.AddAttribute("value",value);
            return inputElelement.ToString();
        }
    }
}