using System;
using OnlineShopLogic.Models.Enums;
using OnlineShopModels.Models.Enums;

namespace OnlineShopModels.Models
{
    public class Customer
    {
        private Guid _id;
        private DateTime _registrationDate;
        private string _name;
        private string _surname;
        private string _secondName;
        private DateTime _birthDate;
        private Gender _gender;
        private readonly Guid _applicationUserId;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime RegistrationDate
        {
            get => _registrationDate;
            set => _registrationDate = value;
        }

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

        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public Gender Gender
        {
            get => _gender;
            set => _gender = value;
        }

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
        
        public Customer(){}
        
    }
}