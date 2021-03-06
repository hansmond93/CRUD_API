using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRUD_Core.Specifications
{
    /// <summary>
    /// Query parameters
    /// </summary>
    public class ModelSpecParams
    {
        private const int MaxPageSize = 50;

        private string _search;

        public int PageIndex { get; set; } = 1;

        // default page size
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        /// <summary>
        /// sort by the following 'idAsc', 'idDesc', 'titleAsc', 'titleDesc' 
        /// </summary>
        public string Sort { get; set; }

        public bool? IsCompleted { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
