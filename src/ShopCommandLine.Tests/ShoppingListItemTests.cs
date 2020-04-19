using System;
using FluentAssertions;
using Xunit;

namespace ShopCommandLine.Tests
{
    public class ShoppingListItemTests
    {
        [Fact]
        public void Its_constructor_requires_name()
        {
            Action act = () => new ShoppingListItem(null, 23);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Its_constructor_requires_quantity_to_be_greater_than_one()
        {
            Action act = () => new ShoppingListItem("name", -2);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Its_constructor_sets_its_properties()
        {
            var name = "Coffee";
            var quantity = 8;

            var item = new ShoppingListItem(name, quantity);

            item.Name.Should().Be(name);
            item.Quantity.Should().Be(quantity);
        }

        [Fact]
        public void It_sorts_by_item_name()
        {
            var items = new[]
            {
                new ShoppingListItem {Name = "C"},
                new ShoppingListItem {Name = "A"},
                new ShoppingListItem {Name = "B"}
            };

            Array.Sort(items);

            items[0].Name.Should().Be("A");
            items[1].Name.Should().Be("B");
            items[2].Name.Should().Be("C");
        }
    }
}
