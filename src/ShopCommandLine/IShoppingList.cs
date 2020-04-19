using System.CommandLine;
using System.Threading.Tasks;

namespace ShopCommandLine
{
    public interface IShoppingList
    {
        string ListName { get; }
        ShoppingListItem[] Items { get; }
        Task AddItemsAsync(IConsole console, string name, int quantity);
        Task RemoveItemsAsync(IConsole console, string name, int quantity);
        void Print(IConsole console);
    }
}