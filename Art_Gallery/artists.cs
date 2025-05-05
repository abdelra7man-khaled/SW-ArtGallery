using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Art_Gallery
{
    public partial class artists : Form
    {
        OracleConnection conn;
        public static int artistId;
        public static string Artwork_title;
        public static string description;
        public static string imageURL;
        public static int Artwork_price;
        public static bool Upload = false;
        public static bool AdminApprove = false;
        public static bool Refresh = false;
        public artists()
        {
            InitializeComponent();
            conn = MainForm.conn;

            title_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            title_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void artists_Load(object sender, EventArgs e)
        {

            OracleCommand IDcmd = new OracleCommand();
            IDcmd.Connection = conn;
            IDcmd.CommandText = "select artist_id from accounts where username = :userName and password = :pass";
            IDcmd.CommandType = CommandType.Text;
            IDcmd.Parameters.Add("artist_id", MainForm.UserName);
            IDcmd.Parameters.Add("artist_id", MainForm.Password);
            OracleDataReader dr1 = IDcmd.ExecuteReader();
            while (dr1.Read())
            {
                artistId = Convert.ToInt32(dr1[0].ToString());
            }
            dr1.Close();


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select title from artworks where artist_id = :artist_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("artist_id", artistId);
            OracleDataReader dr2 = cmd.ExecuteReader();
            while (dr2.Read())
            {
                title_comboBox.Items.Add(dr2[0].ToString());
            }
            dr2.Close();
        }
        
        private void change_button_Click(object sender, EventArgs e)
        {
            Artworks_groupBox.Visible = false;
            change_Info_groupBox.Visible = true;
            new_username_textBox.Text = MainForm.UserName;
            new_password_textBox.Text = MainForm.Password;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            change_Info_groupBox.Visible = false;
            Artworks_groupBox.Visible = true;
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
            if (conf_new_password_textBox.Text != new_password_textBox.Text)
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

        private void confirm_changes_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(new_username_textBox.Text))
            {
                MessageBox.Show("Username is required !");
                new_username_textBox.BackColor = Color.MistyRose;
                new_username_textBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(new_password_textBox.Text))
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
            cmd.Parameters.Add("lastPassword", MainForm.Password);

            cmd.ExecuteNonQuery();
            MainForm.UserName = new_username_textBox.Text;
            MainForm.Password = new_password_textBox.Text;
            MessageBox.Show("Account information updated successfully!");
            cancel_button.PerformClick();
        }

        private void title_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ratings_comboBox.Items.Clear();
            comment_textBox.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select description , price
                                from artworks
                                 where title = :title";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("title", title_comboBox.SelectedItem.ToString());

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                artwork_description_textBox.Text = dr[0].ToString();
                Price_textBox.Text = dr[1].ToString() + "$";
            }
            dr.Close();

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

            OracleCommand order_cmd = new OracleCommand();
            order_cmd.Connection = conn;
            order_cmd.CommandText = "get_artwork_stats";
            order_cmd.CommandType = CommandType.StoredProcedure;
            order_cmd.Parameters.Add("artwork_title",title_comboBox.SelectedItem.ToString());
            order_cmd.Parameters.Add("order_count", OracleDbType.Int32, ParameterDirection.Output);
            order_cmd.Parameters.Add("total_profit", OracleDbType.Int32, ParameterDirection.Output);

            order_cmd.ExecuteNonQuery();
            
            orderCount_textBox.Text = order_cmd.Parameters["order_count"].Value.ToString();
            profit_textBox.Text = order_cmd.Parameters["total_profit"].Value.ToString();
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

        private void upload_Artwork_button_Click(object sender, EventArgs e)
        {
            Artworks_groupBox.Visible = false;
            upload_groupBox.Visible = true;
        }

        private void upload_button_Click(object sender, EventArgs e)
        {
            Artwork_title = Newtitle_textBox.Text;
            description = Newdescription_textBox.Text;
            imageURL = image_textBox.Text;
            if (string.IsNullOrEmpty(Artwork_title))
            {
                MessageBox.Show(" Artwork title is Required !");
                Newtitle_textBox.BackColor = Color.MistyRose;
                Newtitle_textBox.Focus();
                return;
            }
            Newtitle_textBox.BackColor = Color.White;
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show(" Artwork description is Required !");
                Newdescription_textBox.BackColor = Color.MistyRose;
                Newtitle_textBox.Focus();
                return;
            }
            Newdescription_textBox.BackColor = Color.White;
            if (string.IsNullOrEmpty(Newprice_textBox.Text))
            {
                MessageBox.Show(" Artwork Price is Required !");
                Newprice_textBox.BackColor = Color.MistyRose;
                Newprice_textBox.Focus();
                return;
            }
            Newprice_textBox.BackColor = Color.White;
            if (string.IsNullOrEmpty(imageURL))
            {
                MessageBox.Show(" Artwork Image URL is Required !");
                image_textBox.BackColor = Color.MistyRose;
                image_textBox.Focus();
                return;
            }
            image_textBox.BackColor = Color.White;
            if (!int.TryParse(Newprice_textBox.Text, out int price))
            {
                MessageBox.Show("Price must be a number .");
                Newprice_textBox.BackColor = Color.MistyRose;
                Newprice_textBox.Focus();
                return;
            }
            Artwork_price = price;
            Upload = true;
            this.Hide();
            admin Admin = new admin();
            Admin.ShowDialog();
            this.Show();
            if(AdminApprove)
            {
                DialogResult result = MessageBox.Show("admin approved your artwork .", "Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    int new_artwork_id;
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "get_max_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("table_name", "artworks");
                    cmd.Parameters.Add("max_id" , OracleDbType.Int32  ,ParameterDirection.Output);
                    cmd.ExecuteNonQuery();

                    new_artwork_id = Convert.ToInt32(cmd.Parameters["max_id"].Value.ToString())+1;

                    OracleCommand newArtwork = new OracleCommand();
                    newArtwork.Connection = conn;
                    newArtwork.CommandText = @"insert into Artworks (artwork_id,artist_id,title,description,price,image_url,upload_date)
                                                values 
                                                (:artwork_id , :artist_id,:title,:description , :price , :image_url , :upload_date)";
                    newArtwork.CommandType = CommandType.Text;
                    newArtwork.Parameters.Add("artwork_id", new_artwork_id);
                    newArtwork.Parameters.Add("artist_id", artistId);
                    newArtwork.Parameters.Add("title", Artwork_title);
                    newArtwork.Parameters.Add("description",OracleDbType.Clob).Value = description;
                    newArtwork.Parameters.Add("price", Artwork_price);
                    newArtwork.Parameters.Add("image_url", imageURL);
                    newArtwork.Parameters.Add("upload_date",OracleDbType.Date).Value = DateTime.Now;
                    newArtwork.ExecuteNonQuery();
                    MessageBox.Show("Artwork Uploaded.");
                    cancel_upload_button.PerformClick();
                }
                else
                { 
                    MessageBox.Show("Upload Artwork canceled.");
                    cancel_upload_button.PerformClick();
                }
              
            }
            else
            {
                MessageBox.Show("admin reject your artwork .");
                cancel_upload_button.PerformClick();
            }

        }

        private void cancel_upload_button_Click(object sender, EventArgs e)
        {
            upload_groupBox.Visible = false;
            Artworks_groupBox.Visible = true;
        }

        private void change_price_button_Click(object sender, EventArgs e)
        {
            newPrice_label.Visible = true;
            update_price_textBox.Visible = true;
            update_price_textBox.ReadOnly = false;
            update_button.Visible = true;
            cancel_update_button.Visible = true;
            change_price_button.Visible = false;
        }

        private void cancel_update_button_Click(object sender, EventArgs e)
        {
            newPrice_label.Visible = false;
            update_price_textBox.Visible = false;
            update_price_textBox.ReadOnly = true;
            update_button.Visible = false;
            cancel_update_button.Visible = false;
            change_price_button.Visible = true;
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(update_price_textBox.Text))
            {
                if (!int.TryParse(update_price_textBox.Text, out int price) || price <= 0 || price > 3000)
                {
                    MessageBox.Show("Price must be greater than 0 and less than or equal 3000 .");
                    Newprice_textBox.BackColor = Color.MistyRose;
                    Newprice_textBox.Focus();
                    return;
                }
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update artworks set price = :newPrice where title = :awtitle";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("newPrice", price);
                cmd.Parameters.Add("awtitle", title_comboBox.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Artwork Price updated successfully .");
                cancel_update_button.PerformClick();
            }
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            this.Close();
            Refresh = true;
        }
    }
}
