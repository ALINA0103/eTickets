﻿namespace eTickets.Data.ViewModel
{
    public class CartVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
