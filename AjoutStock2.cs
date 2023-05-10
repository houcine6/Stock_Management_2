using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MATDESQ2
{
    public partial class AjoutStock2 : MaterialForm
    {
        private MaterialForm1 _parentForm;
        private int _tourD;

        public AjoutStock2(MaterialForm1 parentForm, int tourD)
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
                MessageBox.Show("Le champ 'Nom Article' est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(materialTextBox22.Text))
            {
                MessageBox.Show("Le champ 'Quantité' est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(materialTextBox23.Text))
            {
                MessageBox.Show("Le champ 'Prix d'achat' est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(materialTextBox24.Text))
            {
                MessageBox.Show("Le champ 'Prix de Vente' est vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    // Get the values from the MaterialTextBox controls 
                    string nom = materialTextBox21.Text;
                    decimal quantite = decimal.Parse(materialTextBox22.Text);
                    decimal prixAchat = decimal.Parse(materialTextBox23.Text);
                    decimal prixVente = decimal.Parse(materialTextBox24.Text);

                    if (prixAchat > prixVente)
                    {
                        DialogResult result = MessageBox.Show("Attention: le 'Prix d'achat' est Supérieur au 'Prix de Vente'! Voulez-vous continuer quand même?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            // Cancel the operation
                            return;
                        }
                    }

                    //calculs Montant
                    decimal montant = quantite * prixVente;

                    // Create a SqlConnection object using the connection string
                    string connectionString = Properties.Settings.Default.DatabaseApplicationConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Open the connection, execute the command, and retrieve the new identity value
                        connection.Open();

                        // Check the count of rows in the table
                        SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM stockV4", connection);
                        int count = (int)countCommand.ExecuteScalar();

                        // Check if the count exceeds the limit of 10 rows
                        if (count >= 10)
                        {
                            MessageBox.Show("Votre logiciel est en mode démonstration. La version est limitée à 10 produits.", "Information");
                            return;
                        }

                        // Create a SqlCommand object to insert the data into the table
                        SqlCommand command = new SqlCommand("INSERT INTO stockV4 (Nom, Quantité, [Prix d'achat], [Prix de vente], Montant) VALUES (@Nom, @Quantité, @PrixAchat, @PrixVente, @Montant); SELECT SCOPE_IDENTITY();", connection);
                        command.Parameters.Add("@Nom", SqlDbType.NVarChar, 100).Value = nom;
                        command.Parameters.Add("@Quantité", SqlDbType.Decimal, 18, "Quantité").Value = quantite;
                        command.Parameters.Add("@PrixAchat", SqlDbType.Decimal, 18, "Prix d'achat").Value = prixAchat;
                        command.Parameters.Add("@PrixVente", SqlDbType.Decimal, 18, "Prix de vente").Value = prixVente;
                        command.Parameters.Add("@Montant", SqlDbType.Decimal, 18, "Montant").Value = montant;

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

        private void AjoutStock2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseApplicationDataSet.stockV4' table. You can move, or remove it, as needed.
            this.stockV4TableAdapter.Fill(this.databaseApplicationDataSet.stockV4);

            // Clear the MaterialTextBox controls
            materialTextBox21.Clear();
            materialTextBox22.Clear();
            materialTextBox23.Clear();
            materialTextBox24.Clear();
        }

        private void materialTextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != ',' && ch != ' ' && ch != 8)
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

        private void materialTextBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != ',' && ch != ' ' && ch != 8)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
