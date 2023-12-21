using FPT.Framework.Data;

namespace QuickSupport_v2.Model
{
    public class QuerySql
    {
        public string query { get; set; }

        public string code { get; set; }

        public DataObject param { get; set; }
    }
}
