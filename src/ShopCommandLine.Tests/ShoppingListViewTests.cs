using System.CommandLine.Rendering;
using System.CommandLine.Tests.Utility;
using System.Drawing;
using FluentAssertions;
using Moq.AutoMock;
using Xunit;

namespace ShopCommandLine.Tests
{
    public class ShoppingListViewTests
    {
        private readonly TestTerminal _terminal;

        public ShoppingListViewTests()
        {
            _terminal = new TestTerminal();
        }

        [Fact]
        public void It_renders_all_rows()
        {
            var mocker = new AutoMocker();
            var items = new []
            {
                new ShoppingListItem("Coffee", 1),
                new ShoppingListItem("Eggs", 12)
            };
            var name = "Test Shopping List";

            var shoppingList = mocker.GetMock<IShoppingList>();
            shoppingList.Setup(x => x.Items).Returns(items);
            shoppingList.Setup(x => x.ListName).Returns(name);

            var view = new ShoppingListView(shoppingList.Object);

            view.Render(new ConsoleRenderer(_terminal, OutputMode.NonAnsi), new Region(0, 0, 100, 7));

            var lines = _terminal.RenderOperations();

            lines
                .Should()
                .BeEquivalentSequenceTo(
                    Cell(name, 0, 0),
                    Cell("#   ", 0, 2), Cell("Items to Purchase", 4, 2),
                    Cell("1   ", 0, 3), Cell("Coffee           ", 4, 3),
                    Cell("12  ", 0, 4), Cell("Eggs             ", 4, 4)
                );
        }

        private TextRendered Cell(string text, int left, int top) => new TextRendered(text, new Point(left, top));
    }
}