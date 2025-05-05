using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Art_Gallery
{
    partial class MainForm
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
            this.log_in_button = new System.Windows.Forms.Button();
            this.UserName_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.userName_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.create_account_button = new System.Windows.Forms.Button();
            this.customer_radioButton = new System.Windows.Forms.RadioButton();
            this.artist_radioButton = new System.Windows.Forms.RadioButton();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.name_label = new System.Windows.Forms.Label();
            this.userName_NewAccount_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password_NewAccount_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.email_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneNumber_textBox = new System.Windows.Forms.TextBox();
            this.skip_button = new System.Windows.Forms.Button();
            this.finish_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.NewAccount_groupBox = new System.Windows.Forms.GroupBox();
            this.show_NewPassword_checkBox = new System.Windows.Forms.CheckBox();
            this.clear_newAccount_button = new System.Windows.Forms.Button();
            this.cancelNewAccount_button = new System.Windows.Forms.Button();
            this.log_in_groupBox = new System.Windows.Forms.GroupBox();
            this.showpassword_checkBox = new System.Windows.Forms.CheckBox();
            this.NewAccount_groupBox.SuspendLayout();
            this.log_in_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // log_in_button
            // 
            this.log_in_button.BackColor = System.Drawing.SystemColors.Info;
            this.log_in_button.Location = new System.Drawing.Point(49, 175);
            this.log_in_button.Name = "log_in_button";
            this.log_in_button.Size = new System.Drawing.Size(96, 41);
            this.log_in_button.TabIndex = 1;
            this.log_in_button.Text = "log in";
            this.log_in_button.UseVisualStyleBackColor = false;
            this.log_in_button.Click += new System.EventHandler(this.log_in_button_Click);
            // 
            // UserName_textBox
            // 
            this.UserName_textBox.Location = new System.Drawing.Point(173, 40);
            this.UserName_textBox.Name = "UserName_textBox";
            this.UserName_textBox.Size = new System.Drawing.Size(229, 22);
            this.UserName_textBox.TabIndex = 2;
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(173, 101);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(229, 22);
            this.password_textBox.TabIndex = 3;
            // 
            // userName_label
            // 
            this.userName_label.AutoSize = true;
            this.userName_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.userName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName_label.Location = new System.Drawing.Point(45, 42);
            this.userName_label.Name = "userName_label";
            this.userName_label.Size = new System.Drawing.Size(88, 20);
            this.userName_label.TabIndex = 4;
            this.userName_label.Text = "user name";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(45, 101);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(81, 20);
            this.password_label.TabIndex = 5;
            this.password_label.Text = "password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(518, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "Welcome";
            // 
            // create_account_button
            // 
            this.create_account_button.BackColor = System.Drawing.SystemColors.Info;
            this.create_account_button.Location = new System.Drawing.Point(199, 175);
            this.create_account_button.Name = "create_account_button";
            this.create_account_button.Size = new System.Drawing.Size(96, 51);
            this.create_account_button.TabIndex = 7;
            this.create_account_button.Text = "create an account";
            this.create_account_button.UseVisualStyleBackColor = false;
            this.create_account_button.Click += new System.EventHandler(this.create_account_button_Click);
            // 
            // customer_radioButton
            // 
            this.customer_radioButton.AutoSize = true;
            this.customer_radioButton.Checked = true;
            this.customer_radioButton.Location = new System.Drawing.Point(259, 28);
            this.customer_radioButton.Name = "customer_radioButton";
            this.customer_radioButton.Size = new System.Drawing.Size(83, 20);
            this.customer_radioButton.TabIndex = 8;
            this.customer_radioButton.TabStop = true;
            this.customer_radioButton.Text = "customer";
            this.customer_radioButton.UseVisualStyleBackColor = true;
            // 
            // artist_radioButton
            // 
            this.artist_radioButton.AutoSize = true;
            this.artist_radioButton.Location = new System.Drawing.Point(418, 28);
            this.artist_radioButton.Name = "artist_radioButton";
            this.artist_radioButton.Size = new System.Drawing.Size(56, 20);
            this.artist_radioButton.TabIndex = 9;
            this.artist_radioButton.Text = "artist";
            this.artist_radioButton.UseVisualStyleBackColor = true;
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(144, 88);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(221, 22);
            this.Name_textBox.TabIndex = 10;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(76, 90);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(53, 20);
            this.name_label.TabIndex = 11;
            this.name_label.Text = "Name";
            // 
            // userName_NewAccount_textBox
            // 
            this.userName_NewAccount_textBox.Location = new System.Drawing.Point(144, 133);
            this.userName_NewAccount_textBox.Name = "userName_NewAccount_textBox";
            this.userName_NewAccount_textBox.Size = new System.Drawing.Size(221, 22);
            this.userName_NewAccount_textBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "user name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "password";
            // 
            // password_NewAccount_textBox
            // 
            this.password_NewAccount_textBox.Location = new System.Drawing.Point(144, 178);
            this.password_NewAccount_textBox.Name = "password_NewAccount_textBox";
            this.password_NewAccount_textBox.PasswordChar = '*';
            this.password_NewAccount_textBox.Size = new System.Drawing.Size(221, 22);
            this.password_NewAccount_textBox.TabIndex = 15;
            this.password_NewAccount_textBox.TextChanged += new System.EventHandler(this.password_NewAccount_textBox_TextChanged);
            this.password_NewAccount_textBox.Leave += new System.EventHandler(this.password_NewAccount_textBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(483, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "e-mail";
            // 
            // email_textBox
            // 
            this.email_textBox.Location = new System.Drawing.Point(578, 88);
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(221, 22);
            this.email_textBox.TabIndex = 17;
            this.email_textBox.TextChanged += new System.EventHandler(this.email_textBox_TextChanged);
            this.email_textBox.Leave += new System.EventHandler(this.email_textBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(447, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "phone number";
            // 
            // phoneNumber_textBox
            // 
            this.phoneNumber_textBox.Location = new System.Drawing.Point(578, 135);
            this.phoneNumber_textBox.Name = "phoneNumber_textBox";
            this.phoneNumber_textBox.Size = new System.Drawing.Size(221, 22);
            this.phoneNumber_textBox.TabIndex = 19;
            // 
            // skip_button
            // 
            this.skip_button.BackColor = System.Drawing.SystemColors.Info;
            this.skip_button.Location = new System.Drawing.Point(473, 175);
            this.skip_button.Name = "skip_button";
            this.skip_button.Size = new System.Drawing.Size(96, 41);
            this.skip_button.TabIndex = 20;
            this.skip_button.Text = "skip";
            this.skip_button.UseVisualStyleBackColor = false;
            this.skip_button.Click += new System.EventHandler(this.skip_button_Click);
            // 
            // finish_button
            // 
            this.finish_button.BackColor = System.Drawing.SystemColors.Info;
            this.finish_button.Location = new System.Drawing.Point(487, 203);
            this.finish_button.Name = "finish_button";
            this.finish_button.Size = new System.Drawing.Size(96, 41);
            this.finish_button.TabIndex = 21;
            this.finish_button.Text = "finish";
            this.finish_button.UseVisualStyleBackColor = false;
            this.finish_button.Click += new System.EventHandler(this.finish_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.BackColor = System.Drawing.SystemColors.Info;
            this.clear_button.Location = new System.Drawing.Point(323, 175);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(96, 41);
            this.clear_button.TabIndex = 22;
            this.clear_button.Text = "clear";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // NewAccount_groupBox
            // 
            this.NewAccount_groupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NewAccount_groupBox.Controls.Add(this.show_NewPassword_checkBox);
            this.NewAccount_groupBox.Controls.Add(this.clear_newAccount_button);
            this.NewAccount_groupBox.Controls.Add(this.cancelNewAccount_button);
            this.NewAccount_groupBox.Controls.Add(this.finish_button);
            this.NewAccount_groupBox.Controls.Add(this.phoneNumber_textBox);
            this.NewAccount_groupBox.Controls.Add(this.label5);
            this.NewAccount_groupBox.Controls.Add(this.email_textBox);
            this.NewAccount_groupBox.Controls.Add(this.label4);
            this.NewAccount_groupBox.Controls.Add(this.password_NewAccount_textBox);
            this.NewAccount_groupBox.Controls.Add(this.label3);
            this.NewAccount_groupBox.Controls.Add(this.label2);
            this.NewAccount_groupBox.Controls.Add(this.userName_NewAccount_textBox);
            this.NewAccount_groupBox.Controls.Add(this.name_label);
            this.NewAccount_groupBox.Controls.Add(this.Name_textBox);
            this.NewAccount_groupBox.Controls.Add(this.artist_radioButton);
            this.NewAccount_groupBox.Controls.Add(this.customer_radioButton);
            this.NewAccount_groupBox.Location = new System.Drawing.Point(258, 132);
            this.NewAccount_groupBox.Name = "NewAccount_groupBox";
            this.NewAccount_groupBox.Size = new System.Drawing.Size(819, 255);
            this.NewAccount_groupBox.TabIndex = 23;
            this.NewAccount_groupBox.TabStop = false;
            this.NewAccount_groupBox.Text = "create account";
            this.NewAccount_groupBox.Visible = false;
            // 
            // show_NewPassword_checkBox
            // 
            this.show_NewPassword_checkBox.AutoSize = true;
            this.show_NewPassword_checkBox.Location = new System.Drawing.Point(144, 206);
            this.show_NewPassword_checkBox.Name = "show_NewPassword_checkBox";
            this.show_NewPassword_checkBox.Size = new System.Drawing.Size(122, 20);
            this.show_NewPassword_checkBox.TabIndex = 25;
            this.show_NewPassword_checkBox.Text = "show password";
            this.show_NewPassword_checkBox.UseVisualStyleBackColor = true;
            this.show_NewPassword_checkBox.CheckedChanged += new System.EventHandler(this.show_NewPassword_checkBox_CheckedChanged);
            // 
            // clear_newAccount_button
            // 
            this.clear_newAccount_button.BackColor = System.Drawing.SystemColors.Info;
            this.clear_newAccount_button.Location = new System.Drawing.Point(691, 203);
            this.clear_newAccount_button.Name = "clear_newAccount_button";
            this.clear_newAccount_button.Size = new System.Drawing.Size(96, 41);
            this.clear_newAccount_button.TabIndex = 24;
            this.clear_newAccount_button.Text = "clear";
            this.clear_newAccount_button.UseVisualStyleBackColor = false;
            this.clear_newAccount_button.Click += new System.EventHandler(this.clear_newAccount_button_Click);
            // 
            // cancelNewAccount_button
            // 
            this.cancelNewAccount_button.BackColor = System.Drawing.SystemColors.Info;
            this.cancelNewAccount_button.Location = new System.Drawing.Point(589, 203);
            this.cancelNewAccount_button.Name = "cancelNewAccount_button";
            this.cancelNewAccount_button.Size = new System.Drawing.Size(96, 41);
            this.cancelNewAccount_button.TabIndex = 22;
            this.cancelNewAccount_button.Text = "cancel";
            this.cancelNewAccount_button.UseVisualStyleBackColor = false;
            this.cancelNewAccount_button.Click += new System.EventHandler(this.cancelNewAccount_button_Click);
            // 
            // log_in_groupBox
            // 
            this.log_in_groupBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.log_in_groupBox.Controls.Add(this.showpassword_checkBox);
            this.log_in_groupBox.Controls.Add(this.clear_button);
            this.log_in_groupBox.Controls.Add(this.skip_button);
            this.log_in_groupBox.Controls.Add(this.create_account_button);
            this.log_in_groupBox.Controls.Add(this.password_label);
            this.log_in_groupBox.Controls.Add(this.userName_label);
            this.log_in_groupBox.Controls.Add(this.password_textBox);
            this.log_in_groupBox.Controls.Add(this.UserName_textBox);
            this.log_in_groupBox.Controls.Add(this.log_in_button);
            this.log_in_groupBox.Location = new System.Drawing.Point(327, 123);
            this.log_in_groupBox.Name = "log_in_groupBox";
            this.log_in_groupBox.Size = new System.Drawing.Size(589, 245);
            this.log_in_groupBox.TabIndex = 24;
            this.log_in_groupBox.TabStop = false;
            this.log_in_groupBox.Text = "log in";
            // 
            // showpassword_checkBox
            // 
            this.showpassword_checkBox.AutoSize = true;
            this.showpassword_checkBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.showpassword_checkBox.Location = new System.Drawing.Point(173, 129);
            this.showpassword_checkBox.Name = "showpassword_checkBox";
            this.showpassword_checkBox.Size = new System.Drawing.Size(122, 20);
            this.showpassword_checkBox.TabIndex = 23;
            this.showpassword_checkBox.Text = "show password";
            this.showpassword_checkBox.UseVisualStyleBackColor = false;
            this.showpassword_checkBox.CheckedChanged += new System.EventHandler(this.showpassword_checkBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1240, 706);
            this.Controls.Add(this.log_in_groupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewAccount_groupBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.NewAccount_groupBox.ResumeLayout(false);
            this.NewAccount_groupBox.PerformLayout();
            this.log_in_groupBox.ResumeLayout(false);
            this.log_in_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private void email_textBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button log_in_button;
        private System.Windows.Forms.TextBox UserName_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Label userName_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button create_account_button;
        private System.Windows.Forms.RadioButton customer_radioButton;
        private System.Windows.Forms.RadioButton artist_radioButton;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox userName_NewAccount_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password_NewAccount_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox email_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox phoneNumber_textBox;
        private System.Windows.Forms.Button skip_button;
        private System.Windows.Forms.Button finish_button;
        private System.Windows.Forms.Button clear_button;
        private GroupBox NewAccount_groupBox;
        private Button cancelNewAccount_button;
        private Button clear_newAccount_button;
        private GroupBox log_in_groupBox;
        private CheckBox showpassword_checkBox;
        private CheckBox show_NewPassword_checkBox;
    }
}

