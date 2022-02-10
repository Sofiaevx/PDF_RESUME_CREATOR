
namespace PDFRESUMECREATOR
{
    partial class ResumeCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(221, 71);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(88, 33);
            this.buttonConvert.TabIndex = 0;
            this.buttonConvert.TabStop = false;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Visible = false;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // buttonload
            // 
            this.buttonload.Location = new System.Drawing.Point(47, 71);
            this.buttonload.Name = "buttonload";
            this.buttonload.Size = new System.Drawing.Size(90, 33);
            this.buttonload.TabIndex = 1;
            this.buttonload.TabStop = false;
            this.buttonload.Text = "Load";
            this.buttonload.UseVisualStyleBackColor = true;
            this.buttonload.Click += new System.EventHandler(this.buttonload_Click);
            // 
            // ResumeCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 141);
            this.Controls.Add(this.buttonload);
            this.Controls.Add(this.buttonConvert);
            this.Name = "ResumeCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF RESUME CREATOR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonload;
    }
}

