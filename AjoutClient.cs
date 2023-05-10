using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MATDESQ2
{
    public partial class AjoutClient : MaterialForm
    {
        private MaterialForm1 _parentForm;
        private int _tourD;

        public AjoutClient(MaterialForm1 parentForm, int tourD)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _tourD = tourD;

            if (_tourD == 0)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else if (_tourD == 1)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }

            dateTimePicker1.Value = DateTime.Now;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialTextBox21.Text = "";
            materialTextBox22.Text = "";
            materialTextBox23.Text = "";
            materialTextBox24.Text = "";
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(materialTextBox21.Text))
            {
                MessageBox.Show("Le champ 'Nom & Prenom' est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Get the values from the MaterialTextBox controls 
                    string nom = materialTextBox21.Text;
                    string telephone = materialTextBox22.Text;
                    string adresse = materialTextBox23.Text;
                    decimal credit;
                    if (!decimal.TryParse(materialTextBox24.Text, out credit))
                    {
                        credit = 0.00m;
                    }
                    // Get the date value from the DateTimePicker control
                    DateTime date = dateTimePicker1.Value;

                    // Convert the date value to a string in the format that matches the data type of your database column
                    string dateString = date.ToString("yyyy-MM-dd"); // Use the format "yyyy-MM-dd" for a SQL Server date column


                    // Create a SqlConnection object using the connection string
                    string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the connection, execute the command, and retrieve the new identity value
                        connection.Open();

                        // Check the number of rows in the table
                        SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM ClientV1", connection);
                        int rowCount = (int)countCommand.ExecuteScalar();
                        countCommand.Dispose();

                        // Check if the number of rows exceeds 5
                        if (rowCount >= 5)
                        {
                            MessageBox.Show("Votre logiciel est en mode démonstration. La version est limitée à 5 clients.", "Information");
                        }
                        else
                        {
                            // Create a SqlCommand object to insert the data into the table
                            SqlCommand command = new SqlCommand("INSERT INTO ClientV1 (Nom, Téléphone, Addresse, Crédit, Date) VALUES (@Nom, @Téléphone, @Addresse, @Crédit, @Date); SELECT SCOPE_IDENTITY();", connection);
                            command.Parameters.Add("@Nom", SqlDbType.NVarChar, 100).Value = nom;
                            command.Parameters.Add("@Téléphone", SqlDbType.NVarChar, 100).Value = telephone;
                            command.Parameters.Add("@Addresse", SqlDbType.NVarChar, 100).Value = adresse;
                            command.Parameters.Add("@Crédit", SqlDbType.Decimal, 18, "Crédit").Value = credit;
                            command.Parameters.Add("@Date", SqlDbType.NVarChar, 100).Value = dateString;

                            command.ExecuteNonQuery();
                            command.Dispose();
                            connection.Close();

                            _parentForm.LoadDB();

                            // Display a message to indicate that the data was inserted successfully
                            MessageBox.Show("Les Données ont été insérées avec Succès.");

                            // Clear the MaterialTextBox controls
                            materialTextBox21.Clear();
                            materialTextBox22.Clear();
                            materialTextBox23.Clear();
                            materialTextBox24.Clear();
                        }

                    }
                }
                catch (Exception ex)
                {
                    // Display error message
                    MessageBox.Show("Une Erreur s'est Produite lors de l'insertion des Données:\n" + ex.Message);
                }
            }
        }

        private void materialTextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
                return;
            }

        }

        private void materialTextBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != ',' && ch != ' ' && ch != 8)
            {
                e.Handled = true;
                return;
            }
        }

        private void AjoutClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.ClientV1' table. You can move, or remove it, as needed.
            this.clientV1TableAdapter.Fill(this.databaseApplicationDataSet.ClientV1);

            // Clear the MaterialTextBox controls
            materialTextBox21.Clear();
            materialTextBox22.Clear();
            materialTextBox23.Clear();
            materialTextBox24.Clear();

        }

    }
}
