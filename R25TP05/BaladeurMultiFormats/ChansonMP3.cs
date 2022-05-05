using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        public override string Format { get { return "MP3"; } }

        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {

        }
        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {

        }

        public override void LireEntete()
        {
            StreamReader stream = new StreamReader(NomFichier);
            string[] Entete = stream.ReadLine().Trim().Split('|');

            m_artiste = Entete[0];
            m_annee = int.Parse(Entete[1]);
            m_titre = Entete[2];
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderMP3(pobjFichier.ReadToEnd());
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(Artiste + " | " + Annee.ToString() + " | " + Titre);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderMP3(pParoles));
        }
    }
}
