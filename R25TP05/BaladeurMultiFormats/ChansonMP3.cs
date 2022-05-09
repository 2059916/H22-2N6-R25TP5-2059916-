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
            string[] Entete = stream.ReadLine().Split('|');

            m_artiste = Entete[0].Trim();
            m_annee = int.Parse(Entete[1]);
            m_titre = Entete[2].Trim();
            stream.Close();
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
            m_paroles = pParoles;
            string parolesEncode = OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.WriteLine(parolesEncode);
        }
    }
}
