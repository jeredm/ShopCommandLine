using System;

namespace ShopCommandLine
{
    public class ShoppingListItem : IComparable
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

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