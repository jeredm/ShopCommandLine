using System;

namespace ShopCommandLine
{
    public class ShoppingListItem : IComparable
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public ShoppingListItem() {}

        public ShoppingListItem(string name, int quantity)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} cannot be null or empty.");
            }
            if (quantity < 1)
            {
                throw new ArgumentException($"{nameof(quantity)} must be larger than 1. {quantity} was passed.");
            }

            Name = name;
            Quantity = quantity;
        }

        public int CompareTo(object otherObject)
        {
            if (otherObject is null) 
                return 1;

            var otherItem = otherObject as ShoppingListItem;
            if (otherItem is null) 
                return 1;

            return Name.CompareTo(otherItem.Name);
        }
    }
}