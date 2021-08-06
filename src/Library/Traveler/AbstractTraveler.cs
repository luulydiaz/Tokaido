using System;
using System.Collections.Generic;

namespace Tokaido
{
    /*
        La clase AbstractTraveler sera heredada por todos los tipos de experiencias.
        Al ser abstracta no puede crearse una instacia de Traveler.
        Se utiliza herencia para la reutilizacion del codigo.
        AbstractTraveler es un observable segun el patro Observer, por eso tendra una lista de Observadores
        a los que se le notificara en determinado momento.
        Posee la responsabilidad de moverse, AbstractTraveler es experto en conocer la posicion y cuando se 
        mueve notifica a los observadores.
        Cumple con OCP, porque para crear distintos tipos de Viajeros no se modifica el codigo 
        que ya existe, solo se crea una clase nueva que hereda AbstractTraveler.
    */
    public abstract class AbstractTraveler

    {
        private int score = 0;
        private int coins = 0;
        private int position = 0;
        private int visitedMontains = 0;
        private int visitedOceans = 0;

        public string Name {get;set;}
        public int  Score
        {
            get 
            {
                return score;
            }
            set
            {
                if (value>0)
                {
                    score = value;                    
                }
            }
        }
        public int Coins
        {
            get 
            {
                return coins;
            }
            set
            {
                if (value>0)
                {
                    coins = value;                    
                }
            }
        }
        public int Position
        {
            get 
            {
                return position;
            }
            set
            {
                if (value>0)
                {
                    position = value;                    
                }
            }
        }
        public int VisitedMontains
        {
            get 
            {
                return visitedMontains;
            }
            set
            {
                if (value>0)
                {
                    visitedMontains = value;                    
                }
            }
        }
        public int VisitedOceans
        {
            get 
            {
                return visitedOceans;
            }
            set
            {
                if (value>0)
                {
                    visitedOceans = value;                    
                }
            }
        }

        public AbstractTraveler(string name)
        {
            Name = name;
        }

        private List<AbstractExperience> observers = new List<AbstractExperience>();


        /// <summary>
        /// Mueve al viajero de posicion y notifica a los observadores si lo hace
        /// </summary>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        public bool MoveTraveler(int newPosition)
        {
            if(newPosition > this.Position)
            {
                this.Position = newPosition;
                this.NotifyObserver();
                return true;
            }
            else return false;
        }   

        /// <summary>
        /// Notifica a los observadores
        /// </summary>
        public void NotifyObserver()
        {
            foreach(AbstractExperience observer in observers)
            {
                observer.PositionChange(this);
            }
        }

        /// <summary>
        /// Elimina los observadores
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(AbstractExperience observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// Agrega observadores
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(AbstractExperience observer)
        {
            observers.Add(observer);
        }
    }
}