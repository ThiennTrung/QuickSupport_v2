using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using DevExpress.XtraPrinting.Native;
using QuickSupport_v2.Model;

namespace QuickSupport_v2.DbTool
{
    public class DbTool
    {
        public static DataTable Query(SqlConnection connection, string strCommand, FPT.Framework.Data.DataObject parameters)
        {
            DataTable dataTable = new DataTable();
            if (ExIsOpen(connection))
            {
                using (SqlCommand command = new SqlCommand(strCommand, connection))
                {
                    try
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = strCommand;
                            command.CommandType = CommandType.Text;
                            if (parameters != null)
                            {
                                foreach (KeyValuePair<string, object> parameter in (IEnumerable<KeyValuePair<string, object>>)parameters)
                                {
                                    if (!(parameter.Key == string.Empty))
                                        command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value ?? (object)DBNull.Value);
                                }
                            }
                            sqlDataAdapter.Fill(dataTable);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return null;
                    }
                }
            }
            return dataTable;
        }

        public static bool ExecuteNonQuery(SqlConnection connection, string strCommand, FPT.Framework.Data.DataObject parameters = null)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    if (ExIsOpen(connection))
                    {
                        cmd.CommandText = strCommand;
                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, object> parameter in (IEnumerable<KeyValuePair<string, object>>)parameters)
                            {
                                if (!(parameter.Key == string.Empty))
                                    cmd.Parameters.AddWithValue("@" + parameter.Key, parameter.Value ?? (object)DBNull.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;  
            }
        }

        public static DataSet QueryStored(SqlConnection connection, string strCommand, FPT.Framework.Data.DataObject parameters)
        {
            DataSet ds = new DataSet();
            if (ExIsOpen(connection))
            {
                using (SqlCommand command = new SqlCommand(strCommand, connection))
                {
                    try
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                        {

                            command.CommandText = strCommand;
                            command.CommandType = CommandType.StoredProcedure;
                            if (parameters != null)
                            {
                                foreach (KeyValuePair<string, object> parameter in (IEnumerable<KeyValuePair<string, object>>)parameters)
                                {
                                    if (!(parameter.Key == string.Empty))
                                        command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value ?? (object)DBNull.Value);
                                }
                            }
                            sqlDataAdapter.Fill(ds);
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return null;
                    }
                }
            }
            return ds;
        }

        public static void ExcuteStored(SqlConnection connection, string strCommand, FPT.Framework.Data.DataObject parameters)
        {
            if (ExIsOpen(connection))
            {
                using (SqlCommand command = new SqlCommand(strCommand, connection))
                {
                    try
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                        {
                            command.CommandText = strCommand;
                            command.CommandType = CommandType.StoredProcedure;
                            if (parameters != null)
                            {
                                foreach (KeyValuePair<string, object> parameter in (IEnumerable<KeyValuePair<string, object>>)parameters)
                                {
                                    if (!(parameter.Key == string.Empty))
                                        command.Parameters.AddWithValue("@" + parameter.Key, parameter.Value ?? (object)DBNull.Value);
                                }
                            }
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        public static bool ExIsOpen(SqlConnection connection)
        {
            if (connection == null) { return false; }
            if (connection.State == ConnectionState.Open) { return true; }

            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return false;
        }
        public static void CloseConn(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static string Object2DB(string prop)
        {
            switch (prop)
            {
                case "Anchor":
                    return "ANCHOR";
                case "Attributes":
                    return "ATTRIBUTES";
                case "Command_Click":
                    return "CLICK";
                case "Command_DoubleClick":
                    return "DOUBLECLICK";
                case "Command_SelChanged":
                    return "SELCHANGED";
                case "Command_TextChanged":
                    return "TEXTCHANGED";
                case "DataBindingName":
                    return "DATABINDINGNAME";
                case "DataRefName":
                    return "DATAREFNAME";
                case "Dock":
                    return "DOCK";
                case "Enabled":
                    return "ENABLE";
                case "FormatId":
                    return "FORMAT";
                case "HOSPITAL_ID":
                    return "HOSPITAL_ID";
                case "Height":
                    return "HEIGHT";
                case "Help":
                    return "HELP";
                case "HotKeyId":
                    return "HOTKEY";
                case "Id":
                    return "ID";
                case "Image1":
                    return "IMAGE1";
                case "Image2":
                    return "IMAGE2";
                case "Left":
                    return "X";
                case "Locale":
                    return "LOCALE";
                case "Margin":
                    return "MARGIN";
                case "MaxLength":
                    return "MAXLENGTH";
                case "Name":
                    return "NAME";
                case "Padding":
                    return "PADDING";
                case "Page":
                    return "PAGE";
                case "ParentName":
                    return "PARENTNAME";
                case "StyleId":
                    return "STYLE";
                case "TabIndex":
                    return "TABINDEX";
                case "Template":
                    return "TEMPLATE";
                case "Text":
                    return "TEXT";
                case "Top":
                    return "Y";
                case "ValidationId":
                    return "VALIDATION";
                case "Visible":
                    return "VISIBLE";
                case "WaterMark":
                    return "WATERMARK";
                case "Width":
                    return "WIDTH";
                case "X":
                    return "X";
                case "Y":
                    return "Y";
                default:
                    return string.Empty;
            }
        }
        public static string DB2Object(string prop)
        {
            switch (prop)
            {
                case "ANCHOR":
                    return "Anchor";
                case "ATTRIBUTES":
                    return "Attributes";
                case "CLICK":
                    return "Command_Click";
                case "DATABINDINGNAME":
                    return "DataBindingName";
                case "DATAREFNAME":
                    return "DataRefName";
                case "DOCK":
                    return "Dock";
                case "DOUBLECLICK":
                    return "Command_DoubleClick";
                case "ENABLE":
                    return "Enable";
                case "FORMAT":
                    return "FormatId";
                case "HEIGHT":
                    return "Height";
                case "HELP":
                    return "Help";
                case "HOTKEY":
                    return "HotKeyId";
                case "ID":
                    return "Id";
                case "IMAGE1":
                    return "Image1";
                case "IMAGE2":
                    return "Image2";
                case "MARGIN":
                    return "Margin";
                case "MAXLENGTH":
                    return "MaxLength";
                case "NAME":
                    return "Name";
                case "PADDING":
                    return "Padding";
                case "PAGE":
                    return "Page";
                case "PARENTNAME":
                    return "ParentName";
                case "SELCHANGED":
                    return "Command_SelChanged";
                case "STYLE":
                    return "StyleId";
                case "TABINDEX":
                    return "TabIndex";
                case "TEMPLATE":
                    return "Template";
                case "TEXT":
                    return "Text";
                case "TEXTCHANGED":
                    return "Command_TextChanged";
                case "VALIDATION":
                    return "ValidationId";
                case "VISIBLE":
                    return "Visible";
                case "WATERMARK":
                    return "WaterMark";
                case "WIDTH":
                    return "Width";
                case "X":
                    return "Left";
                case "Y":
                    return "Top";
                default:
                    return prop;
            }
        }
        public static List<FPT.Framework.Data.DataObject> Decompress(FileInfo fileToDecompress)
        {
            List<FPT.Framework.Data.DataObject> dataObjectList = null;
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                using (GZipStream gzipStream = new GZipStream((Stream)originalFileStream, CompressionMode.Decompress))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)gzipStream))
                    {
                        dataObjectList = JsonConvert.DeserializeObject<List<FPT.Framework.Data.DataObject>>(streamReader.ReadToEnd());
                    }
                }
            }
            return dataObjectList;
        }

    }
}
