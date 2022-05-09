using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        public override string Format { get { return "AAC"; } }

        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {

        }
        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire,pArtiste,pTitre,pAnnée)
        {

        }

        public override void LireEntete()
        {
            StreamReader stream = new StreamReader(NomFichier);
            string[] Entete = stream.ReadLine().Split(':');

            m_titre = Entete[0].Split('=')[1].Trim();
            m_artiste = Entete[1].Split('=')[1].Trim();
            m_annee = int.Parse(Entete[2].Split('=')[1]);
            stream.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderAAC(pobjFichier.ReadToEnd());
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine("TITRE = " + Titre + " : ARTISTE = " + Artiste + " : ANNÉE  = " + Annee.ToString());
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            m_paroles = pParoles;
            string parolesEncode = OutilsFormats.EncoderAAC(pParoles);
            pobjFichier.WriteLine(parolesEncode);
        }
    }
}
