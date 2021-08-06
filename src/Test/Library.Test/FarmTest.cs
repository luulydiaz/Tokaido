using NUnit.Framework;
using Tokaido;
namespace Tokaido.Test
{
    public class FarmTest
    {
        Farm farm1;
        Farm farm2;
        Farm farm3;

        TravelerOne oneTraveler;
        TravelerOne twoTraveler;

        Game game;
        
        [SetUp]
        public void Setup()
        {
            farm1 = new Farm("Granja1",2,1,2);
            farm2 = new Farm("Granja2",3,2,1);
            farm3 = new Farm("Granja3",1,3,3);
            oneTraveler = new TravelerOne("Pedro");
            twoTraveler = new TravelerOne("Maria");
            game = new Game();
            game.AddTravelers(oneTraveler);
            game.AddTravelers(twoTraveler);
            game.AddExperience(farm1);
            game.AddExperience(farm2);
            game.AddExperience(farm3);
            game.LoadObservers();
        }

        /// <summary>
        /// Comprueba la puntuacion.
        /// </summary>
        [Test]
        public void TestGivePoints()
        {
            oneTraveler.MoveTraveler(1);
            twoTraveler.MoveTraveler(1);
            
            Assert.AreEqual(oneTraveler.Score, 2);
            Assert.AreEqual(twoTraveler.Score, 2);
        }

        /// <summary>
        /// Comprueba la puntuacion cuando un viajero pasa por varias Aguas Termales.
        /// </summary>
        [Test]
        public void TestGivePointsTwo()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(2);
            oneTraveler.MoveTraveler(3);

            Assert.AreEqual(oneTraveler.Score, 6);
        }

        /// <summary>
        ///  Comprueba que un viajero puede ingresar a cualquier Agua Termal que este despues.
        /// </summary>        
        [Test]
        public void TestNewExperience()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(3);
            bool expected = farm3.Travelers.Contains(oneTraveler);

            Assert.AreEqual(true,expected);
        }

        /// <summary>
        /// Comprueba que un viajero no puede ingresar a un Agua Termal que este antes.
        /// </summary>
        [Test]
        public void TestPreviousExperience()
        {
            oneTraveler.MoveTraveler(2);
            oneTraveler.MoveTraveler(1);
            bool expected = farm2.Travelers.Contains(oneTraveler);
            bool expected2 = farm1.Travelers.Contains(oneTraveler);

            Assert.AreEqual(expected,true);
            Assert.AreEqual(expected2,false);
        }

        /// <summary>
        /// Comprueba que cuando viajero se mueve a otra Agua Termal, es eliminado de la que se encontraba 
        /// </summary>
        [Test]
        public void TestRemoveTraveler()
        {
            oneTraveler.MoveTraveler(1);
            bool expected = farm1.Travelers.Contains(oneTraveler);
            oneTraveler.MoveTraveler(2);
            bool expected2 = farm1.Travelers.Contains(oneTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }   

        /// <summary>
        /// Comprueba que si el Agua Termal está llena no puede ingresar otro Viajero.
        /// </summary>
        [Test]
        public void TestFullExperience()
        {
            oneTraveler.MoveTraveler(3);
            twoTraveler.MoveTraveler(3);
            bool expected = farm3.Travelers.Contains(oneTraveler);
            bool expected2 = farm3.Travelers.Contains(twoTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }
    }
}
