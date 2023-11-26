using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace OnlineShopLogic.Models
{
    public class Cart
    {
        private Guid _id;
        private Guid _customerId;
        private int _price;
        //private Dictionary<Item, int> _items;
        private List<CartItem> _items;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public Guid Customer
        {
            get => _customerId;
            set => _customerId = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        /*
        Dictionary<Item, int> Remove and Add methods
        public bool AddItem(Item item, int quantity)
        {
            if (item.Quantity < quantity)
                return false;

            _items.Add(item, quantity);
            _price += item.Price * quantity;
            return true;
        }

        public bool RemoveItem(Item item, int quantity)
        {
            if (_items.ContainsKey(item))
            {
                if (_items[item] < quantity)
                    return false;

                if (_items[item] == quantity)
                {
                    _items.Remove(item);
                    _price -= item.Price * quantity;
                    return true;
                }
                
                _items[item] -= quantity;
                _price -= item.Price * quantity;
                return true;
            }
            
            return false;
        }
        */

        public bool AddItem(Item item, int quantity)
        {
            if (item.Quantity < quantity)
                return false;
            
            _items.Add(new CartItem(_id, item, quantity));
            _price += item.Price * quantity;
            return true;
        }

        //TODO
        public bool RemoveItem(Item item, int quantity)
        {

            return false;
        }
        
        public Cart(Guid customerId)
        {
            _id = Guid.NewGuid();
            _customerId = customerId;
            _items = new List<CartItem>();  //new Dictionary<Item, int>();
        }
        
    }
}