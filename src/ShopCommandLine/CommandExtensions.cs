using System.CommandLine;
using System.CommandLine.Invocation;

namespace ShopCommandLine
{
    public static class CommandExtensions
    {
        public static RootCommand UseAddItemCommand(this RootCommand rootCommand, IShoppingList shoppingList)
        {
            var addCommmand = new Command("add-item", "Adds a grocery item to the list")
            {
                new Option<int>(new string[] { "--quantity", "-q" }, () => 1, "The number of items to add (between 1 and 999)")
                    .WithinRange(1, 999),
                new Argument<string>("name")
                {
                    Description = "The name of the grocery item"
                }
            };
            addCommmand.AddAlias("add");

            addCommmand.Handler = CommandHandler.Create<IConsole, string, int>(async (console, name, quantity) =>
                await shoppingList.AddItemsAsync(console, name, quantity));

            rootCommand.AddCommand(addCommmand);
            return rootCommand;
        }

        public static RootCommand UseRemoveItemCommand(this RootCommand rootCommand, IShoppingList shoppingList)
        {
            var removeCommand = new Command("remove-item", "Removes a grocery item to the list") {
                new Option<int>(new string[] { "--quantity", "-q" }, () => 1, "The number of items to remove (between 1 and 999)")
                    .WithinRange(1, 999),
                new Argument<string>("name")
                {
                    Description = "The name of the grocery item"
                }
            };
            removeCommand.AddAlias("remove");

            removeCommand.Handler = CommandHandler.Create<IConsole, string, int>(async (console, name, quantity) =>
                await shoppingList.RemoveItemsAsync(console, name, quantity));

            rootCommand.AddCommand(removeCommand);
            return rootCommand;
        }

        public static RootCommand UseListCommand(this RootCommand rootCommand, IShoppingList shoppingList)
        {
            var removeCommand = new Command("list", "Displays the list of items in the shopping list");
            removeCommand.Handler = CommandHandler.Create<IConsole>((console) => shoppingList.Print(console));
            rootCommand.AddCommand(removeCommand);
            return rootCommand;
        }
    }
}