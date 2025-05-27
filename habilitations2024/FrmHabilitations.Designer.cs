namespace habilitations2024
{
    partial class FrmHabilitations
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxProfils;    // La première ComboBox (probablement pour filtrer les profils)
        private System.Windows.Forms.ComboBox comboBoxProfil;     // La deuxième ComboBox (pour sélectionner un profil précis dans le formulaire)
        private System.Windows.Forms.DataGridView dataGridViewDeveloppeurs;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblProfil;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxProfils = new System.Windows.Forms.ComboBox();
            this.comboBoxProfil = new System.Windows.Forms.ComboBox();
            this.dataGridViewDeveloppeurs = new System.Windows.Forms.DataGridView();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblProfil = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeveloppeurs)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxProfils
            // 
            this.comboBoxProfils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProfils.FormattingEnabled = true;
            this.comboBoxProfils.Location = new System.Drawing.Point(12, 12);
            this.comboBoxProfils.Name = "comboBoxProfils";
            this.comboBoxProfils.Size = new System.Drawing.Size(200, 24);
            this.comboBoxProfils.TabIndex = 0;
            // 
            // dataGridViewDeveloppeurs
            // 
            this.dataGridViewDeveloppeurs.AllowUserToAddRows = false;
            this.dataGridViewDeveloppeurs.AllowUserToDeleteRows = false;
            this.dataGridViewDeveloppeurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDeveloppeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeveloppeurs.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewDeveloppeurs.MultiSelect = false;
            this.dataGridViewDeveloppeurs.Name = "dataGridViewDeveloppeurs";
            this.dataGridViewDeveloppeurs.ReadOnly = true;
            this.dataGridViewDeveloppeurs.RowHeadersWidth = 51;
            this.dataGridViewDeveloppeurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDeveloppeurs.Size = new System.Drawing.Size(500, 200);
            this.dataGridViewDeveloppeurs.TabIndex = 1;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(580, 42);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(150, 22);
            this.txtNom.TabIndex = 3;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(530, 45);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(36, 16);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(580, 75);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(150, 22);
            this.txtPrenom.TabIndex = 5;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(530, 78);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(54, 16);
            this.lblPrenom.TabIndex = 4;
            this.lblPrenom.Text = "Prénom";
            // 
            // lblProfil
            // 
            this.lblProfil.AutoSize = true;
            this.lblProfil.Location = new System.Drawing.Point(530, 110);
            this.lblProfil.Name = "lblProfil";
            this.lblProfil.Size = new System.Drawing.Size(37, 16);
            this.lblProfil.TabIndex = 6;
            this.lblProfil.Text = "Profil";
            // 
            // comboBoxProfil
            // 
            this.comboBoxProfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProfil.FormattingEnabled = true;
            this.comboBoxProfil.Location = new System.Drawing.Point(580, 107);
            this.comboBoxProfil.Name = "comboBoxProfil";
            this.comboBoxProfil.Size = new System.Drawing.Size(200, 24);
            this.comboBoxProfil.TabIndex = 7;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(533, 195);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(75, 25);
            this.btnAjouter.TabIndex = 8;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(614, 195);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 25);
            this.btnModifier.TabIndex = 9;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(695, 195);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(75, 25);
            this.btnSupprimer.TabIndex = 10;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // FrmHabilitations
            // 
            this.ClientSize = new System.Drawing.Size(800, 270);
            this.Controls.Add(this.comboBoxProfil);
            this.Controls.Add(this.comboBoxProfils);
            this.Controls.Add(this.dataGridViewDeveloppeurs);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblProfil);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Name = "FrmHabilitations";
            this.Text = "Gestion des habilitations";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeveloppeurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
