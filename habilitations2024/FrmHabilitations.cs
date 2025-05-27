using System;
using System.Collections.Generic;
using System.Windows.Forms;
using habilitations2024.Controleur; // Pour accéder au DeveloppeurController

namespace habilitations2024
{
    public partial class FrmHabilitations : Form
    {
        private readonly DeveloppeurController _controller = new DeveloppeurController();
        private List<Developpeur> developpeurs; // Liste en mémoire des développeurs affichés

        public FrmHabilitations()
        {
            InitializeComponent();

            ChargementComboBoxProfils();

            comboBoxProfils.SelectedIndexChanged += ComboBoxProfils_SelectedIndexChanged;
            dataGridViewDeveloppeurs.SelectionChanged += DataGridViewDeveloppeurs_SelectionChanged;

            // Sélectionne la ligne vide au démarrage
            comboBoxProfils.SelectedIndex = 0;
        }

        /// <summary>
        /// Charge le comboBox des profils avec une ligne vide en premier.
        /// </summary>
        private void ChargementComboBoxProfils()
        {
            comboBoxProfils.Items.Clear();
            comboBoxProfils.Items.Add(""); // Ligne vide pour "Tous les profils"

            List<string> profils = _controller.GetLesProfils();
            foreach (var profil in profils)
            {
                comboBoxProfils.Items.Add(profil);
            }
        }

        /// <summary>
        /// Événement déclenché lors du changement de sélection du comboBox des profils.
        /// Recharge la liste des développeurs selon le filtre.
        /// </summary>
        private void ComboBoxProfils_SelectedIndexChanged(object sender, EventArgs e)
        {
            string profilSelectionne = comboBoxProfils.SelectedItem?.ToString() ?? "";
            ChargerListeDeveloppeurs(profilSelectionne);
            ViderChamps();
        }

        /// <summary>
        /// Charge la DataGridView des développeurs selon le profil (vide = tous).
        /// </summary>
        /// <param name="profil">Profil filtré</param>
        private void ChargerListeDeveloppeurs(string profil)
        {
            developpeurs = _controller.GetLesDeveloppeurs(profil);
            dataGridViewDeveloppeurs.DataSource = null;
            dataGridViewDeveloppeurs.DataSource = developpeurs;

            // Masquer la colonne Id pour plus de lisibilité
            if (dataGridViewDeveloppeurs.Columns["Id"] != null)
                dataGridViewDeveloppeurs.Columns["Id"].Visible = false;
        }

        /// <summary>
        /// Vide les champs de saisie.
        /// </summary>
        private void ViderChamps()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtProfil.Text = "";
        }

        /// <summary>
        /// Quand on sélectionne un développeur dans le DataGridView,
        /// on affiche ses informations dans les champs de texte.
        /// </summary>
        private void DataGridViewDeveloppeurs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDeveloppeurs.SelectedRows.Count == 1)
            {
                var dev = (Developpeur)dataGridViewDeveloppeurs.SelectedRows[0].DataBoundItem;
                txtNom.Text = dev.Nom;
                txtPrenom.Text = dev.Prenom;
                txtProfil.Text = dev.Profil;
            }
            else
            {
                ViderChamps();
            }
        }

        /// <summary>
        /// Ajoute un nouveau développeur.
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                var nouveauDev = new Developpeur
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    Profil = txtProfil.Text.Trim()
                };

                if (string.IsNullOrEmpty(nouveauDev.Nom) ||
                    string.IsNullOrEmpty(nouveauDev.Prenom) ||
                    string.IsNullOrEmpty(nouveauDev.Profil))
                {
                    MessageBox.Show("Veuillez remplir tous les champs (Nom, Prénom, Profil).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _controller.AjouterDeveloppeur(nouveauDev);

                // Recharge la liste avec le filtre actif
                string profilSelectionne = comboBoxProfils.SelectedItem?.ToString() ?? "";
                ChargerListeDeveloppeurs(profilSelectionne);

                ViderChamps();
                MessageBox.Show("Développeur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mise à jour des profils dans le comboBox
                int index = comboBoxProfils.SelectedIndex;
                ChargementComboBoxProfils();
                comboBoxProfils.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Modifie le développeur sélectionné.
        /// </summary>
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
                dev.Profil = txtProfil.Text.Trim();

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

        /// <summary>
        /// Supprime le développeur sélectionné.
        /// </summary>
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
