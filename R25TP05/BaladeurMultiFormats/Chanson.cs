using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    class Chanson : IChanson
    {
        private int m_annee;
        private string m_artiste;
        private string m_nomFichier;
        private string m_titre;

        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
        }

        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnee)
        {

        }

    }
}
