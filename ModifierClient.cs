using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MATDESQ2
{
    public partial class ModifierClient : MaterialForm
    {
        private MaterialForm1 _parentForm;
        private string _id;
        private int _tourD;

        public ModifierClient(MaterialForm1 parentForm, string id, int tourD)
        {
            InitializeComponent();

            _parentForm = parentForm;
            _id = id;
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

        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialTextBox21.Text = "";
            materialTextBox22.Text = "";
            materialTextBox23.Text = "";
            materialTextBox24.Text = "";
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ModifierClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.ClientV1' table. You can move, or remove it, as needed.
            this.clientV1TableAdapter.Fill(this.databaseApplicationDataSet.ClientV1);

            // Clear the MaterialTextBox controls
            materialTextBox21.Clear();
            materialTextBox22.Clear();
            materialTextBox23.Clear();
            materialTextBox24.Clear();


            Console.WriteLine("ID PASSED =" + _id);

            // Create a SqlConnection object using the connection string
            string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;

            // Create a new SqlConnection object with the connection string
            SqlConnection connection = new SqlConnection(connectionString);

            // Open the connection
            connection.Open();

            // Create a new SqlCommand object to execute the SQL statement
            SqlCommand command = new SqlCommand("SELECT * FROM ClientV1 WHERE Id=@_id", connection);

            // Add the parameter for the id to the command
            command.Parameters.AddWithValue("@_id", _id);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            // Close the connection
            connection.Close();

            // Use the first row of the DataTable as needed
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                string nomETprenom = row["Nom"].ToString();
                string tlfn = row["Téléphone"].ToString();
                string addrss = row["Addresse"].ToString();
                decimal credit = Convert.ToDecimal(row["Crédit"]);
                DateTime date = Convert.ToDateTime(row["Date"]); // Convert the value to a DateTime object

                // Set the values of the text boxes
                materialTextBox21.Text = nomETprenom;
                materialTextBox22.Text = tlfn.ToString();
                materialTextBox23.Text = addrss.ToString();
                materialTextBox24.Text = credit.ToString();
                dateTimePicker1.Value = date;
            }


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

                        // Create a SqlCommand object to insert the data into the table
                        SqlCommand command = new SqlCommand("UPDATE ClientV1 SET Nom=@Nom, Téléphone=@Telephone, Addresse=@Addresse, Crédit=@Credit, [Date]=@Date WHERE Id=" + _id, connection);

                        // Add parameters to the SqlCommand object
                        command.Parameters.AddWithValue("@Nom", nom);
                        command.Parameters.AddWithValue("@Telephone", telephone);
                        command.Parameters.AddWithValue("@Addresse", adresse);
                        command.Parameters.AddWithValue("@Credit", credit);
                        command.Parameters.AddWithValue("@Date", dateString);


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
                catch (Exception ex)
                {
                    // Display error message
                    MessageBox.Show("Une Erreur s'est Produite lors de l'insertion des Données:\n" + ex.Message);
                }
            }
        }
    }
}
