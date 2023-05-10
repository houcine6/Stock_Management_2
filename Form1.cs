using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace MATDESQ2
{
    public partial class MaterialForm1 : MaterialForm
    {
        public MaterialForm1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Grey800,
            Primary.Grey900,
            Primary.Green50,
            Accent.Red700,
            TextShade.WHITE);

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        public void LoadDB()
        {
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.ClientV1' table. You can move, or remove it, as needed.
            this.clientV1TableAdapter.Fill(this.databaseApplicationDataSet.ClientV1);
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.stockV4' table. You can move, or remove it, as needed.
            this.stockV4TableAdapter.Fill(this.databaseApplicationDataSet.stockV4);
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.HistoriqueV1' table. You can move, or remove it, as needed.
            this.historiqueV1TableAdapter.Fill(this.databaseApplicationDataSet.HistoriqueV1);

            materialButton4.Enabled = false;
            materialButton5.Enabled = false;

            materialButton7.Enabled = false;
            materialButton8.Enabled = false;

            materialButton17.Enabled = false;
            materialButton16.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.HistoriqueV1' table. You can move, or remove it, as needed.
            this.historiqueV1TableAdapter.Fill(this.databaseApplicationDataSet.HistoriqueV1);
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.ClientV1' table. You can move, or remove it, as needed.
            this.clientV1TableAdapter.Fill(this.databaseApplicationDataSet.ClientV1);
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.stockV4' table. You can move, or remove it, as needed.
            this.stockV4TableAdapter.Fill(this.databaseApplicationDataSet.stockV4);


            // Create a new timer object with an interval of 1000 milliseconds (1 second)
            Timer timer = new Timer();
            timer.Interval = 1000;

            // Attach an event handler to the timer's Tick event
            timer.Tick += timer_Tick;

            // Start the timer
            timer.Start();

            MessageBox.Show("Votre Logiciel est en Mode Démonstration \n" +
                            "La Version est Limmité : \n" +
                            "- 10 Produits \n" +
                            "- 5 Clients \n" +
                            "- 10 Ventes \n", "Information");
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // Update the label with the current time
            materialLabel19.Text = DateTime.Now.ToString("hh:mm:ss tt");

            // Update the text of the date label every second in the format of "MM/dd/yyyy"
            materialLabel20.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            AjoutStock2 ajoutStock2 = new AjoutStock2(this, tourD);
            ajoutStock2.Show();

            materialButton4.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialTextBox1.Text = "";
            stockV4BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox1.Text + "%'");
        }

        string Id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the currently selected row
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;

            // Get the value of the second cell (index 1) in the selected row
            object nomObject = selectedRow.Cells[1].Value;
            string nom = nomObject != DBNull.Value ? nomObject.ToString() : null;

            // Check if the value of the second cell is not null
            if (nom != null)
            {
                // Get the value of the first cell in the selected row
                Id = selectedRow.Cells[0].Value.ToString();

                // Set the current row selection to true and enable a button
                selectedRow.Selected = true;
                materialButton4.Enabled = true;
                materialButton5.Enabled = true;
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            // Pass the value to the ModifierStock form and open it
            ModifierStock modifierStock = new ModifierStock(this, Id, tourD);
            modifierStock.Show();

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            // Prompt the user for confirmation before deleting the row
            DialogResult result = MessageBox.Show("Êtes-vous Sûr de Vouloir Supprimer Cette Ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SqlConnection connection = null;
                try
                {
                    // Define connection string
                    string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;

                    // Define SQL query to delete row with specific Id
                    string query = "DELETE FROM [dbo].[stockV4] WHERE Id = @id";

                    // Create connection object
                    using (connection = new SqlConnection(connectionString))
                    {
                        // Create command object with query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter for Id value
                            command.Parameters.AddWithValue("@id", Id); // Replace idValue with the actual Id value you want to delete

                            // Open connection
                            connection.Open();

                            // Execute command
                            int rowsAffected = command.ExecuteNonQuery();

                            LoadDB();

                            // Row was deleted successfully
                            MessageBox.Show(string.Format("L'article Sélectionné a été supprimé avec Succès."), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    MessageBox.Show("Une Erreur s'est Produite Lors de la Suppression de la Ligne. Détails de l'erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close connection
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }

        }

        private void materialTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(materialTextBox1.Text))
                {
                    stockV4BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox1.Text + "%'");
                }
                else
                {
                    stockV4BindingSource.Filter = string.Empty;
                }
            }
        }

        int numRowsstock;
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Get the number of rows in the DataGridView
            numRowsstock = dataGridView1.Rows.Count - 1;

            // Set the label's Text property to the number of rows
            materialLabel3.Text = "" + numRowsstock.ToString();
            //acceuil
            materialLabel4.Text = "" + numRowsstock.ToString();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            AjoutClient ajoutClient = new AjoutClient(this, tourD);
            ajoutClient.Show();
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            // Pass the value to the ModifierStock form and open it
            ModifierClient modifierClient = new ModifierClient(this, IdC, tourD);
            modifierClient.Show();
        }

        int numRowsClient;
        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Get the number of rows in the DataGridView
            numRowsClient = dataGridView2.Rows.Count - 1;

            // Set the label's Text property to the number of rows
            materialLabel11.Text = "" + numRowsClient.ToString();
            //acceille
            materialLabel5.Text = "" + numRowsClient.ToString();

            // Calculate the sum of the values in column 4
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                if (row.Cells[4].Value != null && row.Cells[4].Value != DBNull.Value)
                {
                    sum += Convert.ToDouble(row.Cells[4].Value);
                }
            }

            // Display the sum in the label
            materialLabel7.Text = sum.ToString("0.00") + " Da";
        }

        string IdC;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the currently selected row
            DataGridViewRow selectedRow = dataGridView2.CurrentRow;

            // Get the value of the second cell (index 1) in the selected row
            object nomObject = selectedRow.Cells[1].Value;
            string nom = nomObject != DBNull.Value ? nomObject.ToString() : null;

            // Check if the value of the second cell is not null
            if (nom != null)
            {
                // Get the value of the first cell in the selected row
                IdC = selectedRow.Cells[0].Value.ToString();

                // Set the current row selection to true and enable a button
                selectedRow.Selected = true;
                materialButton8.Enabled = true;
                materialButton7.Enabled = true;
            }
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            // Prompt the user for confirmation before deleting the row
            DialogResult result = MessageBox.Show("Êtes-vous Sûr de Vouloir Supprimer Cette Ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SqlConnection connection = null;
                try
                {
                    // Define connection string
                    string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;

                    // Define SQL query to delete row with specific Id
                    string query = "DELETE FROM [dbo].[ClientV1] WHERE Id = @id";

                    // Create connection object
                    using (connection = new SqlConnection(connectionString))
                    {
                        // Create command object with query and connection
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter for Id value
                            command.Parameters.AddWithValue("@id", IdC); // Replace idValue with the actual Id value you want to delete

                            // Open connection
                            connection.Open();

                            // Execute command
                            int rowsAffected = command.ExecuteNonQuery();

                            LoadDB();

                            // Row was deleted successfully
                            MessageBox.Show(string.Format("Le Client Sélectionné a été supprimé avec Succès."), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    MessageBox.Show("Une Erreur s'est Produite Lors de la Suppression de la Ligne. Détails de l'erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close connection
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            materialTextBox2.Text = "";
            clientV1BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox2.Text + "%'");
        }

        private void materialTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(materialTextBox2.Text))
                {
                    clientV1BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox2.Text + "%'");
                }
                else
                {
                    clientV1BindingSource.Filter = string.Empty;
                }
            }
        }

        string nom;
        decimal quantite;
        decimal prixAchat;
        decimal prixVente;
        int IdArticle;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // make sure the click is on a valid row
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != "")
                {
                    dataGridView3.CurrentRow.Selected = true;

                    IdArticle = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                    nom = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                    quantite = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[2].Value.ToString());
                    prixAchat = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[3].Value.ToString());
                    prixVente = Convert.ToDecimal(dataGridView3.CurrentRow.Cells[4].Value.ToString());

                    materialTextBox24.Text = prixVente.ToString();

                }
                else
                {

                }
            }
            else
            {

            }
        }

        private void materialTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(materialTextBox3.Text))
                {
                    stockV4BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox3.Text + "%'");
                }
                else
                {
                    stockV4BindingSource.Filter = string.Empty;
                }
            }
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            materialTextBox3.Text = "";
            stockV4BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox3.Text + "%'");
        }

        private void materialTextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != ',' && ch != 8)
            {
                e.Handled = true;
                return;
            }
        }

        private void materialTextBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != ',' && ch != 8)
            {
                e.Handled = true;
                return;
            }
        }

        String quantity, price, mon; // pour la liste
        List<string> printList = new List<string>();
        List<int> idHistoriqueList = new List<int>();

        String day = DateTime.Now.ToString("d");

        decimal Mont = 0;
        decimal TP = 0;

        decimal qteSaisi;

        private void materialFloatingActionButton5_Click(object sender, EventArgs e)
        {
            materialLabel13.Text = "0";
            materialTextBox22.Text = "";
            materialTextBox24.Text = "";
            TP = 0;
            dataGridView4.Rows.Clear();
            printList.Clear();
            idHistoriqueList.Clear();
            materialButton13.Enabled = false;

            nom = "";
            qteSaisi = 0;
            quantite = 0;
            prixSaisi = 0;
            prixVente = 0;
            Mont = 0;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView4.Rows[e.RowIndex].Cells[0].Value != null)
            {
                dataGridView4.Rows[e.RowIndex].Selected = true;
                materialButton13.Enabled = true;

                // Get the corresponding index from the idHistoriqueList
                IDH = idHistoriqueList[e.RowIndex];
            }
        }
        int IDH;
        private void materialButton13_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow.Selected == true)
            {
                if (dataGridView4.CurrentRow.Cells[0].Value != null)
                {
                    // Get the values of the selected row
                    string nomRetour = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                    decimal quantiteRetour = Convert.ToDecimal(dataGridView4.CurrentRow.Cells[1].Value.ToString());
                    decimal mont = Convert.ToDecimal(dataGridView4.CurrentRow.Cells[3].Value.ToString());

                    // Use the retrieved values as needed
                    // Update the 'Quantité' value in the 'stockV4' table for the selected 'Nom'
                    try
                    {
                        string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "SELECT Id FROM [dbo].[stockV4] WHERE Nom = @nom";

                            using (SqlCommand command1 = new SqlCommand(query, connection))
                            {
                                command1.Parameters.AddWithValue("@nom", nomRetour);

                                SqlDataReader reader = command1.ExecuteReader();

                                if (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    reader.Close(); // close the reader before executing the update query
                                    string updateQuery = "UPDATE stockV4 SET Quantité = Quantité + @QuantiteRetour WHERE Nom = @NomRetour AND id = @id";

                                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@NomRetour", nomRetour);
                                        command.Parameters.AddWithValue("@QuantiteRetour", quantiteRetour);
                                        command.Parameters.AddWithValue("@id", id);

                                        int rowsAffected = command.ExecuteNonQuery();

                                        dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                                    }
                                }
                                reader.Close();

                                //deliting row 
                                // Define SQL query to delete row with specific Id
                                string query2 = "DELETE FROM [dbo].[HistoriqueV1] WHERE Id = @id";

                                // Create command object with query and connection
                                using (SqlCommand command = new SqlCommand(query2, connection))
                                {
                                    // Add parameter for Id value
                                    command.Parameters.AddWithValue("@id", IDH); // Replace idValue with the actual Id value you want to delete

                                    // Execute command
                                    int rowsAffected = command.ExecuteNonQuery();

                                    dataGridView5.CurrentRow.Selected = false;

                                    idHistoriqueList.RemoveAll(x => x == IDH);
                                }
                            }
                            connection.Close();
                        }
                        LoadDB();

                        TP = TP - mont;
                        string formattedTP = TP.ToString("#,##0.00", new System.Globalization.CultureInfo("fr-FR"));
                        materialLabel13.Text = formattedTP.Replace(".", ",");

                    }
                    catch (Exception ex)
                    {
                        // Display error message
                        MessageBox.Show("Une Erreur est survenue lors du Retour du produit:\n" + ex.Message);
                    }

                    materialButton13.Enabled = false;
                }
                else
                {
                    // Show an error message if the 'Nom' value is null
                    MessageBox.Show("Veuillez choisir un Article à retourner au Stock.", "Erreur");
                }
            }
            else
            {
                // Show an error message or handle the case where no row is selected
                MessageBox.Show("Veuillez choisir un Article à retourner au Stock.", "Erreur");
            }
        }

        private void historiqueV1BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            materialTextBox4.Text = "";
            historiqueV1BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox4.Text + "%'");
        }

        private void materialTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(materialTextBox4.Text))
                {
                    historiqueV1BindingSource.Filter = string.Format("Nom LIKE '%" + materialTextBox4.Text + "%'");
                }
                else
                {
                    historiqueV1BindingSource.Filter = string.Empty;
                }
            }
        }

        string IdH;
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the currently selected row
            DataGridViewRow selectedRow = dataGridView5.CurrentRow;

            // Get the value of the second cell (index 1) in the selected row
            object nomObject = selectedRow.Cells[1].Value;
            string nom = nomObject != DBNull.Value ? nomObject.ToString() : null;

            // Check if the value of the second cell is not null
            if (nom != null)
            {
                // Get the value of the first cell in the selected row
                IdH = selectedRow.Cells[0].Value.ToString();

                // Set the current row selection to true and enable a button
                selectedRow.Selected = true;
                materialButton17.Enabled = true;
                materialButton16.Enabled = true;
            }
        }

        private void materialButton16_Click(object sender, EventArgs e)
        {
            // Check if the app is in trial mode
            bool isTrial = true;// your code to check if the app is in trial mode

            // If the app is in trial mode, display a message
            if (isTrial)
            {
                MessageBox.Show("Ce bouton n'est pas disponible dans la version d'essai de cette application.", "Information");
            }
            else
            {
                // your code to handle the button click event when the app is not in trial mode
                // Prompt the user for confirmation before deleting the row
                DialogResult result = MessageBox.Show("Êtes-vous Sûr de Vouloir Supprimer Cette Ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SqlConnection connection = null;
                    try
                    {
                        // Define connection string
                        string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;

                        // Define SQL query to delete row with specific Id
                        string query = "DELETE FROM [dbo].[HistoriqueV1] WHERE Id = @id";

                        // Create connection object
                        using (connection = new SqlConnection(connectionString))
                        {
                            // Create command object with query and connection
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Add parameter for Id value
                                command.Parameters.AddWithValue("@id", IdH); // Replace idValue with the actual Id value you want to delete

                                // Open connection
                                connection.Open();

                                // Execute command
                                int rowsAffected = command.ExecuteNonQuery();

                                LoadDB();

                                // Row was deleted successfully
                                MessageBox.Show(string.Format("La ligne sélectionnée a été supprimée avec succès."), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        MessageBox.Show("Une erreur s'est produite lors de la suppression de la ligne. Détails de l'erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Close connection
                        if (connection != null)
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        private void materialButton17_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow.Selected == true)
            {
                if (dataGridView5.CurrentRow.Cells[0].Value != null)
                {
                    // Get the values of the selected row
                    int idh = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value);
                    string nomRetour = dataGridView5.CurrentRow.Cells[1].Value.ToString();
                    decimal quantiteRetour = Convert.ToDecimal(dataGridView5.CurrentRow.Cells[2].Value.ToString());

                    // Use the retrieved values as needed
                    // Update the 'Quantité' value in the 'stockV4' table for the selected 'Nom'
                    try
                    {
                        string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "SELECT Id FROM [dbo].[stockV4] WHERE Nom = @nom";

                            using (SqlCommand command1 = new SqlCommand(query, connection))
                            {
                                command1.Parameters.AddWithValue("@nom", nomRetour);

                                SqlDataReader reader = command1.ExecuteReader();

                                if (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    reader.Close(); // close the reader before executing the update query
                                    string updateQuery = "UPDATE stockV4 SET Quantité = Quantité + @QuantiteRetour WHERE Nom = @NomRetour AND id = @id";

                                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@NomRetour", nomRetour);
                                        command.Parameters.AddWithValue("@QuantiteRetour", quantiteRetour);
                                        command.Parameters.AddWithValue("@id", id);

                                        int rowsAffected = command.ExecuteNonQuery();
                                    }
                                }
                                reader.Close();

                                //deliting row 
                                // Define SQL query to delete row with specific Id
                                string query2 = "DELETE FROM [dbo].[HistoriqueV1] WHERE Id = @id";

                                // Create command object with query and connection
                                using (SqlCommand command = new SqlCommand(query2, connection))
                                {
                                    // Add parameter for Id value
                                    command.Parameters.AddWithValue("@id", idh); // Replace idValue with the actual Id value you want to delete

                                    // Execute command
                                    int rowsAffected = command.ExecuteNonQuery();

                                    dataGridView5.CurrentRow.Selected = false;

                                    // Row was deleted successfully
                                    MessageBox.Show("L'article a été retourné aux stock.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                                LoadDB();
                            }
                            connection.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        // Display error message
                        MessageBox.Show("Une Erreur est survenue lors du Retour du produit:\n" + ex.Message);
                    }

                    materialButton17.Enabled = false;
                }
                else
                {
                    // Show an error message if the 'Nom' value is null
                    MessageBox.Show("Veuillez choisir un Article à retourner au Stock.", "Erreur");
                }
            }
            else
            {
                // Show an error message or handle the case where no row is selected
                MessageBox.Show("Veuillez choisir un Article à retourner au Stock.", "Erreur");
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        int tourD = 0;
        private void materialFloatingActionButton6_Click(object sender, EventArgs e)
        {
            if (tourD == 0)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                tourD = 1;
            }
            else if (tourD == 1)
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                tourD = 0;
            }

        }

        DateTime from;
        DateTime tod;
        decimal tp2 = 0;
        private void materialButton12_Click(object sender, EventArgs e)
        {
            tp2 = 0;
            materialLabel17.Text = "" + tp2;

            DateTime from = DateTime.ParseExact(dateTimePicker1.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime tod = DateTime.ParseExact(dateTimePicker2.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int leng = dataGridView5.Rows.Count - 1;

            for (int i = 0; i < leng; i++)
            {
                dataGridView5.Rows[i].Selected = true;

                String dateCompare = dataGridView5.Rows[i].Cells[5].Value.ToString();
                DateTime dc = DateTime.Parse(dateCompare);

                dataGridView5.Rows[i].Selected = false;

                if (from <= dc && tod >= dc)
                {

                    decimal price = Convert.ToDecimal(dataGridView5.Rows[i].Cells[3].Value);
                    decimal quantity = Convert.ToDecimal(dataGridView5.Rows[i].Cells[2].Value);

                    decimal montant = price * quantity;

                    tp2 = tp2 + montant;

                    string formattedTP = tp2.ToString("#,##0.00", new System.Globalization.CultureInfo("fr-FR"));
                    materialLabel17.Text = formattedTP.Replace(".", ",") + " Da";

                    montant = 0;

                }

            }
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            // Check if the app is in trial mode
            bool isTrial = true;// your code to check if the app is in trial mode

            // If the app is in trial mode, display a message
            if (isTrial)
            {
                MessageBox.Show("Ce bouton n'est pas disponible dans la version d'essai de cette application.", "Information");
            }
            else
            {
                // your code to handle the button click event when the app is not in trial mode
                // Prompt the user for confirmation before deleting the row
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer toutes les lignes de l'historique ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string sql = "DELETE FROM HistoriqueV1 WHERE Id >= 0";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Supprimé {rowsAffected} lignes de l'historique.", "Confirmation de suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LoadDB();
                        connection.Close();
                    }
                }
            }
        }

        private void dataGridView5_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int salesCount = 0;
            decimal profit = 0.00m;
            DateTime today = DateTime.Today;

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                if (row.Cells[5].Value != null && DateTime.Parse(row.Cells[5].Value.ToString()).Date == today)
                {
                    salesCount++;
                    profit += Convert.ToDecimal(row.Cells[4].Value);
                }
            }


            materialLabel9.Text = salesCount.ToString();

            string formattedTP = profit.ToString("#,##0.00", new System.Globalization.CultureInfo("fr-FR"));
            materialLabel21.Text = formattedTP.Replace(".", ",") + " Da";
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            // Show a message box to confirm that the user wants to exit the application
            DialogResult result = MessageBox.Show("Voulez-vous vraiment quitter l'application ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicked the "Yes" button, close the application
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        decimal prixSaisi;
        private void materialButton10_Click(object sender, EventArgs e)
        {
            //qte
            if (!string.IsNullOrEmpty(materialTextBox22.Text))
            {
                try
                {
                    //quantity
                    qteSaisi = decimal.Parse(materialTextBox22.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("La Quantité Saisie n'est pas Valide", "Erreur");
                }


                if (qteSaisi > quantite || qteSaisi == 0)
                {
                    MessageBox.Show("Quantité insuffisante", "Erreur");
                }
                else
                {
                    //prix
                    if (!string.IsNullOrEmpty(materialTextBox24.Text))
                    {
                        if (true/*c <= 10*/)
                        {
                            prixSaisi = decimal.Parse(materialTextBox24.Text);

                            Mont = (prixSaisi * qteSaisi);
                            TP = TP + (prixSaisi * qteSaisi);

                            decimal rest;

                            rest = quantite - qteSaisi;

                            string formattedTP = TP.ToString("#,##0.00", new System.Globalization.CultureInfo("fr-FR"));
                            materialLabel13.Text = formattedTP.Replace(".", ",");

                            dataGridView4.Rows.Add(nom, qteSaisi, prixSaisi, Mont);

                            //historique
                            try
                            {
                                string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    // check if the HistoriqueV1 table already contains 10 rows
                                    string countQuery = "SELECT COUNT(*) FROM HistoriqueV1";
                                    using (SqlCommand countCommand = new SqlCommand(countQuery, connection))
                                    {
                                        int count = (int)countCommand.ExecuteScalar();
                                        if (count >= 10)
                                        {
                                            // display a message indicating that the software is in demo mode
                                            MessageBox.Show("Votre logiciel est en mode démonstration. La version est limitée à 10 Ventes.", "Information");
                                            return;
                                        }
                                    }

                                    string insertQuery = "INSERT INTO HistoriqueV1 (Nom, Quantité, Prix, Date, Montant) VALUES (@Nom, @Quantite, @Prix, @Date, @Montant); SELECT CAST(scope_identity() AS int)";
                                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Nom", nom);
                                        command.Parameters.AddWithValue("@Quantite", qteSaisi);
                                        command.Parameters.AddWithValue("@Prix", prixSaisi);
                                        string dayString = Convert.ToDateTime(day).ToString("dd/MM/yyyy");
                                        command.Parameters.AddWithValue("@Date", dayString);
                                        command.Parameters.AddWithValue("@Montant", Mont);

                                        // Execute the insert command and get the ID of the inserted row
                                        int newId = (int)command.ExecuteScalar();

                                        // Check the 'newId' value to ensure that the insert was successful
                                        idHistoriqueList.Add(newId);
                                    }

                                    string updateQuery = "UPDATE stockV4 SET Quantité = @Quantite WHERE Id = @id";
                                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@Quantite", rest); // replace newQuantiteValue with the new quantity value you want to set
                                        command.Parameters.AddWithValue("@id", IdArticle); // replace IdArticle with the actual Id value you want to update

                                        int rowsAffected = command.ExecuteNonQuery();
                                        // Check the 'rowsAffected' value to ensure that the update was successful
                                    }

                                    connection.Close();
                                    LoadDB();
                                }
                            }
                            catch (Exception ex)
                            {
                                // Display error message
                                MessageBox.Show("Une Erreur est survenue lors de l'insertion des données dans l'historique:\n" + ex.Message);
                            }

                            dataGridView3.CurrentRow.Selected = false;
                            materialTextBox22.Text = "";
                            materialTextBox24.Text = "";

                            quantity = Convert.ToString(qteSaisi);
                            price = Convert.ToString(prixSaisi);
                            mon = Convert.ToString(Mont);

                            printList.Add(nom);
                            printList.Add(quantity);
                            printList.Add(price);
                            printList.Add(mon);

                            nom = "";
                            qteSaisi = 0;
                            quantite = 0;
                            prixSaisi = 0;
                            prixVente = 0;
                            Mont = 0;
                        }
                        else if (false/*c > 10*/)
                        {
                            MessageBox.Show("votre logiciel est en mode démonstration \n" +
                               "la version est limmité : \n" +
                               "- 10 Ventes \n", "Information");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez Entrer un Prix", "Erreur");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez Entrer une Quantité", "Erreur");
            }
        }

    }
}
