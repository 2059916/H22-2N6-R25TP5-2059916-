using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        private const string NOM_REPERTOIRE = "Chansons";
        private List<Chanson> m_colChansons = new List<Chanson>();
        public int NbChansons { get { return m_colChansons.Count; } }

        public Baladeur()
        {
            ConstruireLaListeDesChansons();
        }

        public void ConstruireLaListeDesChansons()
        {
            if (Directory.Exists(NOM_REPERTOIRE))
                foreach(string fichier in Directory.GetFiles(NOM_REPERTOIRE))
                {
                    Chanson chanson = null;
                    if (File.Exists(fichier))
                    {
                        if (fichier.EndsWith(".aac"))
                            chanson = new ChansonAAC(fichier);
                        else if (fichier.EndsWith(".mp3"))
                            chanson = new ChansonMP3(fichier);
                        else if (fichier.EndsWith(".wma"))
                            chanson = new ChansonWMA(fichier);
                    }
                    if (chanson != null)
                        m_colChansons.Add(chanson);
                }
        }

        public Chanson ChansonAt(int pIndex)
        {
            Chanson chanson = null;
            if (pIndex < NbChansons)
                chanson = m_colChansons[pIndex];
            return chanson;
        }

        public void ConvertirVersAAC(int pIndex)
        {
            Chanson chanson = ChansonAt(pIndex);
            if (chanson == null) return;
            string paroles = chanson.Paroles;
        }


    }
}
