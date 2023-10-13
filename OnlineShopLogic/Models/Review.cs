using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Review
    {
        private Guid _id;
        private Guid _customerId;
        private Item _item;
        private string _text;
        private Stars _stars;
        private DateTime _reviewDate;
        private List<Photo> _photos;

        public Guid Id => _id;

        public Guid CustomerId => _customerId;

        public Item Item => _item;

        public string Text => _text;

        public Stars Stars => _stars;

        public DateTime ReviewDate => _reviewDate;

        public List<Photo> Photos
        {
            get => _photos;
            set => _photos = value;
        }

        public Review(Guid customerId, Item item, string text, Stars stars, DateTime reviewDate)
        {
            _id = Guid.NewGuid();
            _customerId = customerId;
            _item = item;
            _text = text;
            _stars = stars;
            _reviewDate = reviewDate;
            _photos = new List<Photo>();
        }
        
    }
}