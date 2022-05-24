using HtmlAgilityPack;

namespace baidu_searcher
{
    internal class Parser
    {
        public static IEnumerable<IEntity> Parse(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectNodes("//div[@id='results']/div[@class='c-result result' and @new_srcid='1599']")
                 .Select(x =>
                 {
                     return new Www_normal
                     {
                         Title = x.SelectSingleNode("//header").InnerText.Trim(),
                         Description = x.SelectSingleNode("//div[@class='c-touchable-feedback-content']").InnerText.Trim(),
                         From = x.SelectSingleNode("//section//div[contains(@class,'c-flexbox')]/div[1]/div[1]/div[1]/*[1]").InnerText.Trim(),
                         Link = x.SelectSingleNode("//article").GetAttributeValue("rl-link-href", null),
                     };
                 });
        }

    }
}