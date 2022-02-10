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
            string[] variable = { "CONTACT", "PHONE", "ADDRESS", "EMAIL","OBJECTIVE" };
            //for json file value
            iTextSharp.text.Image myimage = iTextSharp.text.Image.GetInstance(output.MYIMAGE);
            Paragraph f_name = new Paragraph(output.FULLNAME);
            Paragraph prof = new Paragraph(output.PROFESSION);
            Paragraph phone = new Paragraph(output.PHONE);
            Paragraph address = new Paragraph(output.ADDRESS);
            Paragraph email = new Paragraph(output.EMAIL);
            Paragraph about = new Paragraph(output.ABOUTME);

            //variable
            Paragraph con = new Paragraph(variable[0]);
            Paragraph ph = new Paragraph(variable[1]);
            Paragraph add = new Paragraph(variable[2]);
            Paragraph em = new Paragraph(variable[3]);
            Paragraph ob = new Paragraph(variable[4]);

            //variable designing
            con.Font.Color = BaseColor.WHITE;
            ph.Font.Color = BaseColor.WHITE;
            add.Font.Color = BaseColor.WHITE;
            em.Font.Color = BaseColor.WHITE;
            
            

            //image Scaling
            myimage.ScaleAbsolute(100, 100);
           
          //designing font
            f_name.Font.Size = 15;
            f_name.Font.Color = BaseColor.BLACK;

            prof.Font.Size = 20;
            prof.Font.Color = BaseColor.DARK_GRAY;
            phone.Font.Color = BaseColor.WHITE;

            //table
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = 1;
            table.WidthPercentage = 100f;

            //viable makiing new pdfcell
            PdfPCell contact = new PdfPCell(new Phrase(con));
            PdfPCell add1 = new PdfPCell(new Phrase(add));
            PdfPCell ph1 = new PdfPCell(new Phrase(ph));
            PdfPCell em1 = new PdfPCell(new Phrase(em));
            PdfPCell ob1 = new PdfPCell(new Phrase(ob));
            //making a new pdfcell
            PdfPCell my_img = new PdfPCell(myimage, false);
            PdfPCell my_fullname = new PdfPCell(new Phrase(f_name));
            PdfPCell my_prof = new PdfPCell(new Phrase(prof));
            PdfPCell my_phone= new PdfPCell(new Phrase(phone));
            PdfPCell my_address= new PdfPCell(new Phrase(address));
            PdfPCell my_email = new PdfPCell(new Phrase(email));
            PdfPCell my_about = new PdfPCell(new Phrase(about));

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
            add1.HorizontalAlignment = 1;
            ph1.HorizontalAlignment = 1;
            em1.HorizontalAlignment = 1;
            add1.BackgroundColor = BaseColor.BLACK;
            ph1.BackgroundColor = BaseColor.BLACK;
            em1.BackgroundColor = BaseColor.BLACK;


            my_phone.HorizontalAlignment = 1;
            my_phone.BackgroundColor = BaseColor.BLACK;
            my_about.Rowspan = 6;
            my_about.Colspan = 2;

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
            table.AddCell(ob1);
            table.AddCell("");

            table.AddCell(ph1);
            table.AddCell(my_about);
          
            table.AddCell(my_phone);
           
            table.AddCell(add1);
         
            table.AddCell(my_address);
            
            table.AddCell(em1);
           
            table.AddCell(my_email);
           
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
            public string ADDRESS { get; set; }
            public string EMAIL { get; set; }
            public string ABOUTME { get; set; }
        }
    }
}
