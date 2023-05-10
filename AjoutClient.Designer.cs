
namespace MATDESQ2
{
    partial class AjoutClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjoutClient));
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox24 = new MaterialSkin.Controls.MaterialTextBox2();
            this.clientV1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseApplicationDataSet = new MATDESQ2.DatabaseApplicationDataSet();
            this.materialTextBox23 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox22 = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.clientV1TableAdapter = new MATDESQ2.DatabaseApplicationDataSetTableAdapters.ClientV1TableAdapter();
            this.tableAdapterManager = new MATDESQ2.DatabaseApplicationDataSetTableAdapters.TableAdapterManager();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.clientV1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseApplicationDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton2.Icon")));
            this.materialButton2.Location = new System.Drawing.Point(57, 429);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(152, 36);
            this.materialButton2.TabIndex = 34;
            this.materialButton2.Text = "Effacer tout";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton1.Icon")));
            this.materialButton1.Location = new System.Drawing.Point(434, 429);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(115, 36);
            this.materialButton1.TabIndex = 33;
            this.materialButton1.Text = "Annuler";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton3.Icon")));
            this.materialButton3.Location = new System.Drawing.Point(641, 429);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(145, 36);
            this.materialButton3.TabIndex = 32;
            this.materialButton3.Text = "Enregistrer";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // materialTextBox24
            // 
            this.materialTextBox24.AnimateReadOnly = false;
            this.materialTextBox24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox24.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox24.Depth = 0;
            this.materialTextBox24.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox24.HideSelection = true;
            this.materialTextBox24.Hint = "Crédit";
            this.materialTextBox24.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("materialTextBox24.LeadingIcon")));
            this.materialTextBox24.Location = new System.Drawing.Point(497, 220);
            this.materialTextBox24.MaxLength = 32767;
            this.materialTextBox24.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox24.Name = "materialTextBox24";
            this.materialTextBox24.PasswordChar = '\0';
            this.materialTextBox24.PrefixSuffixText = null;
            this.materialTextBox24.ReadOnly = false;
            this.materialTextBox24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox24.SelectedText = "";
            this.materialTextBox24.SelectionLength = 0;
            this.materialTextBox24.SelectionStart = 0;
            this.materialTextBox24.ShortcutsEnabled = true;
            this.materialTextBox24.Size = new System.Drawing.Size(340, 48);
            this.materialTextBox24.TabIndex = 31;
            this.materialTextBox24.TabStop = false;
            this.materialTextBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox24.TrailingIcon = null;
            this.materialTextBox24.UseSystemPasswordChar = false;
            this.materialTextBox24.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialTextBox24_KeyPress);
            // 
            // clientV1BindingSource
            // 
            this.clientV1BindingSource.DataMember = "ClientV1";
            this.clientV1BindingSource.DataSource = this.databaseApplicationDataSet;
            // 
            // databaseApplicationDataSet
            // 
            this.databaseApplicationDataSet.DataSetName = "DatabaseApplicationDataSet";
            this.databaseApplicationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // materialTextBox23
            // 
            this.materialTextBox23.AnimateReadOnly = false;
            this.materialTextBox23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox23.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox23.Depth = 0;
            this.materialTextBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox23.HideSelection = true;
            this.materialTextBox23.Hint = "Adresse";
            this.materialTextBox23.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("materialTextBox23.LeadingIcon")));
            this.materialTextBox23.Location = new System.Drawing.Point(497, 113);
            this.materialTextBox23.MaxLength = 32767;
            this.materialTextBox23.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox23.Name = "materialTextBox23";
            this.materialTextBox23.PasswordChar = '\0';
            this.materialTextBox23.PrefixSuffixText = null;
            this.materialTextBox23.ReadOnly = false;
            this.materialTextBox23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox23.SelectedText = "";
            this.materialTextBox23.SelectionLength = 0;
            this.materialTextBox23.SelectionStart = 0;
            this.materialTextBox23.ShortcutsEnabled = true;
            this.materialTextBox23.Size = new System.Drawing.Size(340, 48);
            this.materialTextBox23.TabIndex = 30;
            this.materialTextBox23.TabStop = false;
            this.materialTextBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox23.TrailingIcon = null;
            this.materialTextBox23.UseSystemPasswordChar = false;
            // 
            // materialTextBox22
            // 
            this.materialTextBox22.AnimateReadOnly = false;
            this.materialTextBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox22.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox22.Depth = 0;
            this.materialTextBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox22.HideSelection = true;
            this.materialTextBox22.Hint = "Téléphone";
            this.materialTextBox22.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("materialTextBox22.LeadingIcon")));
            this.materialTextBox22.Location = new System.Drawing.Point(36, 220);
            this.materialTextBox22.MaxLength = 32767;
            this.materialTextBox22.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox22.Name = "materialTextBox22";
            this.materialTextBox22.PasswordChar = '\0';
            this.materialTextBox22.PrefixSuffixText = null;
            this.materialTextBox22.ReadOnly = false;
            this.materialTextBox22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox22.SelectedText = "";
            this.materialTextBox22.SelectionLength = 0;
            this.materialTextBox22.SelectionStart = 0;
            this.materialTextBox22.ShortcutsEnabled = true;
            this.materialTextBox22.Size = new System.Drawing.Size(340, 48);
            this.materialTextBox22.TabIndex = 29;
            this.materialTextBox22.TabStop = false;
            this.materialTextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox22.TrailingIcon = null;
            this.materialTextBox22.UseSystemPasswordChar = false;
            this.materialTextBox22.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.materialTextBox22_KeyPress);
            // 
            // materialTextBox21
            // 
            this.materialTextBox21.AnimateReadOnly = false;
            this.materialTextBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox21.Depth = 0;
            this.materialTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox21.HideSelection = true;
            this.materialTextBox21.Hint = "Nom & Prenom";
            this.materialTextBox21.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("materialTextBox21.LeadingIcon")));
            this.materialTextBox21.Location = new System.Drawing.Point(36, 113);
            this.materialTextBox21.MaxLength = 32767;
            this.materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox21.Name = "materialTextBox21";
            this.materialTextBox21.PasswordChar = '\0';
            this.materialTextBox21.PrefixSuffixText = null;
            this.materialTextBox21.ReadOnly = false;
            this.materialTextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox21.SelectedText = "";
            this.materialTextBox21.SelectionLength = 0;
            this.materialTextBox21.SelectionStart = 0;
            this.materialTextBox21.ShortcutsEnabled = true;
            this.materialTextBox21.Size = new System.Drawing.Size(340, 48);
            this.materialTextBox21.TabIndex = 28;
            this.materialTextBox21.TabStop = false;
            this.materialTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox21.TrailingIcon = null;
            this.materialTextBox21.UseSystemPasswordChar = false;
            // 
            // clientV1TableAdapter
            // 
            this.clientV1TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClientV1TableAdapter = this.clientV1TableAdapter;
            this.tableAdapterManager.HistoriqueV1TableAdapter = null;
            this.tableAdapterManager.stockV4TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = MATDESQ2.DatabaseApplicationDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Gray;
            this.dateTimePicker1.Font = new System.Drawing.Font("Roboto Condensed", 9F);
            this.dateTimePicker1.Location = new System.Drawing.Point(497, 323);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(289, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(340, 50);
            this.dateTimePicker1.TabIndex = 35;
            this.dateTimePicker1.Value = new System.DateTime(2023, 3, 14, 18, 39, 7, 0);
            // 
            // AjoutClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(889, 526);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.materialTextBox24);
            this.Controls.Add(this.materialTextBox23);
            this.Controls.Add(this.materialTextBox22);
            this.Controls.Add(this.materialTextBox21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(889, 482);
            this.Name = "AjoutClient";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nouveau Client";
            this.Load += new System.EventHandler(this.AjoutClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientV1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseApplicationDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox24;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox23;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox22;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private DatabaseApplicationDataSet databaseApplicationDataSet;
        private System.Windows.Forms.BindingSource clientV1BindingSource;
        private DatabaseApplicationDataSetTableAdapters.ClientV1TableAdapter clientV1TableAdapter;
        private DatabaseApplicationDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}