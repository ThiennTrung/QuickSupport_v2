using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSupport_v2.Function
{
    public class StringWriterWithEncoding : StringWriter
    {
        public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
            : base(sb)
        {
            this.m_Encoding = encoding;
        }
        private readonly Encoding m_Encoding;
        public override Encoding Encoding
        {
            get
            {
                return this.m_Encoding;
            }
        }
    }

}
