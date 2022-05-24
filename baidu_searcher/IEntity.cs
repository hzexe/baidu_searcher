using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baidu_searcher
{
    /// <summary>
    /// 常规搜索结果
    /// </summary>
    public class Www_normal : IEntity
    {
        /// <inheritdoc/>
        public string Srcid => "www_normal";
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; internal set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; internal set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string From { get; internal set; }
        /// <inheritdoc/>
        public string Link { get; internal set; }
    }




    /// <summary>
    /// 搜索结果
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 结果类型
        /// </summary>
        public string Srcid { get; }

        /// <summary>
        /// 连接
        /// </summary>
        public string Link { get; }
    }
}
