using System;
using System.Collections.Generic;
using OnlineShopLogic.Models.Enums;

namespace OnlineShopLogic.Models
{
    public class Order
    {
        private Guid _id;
        private Guid _customerId;
        private Dictionary<Item, int> _items;
        private DateTime _orderDate;
        private Status _status;

        public Guid Id => _id;

        public Guid CustomerId => _customerId;

        public Dictionary<Item, int> Items
        {
            get => _items;
            set => _items = value;
        }

        public DateTime OrderDate => _orderDate;

        public Status Status
        {
            get => _status;
            set => _status = value;
        }

        public Order(Guid customerId)
        {
            _id = Guid.NewGuid();
            _customerId = customerId;
            _orderDate = DateTime.Now;
            _status = Status.Created;
            _items = new Dictionary<Item, int>();
        }
        
    }
}