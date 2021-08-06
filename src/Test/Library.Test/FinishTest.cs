using NUnit.Framework;
using Tokaido;
using System.Collections.Generic;
namespace Tokaido.Test
{
    public class FinishTest
    {
        Game game1;
        Game game2;

        TravelerOne oneTraveler;
        TravelerOne twoTraveler;

        Mountain mountain;
        Ocean ocean;
        Farm farm;
        ThermalWater thermal;
        

        [SetUp]
        public void SetUp()
        {
            game1 = new Game();
            game2 = new Game();
            mountain = new Mountain("Aconcagua",2,1);
            ocean = new Ocean("Antártico",3,2);
            farm = new Farm("Granja1",2,1,2);
            thermal = new ThermalWater("Salto Grande",2,1,3);
            oneTraveler = new TravelerOne("Pedro");
            twoTraveler = new TravelerOne("Maria");

            game1.AddExperience(mountain);
            game1.AddExperience(ocean);
            game1.AddExperience(farm);
            game1.AddExperience(thermal);
            game1.AddTravelers(oneTraveler);
            game1.AddTravelers(twoTraveler);
            game1.FinalPositionOfRoad();
            game1.LoadObservers();

        }

        /// <summary>
        /// Compueba que solo puede existir una instancia de Finish.
        /// </summary>
        [Test]
        public void TestOnlyOneFinish()
        {
            
            Finish finish = Finish.Instance("final",1,2);
            Finish finishTwo = Finish.Instance("OTHER",5,6);

            Assert.AreEqual(finish,finishTwo);
        }
        
        /// <summary>
        /// Comprueba el ganador.
        /// </summary>
        [Test]
        public void TestWinner()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(2);
            oneTraveler.MoveTraveler(3);
            oneTraveler.MoveTraveler(4);
            oneTraveler.MoveTraveler(5);

            twoTraveler.MoveTraveler(1);
            twoTraveler.MoveTraveler(3);
            twoTraveler.MoveTraveler(5);
            AbstractTraveler winner = game1.Final.Winners[0];

            Assert.AreEqual(oneTraveler.Name, winner.Name);
            Assert.AreEqual(oneTraveler.Score,oneTraveler.Score);
            Assert.AreEqual(oneTraveler.Position,winner.Position);
                   
        }

        /// <summary>
        /// Comprueba que puede haber más de un ganador.
        /// </summary>
        [Test]
        public void TestMoreThanOneWinner()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(3);
            oneTraveler.MoveTraveler(5);

            twoTraveler.MoveTraveler(1);
            twoTraveler.MoveTraveler(3);
            twoTraveler.MoveTraveler(5);
            List<AbstractTraveler> winners = new List<AbstractTraveler>();
            winners.Add(oneTraveler);
            winners.Add(twoTraveler);

            List<AbstractTraveler> listWinners = game1.Final.Winners;

            Assert.AreEqual(winners,listWinners);  
        }
    }
}