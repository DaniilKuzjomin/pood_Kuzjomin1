using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace pood_Kuzjomin
{
    public partial class Form1 : Form
    {

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Daniil Kuzjomin TARpv21\pood_Kuzjomin\pood_Kuzjomin\AppData\Tooded_DB.mdf;Integrated Security=True");
        SqlCommand cmd;
        int Id;




        SqlDataAdapter adapter_toode, adapter_kat;
        public Form1()
        {
            InitializeComponent();
            Naita_Andmed();
        }



        public void Kustuta_Andmed()
        {
            tooded_txt.Text = "";
            Kogus_UpDown.Value = 0;
            Hind_UpDown.Value = 0;
            Kat_Combo.Items.Clear();
        }

        private void kat_button_Click(object sender, EventArgs e)
        {
            if (Kat_Combo.Text != "")
            {


                connect.Open();
                cmd = new SqlCommand("INSERT INTO Kategooria (Kategooria_nimetus, Kirjeldus) VALUES (@Kat, @Kir)", connect);

                cmd.Parameters.AddWithValue("@Kat", Kat_Combo.Text);
                cmd.Parameters.AddWithValue("@Kir", Kat_Combo.Text);
                cmd.ExecuteNonQuery();
                connect.Close();
                Kustuta_Andmed();
                Naita_Kat();
            }
        }

        public void Naita_Andmed()
        {
            connect.Open();
            DataTable tbl = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM Toodetable", connect);
            adapter_toode.Fill(tbl);
            dataGridView1.DataSource = tbl;
            
            Toode_img.Image= System.Drawing.Image.FromFile("../../Images/about.png");
            Toode_img.SizeMode = PictureBoxSizeMode.StretchImage;
            connect.Close();

            Naita_Kat();
        }

        public void Naita_Kat()
        {
            connect.Open();
            adapter_kat = new SqlDataAdapter("SELECT Kategooria_nimetus FROM Kategooria", connect);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            foreach (DataRow nimetus in dt_kat.Rows)
            {
                Kat_Combo.Items.Add(nimetus["Kategooria_nimetus"]);
            }
            connect.Close();
        }
        

        private void Lisa_btn_Click(object sender, EventArgs e)
        {
            if (tooded_txt.Text.Trim() != String.Empty && Kogus_UpDown.Value > 0 && Hind_UpDown.Value > 0 && Kat_Combo.SelectedItem != null)
            {

                    cmd = new SqlCommand("INSERT INTO Toodetable (Toodenimetus, Kogus, Hind, Pilt, Kategooria_Id) VALUES (@toode, @kogus, @hind, @pilt, @kat)", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@toode", tooded_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_UpDown.Value); // format andmebaasis ja vormis võrdsed
                    cmd.Parameters.AddWithValue("@hind", Hind_UpDown.Value); // format andmebaasis ja vormis võrdsed
                    cmd.Parameters.AddWithValue("@pilt", tooded_txt.Text + ".jpg"); // format?
                    cmd.Parameters.AddWithValue("@kat", Kat_Combo.SelectedIndex + 1); // id andmebaasist võtta
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Kustuta_Andmed();
                    Naita_Andmed();



            }
            else
            {
                MessageBox.Show("Sisesta andmeid");
            }

        }


        private void Kustuta_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM Toodetable WHERE Id = @rowID";

            using (SqlCommand deleteRecord = new SqlCommand(sql, connect))
            {
                connect.Open();

                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int RowID = Convert.ToInt32(dataGridView1[0, selectedIndex].Value);

                deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = RowID;
                deleteRecord.ExecuteNonQuery();

                dataGridView1.Rows.RemoveAt(selectedIndex);

                connect.Close();
            }
        }

        private void kat_btn_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("SELECT Id from Kategooria WHERE Kategooria_nimetus =@Kat", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@Kat", Kat_Combo.Text);
            cmd.ExecuteNonQuery();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            if ( Id != 0)
            {

                cmd = new SqlCommand("DELETE FROM Kategooria WHERE Id =@Id", connect);
                connect.Open();
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
                connect.Close();
                Kustuta_Andmed();
                Naita_Kat();
                MessageBox.Show("Andmed tabelist kategooria on kustutatud");


            }
            else
            {
                MessageBox.Show("Viga Kustutamisega");
            }





        }

        Random rand = new Random();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private void Otsi_btn_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\opilane\source\repos\Daniil Kuzjomin TARpv21\pood_Kuzjomin\pood_Kuzjomin\Images";
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                Toode_img.Load(openFileDialog1.FileName);
                Toode_img.Show();
                string destinationFile;
                try
                {
                    destinationFile = @"..\..\images\" + tooded_txt.Text + ext;
                    File.Copy(openFileDialog1.FileName, destinationFile);
                }
                catch 
                {
                    destinationFile = @"..\..\images\" + tooded_txt.Text + rand.Next(1, 99999).ToString() + ext;
                    File.Copy(openFileDialog1.FileName, destinationFile);
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            tooded_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Kogus_UpDown.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            Hind_UpDown.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

            try
            {
                Toode_img.Image = System.Drawing.Image.FromFile(@"..\..\images\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch (Exception)
            {
                Toode_img.Image = System.Drawing.Image.FromFile(@"..\..\Images\about.png");
                MessageBox.Show("Fail puudub");




                var vastus = MessageBox.Show("Kas tahate uus pilt lisada?", "Küsimus", MessageBoxButtons.YesNo);
                if (vastus == DialogResult.Yes)
                {
                    openFileDialog1.InitialDirectory = @"C:\Users\opilane\source\repos\Daniil Kuzjomin TARpv21\pood_Kuzjomin\pood_Kuzjomin\Images";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string ext = Path.GetExtension(openFileDialog1.FileName);
                        Toode_img.Load(openFileDialog1.FileName);
                        Toode_img.Show();
                        string destinationFile;
                        try
                        {
                            destinationFile = @"..\..\images\" + tooded_txt.Text + ext;
                            File.Copy(openFileDialog1.FileName, destinationFile);
                        }
                        catch
                        {
                            destinationFile = @"..\..\images\" + tooded_txt.Text + rand.Next(1, 99999).ToString() + ext;
                            File.Copy(openFileDialog1.FileName, destinationFile);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Viga");
                }


            }
            
            
            string v = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            Kat_Combo.SelectedIndex = Int32.Parse(v) - 1;
        }

        private void Uuenda_btn_Click(object sender, EventArgs e)
        {

            if (tooded_txt.Text != "" && Kogus_UpDown.Value > 0  && Hind_UpDown.Value > 0 && Kat_Combo.SelectedItem != null)
            {
                try
                {
                    cmd = new SqlCommand("UPDATE Toodetable SET Toodenimetus=@toode, Kogus = @kogus, Hind = @hind, Pilt = @pilt WHERE Id=@id", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@toode", tooded_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_UpDown.Value); // format andmebaasis ja vormis võrdsed
                    cmd.Parameters.AddWithValue("@hind", Hind_UpDown.Value); // format andmebaasis ja vormis võrdsed
                    string file_pilt = tooded_txt.Text + ".jpg";
                    cmd.Parameters.AddWithValue("@pilt", file_pilt); // format?
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Kustuta_Andmed();
                    Naita_Andmed();
                    MessageBox.Show("Andmed uuendatud");

                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga!");
                }

            }
            else
            {
                MessageBox.Show("Sisesta andmeid");
            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
