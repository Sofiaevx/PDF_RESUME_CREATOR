using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;
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
        string openjson;
        public ResumeCreator()
        {
            InitializeComponent();
        }
        private void buttonload_Click(object sender, EventArgs e)
        {
            openjson = File.ReadAllText(jsonpath);
            buttonConvert.Visible = true;
        }
        private void buttonConvert_Click(object sender, EventArgs e)
        {
        
             //Organizing json context
           Information_json output = JsonConvert.DeserializeObject<Information_json>(openjson);
            //creating pdf file located at bin-> Debug folder
            Document jsontopdf = new Document();
            PdfWriter.GetInstance(jsontopdf, new FileStream("VILLANUEVA_SOFIARUTH.pdf", FileMode.Create));
            jsontopdf.Open();
            string[] variable = { "CONTACT", "PHONE", "ADDRESS", "EMAIL","OBJECTIVE", "EXPERTISE", "EDUCATIONAL BACKGROUND","REFFERENCE","EXPERIENCE"};
            //for json file value
            Image myimage =Image.GetInstance(output.MYIMAGE);
            Paragraph f_name = new Paragraph(output.FULLNAME);
            Paragraph f_name1 = new Paragraph("\n\n" +  output.FULLNAME);
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
            Paragraph ref1 = new Paragraph(output.REF1);
            Paragraph ref2 = new Paragraph(output.REF2);
            Paragraph ex1 = new Paragraph(output.EXP1);
            Paragraph ex2 = new Paragraph(output.EXP2);
            Paragraph hereby = new Paragraph("\n\n\n"+ output.HEREBY);
           Image Signature = Image.GetInstance(output.SIGNATURE);


            //variable
            Paragraph con = new Paragraph(variable[0]);
            Paragraph ph = new Paragraph(variable[1]);
            Paragraph add = new Paragraph(variable[2]);
            Paragraph em = new Paragraph(variable[3]);
            Paragraph ob = new Paragraph(variable[4]);
            Paragraph exp = new Paragraph(variable[5]);
            Paragraph edu = new Paragraph(variable[6]);
            Paragraph refference = new Paragraph(variable[7]);
            Paragraph experience = new Paragraph(variable[8]);


            con.Font.Size = 18;
            con.Alignment = Element.ALIGN_CENTER;
            con.SetLeading(10, 1);
            ph.Font.Size = 12;
            ph.Alignment = Element.ALIGN_CENTER;
            ph.SetLeading(10, 1);
            add.Font.Size = 12;
            add.Alignment = Element.ALIGN_CENTER;
            add.SetLeading(10, 1);
            em.Font.Size = 12;
            em.Alignment = Element.ALIGN_CENTER;
            em.SetLeading(10, 1);
            ob.Font.Size = 18;
            ob.IndentationLeft = 5;
            refference.Font.Size = 18;
            refference.Alignment = Element.ALIGN_CENTER;
            refference.IndentationLeft = 5;
            experience.Font.Size = 18;
            experience.IndentationLeft = 5;
            experience.SetLeading(10, 1);


            //variable designing color
            exp.Font.Color = BaseColor.ORANGE;
            con.Font.Color = BaseColor.ORANGE;
            ph.Font.Color = BaseColor.WHITE;
            add.Font.Color = BaseColor.WHITE;
            em.Font.Color = BaseColor.WHITE;
            refference.Font.Color = BaseColor.ORANGE;

            //image Scaling
            myimage.ScaleAbsolute(100, 100);
      
           //designing font
            f_name.Font.Size = 15;
            f_name.Font.Color = BaseColor.BLACK;
            prof.Font.Size = 15;
            prof.Font.Color = BaseColor.BLACK;
            phone.Font.Color = BaseColor.LIGHT_GRAY;
            phone.Alignment = Element.ALIGN_CENTER;
            phone.SetLeading(6, 1);
            email.Font.Color = BaseColor.LIGHT_GRAY;
            email.Alignment = Element.ALIGN_CENTER;
            email.SetLeading(6, 1);
            address.Font.Color = BaseColor.LIGHT_GRAY;
            address.Alignment = Element.ALIGN_CENTER;
            address.SetLeading(6, 1);
            about.Font.Size = 12;
            about.IndentationRight = 5;
            about.IndentationLeft = 5;
            about.Alignment = Element.ALIGN_JUSTIFIED;
            about.SetLeading(10, 1);
            exp.Font.Size = 18;
            exp.Alignment = Element.ALIGN_CENTER;
            exp.SetLeading(10, 1);
            edu.Font.Size = 18;
            edu.IndentationLeft = 5;
            elem.IndentationLeft = 50;
            second.IndentationLeft = 50;
            college.IndentationLeft = 50;
            skill1.Font.Color = BaseColor.LIGHT_GRAY;
            skill1.Alignment = Element.ALIGN_CENTER;
            skill1.SetLeading(8, 1);
            skill2.Font.Color = BaseColor.LIGHT_GRAY;
            skill2.Alignment = Element.ALIGN_CENTER;
            skill2.SetLeading(6, 1);
            skill3.Font.Color = BaseColor.LIGHT_GRAY;
            skill3.Alignment = Element.ALIGN_CENTER;
            skill3.SetLeading(6, 1);
            skill4.Font.Color = BaseColor.LIGHT_GRAY;
            skill4.Alignment = Element.ALIGN_CENTER;
            skill4.SetLeading(6, 1);
            ref1.Font.Color = BaseColor.LIGHT_GRAY;
            ref1.Alignment = Element.ALIGN_CENTER;
            ref1.SetLeading(6, 1);
            ref2.Font.Color = BaseColor.LIGHT_GRAY;
            ref2.Alignment = Element.ALIGN_CENTER;
            ref2.SetLeading(6, 1);
            ex1.IndentationLeft = 50;
            ex2.IndentationLeft = 50;
            hereby.Alignment = Element.ALIGN_CENTER;
            f_name1.Alignment = Element.ALIGN_RIGHT;
            Signature.IndentationRight = 20;
            Signature.ScalePercent(30f);
            Signature.Alignment = Image.UNDERLYING | Image.ALIGN_RIGHT;

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
            PdfPCell edu1 = new PdfPCell(new Phrase(edu));
            PdfPCell reff= new PdfPCell(new Phrase(refference));
            PdfPCell exper = new PdfPCell(new Phrase(experience));


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
            PdfPCell my_ref1 = new PdfPCell(new Phrase(ref1));
            PdfPCell my_ref2 = new PdfPCell(new Phrase(ref2));
            PdfPCell my_ex1 = new PdfPCell(new Phrase(ex1));
            PdfPCell my_ex2 = new PdfPCell(new Phrase(ex2));
            PdfPCell my_hereby = new PdfPCell(new Phrase(hereby));


            my_img.BackgroundColor = BaseColor.LIGHT_GRAY;
            my_img.HorizontalAlignment = 1;
            my_fullname.HorizontalAlignment = Element.ALIGN_CENTER;
            my_fullname.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_fullname.BackgroundColor = BaseColor.LIGHT_GRAY;

          
            my_prof.HorizontalAlignment = Element.ALIGN_CENTER;
            my_prof.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_prof.BackgroundColor = BaseColor.LIGHT_GRAY;

            my_address.AddElement(address);
            my_email.AddElement(email);
            my_address.BackgroundColor = BaseColor.BLACK;
            my_email.BackgroundColor = BaseColor.BLACK;

            ob1.Colspan = 2;
            ob1.AddElement(ob);
            contact.BackgroundColor = BaseColor.BLACK;
            contact.AddElement(con);
            exp1.AddElement(exp);
            exp1.BackgroundColor = BaseColor.BLACK;
            
            add1.AddElement(add);
            ph1.AddElement(ph);
            em1.AddElement(em);
            add1.BackgroundColor = BaseColor.BLACK;
            ph1.BackgroundColor = BaseColor.BLACK;
            em1.BackgroundColor = BaseColor.BLACK;
            edu1.AddElement(edu);
            
            edu1.Colspan = 2;
            edu1.Rowspan = 2;
            reff.BackgroundColor = BaseColor.BLACK;
            reff.AddElement(refference);
            exper.AddElement(experience);

            my_phone.AddElement(phone);
            my_phone.BackgroundColor = BaseColor.BLACK;
            my_about.Rowspan = 6;
            my_about.Colspan = 2;
            my_about.Indent = 15;
            my_about.AddElement(about);
            my_skill1.AddElement(skill1);
            my_skill2.AddElement(skill2);
            my_skill3.AddElement(skill3);
            my_skill4.AddElement(skill4);
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
            my_ref1.AddElement(ref1);
            my_ref2.AddElement(ref2);
            my_ref1.BackgroundColor = BaseColor.BLACK;
            my_ref2.BackgroundColor = BaseColor.BLACK;
            exper.Colspan = 2;
            my_ex1.Colspan = 2;
            my_ex1.AddElement(ex1);
            my_ex1.VerticalAlignment = Element.ALIGN_MIDDLE;
            my_ex2.Colspan = 2;
            my_ex2.AddElement(ex2);
       
            //removing border
            my_img.BorderWidth = 0;
            my_fullname.BorderWidth = 0;
            my_prof.BorderWidth = 0;
            my_about.BorderWidth = 0;
            ob1.BorderWidth = 0;
            edu1.BorderWidth = 0;
            my_elem.BorderWidth = 0;
            my_second.BorderWidth = 0;
            my_college.BorderWidth = 0;
            exper.BorderWidth = 0;
            my_ex1.BorderWidth = 0;
            my_ex2.BorderWidth = 0;
            //inserting data to pdf
            //Header

            table.AddCell(my_img);
            table.AddCell(my_fullname);
            table.AddCell(my_prof);

            //profile and objective Section
            table.AddCell(contact);
            table.AddCell(ob1);
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
            table.AddCell(reff);
            table.AddCell(exper);
        
            table.AddCell(my_ref1);
            table.AddCell(my_ex1);
   
            table.AddCell(my_ref2);
            table.AddCell(my_ex2);

           
            jsontopdf.Add(table);
            
            jsontopdf.Add(hereby);
            jsontopdf.Add(Signature);
            jsontopdf.Add(f_name1);

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
            public string  REF1 { get; set; }
            public string REF2 { get; set; }
            public string EXP1 { get; set; }
            public string EXP2 { get; set; }
            public string HEREBY{ get; set; }
            public string SIGNATURE { get; set; }
        }

       
    }
}
