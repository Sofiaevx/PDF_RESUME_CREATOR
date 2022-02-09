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
        //this json path leads to json file, located at debug folder 
        string jsonpath = "SofiaVillanueva.json";
        public ResumeCreator()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            string openjson = File.ReadAllText(jsonpath);

            //Organizing json context
            Information_json output = JsonConvert.DeserializeObject<Information_json>(openjson);
            //creating pdf file located at bin-> Debug folder
            Document jsontopdf = new Document();
            PdfWriter.GetInstance(jsontopdf, new FileStream("VILLANUEVA_SOFIARUTH.pdf", FileMode.Create));
            jsontopdf.Open();

            //for json file value
            iTextSharp.text.Image myimage = iTextSharp.text.Image.GetInstance(output.MYIMAGE);
            Paragraph f_name = new Paragraph(output.FULLNAME);
            Paragraph age = new Paragraph(output.AGE);

            myimage.ScaleAbsolute(100, 100);
           
          
            f_name.Font.Size = 15;
            f_name.Font.Color = BaseColor.WHITE;
            age.Font.Size = 15;
            age.Font.Color = BaseColor.WHITE;

            //table
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 1;
            table.WidthPercentage = 100f;

            PdfPCell my_img = new PdfPCell(myimage, false);
            PdfPCell my_fullname = new PdfPCell(new Phrase(f_name));
            PdfPCell my_age = new PdfPCell(new Phrase(age));

            my_img.BackgroundColor = BaseColor.BLACK;
            my_fullname.HorizontalAlignment = Element.ALIGN_CENTER;
            my_fullname.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_fullname.BackgroundColor = BaseColor.BLACK;

            my_age.HorizontalAlignment = Element.ALIGN_RIGHT;
            my_age.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_age.BackgroundColor = BaseColor.BLACK;
            //inserting data to pdf
            table.AddCell(my_img);
            table.AddCell(my_fullname);
            table.AddCell(my_age);
            

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
