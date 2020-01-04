﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TUTORIALS_LOB.Core.Models
{
    public class OrderItem
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
    public class Order : INotifyPropertyChanged
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Company { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime? DatePicked { get; set; }
        public bool Delivered => DatePicked != null;
        private IEnumerable<OrderItem> _orderItems;
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<OrderItem> OrderItems
        {
            get => _orderItems;
            set
            {
                _orderItems = value;
                PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs("OrderItems"));
            }
        }
        public override string ToString() => $"{Company} {OrderDate:g}  {OrderTotal}";
    }
}
