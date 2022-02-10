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
            string[] variable = { "CONTACT", "PHONE", "ADDRESS", "EMAIL","OBJECTIVE", "EXPERTISE", "EDUCATIONAL BACKGROUND"};
            //for json file value
            iTextSharp.text.Image myimage = iTextSharp.text.Image.GetInstance(output.MYIMAGE);
            Paragraph f_name = new Paragraph(output.FULLNAME);
            Paragraph prof = new Paragraph(output.PROFESSION);
            Paragraph phone = new Paragraph(output.PHONE);
            Paragraph address = new Paragraph(output.ADDRESS);
            Paragraph email = new Paragraph(output.EMAIL);
            Paragraph about = new Paragraph(output.ABOUTME);
            Paragraph skill1 = new Paragraph(output.SKILL1);
            Paragraph skill2 = new Paragraph(output.SKILL2);
            Paragraph skill3 = new Paragraph(output.SKILL3);
            Paragraph skill4 = new Paragraph(output.SKILL4);
            Paragraph elem = new Paragraph(output.ELEM);
            Paragraph second = new Paragraph(output.SECONDARY);
            Paragraph college = new Paragraph(output.COLLEGE);

            //variable
            Paragraph con = new Paragraph(variable[0]);
            Paragraph ph = new Paragraph(variable[1]);
            Paragraph add = new Paragraph(variable[2]);
            Paragraph em = new Paragraph(variable[3]);
            Paragraph ob = new Paragraph(variable[4]);
            Paragraph exp = new Paragraph(variable[5]);
            Paragraph edu = new Paragraph(variable[6]);
            con.Font.Size = 18;
            ph.Font.Size = 12;
            add.Font.Size = 12;
            em.Font.Size = 12;
            ob.Font.Size = 18;
            about.Font.Size = 12;
            about.IndentationRight = 5;
            about.IndentationLeft = 5;
            about.Alignment = Element.ALIGN_JUSTIFIED;
            about.SetLeading(10, 1);
            exp.Font.Size = 18;
            edu.Font.Size = 18;
            skill1.Font.Color = BaseColor.LIGHT_GRAY;
            skill2.Font.Color = BaseColor.LIGHT_GRAY;
            skill3.Font.Color = BaseColor.LIGHT_GRAY;
            skill4.Font.Color = BaseColor.LIGHT_GRAY;

            elem.IndentationLeft = 15;
            second.IndentationLeft = 15;
            college.IndentationLeft = 15;
            //variable designing
            exp.Font.Color = BaseColor.ORANGE;
            con.Font.Color = BaseColor.ORANGE;
            ph.Font.Color = BaseColor.WHITE;
            add.Font.Color = BaseColor.WHITE;
            em.Font.Color = BaseColor.WHITE;
            
            //image Scaling
            myimage.ScaleAbsolute(100, 100);
      
          //designing font
            f_name.Font.Size = 15;
            f_name.Font.Color = BaseColor.BLACK;
            prof.Font.Size = 15;
            prof.Font.Color = BaseColor.BLACK;
            phone.Font.Color = BaseColor.LIGHT_GRAY;
            email.Font.Color = BaseColor.LIGHT_GRAY;
            address.Font.Color = BaseColor.LIGHT_GRAY;

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
            PdfPCell exp1 = new PdfPCell(new Phrase(exp));
            PdfPCell edu1= new PdfPCell(new Phrase(edu));
            //making a new pdfcell
            PdfPCell my_img = new PdfPCell(myimage, false);
            PdfPCell my_fullname = new PdfPCell(new Phrase(f_name));
            PdfPCell my_prof = new PdfPCell(new Phrase(prof));
            PdfPCell my_phone= new PdfPCell(new Phrase(phone));
            PdfPCell my_address= new PdfPCell(new Phrase(address));
            PdfPCell my_email = new PdfPCell(new Phrase(email));
            PdfPCell my_about = new PdfPCell(new Phrase(about));
            PdfPCell my_skill1 = new PdfPCell(new Phrase(skill1));
            PdfPCell my_skill2 = new PdfPCell(new Phrase(skill2));
            PdfPCell my_skill3 = new PdfPCell(new Phrase(skill3));
            PdfPCell my_skill4 = new PdfPCell(new Phrase(skill4));
            PdfPCell my_elem = new PdfPCell(new Phrase(elem));
            PdfPCell my_second = new PdfPCell(new Phrase(second));
            PdfPCell my_college = new PdfPCell(new Phrase(college));

            my_img.BackgroundColor = BaseColor.LIGHT_GRAY;
            my_img.HorizontalAlignment = 1;
            my_fullname.HorizontalAlignment = Element.ALIGN_CENTER;
            my_fullname.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_fullname.BackgroundColor = BaseColor.LIGHT_GRAY;

          
            my_prof.HorizontalAlignment = Element.ALIGN_CENTER;
            my_prof.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_prof.BackgroundColor = BaseColor.LIGHT_GRAY;

            my_address.HorizontalAlignment = 1;
            my_email.HorizontalAlignment = 1;
            my_address.BackgroundColor = BaseColor.BLACK;
            my_email.BackgroundColor = BaseColor.BLACK;
            contact.HorizontalAlignment = 1;
            contact.BackgroundColor = BaseColor.BLACK;
            exp1.HorizontalAlignment = 1;
            exp1.BackgroundColor = BaseColor.BLACK;
            add1.HorizontalAlignment = 1;
            ph1.HorizontalAlignment = 1;
            em1.HorizontalAlignment = 1;
            add1.BackgroundColor = BaseColor.BLACK;
            ph1.BackgroundColor = BaseColor.BLACK;
            em1.BackgroundColor = BaseColor.BLACK;
            edu1.Colspan = 2;
            edu1.Rowspan = 2;


            my_phone.HorizontalAlignment = 1;
            my_phone.BackgroundColor = BaseColor.BLACK;
            my_about.Rowspan = 6;
            my_about.Colspan = 2;
            my_about.Indent = 15;
            my_about.AddElement(about);
            my_skill1.HorizontalAlignment = 1;
            my_skill2.HorizontalAlignment = 1;
            my_skill3.HorizontalAlignment = 1;
            my_skill4.HorizontalAlignment = 1;
            my_skill1.BackgroundColor = BaseColor.BLACK;
            my_skill2.BackgroundColor = BaseColor.BLACK;
            my_skill3.BackgroundColor = BaseColor.BLACK;
            my_skill4.BackgroundColor = BaseColor.BLACK;

            my_elem.Colspan = 2;
            my_second.Colspan = 2;
            my_college.Colspan = 2;
            my_elem.AddElement(elem);
            my_second.AddElement(second);
            my_college.AddElement(college);
            //removing border
            my_img.BorderWidth = 0;
            my_fullname.BorderWidth = 0;
            my_prof.BorderWidth = 0;

            //inserting data to pdf
            //Header
            table.AddCell(my_img);
            table.AddCell(my_fullname);
            table.AddCell(my_prof);

            //profile and objective Section
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
            //expertise section and Education background
            table.AddCell(exp1);
            table.AddCell(edu1);
           
            table.AddCell(my_skill1);
            
            table.AddCell(my_skill2);
            table.AddCell(my_elem);
           
            table.AddCell(my_skill3);
            table.AddCell(my_second);
          
            table.AddCell(my_skill4);
            table.AddCell(my_college);
          
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
            public string SKILL1 { get; set; }
            public string SKILL2 { get; set; }
            public string SKILL3 { get; set; }
            public string SKILL4 { get; set; }
            public string ELEM { get; set; }
            public string SECONDARY { get; set; }
            public string COLLEGE { get; set; }
        }
    }
}
