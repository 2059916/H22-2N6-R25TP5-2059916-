using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    class IChanson
    {
        public int Annee { get; }
        public string Artiste { get; }
        public string Format { get; }
        public string NomFichier { get; }
        public string Paroles { get; }
        public string Titre { get; }

        public void LireEntete()
        {

        }

        public void LireParoles(StreamReader pobjFichier)
        {

        }
        public void SauterEntete(StreamReader pobjFichier)
        {

        }
        public void EcrireEntete(StreamWriter pobjFichier)
        {

        }
        public void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {

        }
        public void Ecrire(string pParoles)
        {

        }
    }
}
