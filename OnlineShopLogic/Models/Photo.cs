using System;

namespace OnlineShopLogic.Models
{
    public class Photo
    {
        private Guid _id;
        private string _name;
        private string _link;

        public Guid Id => _id;

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

        public Photo(string name, string link)
        {
            _id = Guid.NewGuid();
            _name = name;
            _link = link;
        }
        
    }
}