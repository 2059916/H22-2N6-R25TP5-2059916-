using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaladeurMultiFormatsTests
{
    [TestClass]
    public class UnitTestHistoriqueTODOs
    {
        
        #region Tests de la méthode NbConsultationDepuisXSecondes
        // TODO Test E : HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest
        // Compléter la méthode pour tester le cas où la valeur du délai passé en paramètre est négative

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest()
        {
            // Arrange : Instancier un objet Historique
            // À compléter...
            Historique historique_test = new Historique();
            // Act : Appeler la méthode NbConsultationsDepuisXSecondes
            // À compléter...
            historique_test.NbConsultationsDepuisXSecondes(-1);

            // Assert : Vérifier si la méthode lève une exception IndexOutOfRangeException
            // À compléter...
            //[ExpectedException(typeof(IndexOutOfRangeException))]
        }


        // TODO Test F : HistoriqueTestNbConsultationDepuisXSecondesValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod()]
        public void HistoriqueTestNbConsultationDepuisXSecondesValideTest()
        {
            // Arrange : Instancier un objet Historique et y ajouter trois consultations d'une même chansonAAC
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // À compléter...
            Historique historique_test = new Historique();
            ChansonAAC chanson_Test = new ChansonAAC("Chansons\\Blame It On Me.aac");
            DateTime date = DateTime.Now;
            historique_test.Add(new Consultation(date.AddSeconds(-100),chanson_Test));
            historique_test.Add(new Consultation(date.AddSeconds(-150), chanson_Test));
            historique_test.Add(new Consultation(date.AddSeconds(-300), chanson_Test));


            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de chansons consultées depuis 200 secondes.
            // À compléter...
            int nb_Consultation = historique_test.NbConsultationsDepuisXSecondes(200);

            // Assert : Vérifier si la méthode retourne le bon nombre de consultations qui est 2 !
            // À compléter...
            Assert.AreEqual(2, nb_Consultation);


        }
        #endregion

        #region Tests de la méthode NbConsultationsPourUneChanson
        // TODO Test G : HistoriqueTestNbConsultationsPourUneChansonParamNullTest
        // Compléter la méthode pour tester le cas où la chanson passée en paramètre est à null
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HistoriqueTestNbConsultationsPourUneChansonParamNullTest()
        {
            // Arrange : Instancier un objet Historique
            // À compléter...
            Historique historique_Test = new Historique();

            // Act : Appeler la méthode NbConsultationsDepuisXSecondes en lui passant la valeur null
            // À compléter...
            historique_Test.NbConsultationsPourUneChanson(null);
           

            // Assert : Vérifier si la méthode lève une exception ArgumentNullException
            // À compléter...
        }

        // TODO Test H : HistoriqueTestNbConsultationsPourUneChansonValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod()]
        public void HistoriqueTestNbConsultationsPourUneChansonValideTest()
        {
            // Arrange : Instancier un objet Historique et un objet ChansonAAC
            // Ajouter quatre consultations de cette même chansonAAC dans l'objet Historique
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // La quatrième consultation depuis 350 secondes (DateTime.AddSeconds(-350))
            // À compléter...
            Historique historique_test = new Historique();
            ChansonAAC chanson_Test = new ChansonAAC("Chansons\\Blame It On Me.aac");
            DateTime date = DateTime.Now;
            historique_test.Add(new Consultation(date.AddSeconds(-100), chanson_Test));
            historique_test.Add(new Consultation(date.AddSeconds(-150), chanson_Test));
            historique_test.Add(new Consultation(date.AddSeconds(-300), chanson_Test));
            historique_test.Add(new Consultation(date.AddSeconds(-350), chanson_Test));


            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de fois que la chansonAAC a été consultée.
            // À compléter...
            int nb_Consultation = historique_test.NbConsultationsPourUneChanson(chanson_Test);

            // Assert : Vérifier si la méthode retourne la bon nombre de consultations qui est 4
            // À compléter...
            Assert.AreEqual(4, nb_Consultation);



        }


        #endregion
    }
}
