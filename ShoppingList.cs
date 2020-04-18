using System;
using System.CommandLine;
using System.CommandLine.IO;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;
using System.Threading.Tasks;

namespace ShopCommandLine
{
    public class ShoppingList : IShoppingList
    {
        public string ListName => "Default Shopping List";

        public async Task AddItemsAsync(IConsole console, string name, int quantity)
        {
            console.Out.WriteLine($"Successfully added {quantity} '{name}' to the shopping list: {ListName}");
            await Task.CompletedTask;
        }

        public async Task RemoveItemsAsync(IConsole console, string name, int quantity)
        {
            console.Out.WriteLine($"Successfully removed {quantity} '{name}' to the shopping list: {ListName}");
            await Task.CompletedTask;
        }

        public void Print(IConsole console)
        {
            var items = new []
            {
                new ShoppingListItem { Name = "Tortillas", Quantity = 1 },
                new ShoppingListItem { Name = "Mountain Dew", Quantity = 24 },
                new ShoppingListItem { Name = "Cheese", Quantity = 1 },
                new ShoppingListItem { Name = "Chips", Quantity = 1 },
                new ShoppingListItem { Name = "Hot Sauce", Quantity = 2 },
            };

            Array.Sort(items);
            RenderList(console, items);
        }

        private void RenderList(IConsole console, ShoppingListItem[] items)
        {
            var view = new TableView<ShoppingListItem>();
            view.Items = items;
            view.AddColumn<int>(item => item.Quantity, "#");
            view.AddColumn<string>(item => item.Name, "Name");
            view.Render(new ConsoleRenderer(console), new Region(0, 0, 200, 200));
            
            console.Out.WriteLine("\n"); 
        }
    }
}