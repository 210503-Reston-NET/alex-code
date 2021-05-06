namespace RRModels
{
    public class Review
    {
        private int _rating;
        /// <summary>
        /// This describes the overall numeric rating of restraunt
        /// </summary>
        /// <value></value>
        public int Rating {
            get {return _rating;} 
            set
            {
                if(_rating < 0){
                    throw new System.Exception("Need a non-negative number for rating");
                }
                _rating = value;
            }
        }
        /// <summary>
        /// Verbose description of the dining experience
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        public override string ToString()
        {
            return $"\t Rating: {Rating} \n\t Description: {Description}";
        }
    }
}