using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProjectSpecParams
    {
        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
