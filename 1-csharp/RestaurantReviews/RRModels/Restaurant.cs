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
        public string Name { get; }

        /// <summary>
        /// This describes the location
        /// </summary>
        /// <value></value>
        public string City { get;}

        public string State { get;}
        /// <summary>
        /// This has the restraunt review
        /// </summary>
        /// <value></value>
        public Review Review { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} \n Location: {City}, {State} \n Review: {Review.ToString()}";
        }
    }
}