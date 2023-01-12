using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Param
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="name"> Name </param>
        /// <param name="gender"> Gender </param>
        /// <param name="birthDate"> BirthDate </param>
        /// <param name="weight"> Weight </param>
        /// <param name="height"> Height </param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check param
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username cannot be empty or null", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null", nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Impossible date of birth", nameof(birthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentNullException("Weight cannot be less than or equal to zero", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentNullException("Height cannot be less than or equal to zero", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username cannot be empty or null", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
