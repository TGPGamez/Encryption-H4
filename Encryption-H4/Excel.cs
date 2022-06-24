using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;

namespace SimpleEncrypt
{
    public class Excel
    {
        private string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }


        public string ReadCell(int row, int col)
        {
            row++;
            col++;
            if (ws.Cells[row, col].Value != null)
            {
                return ws.Cells[row, col].Value;
            }
            return "";
        }

        public void WriteToCell(int row, int col, string value)
        {
            row++;
            col++;
            ws.Cells[row, col].Value = value;
        }

        public void Save()
        {
            wb.Save();
        }

        public void Close()
        {
            wb.Close();
        }
        
    }
}
