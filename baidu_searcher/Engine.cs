using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baidu_searcher
{
    public class Engine
    {
        const string pre = "https://m.baidu.com/s?word=";

        readonly HttpMessageHandler messageHandler;

        static Engine() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        public Engine(HttpMessageHandler messageHandler) => this.messageHandler = messageHandler;
        public Engine() {
            messageHandler = new SocketsHttpHandler();
        }

        public IEnumerable<IEntity> Search([NotNull] string keyword, params string[] morekeywords)
        {
            keyword = keyword ?? throw new ArgumentNullException(nameof(keyword));
            morekeywords = morekeywords ?? Array.Empty<string>();
            string[] arr = new string[morekeywords.Length + 1];
            arr[0] = keyword;
            if (morekeywords.Length > 0)
                Array.Copy(morekeywords, 0, arr, 1, morekeywords.Length);
            string keywordMerged = string.Join(' ', arr);
            string url = pre + System.Web.HttpUtility.UrlEncode(keywordMerged, Encoding.GetEncoding("GBK"));
            string html;
            using (var client = new HttpClient(messageHandler, false))
                html = client.GetStringAsync(url).Result;
            return Parser.Parse(html);
        }
    }
}
