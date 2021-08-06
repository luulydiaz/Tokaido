using NUnit.Framework;
using Tokaido;
namespace Tokaido.Test
{
    public class MountainTest
    {

        TravelerOne oneTraveler;
        TravelerOne twoTraveler;
        Game game;
        Mountain mountain1;
        Mountain mountain2;
        Mountain mountain3;

        [SetUp]
        public void Setup()
        {
            oneTraveler = new TravelerOne("Pedro");
            twoTraveler = new TravelerOne("Maria");
            
            mountain1 = new Mountain("Aconcagua",2,1);
            mountain2 = new Mountain("Yerupajá",1,2);
            mountain3 = new Mountain("Huascarán",3,3);

            game = new Game();
            game.AddTravelers(oneTraveler);
            game.AddTravelers(twoTraveler);
            game.AddExperience(mountain1);
            game.AddExperience(mountain2);
            game.AddExperience(mountain3);
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
            
            Assert.AreEqual(oneTraveler.Score, 1);
            Assert.AreEqual(twoTraveler.Score, 1);
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
            bool expected = mountain3.Travelers.Contains(oneTraveler);

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
            bool expected = mountain2.Travelers.Contains(oneTraveler);
            bool expected2 = mountain1.Travelers.Contains(oneTraveler);

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
            bool expected = mountain1.Travelers.Contains(oneTraveler);
            oneTraveler.MoveTraveler(2);
            bool expected2 = mountain1.Travelers.Contains(oneTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }   

        /// <summary>
        /// Comprueba que si el Agua Termal está llena no puede ingresar otro Viajero.
        /// </summary>
        [Test]
        public void TestFullExperience()
        {
            oneTraveler.MoveTraveler(2);
            twoTraveler.MoveTraveler(2);
            bool expected = mountain2.Travelers.Contains(oneTraveler);
            bool expected2 = mountain2.Travelers.Contains(twoTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }
    }
}
