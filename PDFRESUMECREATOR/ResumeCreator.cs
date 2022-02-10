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
            Paragraph prof = new Paragraph(output.PROFESSION);
            Paragraph con = new Paragraph("CONTACT");
            Paragraph phone = new Paragraph(output.PHONE);

            //image Scaling
            myimage.ScaleAbsolute(100, 100);
           
          //designing font
            f_name.Font.Size = 15;
            f_name.Font.Color = BaseColor.BLACK;

            prof.Font.Size = 20;
            prof.Font.Color = BaseColor.DARK_GRAY;
            con.Font.Color = BaseColor.WHITE;
            phone.Font.Color = BaseColor.WHITE;

            //table
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 1;
            table.WidthPercentage = 100f;
            
            //making a new pdfcell
            PdfPCell my_img = new PdfPCell(myimage, false);
            PdfPCell my_fullname = new PdfPCell(new Phrase(f_name));
            PdfPCell my_prof = new PdfPCell(new Phrase(prof));
            PdfPCell my_phone= new PdfPCell(new Phrase(phone));
            PdfPCell contact = new PdfPCell(new Phrase(con));

            my_img.BackgroundColor = BaseColor.LIGHT_GRAY;

            my_fullname.HorizontalAlignment = Element.ALIGN_CENTER;
            my_fullname.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_fullname.BackgroundColor = BaseColor.LIGHT_GRAY;

            my_prof.RightIndent = 5;
            my_prof.HorizontalAlignment = Element.ALIGN_RIGHT;
            my_prof.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_prof.BackgroundColor = BaseColor.LIGHT_GRAY;

            contact.HorizontalAlignment = 1;
            contact.BackgroundColor = BaseColor.BLACK;
            my_phone.HorizontalAlignment = 1;
            my_phone.BackgroundColor = BaseColor.BLACK;

            //removing border
            my_img.BorderWidth = 0;
            my_fullname.BorderWidth = 0;
            my_prof.BorderWidth = 0;

            //inserting data to pdf
            //Header
            table.AddCell(my_img);
            table.AddCell(my_fullname);
            table.AddCell(my_prof);

            
            table.AddCell(contact);
            table.AddCell("");
            table.AddCell("");
            table.AddCell(my_phone);
            table.AddCell("");
            table.AddCell("");

            jsontopdf.Add(table);

            
            jsontopdf.Close();
            MessageBox.Show("Pdf Create Successfully!!!");


        }

        public class Information_json
        {
            public string MYIMAGE { get; set; }
            public string FULLNAME{ get; set; }
            public string PROFESSION { get; set; }
            public string PHONE { get; set; }
        }
    }
}
