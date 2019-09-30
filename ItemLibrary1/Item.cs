﻿namespace ItemLibrary1
{
    public  class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quality { get; set; }
        public double Quantity { get; set; }

        public Item(int id, string name, string quality, double quantity)
        {
            Id = id;
            Name = name;
            Quality = quality;
            Quantity = quantity;
        }

        public Item()
        {
            
        }

        public override string ToString()
        {
            return Id + Name + Quality + Quantity;
        }
    }
}
