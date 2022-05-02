using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public interface IChanson
    {
        int Annee { get; }
        string Artiste { get; }
        string Format { get; }
        string NomFichier { get; }
        string Paroles { get; }
        string Titre { get; }

        void LireEntete();

        void LireParoles(StreamReader pobjFichier);
        void SauterEntete(StreamReader pobjFichier);

        void EcrireEntete(StreamWriter pobjFichier);
        void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        void Ecrire(string pParoles);
    }
}
