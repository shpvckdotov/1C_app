using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Npgsql;
using System.Reflection;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Database
{
    public partial class Form1 : Form
    {
        private Facade _facade = new Facade();
        string hero = "";
        //NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=database;username=postgres;password=negr2003");
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void visualize()
        {
            NpgsqlConnection connection = new NpgsqlConnection("host=localhost;port=5432;database=database;username=postgres;password=negr2003");
            listView4.Items.Clear();
            listView5.Items.Clear();
            NpgsqlDataReader dataReader = null;
            try
            {

                connection.Open();
                ListViewItem item = null;
                NpgsqlCommand command4 = new NpgsqlCommand("SELECT \"Name\", \"Sex\" FROM \"Superheroes\"", connection);
                item = null;
                dataReader = command4.ExecuteReader();
                while (dataReader.Read())
                {
                    item = new ListViewItem(new string[] {
                        Convert.ToString(dataReader["Name"]) ,
                        Convert.ToString(dataReader["Sex"])});
                    listView4.Items.Add(item);
                }
                NpgsqlCommand command5 = new NpgsqlCommand("SELECT \"Name\", \"Calories\", \"Protein\", \"Fat\", \"Carbohydrates\", \"EatingDate\" FROM \"Dishes\"", connection);
                item = null;
                dataReader.Close();
                dataReader = command5.ExecuteReader();
                while (dataReader.Read())
                {
                    item = new ListViewItem(new string[] {
                        Convert.ToString(dataReader["Name"]) ,
                        Convert.ToString(dataReader["Calories"]) ,
                        Convert.ToString(dataReader["Protein"]) ,
                        Convert.ToString(dataReader["Fat"]) ,
                        Convert.ToString(dataReader["Carbohydrates"]),
                        Convert.ToString(dataReader["EatingDate"])});
                    listView5.Items.Add(item);
                }
                Series series = new Series("Данные")
                {
                    ChartType = SeriesChartType.Line
                };
                NpgsqlCommand command6 = new NpgsqlCommand("SELECT \"Calories\", \"EatingDate\" FROM \"Dishes\"", connection);
                item = null;
                dataReader.Close();
                dataReader = command6.ExecuteReader();
                while (dataReader.Read())
                {
                    double calories = Convert.ToDouble(dataReader["Calories"]);
                    series.Points.AddXY(Convert.ToDateTime(dataReader["EatingDate"]), calories);
                }
                chart1.Series.Clear();
                chart1.Series.Add(series);
            }
            catch
            {

            }
            finally
            {
                if(dataReader != null && !dataReader.IsClosed) { dataReader.Close(); }
            }
        }


        private void Mouse_Changed(object sender, EventArgs e)
        {
            if ((sender as TextBox).ForeColor == Color.Black && (sender as TextBox).Text != "")
            {
                return;
            }
            if ((sender as TextBox).Focus())
            {
                (sender as TextBox).ForeColor = Color.Gray;
                (sender as TextBox).Text = "Enter " + (sender as TextBox).Tag;
                (sender as TextBox).ReadOnly = true;
            }
            else
            {
                (sender as TextBox).Text = "";
            }
        }
        private void Mouse_Removed(object sender, EventArgs e)
        {
            if ((sender as TextBox).ForeColor == Color.Gray)
            {
                (sender as TextBox).Text = "";
                (sender as TextBox).ReadOnly = false;
            }
        }
        private void Mouse_Click(object sender, EventArgs e)
        {
            (sender as TextBox).ReadOnly = false;
            (sender as TextBox).ForeColor = Color.Black;
            (sender as TextBox).Text = "";
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try {
                if (textBox2.Text == "woman" || textBox2.Text == "man")
                {
                    _facade.RecordSuperhero(textBox1.Text, textBox2.Text);
                }
                else
                {

                }
            }
            catch (Exception exc)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCalculateCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                _facade.RecordDish(textBox4.Text,
                (float)Convert.ToDouble(textBox5.Text), (float)Convert.ToDouble(textBox6.Text), (float)Convert.ToDouble(textBox7.Text), (float)Convert.ToDouble(textBox8.Text), DateTime.Parse(textBox9.Text), textBox3.Text);
            }
            catch (FormatException exc)
            {
                MessageBox.Show("Couldn`t parse CPFC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (OverflowException exc)
            {
                MessageBox.Show("Too big number for CPFC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show("There is no such Superhero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (ArgumentNullException exc)
            {
                MessageBox.Show("There is no such Superhero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch(InvalidCastException exc)
            {
                MessageBox.Show("Wrong date type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            visualize();
        }
    }
}