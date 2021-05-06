using System.Collections.Generic;
/// <summary>
/// Namespace for models/custom data structures involved in Restaurant Reviews
/// </summary>
namespace RRModels
{
    /// <summary>
    /// Data structure used to define a restaurant.
    /// </summary>
    public class Restaurant
    {
        //Class Members 
        //1.Constructor - Creates an instance
        //2. Fields - defines characteristics
        //3. Methods - define class's behaviors
        //4. Properties - also known as smart fields, accesor methods like getter/setter's
        // Prop convention is PascalCase like Methods
        public Restaurant(string name, string city, string state)
        {
            this.Name = name;
            this.City = city;
            this.State = state;
        }
        /// <summary>
        /// This describes the name of your restaurant
        /// </summary>
        /// <value></value>
        public string Name { get; set;}

        /// <summary>
        /// This describes the location
        /// </summary>
        /// <value></value>
        public string City { get; set;}

        public string State { get; set;}
        /// <summary>
        /// This has the restraunt review
        /// </summary>
        /// <value></value>
        public List<Review> Reviews { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} \n Location: {City}, {State}";
        }
        public bool Equals(Restaurant restaurant)
        {
            return this.Name.Equals(restaurant.Name) && this.City.Equals(restaurant.City) && this.State.Equals(restaurant.State);
        }
    }
}