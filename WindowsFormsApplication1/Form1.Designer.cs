using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 90);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(384, 90);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(151, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Find Diffs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Originial List, list with all original values before suspected changes";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(432, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Secondary List, any differences will be copied into the Clipboard (Ctrl+V)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(396, 51);
            this.label3.TabIndex = 5;
            this.label3.Text = "The tool will find any differences regardless of list order, \n both lists should " +
    "have the same structure, \n e.g commas after values or seperated lines (e.g SQL r" +
    "esults)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Powered by Gal S";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 372);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "List Differences Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string data = null;
                if (textBox1.Lines.Count() > 1)
                {
                    string[] inputPoliciesOriginial = textBox1.Lines;
                    string[] inputPoliciesSub = textBox2.Lines;
                    foreach (var item in inputPoliciesOriginial)
                    {
                        if (!inputPoliciesSub.Contains(item))
                        {
                            data = data + item + "'\n,'";

                        }
                    }
                }
                else if (textBox1.Lines.Count() == 1)
                {
                    IList<string> inputPoliciesOriginial = textBox1.Text.Split(',').ToList<string>();
                    IList<string> inputPoliciesSub = textBox2.Text.Split(',').ToList<string>();
                    foreach (var item in inputPoliciesOriginial)
                    {
                        if (!inputPoliciesSub.Contains(item))
                        {
                            data = data + item + "'\n,'";
                           
                        }

                    }
                }
                if (data.Length > 0)
                {
                    data = "'" + data.Substring(0,data.Length-2);
                    Clipboard.SetText(data);
                }
                else
                {
                    data = "matching lists, no differences";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private RichTextBox textBox1;
        private RichTextBox textBox2;
        private System.Windows.Forms.Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}

