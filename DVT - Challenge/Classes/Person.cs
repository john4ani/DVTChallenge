
namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Class that defines a person
    /// </summary>
    public class Person
    {
        private readonly int _id;
        private decimal _weight;

        /// <summary>
        /// Person weight
        /// </summary>
        public decimal Weight => _weight;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Person id</param>
        /// <param name="weight">Person weight</param>
        public Person(int id, decimal weight):this(id)
        {
            _weight = weight;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">Person id</param>
        public Person(int id)
        {
            _id = id;            
        }

        /// <summary>
        /// Person is the same with another person of they have the same id
        /// </summary>
        /// <param name="obj">Other Person object</param>
        /// <returns>True if the same person, false if not the same person</returns>
        public override bool Equals(object? obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return _id == p._id;
            }
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>Hash code, the index</returns>
        public override int GetHashCode()
        {
            return _id;
        }
    }
}
