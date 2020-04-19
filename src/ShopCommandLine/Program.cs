using System.CommandLine;
using System.Threading.Tasks;

namespace ShopCommandLine
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var shoppingList = new ShoppingList();

            var rootCommand = new RootCommand()
                .UseAddItemCommand(shoppingList)
                .UseListCommand(shoppingList)
                .UseRemoveItemCommand(shoppingList);

            return await rootCommand.InvokeAsync(args);
        }
    }
}
