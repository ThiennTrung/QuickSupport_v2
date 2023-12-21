using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSupport_v2.Model
{
    public class Result
    {
        public Result()
        {
            TextInput = new StringBuilder();
            Query = new StringBuilder();
            IdDao = string.Empty;
        }
        public StringBuilder TextInput { get; set; }
        public StringBuilder Query { get; set; }
        public string IdDao { get; set; }
    }
}
