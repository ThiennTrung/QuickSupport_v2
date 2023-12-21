using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuickSupport.Function
{
   public class readfileExcel
    {
        public static DataSet GetDataTableFromExcel(string PathExcel)
        {
            DataSet dtSet = new DataSet();
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;


            Excel.Range range;
            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;

            if (File.Exists(PathExcel))
            {
                try
                {
                    CultureInfo original_Language = System.Threading.Thread.CurrentThread.CurrentCulture;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    xlApp = new    Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkBook = xlApp.Workbooks.Open(PathExcel, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    if (xlWorkBook.Worksheets.Count == 0) return null;
                    String[] excelSheets = new String[xlWorkBook.Worksheets.Count];
                    var lstSheetNames = new DataTable();
                    lstSheetNames.TableName = "lstSheetNames";
                    lstSheetNames.Columns.Add("IndexSheet", typeof(int));
                    lstSheetNames.Columns.Add("SheetName", typeof(string));
                    int STTSheet = 0;
                    int iCount = 0;
                    foreach (Microsoft.Office.Interop.Excel.Worksheet wSheet in xlWorkBook.Worksheets)
                    {
                        //if (wSheet.Name.Contains("Sheet1"))
                        //{
                            STTSheet += 1;
                            DataRow dtRow = lstSheetNames.NewRow();
                            dtRow["IndexSheet"] = STTSheet;
                            dtRow["SheetName"] = wSheet.Name;
                            lstSheetNames.Rows.Add(dtRow);

                            //excelSheets[iCount] = wSheet.Name;
                            iCount++;
                            DataTable dtTemp = new DataTable();
                            dtTemp.TableName = wSheet.Name;//"Table" + iCount;


                            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(iCount);

                           Excel.Range cell1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                            //get the text
                            string text = cell1.Text + "";

                            range = xlWorkSheet.UsedRange;
                            //rw = range.Rows.Count;
                            //cl = range.Columns.Count;
                            //Array myValues = (Array)range.Cells.Value2;
                            object[,] myValues = (object[,])range.Value;// Value2;
                            rw = myValues.GetLength(0);
                            cl = myValues.GetLength(1);
                            //Excel.Worksheet sheet = (Excel.Worksheet)xlWorkBook.Sheets.get_Item(1);
                            //range.NumberFormat = "@";

                            int vertical = myValues.GetLength(0);
                            int horizontal = myValues.GetLength(1);

                            if (cl <= 0 || rw <= 0)
                            {
                                continue;
                            }
                            int IndexStartRow = 1;

                            for (cCnt = 1; cCnt <= cl; cCnt++)//tạo cột
                            {
                                DataColumn c = new DataColumn();
                                string colName =  ConvertSafe.ToString(myValues[IndexStartRow, cCnt]).Trim();//string str = (string)(myValues[rCnt, cCnt]);
                                if (colName + "" == "")
                                { colName = "NoName_" + cCnt; }
                                colName = colName.Replace('\n', ' ').Replace("  ", " ");
                                if (dtTemp.Columns.Contains(colName))
                                {
                                    colName = colName + cCnt.ToString();
                                }
                                c.ColumnName = colName;
                                c.DataType = typeof(string);
                                dtTemp.Columns.Add(c);
                            }

                            //Thêm dòng cho datatable
                            for (rCnt = IndexStartRow + 1; rCnt <= rw; rCnt++)
                            {
                                DataRow r = dtTemp.NewRow();
                                for (cCnt = 1; cCnt <= cl; cCnt++)//đổ dữ liệu
                                {
                                    string CellVal = String.Empty;

                                    CellVal =ConvertSafe.ToString(myValues[rCnt, cCnt]);
                                    //if (CellVal != "") CellVal = CellVal.Replace(" 12:00:00 AM", "");
                                    //string str = (range.Cells[rCnt, cCnt] as Excel.Range).Value2 == null ? "" : (range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString();
                                    try
                                    {
                                        //còn lỗi chỗ có format
                                        //DateTime value = ReadDateFromExcel(CellVal);
                                        //if (value != DateTime.MinValue)
                                        //    CellVal = value.ToString("dd/MM/yyyy HH:mm:ss");
                                    }
                                    catch (Exception) { }
                                    r[cCnt - 1] = CellVal;
                                }
                                // if (!IsEmptyDataRow(r))
                                if ( r!=null)
                                {
                                    dtTemp.Rows.Add(r);
                                }

                            }

                            dtTemp.AcceptChanges();
                            dtSet.Tables.Add(dtTemp);
                            Marshal.ReleaseComObject(xlWorkSheet);
                        //}
                    }

                    //}
                    lstSheetNames.AcceptChanges();
                    dtSet.Tables.Add(lstSheetNames);

                    xlWorkBook.Close(true, null, null);
                    xlApp.Quit();
                    //< restore language >
                    System.Threading.Thread.CurrentThread.CurrentCulture = original_Language;

                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }
                catch (FileLoadException ex)
                {
                    //UI.ShowError("Vui lòng tắt chương trình excel trước khi import \n" + ex.Message);
                    return null;
                }
                catch (ArgumentException ex)
                {
                    //UI.ShowError(ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Dự đoán nguyên nhân lỗi:\n+Chưa chọn file\n+Tên file chứa kí tự đặc biệt hoặc quá dài\n+Trong fie có định dạng đặc biệt (Gộp ô).\nVui lòng kiểm tra lại.", "Lỗi chưa xác định", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    Console.WriteLine(ex);
                    return null;
                }
                return dtSet;
            }
            else
                return null;
        }

    }
}
