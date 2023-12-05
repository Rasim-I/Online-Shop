using System;

namespace OnlineShopLogic.Models
{
    public class Photo
    {
        private Guid _id;
        private string _name;
        private string _link;
        //private Item _item;
        private Guid? _itemId;
        //private Review _review;
        private Guid? _reviewId;
        private bool _isMain;

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

        public Guid? ItemId
        {
            get => _itemId;
            set => _itemId = value;
        }

        public Guid? ReviewId
        {
            get => _reviewId;
            set => _reviewId = value;
        }

        public bool IsMain
        {
            get => _isMain;
            set => _isMain = value;
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