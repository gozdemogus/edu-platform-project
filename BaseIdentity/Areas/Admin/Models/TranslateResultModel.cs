using System;
using System.Collections.Generic;

namespace BaseIdentity.PresentationLayer.Areas.Admin.Models
{
	public class TranslateResultModel
    {
      
    public Data data { get; set; }
    }

    public class Data
    {
        public List<Translation> translations { get; set; }
    }

    public class Translation
    {
        public string translatedText { get; set; }
    }
}

