using System;
using System.Windows.Forms;
using System.IO;


namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChasonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "(Matériel)";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }
        public Baladeur MonBaladeur;
        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            // À COMPLÉTER...
            MonBaladeur = new Baladeur();
            MonBaladeur.AfficherLesChansons(lsvChansons);
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
            MonBaladeur.AfficherLesChansons(lsvChansons);
            lblNbChansons.Text = MonBaladeur.NbChansons.ToString();
            MnuFormatConvertirVersAAC.Enabled = false;
            MnuFormatConvertirVersMP3.Enabled = false;
            MnuFormatConvertirVersWMA.Enabled = false;
            txtParoles.Text = "";
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            if (lsvChansons.SelectedItems.Count <= 0)
            {
                txtParoles.Text = "";
            }
            else
            {
                Chanson chanson = MonBaladeur.ChansonAt(lsvChansons.SelectedItems[0].Index);
                txtParoles.Text = chanson.Paroles;
                MnuFormatConvertirVersAAC.Enabled = !(chanson.Format == "AAC");
                MnuFormatConvertirVersMP3.Enabled = !(chanson.Format == "MP3");
                MnuFormatConvertirVersWMA.Enabled = !(chanson.Format == "WMA");

                Consultation consultation = new Consultation(DateTime.Now, chanson);
                MonHistorique.Add(consultation);
            }
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonBaladeur.ConvertirVersAAC(lsvChansons.SelectedItems[0].Index);
            MonHistorique.Clear();
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonBaladeur.ConvertirVersMP3(lsvChansons.SelectedItems[0].Index);
            MonHistorique.Clear();
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonBaladeur.ConvertirVersWMA(lsvChansons.SelectedItems[0].Index);
            MonHistorique.Clear();
            MettreAJourSelonContexte();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
         //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
