using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace OnlineShopModels.Models
{
    public class Cart
    {
        private Guid _id;
        private Customer _customer;
        private int _price;
        //private Dictionary<Item, int> _items;
        private List<CartItem> _items;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        public List<CartItem> Items
        {
            get => _items;
            set => _items = value;
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

        
        public bool RemoveItem(Item item, int quantity)
        {
            foreach (var cartItem in Items)
            {
                if (cartItem.Item.Equals(item))
                {
                    if (cartItem.Quantity < quantity)
                        return false;

                    if (cartItem.Quantity == quantity)
                    {
                        _items.Remove(cartItem);
                        _price -= cartItem.Item.Price * quantity;
                        return true;
                    }

                    cartItem.Item.Quantity -= quantity;
                    _price -= item.Price * quantity;
                    return true;
                }
            }
            return false;
        }
        
        public Cart(Customer customer)
        {
            _id = Guid.NewGuid();
            _customer = customer;
            _items = new List<CartItem>();  //new Dictionary<Item, int>();
        }
        
        public Cart(){}
    }
}