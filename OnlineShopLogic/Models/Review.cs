using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Review
    {
        private Guid _id;
        private Customer _customer;
        private Item _item;
        private string _text;
        private Stars _stars;
        private DateTime _reviewDate;
        private List<Photo> _photos;

        public Guid Id => _id;

        public Customer Customer => _customer;

        public Item Item => _item;

        public string Text => _text;

        public Stars Stars => _stars;

        public DateTime ReviewDate => _reviewDate;

        public List<Photo> Photos
        {
            get => _photos;
            set => _photos = value;
        }

        public Review(Customer customer, Item item, string text, Stars stars, DateTime reviewDate)
        {
            _id = Guid.NewGuid();
            _customer = customer;
            _item = item;
            _text = text;
            _stars = stars;
            _reviewDate = reviewDate;
            _photos = new List<Photo>();
        }
        
    }
}