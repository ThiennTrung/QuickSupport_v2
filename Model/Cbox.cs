using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSupport_v2.Model
{
    public class Cbox
    {
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }

        public Cbox(string DisplayMember, string ValueMember)
        {
            this.DisplayMember = DisplayMember;
            this.ValueMember = ValueMember;
        }
    }
}
