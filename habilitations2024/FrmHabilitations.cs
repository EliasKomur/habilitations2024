using System;
using System.Collections.Generic;
using System.Windows.Forms;
using habilitations2024.Controleur;

namespace habilitations2024
{
    public partial class FrmHabilitations : Form
    {
        private readonly DeveloppeurController _controller = new DeveloppeurController();
        private List<Developpeur> developpeurs;

        public FrmHabilitations()
        {
            InitializeComponent();

            ChargementComboBoxProfils();
            ChargementComboBoxProfilSaisie();

            comboBoxProfils.SelectedIndexChanged += ComboBoxProfils_SelectedIndexChanged;
            dataGridViewDeveloppeurs.SelectionChanged += DataGridViewDeveloppeurs_SelectionChanged;

            comboBoxProfils.SelectedIndex = 0;
        }

        private void ChargementComboBoxProfils()
        {
            comboBoxProfils.Items.Clear();
            comboBoxProfils.Items.Add("");

            List<string> profils = _controller.GetLesProfils();
            foreach (var profil in profils)
            {
                comboBoxProfils.Items.Add(profil);
            }
        }

        private void ChargementComboBoxProfilSaisie()
        {
            comboBoxProfil.Items.Clear();

            List<string> profils = _controller.GetLesProfils();
            foreach (var profil in profils)
            {
                comboBoxProfil.Items.Add(profil);
            }
        }

        private void ComboBoxProfils_SelectedIndexChanged(object sender, EventArgs e)
        {
            string profilSelectionne = comboBoxProfils.SelectedItem?.ToString() ?? "";
            ChargerListeDeveloppeurs(profilSelectionne);
            ViderChamps();
        }

        private void ChargerListeDeveloppeurs(string profil)
        {
            developpeurs = _controller.GetLesDeveloppeurs(profil);
            dataGridViewDeveloppeurs.DataSource = null;
            dataGridViewDeveloppeurs.DataSource = developpeurs;

            if (dataGridViewDeveloppeurs.Columns["Id"] != null)
                dataGridViewDeveloppeurs.Columns["Id"].Visible = false;
        }

        private void ViderChamps()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            comboBoxProfil.SelectedIndex = -1;
        }

        private void DataGridViewDeveloppeurs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count == 1)
            {
                var dev = (Developpeur)dataGridViewDeveloppeurs.SelectedRows[0].DataBoundItem;
                txtNom.Text = dev.Nom;
                txtPrenom.Text = dev.Prenom;
                comboBoxProfil.SelectedItem = dev.Profil;
            }
            else
            {
                ViderChamps();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var nouveauDev = new Developpeur
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Profil = comboBoxProfil.SelectedItem?.ToString() ?? ""
                };

                if (string.IsNullOrEmpty(nouveauDev.Nom) ||
                    string.IsNullOrEmpty(nouveauDev.Prenom) ||
                    string.IsNullOrEmpty(nouveauDev.Profil))
                {
                    MessageBox.Show("Veuillez remplir tous les champs (Nom, Prénom, Profil).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _controller.AjouterDeveloppeur(nouveauDev);

                string profilSelectionne = comboBoxProfils.SelectedItem?.ToString() ?? "";
                ChargerListeDeveloppeurs(profilSelectionne);

                ViderChamps();
                MessageBox.Show("Développeur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int index = comboBoxProfils.SelectedIndex;
                ChargementComboBoxProfils();
                comboBoxProfils.SelectedIndex = index;

                ChargementComboBoxProfilSaisie();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count != 1)
            {
                MessageBox.Show("Veuillez sélectionner un développeur à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var dev = (Developpeur)dataGridViewDeveloppeurs.SelectedRows[0].DataBoundItem;
                dev.Nom = txtNom.Text.Trim();
                dev.Prenom = txtPrenom.Text.Trim();
                dev.Profil = comboBoxProfil.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrEmpty(dev.Nom) ||
                    string.IsNullOrEmpty(dev.Prenom) ||
                    string.IsNullOrEmpty(dev.Profil))
                {
                    MessageBox.Show("Veuillez remplir tous les champs (Nom, Prénom, Profil).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _controller.ModifierDeveloppeur(dev);

                string profilSelectionne = comboBoxProfils.SelectedItem?.ToString() ?? "";
                ChargerListeDeveloppeurs(profilSelectionne);

                MessageBox.Show("Développeur modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count != 1)
            {
                MessageBox.Show("Veuillez sélectionner un développeur à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmation = MessageBox.Show("Voulez-vous vraiment supprimer ce développeur ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    var dev = (Developpeur)dataGridViewDeveloppeurs.SelectedRows[0].DataBoundItem;
                    _controller.SupprimerDeveloppeur(dev.Id);

                    string profilSelectionne = comboBoxProfils.SelectedItem?.ToString() ?? "";
                    ChargerListeDeveloppeurs(profilSelectionne);

                    ViderChamps();
                    MessageBox.Show("Développeur supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
