using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class QuoteInProg
    {
        public QuoteInProg() { }
        public QuoteInProg(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<FeatureInProg> Features { get; set; } = new List<FeatureInProg>();
    }
}
