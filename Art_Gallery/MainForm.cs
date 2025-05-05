using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Art_Gallery
{
 
    public partial class MainForm : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger";
        public static OracleConnection conn;

       
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static bool sign_up = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            UserName_textBox.Text = string.Empty;
            password_textBox.Text = string.Empty;
        }

        private void log_in_button_Click(object sender, EventArgs e)
        {
            string userName = UserName_textBox.Text.ToString();
            string password = password_textBox.Text.ToString();
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("invalid user name or password !");
                return;
            }
            if (userName == "admin" && password == "admin")
            {
                this.Hide();
                admin adminForm = new admin();
                adminForm.ShowDialog();
                this.Show();
            }
            else
            {
                if (password.Length < 8 || password.Length > 15) 
                { 
                    MessageBox.Show("password length must be from 8 to 15 character");
                    password_textBox.BackColor = Color.MistyRose;
                    password_textBox.Focus(); 
                    return; 
                }
                password_textBox.BackColor = Color.White;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "check_account";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("v_username", OracleDbType.Varchar2).Value = userName;
                cmd.Parameters.Add("v_password", OracleDbType.Varchar2).Value = password;
                cmd.Parameters.Add("v_exist", OracleDbType.Varchar2, 5).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("v_state", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string valid_account = cmd.Parameters["v_exist"].Value.ToString();
                string state = cmd.Parameters["v_state"].Value.ToString();
                if (valid_account == "TRUE")
                {
                    this.Hide();
                    UserName = userName;
                    Password = password;
                    if (state == "customer")
                    {
                        customers customerForm = new customers();
                        customerForm.ShowDialog();
                        this.Show();
                        if (customers.Refresh == true) { customers.Refresh = false; log_in_button.PerformClick(); }
                    }
                    else
                    {
                        artists artistsForm = new artists();
                        artistsForm.ShowDialog();
                        this.Show();
                        if(artists.Refresh == true) { artists.Refresh = false; log_in_button.PerformClick();}
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }


        }

        private void skip_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            visitors visitorForm = new visitors();
            visitorForm.ShowDialog();
            this.Show();
            if(sign_up == true)
            {
                create_account_button.PerformClick();
            }
        }

        private void create_account_button_Click(object sender, EventArgs e)
        {
            log_in_groupBox.Visible = false;
            NewAccount_groupBox.Visible = true;
        }

       
        private void cancelNewAccount_button_Click(object sender, EventArgs e)
        {
            clear_newAccount_button.PerformClick();
            log_in_groupBox.Visible = true;
            NewAccount_groupBox.Visible = false;
        }

        private void finish_button_Click(object sender, EventArgs e)
        {
            string name = Name_textBox.Text;
            string username = userName_NewAccount_textBox.Text;
            string phone_number = phoneNumber_textBox.Text;
            string email = email_textBox.Text;
            string password = password_NewAccount_textBox.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required !");
                Name_textBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("username is required !");
                userName_NewAccount_textBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(phone_number))
            {
                MessageBox.Show("phone number is required !");
                phoneNumber_textBox.Focus();
                return;
            }
            if (password.Length < 8 || password.Length > 15)
            {
                MessageBox.Show("password length must be from 1 to 15");
                password_NewAccount_textBox.Focus();
                return;
            }

            if (!email.EndsWith("@artgallery.com"))
            {
                MessageBox.Show("the email must end with @artgallery.com");
                email_textBox.Focus();
                return;
            }
            bool IsCustomer = customer_radioButton.Checked;
            int new_account_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_max_id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("table_name", "accounts");
            cmd.Parameters.Add("max_id" , OracleDbType.Int32 , ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            
            new_account_id = Convert.ToInt32(cmd.Parameters["max_id"].Value.ToString()) + 1 ;
            if (IsCustomer) 
            {
                int new_customer_id;
                OracleCommand get_custID = new OracleCommand();
                get_custID.Connection = conn;
                get_custID.CommandText = "get_max_id";
                get_custID.CommandType = CommandType.StoredProcedure;
                get_custID.Parameters.Add("table_name", "customers");
                get_custID.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
                get_custID.ExecuteNonQuery();

                new_customer_id = Convert.ToInt32(get_custID.Parameters["max_id"].Value.ToString()) + 1;

                Random random = new Random();
                int[] balances = { 1000, 1500, 2000, 2500, 3000 };
                int randomBalance = balances[random.Next(balances.Length)];

                OracleCommand NewCustomer = new OracleCommand();
                NewCustomer.Connection = conn;
                NewCustomer.CommandText = "insert into customers values(:id,:name , :email , :phone_number , :balance)";
                NewCustomer.CommandType = CommandType.Text;
                NewCustomer.Parameters.Add("id", new_customer_id);
                NewCustomer.Parameters.Add("name" , Name_textBox.Text);
                NewCustomer.Parameters.Add("email", email_textBox.Text);
                NewCustomer.Parameters.Add("phone_number" , phoneNumber_textBox.Text);
                NewCustomer.Parameters.Add("balance", randomBalance);
                NewCustomer.ExecuteNonQuery();

                OracleCommand NewAccount = new OracleCommand();
                NewAccount.Connection = conn;
                NewAccount.CommandText = "insert into accounts values(:id,:username , :password , :state , :custID , :artistID)";
                NewAccount.CommandType = CommandType.Text;
                NewAccount.Parameters.Add("id", new_account_id);
                NewAccount.Parameters.Add("username", userName_NewAccount_textBox.Text);
                NewAccount.Parameters.Add("password", password_NewAccount_textBox.Text);
                NewAccount.Parameters.Add("state", "customer");
                NewAccount.Parameters.Add("custID", new_customer_id);
                NewAccount.Parameters.Add("artistID", null);
                NewAccount.ExecuteNonQuery();

            }
            else
            {
                int new_artist_id;
                OracleCommand get_artistID = new OracleCommand();
                get_artistID.Connection = conn;
                get_artistID.CommandText = "get_max_id";
                get_artistID.CommandType = CommandType.StoredProcedure;
                get_artistID.Parameters.Add("table_name", "artists");
                get_artistID.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
                get_artistID.ExecuteNonQuery();

                new_artist_id = Convert.ToInt32(get_artistID.Parameters["max_id"].Value.ToString()) + 1;

                OracleCommand NewArtist = new OracleCommand();
                NewArtist.Connection = conn;
                NewArtist.CommandText = "insert into artists values(:id,:name , :email , :phone_number)";
                NewArtist.CommandType = CommandType.Text;
                NewArtist.Parameters.Add("id", new_artist_id);
                NewArtist.Parameters.Add("name", Name_textBox.Text);
                NewArtist.Parameters.Add("email", email_textBox.Text);
                NewArtist.Parameters.Add("phone_number", phoneNumber_textBox.Text);
                
                NewArtist.ExecuteNonQuery();

                OracleCommand NewAccount = new OracleCommand();
                NewAccount.Connection = conn;
                NewAccount.CommandText = "insert into accounts values(:id,:username , :password , :state , :custID , :artistID)";
                NewAccount.CommandType = CommandType.Text;
                NewAccount.Parameters.Add("id", new_account_id);
                NewAccount.Parameters.Add("username", userName_NewAccount_textBox.Text);
                NewAccount.Parameters.Add("password", password_NewAccount_textBox.Text);
                NewAccount.Parameters.Add("state", "artist");
                NewAccount.Parameters.Add("custID", null);
                NewAccount.Parameters.Add("artistID", new_artist_id);
                NewAccount.ExecuteNonQuery();
            }
            MessageBox.Show("Account created successfully!");
            if(IsCustomer)
            {
                this.Hide();
                customers customerForm = new customers();
                customerForm.ShowDialog();
                this.Show();
            }
            else
            {
                this.Hide();
                artists artistForm = new artists();
                artistForm.ShowDialog();
                this.Show();
            }
        }

        private void email_textBox_Leave(object sender, EventArgs e)
        {
            string email = email_textBox.Text;
            
            if (!email.EndsWith("@artgallery.com"))
            {
                email_textBox.BackColor = Color.MistyRose;
            }
           
        }

        private void password_NewAccount_textBox_TextChanged(object sender, EventArgs e)
        {
            string password = password_NewAccount_textBox.Text;
            if (password.Length < 8 || password.Length > 15)
            {
                password_NewAccount_textBox.BackColor = Color.MistyRose;
            }
            else
            {
                password_NewAccount_textBox.BackColor = Color.White;
            }
        }

        private void password_NewAccount_textBox_Leave(object sender, EventArgs e)
        {
            string password = password_NewAccount_textBox.Text;
            if (password.Length < 8 || password.Length > 15)
            {
                password_NewAccount_textBox.BackColor = Color.MistyRose;
            }
            
        }

        private void clear_newAccount_button_Click(object sender, EventArgs e)
        {
            customer_radioButton.Checked = true;
            Name_textBox.Text = string.Empty;
            userName_NewAccount_textBox.Text = string.Empty;
            password_NewAccount_textBox.Text = string.Empty;
            email_textBox.Text = string.Empty;
            phoneNumber_textBox.Text = string.Empty;
            password_NewAccount_textBox.BackColor = Color.White;
            email_textBox.BackColor = Color.White;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void showpassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(showpassword_checkBox.Checked)
            {
                password_textBox.PasswordChar = default;
            }
            else
            {
                password_textBox.PasswordChar = '*';
            }
        }

        private void show_NewPassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (show_NewPassword_checkBox.Checked)
            {
                password_NewAccount_textBox.PasswordChar = default;
            }
            else
            {
                password_NewAccount_textBox.PasswordChar = '*';
            }
        }
    }
}
