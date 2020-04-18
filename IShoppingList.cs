using System.CommandLine;
using System.Threading.Tasks;

namespace ShopCommandLine
{
    public interface IShoppingList
    {
         Task AddItemsAsync(IConsole console, string name, int quantity);
         Task RemoveItemsAsync(IConsole console, string name, int quantity);
         void Print(IConsole console);
    }
}