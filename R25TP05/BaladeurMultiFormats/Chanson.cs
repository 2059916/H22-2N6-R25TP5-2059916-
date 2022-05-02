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

        public int Annee { get; set; }
        public string Artiste { get; set; }
        public string NomFichier { get; }
        public string Paroles { get; }
        public string Titre { get; set; }
        public abstract string Format { get; }

        public Chanson(string pNomFichier)
        {
            NomFichier = pNomFichier;
            LireEntete();
        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            Artiste = pArtiste;
            Titre = pTitre;
            Annee = pAnnée;
            NomFichier = pRepertoire;
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
