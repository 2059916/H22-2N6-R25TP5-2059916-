using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        private int m_codage;
        public override string Format { get { return "WMA"; } }

        public ChansonWMA(string pNomFichier) : base(pNomFichier)
        {

        }
        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée)
        {
            m_codage = 15;
        }

        public override void LireEntete()
        {
            StreamReader stream = new StreamReader(NomFichier);
            string[] Entete = stream.ReadLine().Split('/');

            m_codage = int.Parse(Entete[0]);
            m_annee = int.Parse(Entete[1]);
            m_titre = Entete[2].Trim();
            m_artiste = Entete[3].Trim();
            stream.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            return OutilsFormats.DecoderWMA(pobjFichier.ReadToEnd(),m_codage);
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(m_codage.ToString() + " / " + Annee.ToString() + " / " + Titre + " / " + Artiste);
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            m_paroles = pParoles;
            string parolesEncode = OutilsFormats.EncoderWMA(pParoles,m_codage);
            pobjFichier.WriteLine(parolesEncode);
        }
    }
}
