using System;
using System.CommandLine;
using System.CommandLine.IO;
using System.CommandLine.Rendering;
using System.Threading.Tasks;

namespace ShopCommandLine
{
    public class ShoppingList : IShoppingList
    {
        public string ListName => "Default Shopping List";

        // TODO: Get this data from a persistance layer
        public ShoppingListItem[] Items => new []
        {
            new ShoppingListItem { Name = "Tortillas", Quantity = 1 },
            new ShoppingListItem { Name = "Mountain Dew", Quantity = 24 },
            new ShoppingListItem { Name = "Cheese", Quantity = 1 },
            new ShoppingListItem { Name = "Chips", Quantity = 1 },
            new ShoppingListItem { Name = "Hot Sauce", Quantity = 2 },
        }; 

        public async Task AddItemsAsync(IConsole console, string name, int quantity)
        {
            // TODO: Persist this data
            console.Out.WriteLine($"Successfully added {quantity} '{name}' to the shopping list: {ListName}");
            await Task.CompletedTask;
        }

        public async Task RemoveItemsAsync(IConsole console, string name, int quantity)
        {
            // TODO: Persist this data
            console.Out.WriteLine($"Successfully removed {quantity} '{name}' to the shopping list: {ListName}");
            await Task.CompletedTask;
        }

        public void Print(IConsole console)
        {
            ClearTerminal(console);

            // TODO: Adjust implementation to allow for a much larger list instead of limiting it to the visible region.
            // Using Render instead of console.Append to force the OutputMode.Ansi.
            var view = new ShoppingListView(this, console);
            view.Render(new ConsoleRenderer(console, OutputMode.Ansi, true), 
                new Region(Console.WindowLeft, Console.WindowTop));
        }

        private void ClearTerminal(IConsole console)
        {
            if (console is ITerminal terminal)
            {
                terminal.Clear();
            }
            else
            {
                // FIME: There should be a way to do this without using the System.Console directly.
                Console.Clear();
            }
        }
    }
}