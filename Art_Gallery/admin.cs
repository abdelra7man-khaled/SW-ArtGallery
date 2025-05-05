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

namespace Art_Gallery
{
    public partial class admin : Form
    {
        OracleConnection conn;
        OracleDataAdapter adapter;
        DataSet dataset;
        OracleCommandBuilder builder;

        public static string connection = "Data source=orcl;User Id=scott;Password=tiger";
        public admin()
        {
            InitializeComponent();
            conn = MainForm.conn;
        }

        private void admin_Load(object sender, EventArgs e)
        {
            if(artists.Upload == true)
            {
                showRequests_groupBox.Visible = true;
                disconnected_groupBox.Visible = false;
                Newtitle_textBox.Text = artists.Artwork_title;
                Newdescription_textBox.Text = artists.description;
                Newprice_textBox.Text = artists.Artwork_price.ToString();
                image_textBox.Text = artists.imageURL;
            }
            artists.Upload = false;
        }

        private void approve_button_Click(object sender, EventArgs e)
        {
            artists.AdminApprove = true;
            this.Close();
        }

        private void reject_button_Click(object sender, EventArgs e)
        {
            artists.AdminApprove = false;
            this.Close();
        }

        private void load_button_Click(object sender, EventArgs e)
        {
            string select = string.Empty;
           
            if (customers_radioButton.Checked) { select = "select * from customers"; } 
            
            else if (artists_radioButton.Checked) { select = "select * from artists"; }
            
            else if(artworks_radioButton.Checked) { select = "select * from artworks"; }
             
            else if (orders_radioButton.Checked) { select = "select * from orders"; }
           
            else { MessageBox.Show("select the table !");return; }

            change_button.Visible = true;
            disable_button.Visible = true;

            adapter = new OracleDataAdapter(select , connection);
            dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView.DataSource = dataset.Tables[0];
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(dataset.Tables[0]);
            MessageBox.Show("updated successfully .");
        }

        private void show_record_button_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Name_textBox.Text))
            {
                MessageBox.Show($"{name_label} is Required !");
                Name_textBox.Focus();
                return;
            }

            string select = string.Empty;
            if (customers_radioButton.Checked)
            {
                select = "select * from customers where customer_name = :name";
                adapter = new OracleDataAdapter(select, connection);
                dataset = new DataSet();
                adapter.SelectCommand.Parameters.Add("name", Name_textBox.Text);
                adapter.Fill(dataset);
                dataGridView.DataSource = dataset.Tables[0];
            }
            else if (artists_radioButton.Checked)
            {
                select = "select * from artists where artist_name = :name";
                adapter = new OracleDataAdapter(select, connection);
                dataset = new DataSet();
                adapter.SelectCommand.Parameters.Add("name", Name_textBox.Text);
                adapter.Fill(dataset);
                dataGridView.DataSource = dataset.Tables[0];
            }
            else if (artworks_radioButton.Checked)
            {
                select = "select * from artworks where title = :title";
                adapter = new OracleDataAdapter(select, connection);
                dataset = new DataSet();
                adapter.SelectCommand.Parameters.Add("title", Name_textBox.Text);
                adapter.Fill(dataset);
                dataGridView.DataSource = dataset.Tables[0];
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Name_textBox.Text))
            {
                MessageBox.Show($"artist name is Required !");
                Name_textBox.Focus();
                return;
            }
            string select = @"select aw.* 
                            from artworks aw , artists a
                            where aw.artist_id = a.artist_id
                            And a.artist_name = :artist_name";
            adapter = new OracleDataAdapter(select, connection);
            dataset = new DataSet();
            adapter.SelectCommand.Parameters.Add("name", Name_textBox.Text);
            adapter.Fill(dataset);
            dataGridView.DataSource = dataset.Tables[0];
        }

        private void customers_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (customers_radioButton.Checked)
            {
                name_label.Text = "customer name";
                name_label.Visible = true;
                Name_textBox.Visible = true;
                show_record_button.Visible = true;
            }
            else
            {
                name_label.Visible = false;
                Name_textBox.Visible = false;
                show_record_button.Visible = false;
            }
        }

        private void artists_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (artists_radioButton.Checked)
            {
                name_label.Text = "artist name";
                name_label.Visible = true;
                Name_textBox.Visible = true;
                show_record_button.Visible = true;

                artist_artwork_label.Visible=true;
                search_button.Visible = true;
            }
            else
            {
                name_label.Visible = false;
                Name_textBox.Visible = false;
                show_record_button.Visible = false;

                artist_artwork_label.Visible = false;
                search_button.Visible = false;
            }
        }

        private void artworks_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (artworks_radioButton.Checked)
            {
                name_label.Text = "artwork title";
                name_label.Visible = true;
                Name_textBox.Visible = true;
                show_record_button.Visible = true;
            }
            else
            {
                name_label.Visible = false;
                Name_textBox.Visible = false;
                show_record_button.Visible = false;
            }
        }

        private void orders_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(orders_radioButton.Checked)
            {
                name_label.Visible = false;
                Name_textBox.Visible = false;
                show_record_button.Visible = false;
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            save_button.Visible = true;
            dataGridView.ReadOnly = false;
        }

        private void disable_button_Click(object sender, EventArgs e)
        {
            save_button.Visible = false;
            dataGridView.ReadOnly = true;
        }

        private void report1_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report1 r1 = new Report1();
            r1.ShowDialog();
            this.Show();

        }

        private void report2_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report2 r2 = new Report2();
            r2.ShowDialog();
            this.Show();
        }
    }
}
