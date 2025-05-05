namespace Art_Gallery
{
    partial class visitors
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.title_comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.artwork_description_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.artistName_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.image_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Price_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ratings_comboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comment_textBox = new System.Windows.Forms.TextBox();
            this.exit_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.sign_up_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(569, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Art Gallery";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Artwork Title";
            // 
            // title_comboBox
            // 
            this.title_comboBox.FormattingEnabled = true;
            this.title_comboBox.Location = new System.Drawing.Point(551, 145);
            this.title_comboBox.Name = "title_comboBox";
            this.title_comboBox.Size = new System.Drawing.Size(366, 24);
            this.title_comboBox.TabIndex = 2;
            this.title_comboBox.SelectedIndexChanged += new System.EventHandler(this.title_comboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(400, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description";
            // 
            // artwork_description_textBox
            // 
            this.artwork_description_textBox.Location = new System.Drawing.Point(552, 212);
            this.artwork_description_textBox.Multiline = true;
            this.artwork_description_textBox.Name = "artwork_description_textBox";
            this.artwork_description_textBox.ReadOnly = true;
            this.artwork_description_textBox.Size = new System.Drawing.Size(363, 44);
            this.artwork_description_textBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(400, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Artist Name";
            // 
            // artistName_textBox
            // 
            this.artistName_textBox.Location = new System.Drawing.Point(551, 300);
            this.artistName_textBox.Name = "artistName_textBox";
            this.artistName_textBox.ReadOnly = true;
            this.artistName_textBox.Size = new System.Drawing.Size(364, 22);
            this.artistName_textBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Image URL";
            // 
            // image_textBox
            // 
            this.image_textBox.Location = new System.Drawing.Point(475, 403);
            this.image_textBox.Name = "image_textBox";
            this.image_textBox.ReadOnly = true;
            this.image_textBox.Size = new System.Drawing.Size(180, 22);
            this.image_textBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(800, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Price";
            // 
            // Price_textBox
            // 
            this.Price_textBox.Location = new System.Drawing.Point(857, 401);
            this.Price_textBox.Name = "Price_textBox";
            this.Price_textBox.ReadOnly = true;
            this.Price_textBox.Size = new System.Drawing.Size(180, 22);
            this.Price_textBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(373, 518);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ratings";
            // 
            // ratings_comboBox
            // 
            this.ratings_comboBox.FormattingEnabled = true;
            this.ratings_comboBox.Location = new System.Drawing.Point(475, 520);
            this.ratings_comboBox.Name = "ratings_comboBox";
            this.ratings_comboBox.Size = new System.Drawing.Size(128, 24);
            this.ratings_comboBox.TabIndex = 12;
            this.ratings_comboBox.SelectedIndexChanged += new System.EventHandler(this.ratings_comboBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(769, 520);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "comment";
            // 
            // comment_textBox
            // 
            this.comment_textBox.Location = new System.Drawing.Point(857, 477);
            this.comment_textBox.Multiline = true;
            this.comment_textBox.Name = "comment_textBox";
            this.comment_textBox.ReadOnly = true;
            this.comment_textBox.Size = new System.Drawing.Size(513, 111);
            this.comment_textBox.TabIndex = 14;
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.SystemColors.Info;
            this.exit_button.Location = new System.Drawing.Point(655, 593);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(85, 36);
            this.exit_button.TabIndex = 15;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(79, 618);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "sign up to complete purchase";
            // 
            // sign_up_button
            // 
            this.sign_up_button.BackColor = System.Drawing.SystemColors.Info;
            this.sign_up_button.Location = new System.Drawing.Point(299, 613);
            this.sign_up_button.Name = "sign_up_button";
            this.sign_up_button.Size = new System.Drawing.Size(77, 30);
            this.sign_up_button.TabIndex = 17;
            this.sign_up_button.Text = "sign up";
            this.sign_up_button.UseVisualStyleBackColor = false;
            this.sign_up_button.Click += new System.EventHandler(this.sign_up_button_Click);
            // 
            // visitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1394, 667);
            this.Controls.Add(this.sign_up_button);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.comment_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ratings_comboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Price_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.image_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.artistName_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.artwork_description_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.title_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "visitors";
            this.Text = "visitors";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.visitors_FormClosing);
            this.Load += new System.EventHandler(this.visitors_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox title_comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox artwork_description_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox artistName_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox image_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Price_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ratings_comboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox comment_textBox;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button sign_up_button;
    }
}