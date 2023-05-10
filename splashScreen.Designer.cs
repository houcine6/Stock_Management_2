
namespace MATDESQ2
{
    partial class splashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splashScreen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stockV4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databaseApplicationDataSet = new MATDESQ2.DatabaseApplicationDataSet();
            this.clientV1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.historiqueV1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientV1TableAdapter = new MATDESQ2.DatabaseApplicationDataSetTableAdapters.ClientV1TableAdapter();
            this.historiqueV1TableAdapter = new MATDESQ2.DatabaseApplicationDataSetTableAdapters.HistoriqueV1TableAdapter();
            this.stockV4TableAdapter = new MATDESQ2.DatabaseApplicationDataSetTableAdapters.stockV4TableAdapter();
            this.tableAdapterManager = new MATDESQ2.DatabaseApplicationDataSetTableAdapters.TableAdapterManager();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockV4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseApplicationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientV1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiqueV1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.materialProgressBar1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(800, 450);
            this.panel1.MinimumSize = new System.Drawing.Size(800, 450);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Roboto Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(27, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 58;
            this.label6.Text = "Chargement...";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(196, 421);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "V.2.0";
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.ForeColor = System.Drawing.Color.DarkRed;
            this.materialProgressBar1.Location = new System.Drawing.Point(30, 395);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(397, 5);
            this.materialProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.materialProgressBar1.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(90, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 29);
            this.label4.TabIndex = 55;
            this.label4.Text = "Gestion de Stock (Demo)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(148, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 29);
            this.label3.TabIndex = 54;
            this.label3.Text = "0554315620";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(148, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 29);
            this.label2.TabIndex = 53;
            this.label2.Text = "0663822138";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(81, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 29);
            this.label1.TabIndex = 52;
            this.label1.Text = "Développé par Houcine Hs";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(556, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 146);
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // stockV4BindingSource
            // 
            this.stockV4BindingSource.DataMember = "stockV4";
            this.stockV4BindingSource.DataSource = this.databaseApplicationDataSet;
            // 
            // databaseApplicationDataSet
            // 
            this.databaseApplicationDataSet.DataSetName = "DatabaseApplicationDataSet";
            this.databaseApplicationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientV1BindingSource
            // 
            this.clientV1BindingSource.DataMember = "ClientV1";
            this.clientV1BindingSource.DataSource = this.databaseApplicationDataSet;
            // 
            // historiqueV1BindingSource
            // 
            this.historiqueV1BindingSource.DataMember = "HistoriqueV1";
            this.historiqueV1BindingSource.DataSource = this.databaseApplicationDataSet;
            // 
            // clientV1TableAdapter
            // 
            this.clientV1TableAdapter.ClearBeforeFill = true;
            // 
            // historiqueV1TableAdapter
            // 
            this.historiqueV1TableAdapter.ClearBeforeFill = true;
            // 
            // stockV4TableAdapter
            // 
            this.stockV4TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ClientV1TableAdapter = this.clientV1TableAdapter;
            this.tableAdapterManager.HistoriqueV1TableAdapter = this.historiqueV1TableAdapter;
            this.tableAdapterManager.stockV4TableAdapter = null;
            this.tableAdapterManager.UpdateOrder = MATDESQ2.DatabaseApplicationDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // splashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "splashScreen";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splashScreen";
            this.Load += new System.EventHandler(this.splashScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockV4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseApplicationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientV1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historiqueV1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource stockV4BindingSource;
        private DatabaseApplicationDataSet databaseApplicationDataSet;
        private System.Windows.Forms.BindingSource clientV1BindingSource;
        private System.Windows.Forms.BindingSource historiqueV1BindingSource;
        private DatabaseApplicationDataSetTableAdapters.ClientV1TableAdapter clientV1TableAdapter;
        private DatabaseApplicationDataSetTableAdapters.HistoriqueV1TableAdapter historiqueV1TableAdapter;
        private DatabaseApplicationDataSetTableAdapters.stockV4TableAdapter stockV4TableAdapter;
        private DatabaseApplicationDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}