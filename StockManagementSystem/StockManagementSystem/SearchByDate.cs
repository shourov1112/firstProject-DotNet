using StockManagementSystem.DLL;
using StockManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace StockManagementSystem
{
    public partial class SearchByDate : Form
    {
        public SearchByDate()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!(fromDateTimePicker.Value.Date.CompareTo(toDateTimePiker.Value.Date)<0))
            {
                MessageBox.Show("Must be From timepicker less than To timepicker");
            }
            else
            {
                ShowAllData(fromDateTimePicker.Value,toDateTimePiker.Value);
            }
        }
        SearchItemManage searchItemManage = new SearchItemManage();
        public void ShowAllData(DateTime fromDate,DateTime toDate)
        {
            DataTable dt = searchItemManage.SellQuantity(fromDate, toDate);
            List<SearchItemByDate> itemList = new List<SearchItemByDate>();
            if (dt.Rows.Count > 0)
            {
                int sNo=0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    itemList.Add(new SearchItemByDate()
                    {
                        Sl=++sNo,
                        ItemName = dt.Rows[i]["ItemName"].ToString(),
                        SellQuantity = Convert.ToInt32(dt.Rows[i]["QuantityTotal"].ToString()),
                    });
                }
                showGridView.DataSource = itemList;
            }
        }

        private void PdfButton_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Text.pdf", FileMode.Create));
            doc.Open();
            Paragraph para = new Paragraph("Search Items");
            para.IndentationLeft = 244f;
            doc.Add(para);
            //doc.Close();

            PdfPTable table = new PdfPTable(showGridView.Columns.Count);
            for (int i = 0; i < showGridView.Columns.Count; i++)
            {
                table.AddCell(new Phrase(showGridView.Columns[i].HeaderText));
            }
            table.HeaderRows = 1;

            for (int i = 0; i < showGridView.Rows.Count; i++)
            {
                for (int j = 0; j < showGridView.Columns.Count; j++)
                {
                    if (showGridView[j, i].Value != null)
                    {
                        table.AddCell(new Phrase(showGridView[j, i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }
    }
}
