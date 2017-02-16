using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Web;
using System.IO;

namespace HR.Common
{
    /// <summary>
    /// Microsoft.Office.Interop.Excel 的摘要说明
    /// </summary>
    public class ExcelHelper
    {
        public string mFilename;
        public Excel.ApplicationClass excelApp;
        public Excel.Workbooks excelWBS;
        public Excel.Workbook excelWB;
        public Excel.Worksheets excelWSS;
        public Excel.Worksheet excelWS;

        public ExcelHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 创建一个Microsoft.Office.Interop.Excel对象
        /// </summary>
        public void Create()
        {
            excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            excelWBS = excelApp.Workbooks;
            excelWB = excelWBS.Add(true);
        }
        /// <summary>
        /// 打开一个Microsoft.Office.Interop.Excel文件
        /// </summary>
        /// <param name="FileName">Excel完整路径</param>
        public void Open(string FileName)
        {
            excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            excelWBS = excelApp.Workbooks;
            excelWB = excelWBS.Add(FileName);
            mFilename = FileName;
        }
        /// <summary>
        /// 显示Excel
        /// </summary>
        public void ShowExcel()
        {
            excelApp.Visible = true;
        }
        /// <summary>
        /// 获取一个工作表
        /// </summary>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public Microsoft.Office.Interop.Excel.Worksheet GetSheet(string SheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet s = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[SheetName];
            return s;
        }
        /// <summary>
        /// 添加一个工作表
        /// </summary>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public Microsoft.Office.Interop.Excel.Worksheet AddSheet(string SheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet s = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            s.Name = SheetName;
            return s;
        }
        /// <summary>
        /// 删除一个工作表
        /// </summary>
        /// <param name="SheetName"></param>
        public void DeleteSheet(string SheetName)
        {
            //不显示弹框
            excelApp.DisplayAlerts = false;
            ((Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[SheetName]).Delete();
        }
        /// <summary>
        /// 隐藏一个工作表
        /// </summary>
        /// <param name="SheetName"></param>
        public void HideSheet(string SheetName)
        {
            //不显示弹框
            //excelApp.DisplayAlerts = false;
            //((Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[SheetName]).Visible = Excel.XlSheetVisibility.xlSheetVisible;
            Microsoft.Office.Interop.Excel.Worksheet s = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[SheetName];
            s.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden;
        }
        /// <summary>
        /// 根据SheetName重命名一个工作表
        /// </summary>
        /// <param name="OldSheetName"></param>
        /// <param name="NewSheetName"></param>
        /// <returns></returns>
        public Microsoft.Office.Interop.Excel.Worksheet ReNameSheet(string OldSheetName, string NewSheetName)
        {
            Microsoft.Office.Interop.Excel.Worksheet s = (Microsoft.Office.Interop.Excel.Worksheet)excelWB.Worksheets[OldSheetName];
            s.Name = NewSheetName;
            return s;
        }
        /// <summary>
        /// 根据Sheet重命名一个工作表
        /// </summary>
        /// <param name="Sheet"></param>
        /// <param name="NewSheetName"></param>
        /// <returns></returns>
        public Microsoft.Office.Interop.Excel.Worksheet ReNameSheet(Microsoft.Office.Interop.Excel.Worksheet Sheet, string NewSheetName)
        {
            Sheet.Name = NewSheetName;
            return Sheet;
        }
        /// <summary>
        /// ws：要设值的工作表 X行Y列 value 值
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void SetCellValue(Microsoft.Office.Interop.Excel.Worksheet ws, int x, int y, object value)
        {
            try
            {
                ws.Cells[x, y] = value;
            }
            catch (Exception)
            {
                throw new Exception("向单元格[" + x + "," + y + "]写数据出错！");
            }
        }
        /// <summary>
        /// ws：要设值的工作表的名称 X行Y列 value 值
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void SetCellValue(string ws, int x, int y, object value)
        {
            try
            {
                GetSheet(ws).Cells[x, y] = value;
            }
            catch (Exception)
            {
                throw new Exception("向单元格[" + x + "," + y + "]写数据出错！");
            }
        }
        /// <summary>
        /// 设置一个单元格的属性 字体，大小，颜色，对齐方式
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="Startx"></param>
        /// <param name="Starty"></param>
        /// <param name="Endx"></param>
        /// <param name="Endy"></param>
        /// <param name="size"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="HorizontalAlignment"></param>
        public void SetCellProperty(Microsoft.Office.Interop.Excel.Worksheet ws, int Startx, int Starty, int Endx, int Endy, int size, string name, Microsoft.Office.Interop.Excel.Constants color, Microsoft.Office.Interop.Excel.Constants HorizontalAlignment)
        {
            name = "宋体";
            size = 12;
            color = Microsoft.Office.Interop.Excel.Constants.xlAutomatic;
            HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
        }
        public void SetCellProperty(string wsn, int Startx, int Starty, int Endx, int Endy, int size, string name, Microsoft.Office.Interop.Excel.Constants color, Microsoft.Office.Interop.Excel.Constants HorizontalAlignment)
        {
            //name = "宋体";
            //size = 12;
            //color = Microsoft.Office.Interop.Excel.Constants.xlAutomatic;
            //HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

            Microsoft.Office.Interop.Excel.Worksheet ws = GetSheet(wsn);
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;

            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
        }
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void UniteCells(Microsoft.Office.Interop.Excel.Worksheet ws, int x1, int y1, int x2, int y2)
        {
            ws.get_Range(ws.Cells[x1, y1], ws.Cells[x2, y2]).Merge(Type.Missing);
        }
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void UniteCells(string ws, int x1, int y1, int x2, int y2)
        {
            GetSheet(ws).get_Range(GetSheet(ws).Cells[x1, y1], GetSheet(ws).Cells[x2, y2]).Merge(Type.Missing);

        }
        /// <summary>
        /// 将内存中数据表格插入到Microsoft.Office.Interop.Excel指定工作表的指定位置 为在使用模板时控制格式时使用一
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ws"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void InsertTable(System.Data.DataTable dt, string ws, int startX, int startY)
        {

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[startX + i, j + startY] = dt.Rows[i][j].ToString();
                }
            }
        }
        /// <summary>
        /// 将内存中数据表格插入到Microsoft.Office.Interop.Excel指定工作表的指定位置二
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ws"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void InsertTable(System.Data.DataTable dt, Microsoft.Office.Interop.Excel.Worksheet ws, int startX, int startY)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    ws.Cells[startX + i, j + startY] = dt.Rows[i][j];
                }
            }
        }
        /// <summary>
        /// 将内存中数据表格添加到Microsoft.Office.Interop.Excel指定工作表的指定位置一
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ws"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void AddTable(System.Data.DataTable dt, string ws, int startX, int startY)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[i + startX, j + startY] = dt.Rows[i][j];
                }
            }
        }
        /// <summary>
        /// 将内存中数据表格添加到Microsoft.Office.Interop.Excel指定工作表的指定位置二
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ws"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        public void AddTable(System.Data.DataTable dt, Microsoft.Office.Interop.Excel.Worksheet ws, int startX, int startY)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    ws.Cells[i + startX, j + startY] = dt.Rows[i][j];
                }
            }
        }
        //public void InsertPictures(string Filename, string ws)
        ////插入图片操作一
        //{
        //    GetSheet(ws).Shapes.AddPicture(Filename, Microsoft.Office.Core.MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 10, 150, 150);
        //    //后面的数字表示位置
        //}
        /// <summary>
        /// 插入图表操作
        /// </summary>
        /// <param name="ChartType"></param>
        /// <param name="ws"></param>
        /// <param name="DataSourcesX1"></param>
        /// <param name="DataSourcesY1"></param>
        /// <param name="DataSourcesX2"></param>
        /// <param name="DataSourcesY2"></param>
        /// <param name="ChartDataType"></param>
        public void InsertActiveChart(Microsoft.Office.Interop.Excel.XlChartType ChartType, string ws, int DataSourcesX1, int DataSourcesY1, int DataSourcesX2, int DataSourcesY2, Microsoft.Office.Interop.Excel.XlRowCol ChartDataType)
        {
            ChartDataType = Microsoft.Office.Interop.Excel.XlRowCol.xlColumns;
            excelWB.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            {
                excelWB.ActiveChart.ChartType = ChartType;
                excelWB.ActiveChart.SetSourceData(GetSheet(ws).get_Range(GetSheet(ws).Cells[DataSourcesX1, DataSourcesY1], GetSheet(ws).Cells[DataSourcesX2, DataSourcesY2]), ChartDataType);
                excelWB.ActiveChart.Location(Microsoft.Office.Interop.Excel.XlChartLocation.xlLocationAsObject, ws);
            }
        }
        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (mFilename == "")
            {
                return false;
            }
            else
            {
                try
                {
                    excelWB.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 文档另存为
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool SaveAs(object FileName)
        {
            try
            {
                //禁止覆盖提示框
                excelApp.DisplayAlerts = false;
                excelApp.Visible = false;
                excelWB.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭打开的Excel方法
        /// </summary>
        /// <param name="ExcelApplication"></param>
        /// <param name="ExcelWorkbook"></param>
        public void CloseExcel()
        {
            excelWB.Close(Type.Missing, Type.Missing, Type.Missing);
            excelWB = null;
            excelApp.Application.Quit();
            excelApp = null;
            GC.Collect();
            //KeyMyExcelProcess.Kill(excelApp);
        }
        ///// <summary>
        ///// 关闭Excel进程
        ///// </summary>
        //public class KeyMyExcelProcess
        //{
        //    [DllImport("User32.dll", CharSet = CharSet.Auto)]
        //    public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        //    public static void Kill(Microsoft.Office.Interop.Excel.Application excel)
        //    {
        //        try
        //        {
        //            IntPtr t = new IntPtr(excel.Hwnd);   //得到这个句柄，具体作用是得到这块内存入口
        //            int k = 0;
        //            GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k
        //            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用
        //            p.Kill();     //关闭进程k
        //        }
        //        catch (System.Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
        public void DownLoad(string path, string fileName, HttpContext context)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            if (context.Request.UserAgent != null)
            {
                string userAgent = context.Request.UserAgent.ToUpper();
                if (userAgent.IndexOf("FIREFOX", StringComparison.Ordinal) <= 0)
                {
                    context.Response.AddHeader("Content-Disposition",
                                  "attachment;  filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8));
                }
                else
                {
                    context.Response.AddHeader("Content-Disposition", "attachment;  filename=" + fileName);
                }
            }
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.ContentType = "application/x-xls";
            //通知浏览器下载文件而不是打开
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.Response.End();
            fs.Close();
            //删除文件
            //System.IO.File.Delete(path);
        }
    }
}
