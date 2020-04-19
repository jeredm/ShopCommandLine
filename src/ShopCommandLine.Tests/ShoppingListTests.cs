using System.Threading.Tasks;
using System.CommandLine.IO;
using FluentAssertions;
using Xunit;

namespace ShopCommandLine.Tests
{
    public class ShoppingListTests
    {
        [Fact]
        public async Task It_writes_success_for_add_to_console()
        {
            var quantity = 6;
            var name = "Mountain Dew";
            var shoppingList = new ShoppingList();
            var console = new TestConsole();

            await shoppingList.AddItemsAsync(console, name, quantity);

            console.Out.ToString().Should().Be($"Successfully added {quantity} '{name}' to the shopping list: {shoppingList.ListName}\n");
        }

        [Fact]
        public async Task It_writes_success_for_remove_to_console()
        {
            var quantity = 2;
            var name = "Mountain Dew";
            var shoppingList = new ShoppingList();
            var console = new TestConsole();

            await shoppingList.RemoveItemsAsync(console, name, quantity);

            console.Out.ToString().Should().Be($"Successfully removed {quantity} '{name}' to the shopping list: {shoppingList.ListName}\n");
        }

        [Fact]
        public void It_renders_a_mock_list()
        {
            var shoppingList = new ShoppingList();
            var console = new TestConsole();

            shoppingList.Print(console);

            console.Out.ToString().Should().NotBeEmpty();
        }
    }
}