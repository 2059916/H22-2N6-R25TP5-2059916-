using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    abstract class Chanson : IChanson
    {
        private int m_annee;
        private string m_artiste;
        private string m_nomFichier;
        private string m_titre;

        public int Annee { get { return m_annee; } }
        public string Artiste { get { return m_artiste; } }
        public string NomFichier { get { return m_nomFichier; } }
        public string Paroles { get; }
        public string Titre { get { return m_titre; } }

        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnée;
        }

        public abstract void LireEntete();
        public abstract void LireParoles();
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        public void Ecrire(string pParoles)
        {
            StreamWriter stream = new StreamWriter(m_nomFichier);

            EcrireEntete(stream);
            EcrireParoles(stream,pParoles);

            stream.Close();
        }


        
    }
}
