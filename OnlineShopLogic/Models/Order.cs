using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Order
    {
        private Guid _id;
        private Customer _customer;
        private Dictionary<Item, int> _items;
        private DateTime _orderDate;
        private Status _status;

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

        public Dictionary<Item, int> Items
        {
            get => _items;
            set => _items = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }

        public Status Status
        {
            get => _status;
            set => _status = value;
        }

        public Order(Customer customer)
        {
            _id = Guid.NewGuid();
            _customer = customer;
            _orderDate = DateTime.Now;
            _status = Status.Created;
            _items = new Dictionary<Item, int>();
        }
        public Order(){}
    }
}