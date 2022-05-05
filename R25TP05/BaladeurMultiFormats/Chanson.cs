using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        protected int m_annee;
        protected string m_artiste;
        protected string m_nomFichier;
        protected string m_titre;

        public int Annee { get { return m_annee; } }
        public string Artiste { get { return m_artiste; } }
        public string NomFichier { get { return m_nomFichier; } }
        public string Paroles { get; }
        public string Titre { get { return m_titre; } }
        public abstract string Format { get; }

        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
            StreamReader fichier = new StreamReader(pNomFichier);
            SauterEntete(fichier);
            Paroles = LireParoles(fichier);

        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnée;
            m_nomFichier = pRepertoire;
            StreamReader fichier = new StreamReader(m_nomFichier);
            SauterEntete(fichier);
            Paroles = LireParoles(fichier);
        }

        public abstract void LireEntete();
        public abstract string LireParoles(StreamReader pobjFichier);
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        public void Ecrire(string pParoles)
        {
            StreamWriter stream = new StreamWriter(NomFichier);

            EcrireEntete(stream);
            EcrireParoles(stream,pParoles);

            stream.Close();
        }


        
    }
}
