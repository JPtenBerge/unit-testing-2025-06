using Implementation.Utility;
using System;

namespace Implementation
{
    public class User
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AccountNumber { get; set; }
        public int Age
        {
            get
            {
                return AgeCalculator.Calculate(DateOfBirth, DateTime.Now);
            }
        }

        public User(string name, DateTime dateOfBirth, string accountNumber)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            AccountNumber = accountNumber;
        }
    }
}
