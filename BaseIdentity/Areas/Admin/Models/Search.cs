using System;
using System.Collections.Generic;

namespace BaseIdentity.PresentationLayer.Areas.Admin.Models
{
    public class SearchResponse
    {
        public QueryContext queryContext { get; set; }
        public WebPageCollection webPages { get; set; }
    }

    public class QueryContext
    {
        public string originalQuery { get; set; }
    }

    public class WebPageCollection
    {
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<WebPage> value { get; set; }
    }

    public class WebPage
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public bool isFamilyFriendly { get; set; }
        public string displayUrl { get; set; }
        public string snippet { get; set; }
        public DateTime dateLastCrawled { get; set; }
        public string language { get; set; }
        public bool isNavigational { get; set; }
    }

}

