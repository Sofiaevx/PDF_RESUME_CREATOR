using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDFRESUMECREATOR
{
    public partial class ResumeCreator : Form
    {
        string jsonpath = "SofiaVillanueva.json";
        public ResumeCreator()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            string openjson = File.ReadAllText(jsonpath);
            Information_json output = JsonConvert.DeserializeObject<Information_json>(openjson);

            Document jsontopdf = new Document();
            PdfWriter.GetInstance(jsontopdf, new FileStream("VILLANUEVA_SOFIARUTH.pdf", FileMode.Create));
            jsontopdf.Open();
            Paragraph myimage = new Paragraph(output.MYIMAGE);
            Paragraph f_name = new Paragraph(output.FULLNAME);
            Paragraph age = new Paragraph(output.AGE);


            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 1;
            table.WidthPercentage = 100f;

            table.AddCell(myimage);
            table.AddCell(f_name);
            table.AddCell(age);

            jsontopdf.Add(table);

            
            jsontopdf.Close();
            MessageBox.Show("Pdf Create Successfully!!!");


        }

        public class Information_json
        {
            public string MYIMAGE { get; set; }
            public string FULLNAME{ get; set; }
            public string AGE { get; set; }
        }
    }
}
