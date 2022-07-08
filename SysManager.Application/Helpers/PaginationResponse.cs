using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Helpers
{
    public class PaginationResponse<T> where T : class
    {
        public int _pageSize { get; set; }
        public int _page { get; set; }
        public int _total { get; set; }
        public T[] Items { get; set; }
    }
}
