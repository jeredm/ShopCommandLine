using System;
using System.CommandLine;
using System.CommandLine.Rendering;
using System.CommandLine.Rendering.Views;

namespace ShopCommandLine
{
    public class ShoppingListView : StackLayoutView
    {
        public ShoppingListView(IShoppingList shoppingList)
        {
            if (shoppingList is null) throw new ArgumentNullException(nameof(shoppingList));

            var items = shoppingList.Items is null ? new ShoppingListItem[0] : shoppingList.Items;
            
            Array.Sort(items);

            // Your milage may vary when it comes to color here. There are still a few bugs to iron
            // out in the rendering system. So far this is working in VS Code on macOS Catalina.
            Add(new ContentView($"{shoppingList.ListName}".Rgb(168, 139, 50)));
            Add(new ContentView("\n"));

            var view = new TableView<ShoppingListItem>();
            view.Items = items;
            view.AddColumn<TextSpan>(item => item.Quantity.ToString().LightGreen(), new ContentView("#".UnderlineRed()));
            view.AddColumn<TextSpan>(item => item.Name.White(), new ContentView("Items to Purchase".UnderlineRed()));
            Add(view);

            Add(new ContentView("\n"));
            Add(new ContentView("\n"));
        }
    }
}