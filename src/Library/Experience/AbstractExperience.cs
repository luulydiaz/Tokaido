using System.Collections.Generic;

namespace Tokaido
{
    /*
        La clase AbstractExperience sera heredada por todos los tipos de experiencias.
        Al ser abstracta no puede crearse una instacia de Experience
        Se utiliza herencia para la reutilizacion del codigo.
        Cumple con OCP, porque para creardistintos tipos de Experiencias no se modifica el codigo 
        que ya existe, solo se crea una clase nueva que hereda AbstractExperience.
        Cumple con Expert ya que es experta en la capacidad de Viajeros.
        Es Polimorfica ya que el metodo Update es abstracto porque cada subtipo de Experience lo implemneta de 
        manera diferente.
    */
    public abstract class AbstractExperience
    {
                
        private int position;
        public int Limit {get;set;}
        public string Name{get;set;} 
        private List<AbstractTraveler> travelers = new List<AbstractTraveler>();
        public List<AbstractTraveler> Travelers
        {
            get{return travelers;}
        }                       

        /// <summary>
        /// Constructor de Experiencia
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <param name="position"></param>
        public AbstractExperience(string name, int limit, int position)
        {
            Limit = limit;
            Name = name;
            Position = position;
        }

        /// <summary>
        /// Método que se ejecuta cuando un Viajero cambia de posición.
        /// </summary>
        /// <param name="observable"></param>
        public abstract void PositionChange(AbstractTraveler observable);

        /// <summary>
        /// Ingresa un nuevo viajero
        /// </summary>
        /// <param name="traveler"></param>
        /// <returns></returns>
        public bool NewTraveler(AbstractTraveler traveler)
        { 
            if (Travelers.Count < Limit)
            {
                this.Travelers.Add(traveler);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Retorna la posicion y la setea si es mayor a 0
        /// </summary>
        /// <value></value>
        public int Position
        {
            get {return position;}
            
            set
            {
                if (value>0)
                {
                    position = value;
                }
            }
        }
      
    }
}