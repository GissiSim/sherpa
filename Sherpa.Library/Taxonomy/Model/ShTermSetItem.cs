﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sherpa.Library.Taxonomy.Model
{
    public abstract class ShTermSetItem : ShTaxonomyItem
    {
        [JsonProperty(Order = 3)]
        public string CustomSortOrder { get; set; }
        [JsonProperty(Order = 4)]
        public bool NotAvailableForTagging { get; set; }
        [JsonProperty(Order = 5)]
        public List<ShTerm> Terms { get; set; }

        protected ShTermSetItem()
        {
            Terms = new List<ShTerm>();
        }
        protected ShTermSetItem(Guid id, string title) : base(id, title)
        {
            Terms = new List<ShTerm>();
        }
        public bool ShouldSerializeTerms()
        {
            return Terms.Count > 0;
        }
    }
}
