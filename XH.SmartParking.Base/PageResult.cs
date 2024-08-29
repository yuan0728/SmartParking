using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.SmartParking.Base
{
    public class PageResult<T>
    {
        public string? SerarchString { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<T>? DataList { get; set; }
    }
}
