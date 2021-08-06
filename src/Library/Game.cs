using System.Collections.Generic;
using System;

namespace Tokaido
{
    /*
        Esta clase es la que se encarga de armar el camino.
        Es el experto en conocer quienes son los viajeros y cuales son las experiencias,
        tiene la responsabilidad de agregar experiencias y viajeros y tambien la de agregar vaijeros a los observadores.
        Usa Creator ya que tiene la responsabilidad de crear el final del juego, ya que como conoce las experiencias
        del juego sabe cual es la ultima y agrega una lista de ellas al final.
        Utiliza DIP, ya que no depende de cada tipo de viajero o de experiencia, sino que depende de las abstracciones de estas
        Cumple con LCHC ya que no depende de los subtipos de AbstractExperience y AbstractTraveler
        Cumple con OCP ya que puede no es necesario modificar el codigo para crear mas tipos de experiencias y viajeros
        
    */
    public class Game
    {

        private List<AbstractExperience> experiences = new List<AbstractExperience>();
        public List<AbstractExperience> Experiences{get{return experiences;}}
        private List<AbstractTraveler> travelers = new List<AbstractTraveler>();
        public List<AbstractTraveler> Travelers{get{return travelers;}}
        public Finish Final {get;set;}
        
       /// <summary>
       /// Crea la última Experiencia y la agrega a la lista de experiencias del juego.
       /// </summary>
        public void FinalPositionOfRoad()
        {
            int maxPosition = 0;
            foreach(AbstractExperience experience in Experiences)
            {
                if(experience.Position > maxPosition)
                {
                    maxPosition = experience.Position;
                }
            }
            maxPosition += 1;
            Final = Finish.Instance("Final del Camino",travelers.Count,maxPosition);
            AddExperience(Final);
        }

        /// <summary>
        /// Agrega a los observadores(Experiencias) en los Observables (Viajeros)
        /// </summary>
        public void LoadObservers()
        {
            foreach(AbstractTraveler traveler in Travelers)
            {
                foreach(AbstractExperience experience in Experiences)
                {
                    traveler.AddObserver(experience);
                }
            }
        }

        /// <summary>
        /// Agregar nuevas experiencias al juego
        /// </summary>
        /// <param name="experience"></param>
        public void AddExperience(AbstractExperience experience)
        {
            Experiences.Add(experience);
        }

        /// <summary>
        /// Agregar viajeros al juego, no pueden ser mas de 6
        /// </summary>
        /// <param name="traveler"></param>
        public void AddTravelers(AbstractTraveler traveler)
        {
            if(travelers.Count < 6)
            {
                Travelers.Add(traveler);
            }
        }

    }
}