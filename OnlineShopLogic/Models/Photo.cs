using System;

namespace OnlineShopLogic.Models
{
    public class Photo
    {
        private Guid _id;
        private string _name;
        private string _link;
        private Item _item;
        private Review _review;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Link
        {
            get => _link;
            set => _link = value;
        }

        public Item Item
        {
            get => _item;
            set => _item = value;
        }

        public Review Review
        {
            get => _review;
            set => _review = value;
        }
        
        public Photo(string name, string link)
        {
            _id = Guid.NewGuid();
            _name = name;
            _link = link;
        }

        public Photo(){}
    }
}