namespace RRModels
{
    public class Review
    {
        /// <summary>
        /// This describes the overall numeric rating of restraunt
        /// </summary>
        /// <value></value>
        public int Rating { get; set; }
        /// <summary>
        /// Verbose description of the dining experience
        /// </summary>
        /// <value></value>
        public int Desctiption { get; set; }
        public override string ToString()
        {
            return $"\t Rating: {Rating} \n\t Description: {Description}";
        }
    }
}