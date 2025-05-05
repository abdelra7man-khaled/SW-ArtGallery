using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Art_Gallery
{
    public partial class customers : Form
    {
        OracleConnection conn; 
        public static int customer_id;
        public static int artwork_id;
        public static int artist_id;
        public static bool Refresh = false;
        public customers()
        {
            InitializeComponent();
            conn = MainForm.conn;

            title_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            title_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        
        private void customers_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select title from artworks";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                title_comboBox.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

       
        private void confirm_rating_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rate_textBox.Text))
            {
                if (!int.TryParse(rate_textBox.Text, out int rating))
                {
                    MessageBox.Show("Rating must be a number between 1 and 5.");
                    rate_textBox.Focus();
                    return;
                }
                if (rating < 1 || rating > 5)
                {
                    MessageBox.Show("please enter rating from 1 to 5 !");
                    rate_textBox.Focus();
                    return;
                }

                int new_review_id;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "get_max_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("table_name", "reviews");
                cmd.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();

                new_review_id = Convert.ToInt32(cmd.Parameters["max_id"].Value.ToString()) + 1;

                OracleCommand newReview = new OracleCommand();
                newReview.Connection = conn;
                newReview.CommandText = @"INSERT INTO reviews (review_id, customer_id, artwork_id, rating, comments, review_date) 
                                        VALUES (:review_id , :customer_id , :artwork_id , :rating , :comments , :review_date)";
                newReview.CommandType = CommandType.Text;

                newReview.Parameters.Add("review_id", new_review_id);
                newReview.Parameters.Add("customer_id", customer_id);
                newReview.Parameters.Add("artwork_id", artwork_id);
                newReview.Parameters.Add("rating", rating);
                newReview.Parameters.Add("comments", OracleDbType.Clob).Value = review_textBox.Text;
                newReview.Parameters.Add("review_date", OracleDbType.Date).Value = DateTime.Now;

                newReview.ExecuteNonQuery();
                MessageBox.Show("Thanks for rating the artwork .");
                Finish_button.PerformClick();   
            }

        }

        private void title_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ratings_comboBox.Items.Clear();
            comment_textBox.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select description , price , image_url 
                                from artworks
                                 where title = :title";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("title", title_comboBox.SelectedItem.ToString());

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                artwork_description_textBox.Text = dr[0].ToString();
                Price_textBox.Text = dr[1].ToString() + "$";
                image_textBox.Text = dr[2].ToString();
            }
            dr.Close();

            OracleCommand artist_name_cmd = new OracleCommand();
            artist_name_cmd.Connection = conn;
            artist_name_cmd.CommandText = "Get_Artist_Name";
            artist_name_cmd.CommandType = CommandType.StoredProcedure;
            artist_name_cmd.Parameters.Add("title", title_comboBox.SelectedItem.ToString());
            artist_name_cmd.Parameters.Add("artist_name", OracleDbType.Varchar2, 50).Direction = ParameterDirection.Output;
            artist_name_cmd.ExecuteNonQuery();

            artistName_textBox.Text = artist_name_cmd.Parameters["artist_name"].Value.ToString();

            OracleCommand ratings_cmd = new OracleCommand();
            ratings_cmd.Connection = conn;
            ratings_cmd.CommandText = "get_ratings_by_title";
            ratings_cmd.CommandType = CommandType.StoredProcedure;
            ratings_cmd.Parameters.Add("title", title_comboBox.SelectedItem.ToString());
            ratings_cmd.Parameters.Add("ratings", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader odr = ratings_cmd.ExecuteReader();
            while (odr.Read())
            {
                ratings_comboBox.Items.Add(odr[0]);
            }
            odr.Close();
        }

        private void ratings_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand comment_cmd = new OracleCommand();
            comment_cmd.Connection = conn;
            comment_cmd.CommandText = "get_rating_comment";
            comment_cmd.CommandType = CommandType.StoredProcedure;
            comment_cmd.Parameters.Add("title", title_comboBox.SelectedItem.ToString());
            comment_cmd.Parameters.Add("rate", Convert.ToInt32(ratings_comboBox.SelectedItem.ToString()));
            comment_cmd.Parameters.Add("comment", OracleDbType.Clob).Direction = ParameterDirection.Output;
            comment_cmd.ExecuteNonQuery();

            OracleClob clob = (OracleClob)comment_cmd.Parameters["comment"].Value;
            comment_textBox.Text = clob.Value;
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            Artworks_View_groupBox.Visible = false; 
            change_Info_groupBox.Visible = true;
            new_username_textBox.Text = MainForm.UserName;
            new_password_textBox.Text = MainForm.Password;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            change_Info_groupBox.Visible = false;
            Artworks_View_groupBox.Visible = true;
        }

        private void confirm_changes_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(new_username_textBox.Text))
            {
                MessageBox.Show("Username is required !");
                new_username_textBox.BackColor = Color.MistyRose;
                new_username_textBox.Focus();
                return;
            }
            if(string.IsNullOrEmpty(new_password_textBox.Text))
            {
                MessageBox.Show("Password is required !");
                new_password_textBox.BackColor = Color.MistyRose;
                new_password_textBox.Focus();
                return;
            }
            if (new_password_textBox.Text.Length < 8 || new_password_textBox.Text.Length > 15)
            {
                MessageBox.Show("password length must be from 1 to 15");
                new_password_textBox.Focus();
                return;
            }
            if (conf_new_password_textBox.Text != new_password_textBox.Text)
            {
                MessageBox.Show("confirm Password is required !");
                conf_new_password_textBox.Focus();
                return;
            }

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update accounts set username = :userName , password = :pass where username = :lastUserName and password = :lastPassword";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("userName", new_username_textBox.Text);
            cmd.Parameters.Add("pass", new_password_textBox.Text);
            cmd.Parameters.Add("lastUserName", MainForm.UserName);
            cmd.Parameters.Add("lastPassword",MainForm.Password);

            cmd.ExecuteNonQuery();
            MainForm.UserName = new_username_textBox.Text;
            MainForm.Password = new_password_textBox.Text;
            MessageBox.Show("Account information updated successfully!");
            cancel_button.PerformClick();

        }

        private void new_password_textBox_TextChanged(object sender, EventArgs e)
        {
            string password = new_password_textBox.Text;
            if (password.Length < 8 || password.Length > 15)
            {
                new_password_textBox.BackColor = Color.MistyRose;
            }
            else
            {
                new_password_textBox.BackColor = Color.White;
            }
        }

        private void showPassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword_checkBox.Checked)
            {
                new_password_textBox.PasswordChar = default;
                conf_new_password_textBox.PasswordChar = default;
            }
            else
            {
                new_password_textBox.PasswordChar = '*';
                conf_new_password_textBox.PasswordChar = '*';
            }
        }

        private void conf_new_password_textBox_TextChanged(object sender, EventArgs e)
        {
            if(conf_new_password_textBox.Text != new_password_textBox.Text)
            {
                conf_new_password_textBox.BackColor = Color.MistyRose;
            }
            else
            {
                conf_new_password_textBox.BackColor = Color.White;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Purchase_button_Click(object sender, EventArgs e)
        {
            if(title_comboBox.SelectedItem == null)
            {
                MessageBox.Show("select an artwork to complete purchase !");
                return;
            }
            Artworks_View_groupBox.Visible = false;
            purchase_groupBox.Visible = true;
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_customer_info";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("username",MainForm.UserName);
            cmd.Parameters.Add("password",MainForm.Password);
            cmd.Parameters.Add("customer_id",OracleDbType.Int32 , ParameterDirection.Output);
            cmd.Parameters.Add("cust_name" , OracleDbType.Varchar2,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("phone_number" , OracleDbType.Varchar2,12).Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            // customer info 
            name_textBox.Text = cmd.Parameters["cust_name"].Value.ToString();
            phoneNum_textBox.Text = cmd.Parameters["phone_number"].Value.ToString();
            customer_id = Convert.ToInt32(cmd.Parameters["customer_id"].Value.ToString());
          
            //-----------------------------------------------------------------------------

            OracleCommand ids_cmd = new OracleCommand();
            ids_cmd.Connection = conn;
            ids_cmd.CommandText = "get_artwork_id";
            ids_cmd.CommandType = CommandType.StoredProcedure;
            ids_cmd.Parameters.Add("title" , title_comboBox.SelectedItem.ToString());
            ids_cmd.Parameters.Add("artwork_id" , OracleDbType.Int32 , ParameterDirection.Output);
            ids_cmd.Parameters.Add("artist_id", OracleDbType.Int32, ParameterDirection.Output);

            ids_cmd.ExecuteNonQuery();

            //artwork & artist info 
            artwork_id = Convert.ToInt32(ids_cmd.Parameters["artwork_id"].Value.ToString());
            artist_id = Convert.ToInt32(ids_cmd.Parameters["artist_id"].Value.ToString());
           
        }

        private void cancel_purchase_button_Click(object sender, EventArgs e)
        {
            purchase_groupBox.Visible = false;
            Artworks_View_groupBox.Visible = true;
        }

        private void rate_textBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rate_textBox.Text)) review_textBox.ReadOnly = false;
        }

      

        private void confirm_purchase_button_Click(object sender, EventArgs e)
        {
            // check balance 
            OracleCommand balanceChecking = new OracleCommand();
            balanceChecking.Connection = conn;
            balanceChecking.CommandText = "check_balance";
            balanceChecking.CommandType = CommandType.StoredProcedure;
            balanceChecking.Parameters.Add("customer_id", customer_id);
            balanceChecking.Parameters.Add("title" , title_comboBox.SelectedItem.ToString());
            balanceChecking.Parameters.Add("is_enough", OracleDbType.Varchar2, 10).Direction = ParameterDirection.Output;
            balanceChecking.Parameters.Add("balance" , OracleDbType.Int32 , ParameterDirection.Output);
            balanceChecking.ExecuteNonQuery();
           

            string is_enough = balanceChecking.Parameters["is_enough"].Value.ToString();
            int customer_balance = Convert.ToInt32(balanceChecking.Parameters["balance"].Value.ToString());
            if (is_enough.Equals("FALSE"))
            {
                MessageBox.Show("Insufficient balance to complete the purchase .");
                cancel_purchase_button.PerformClick();
                return;
            }
            int new_order_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_max_id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("table_name", "orders");
            cmd.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();

            new_order_id = Convert.ToInt32(cmd.Parameters["max_id"].Value.ToString()) + 1;
           
            // -------------------------------------------------------------------------------------
            OracleCommand getPrice = new OracleCommand();
            getPrice.Connection = conn;
            getPrice.CommandText = "get_artwork_price";
            getPrice.CommandType = CommandType.StoredProcedure;
            getPrice.Parameters.Add("title" , title_comboBox.SelectedItem.ToString());
            getPrice.Parameters.Add("price" , OracleDbType.Int32, ParameterDirection.Output);

            getPrice.ExecuteNonQuery();
            int price = Convert.ToInt32(getPrice.Parameters["price"].Value.ToString());
            string payment_method = credit_radioButton.Checked ? "Credit Card" : paypal_radioButton.Checked ? "PayPal" : "Bank Transfer";

            OracleCommand newOrder = new OracleCommand();
            newOrder.Connection = conn;
           
            newOrder.CommandText = @"INSERT INTO orders 
                        (order_id, artwork_id, artist_id, customer_id, order_date, amount, payment_method) 
                         VALUES 
                        (:order_id, :artwork_id, :artist_id, :customer_id, :order_date, :amount, :payment_method)";

            newOrder.CommandType = CommandType.Text;
            newOrder.Parameters.Add("order_id", new_order_id);
            newOrder.Parameters.Add("artwork_id", artwork_id);
            newOrder.Parameters.Add("artist_id" , artist_id);
            newOrder.Parameters.Add("customer_id", customer_id);
            newOrder.Parameters.Add("order_date", OracleDbType.Date).Value = DateTime.Now;
            newOrder.Parameters.Add("amount",price);
            newOrder.Parameters.Add("payment_method", payment_method);
            newOrder.ExecuteNonQuery();
           
            // update customer balance after purchase
            int NewBalance = customer_balance - price;

            OracleCommand new_balance = new OracleCommand();
            new_balance.Connection = conn;
            new_balance.CommandText = "update customers set balance = :newBalance where customer_id = :cust_id";
            new_balance.CommandType = CommandType.Text;
            new_balance.Parameters.Add("newBalance", NewBalance);
            new_balance.Parameters.Add("cust_id", customer_id);
            new_balance.ExecuteNonQuery();


            MessageBox.Show("Your purchase has been completed! We hope you enjoy your new artwork .");

            // rating the artwork 

            rate_label.Visible = true;
            rate_textBox.Visible = true;
            comment_label.Visible = true;
            review_textBox.Visible = true;
            confirm_rating_button.Visible = true;
            Finish_button.Visible = true;
            MessageBox.Show("Please enter a rating from 1 to 5 .");

        }

        private void Finish_button_Click(object sender, EventArgs e)
        {
            purchase_groupBox.Visible = false;
            Artworks_View_groupBox.Visible = true;
        }

        private void customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            //conn.Dispose();
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            Refresh = true;
            this.Close();
        }
    }
}
