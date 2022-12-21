﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeSystem.Shared.Models
{
    public class QueryParameters
    {
        private int _pageSize = 10;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; }


        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
    }
}
