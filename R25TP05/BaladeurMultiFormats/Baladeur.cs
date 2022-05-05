using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        private const string NOM_REPERTOIRE = "Chansons";
        private List<Chanson> m_colChansons = new List<Chanson>();
        public int NbChansons { get { return m_colChansons.Count; } }

        public Baladeur()
        {
            ConstruireLaListeDesChansons();
        }

        public void ConstruireLaListeDesChansons()
        {
            if (Directory.Exists(NOM_REPERTOIRE))
                foreach (string fichier in Directory.GetFiles(NOM_REPERTOIRE))
                {
                    Chanson chanson = null;
                    if (File.Exists(fichier))
                    {
                        if (fichier.EndsWith(".aac"))
                            chanson = new ChansonAAC(fichier);
                        else if (fichier.EndsWith(".mp3"))
                            chanson = new ChansonMP3(fichier);
                        else if (fichier.EndsWith(".wma"))
                            chanson = new ChansonWMA(fichier);
                    }
                    if (chanson != null)
                        m_colChansons.Add(chanson);
                }
        }

        public void AfficherLesChansons(ListView pListView)
        {
            foreach(Chanson chanson in m_colChansons)
            {
                ListViewItem chansonView = new ListViewItem(chanson.Artiste);
                chansonView.SubItems.Add(chanson.Titre);
                chansonView.SubItems.Add(chanson.Annee.ToString());
                chansonView.SubItems.Add(chanson.Format);
                
                pListView.Items.Add(chansonView);
            }
        }

        public Chanson ChansonAt(int pIndex)
        {
            Chanson chanson = null;
            if (pIndex < NbChansons)
                chanson = m_colChansons[pIndex];
            return chanson;
        }

        public void ConvertirVersAAC(int pIndex)
        {
            Chanson chanson = ChansonAt(pIndex);
            if (chanson == null) return;
            string artiste = chanson.Artiste;
            string titre = chanson.Titre;
            int annee = chanson.Annee;
            string paroles = chanson.Paroles;

            ChansonAAC chansonAAC = new ChansonAAC("Chansons",artiste,titre,annee);
            m_colChansons.Add(chansonAAC);

            File.Delete(NOM_REPERTOIRE + "\\" + chanson.NomFichier);

            StreamWriter stream = new StreamWriter(NOM_REPERTOIRE + "\\" + titre + "." + chansonAAC.Format.ToLower());
            chansonAAC.EcrireEntete(stream);
            chansonAAC.EcrireParoles(stream,paroles);
            stream.Close();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            Chanson chanson = ChansonAt(pIndex);
            if (chanson == null) return;
            string artiste = chanson.Artiste;
            string titre = chanson.Titre;
            int annee = chanson.Annee;
            string paroles = chanson.Paroles;

            ChansonMP3 chansonMP3 = new ChansonMP3("Chansons", artiste, titre, annee);
            m_colChansons.Add(chansonMP3);

            File.Delete(NOM_REPERTOIRE + "\\" + chanson.NomFichier);

            StreamWriter stream = new StreamWriter(NOM_REPERTOIRE + "\\" + titre + "." + chansonMP3.Format.ToLower());
            chansonMP3.EcrireEntete(stream);
            chansonMP3.EcrireParoles(stream, paroles);
            stream.Close();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            Chanson chanson = ChansonAt(pIndex);
            if (chanson == null) return;
            string artiste = chanson.Artiste;
            string titre = chanson.Titre;
            int annee = chanson.Annee;
            string paroles = chanson.Paroles;

            ChansonWMA chansonWMA = new ChansonWMA("Chansons", artiste, titre, annee);
            m_colChansons.Add(chansonWMA);

            File.Delete(NOM_REPERTOIRE + "\\" + chanson.NomFichier);

            StreamWriter stream = new StreamWriter(NOM_REPERTOIRE + "\\" + titre + "." + chansonWMA.Format.ToLower());
            chansonWMA.EcrireEntete(stream);
            chansonWMA.EcrireParoles(stream, paroles);
            stream.Close();
        }

    }
}
