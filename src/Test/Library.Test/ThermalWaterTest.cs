using NUnit.Framework;
using Tokaido;
namespace Tokaido.Test
{
    public class ThermalWaterTest
    {
        ThermalWater thermal1;
        ThermalWater thermal2;
        ThermalWater thermal3;

        TravelerOne oneTraveler;
        TravelerOne twoTraveler;

        Game game;
        

        [SetUp]
        public void Setup()
        {
            thermal1 = new ThermalWater("Salto Grande",2,1,3);
            thermal2 = new ThermalWater("Almirón",2,2,2);
            thermal3 = new ThermalWater("Daymán",1,3,3);
            oneTraveler = new TravelerOne("Pedro");
            twoTraveler = new TravelerOne("Maria");
            game = new Game();
            game.AddTravelers(oneTraveler);
            game.AddTravelers(twoTraveler);
            game.AddExperience(thermal1);
            game.AddExperience(thermal2);
            game.AddExperience(thermal3);
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
            
            Assert.AreEqual(oneTraveler.Score, 3);
            Assert.AreEqual(twoTraveler.Score, 3);
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

            Assert.AreEqual(oneTraveler.Score, 8);
        }

        /// <summary>
        ///  Comprueba que un viajero puede ingresar a cualquier Agua Termal que este despues.
        /// </summary>        
        [Test]
        public void TestNewExperience()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(3);
            bool expected = thermal3.Travelers.Contains(oneTraveler);

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
            bool expected = thermal2.Travelers.Contains(oneTraveler);
            bool expected2 = thermal1.Travelers.Contains(oneTraveler);

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
            bool expected = thermal1.Travelers.Contains(oneTraveler);
            oneTraveler.MoveTraveler(2);
            bool expected2 = thermal1.Travelers.Contains(oneTraveler);

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
            bool expected = thermal3.Travelers.Contains(oneTraveler);
            bool expected2 = thermal3.Travelers.Contains(twoTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }
    }
}