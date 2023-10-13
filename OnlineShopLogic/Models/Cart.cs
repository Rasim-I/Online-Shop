using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopLogic.Models
{
    public class Cart
    {
        private Guid _id;
        private Guid _customerId;
        private int _price;
        private Dictionary<Item, int> _items;

        public Guid Id => _id;

        public Guid Customer => _customerId;

        public int Price => _price;

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

        public Cart(Guid customerId)
        {
            _id = Guid.NewGuid();
            _customerId = customerId;
            _items = new Dictionary<Item, int>();
        }
        
    }
}