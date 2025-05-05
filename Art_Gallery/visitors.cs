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
    public partial class visitors : Form
    {
       // string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        
        public visitors()
        {
            InitializeComponent();
            conn = MainForm.conn;
        }
        private void visitors_Load(object sender, EventArgs e)
        {
            //conn = new OracleConnection(ordb);
            //conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select title from artworks";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                title_comboBox.Items.Add(dr[0].ToString());
            }
            dr.Close();
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
            while(dr.Read())
            {
                artwork_description_textBox.Text = dr[0].ToString();
                Price_textBox.Text = dr[1].ToString()+"$";
                image_textBox.Text = dr[2].ToString();
            }
            dr.Close();

            OracleCommand artist_name_cmd = new OracleCommand();
            artist_name_cmd.Connection = conn;
            artist_name_cmd.CommandText = "Get_Artist_Name";
            artist_name_cmd.CommandType = CommandType.StoredProcedure;
            artist_name_cmd.Parameters.Add("title",title_comboBox.SelectedItem.ToString());
            artist_name_cmd.Parameters.Add("artist_name", OracleDbType.Varchar2,50).Direction = ParameterDirection.Output;
            artist_name_cmd.ExecuteNonQuery();

            artistName_textBox.Text = artist_name_cmd.Parameters["artist_name"].Value.ToString();

            OracleCommand ratings_cmd = new OracleCommand();
            ratings_cmd.Connection = conn;
            ratings_cmd.CommandText = "get_ratings_by_title";
            ratings_cmd.CommandType = CommandType.StoredProcedure;
            ratings_cmd.Parameters.Add("title",title_comboBox.SelectedItem.ToString());
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

        private void visitors_FormClosing(object sender, FormClosingEventArgs e)
        {
            //conn.Dispose();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sign_up_button_Click(object sender, EventArgs e)
        {
            MainForm.sign_up = true;
            exit_button.PerformClick();
        }
    }
}
