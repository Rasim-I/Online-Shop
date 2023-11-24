using System;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Customer
    {
        private readonly Guid _id;
        private readonly DateTime _registrationDate;
        private string _name;
        private string _surname;
        private string _secondName;
        private readonly DateTime _birthDate;
        private readonly Gender _gender;
        private readonly Guid _applicationUserId;

        public Guid Id => _id;

        public DateTime RegistrationDate => _registrationDate;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string SecondName
        {
            get => _secondName;
            set => _secondName = value;
        }

        public DateTime BirthDate => _birthDate;

        public Gender Gender => _gender;

        public Guid ApplicationUserId { get; set; }
        
        public Customer(string name, string surname, string secondName, DateTime birthDate, Gender gender, Guid applicationUserId)
        {
            _id = Guid.NewGuid();
            _name = name;
            _surname = surname;
            _secondName = secondName;
            _birthDate = birthDate;
            _gender = gender;
            _registrationDate = DateTime.Today;
            _applicationUserId = applicationUserId;
        }
        
    }
}