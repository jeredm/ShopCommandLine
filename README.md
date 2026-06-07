# Shop Command Line

This is a command line application that is for managing a grocery list. It is a fun way to play with `System.CommandLine` and `System.CommandLine.Rendering`. This application uses `System.CommandLine` directly. `System.CommandLine` can be used to make createing command line applications even more simple than this example. Check out `System.CommandLine.DragonFruit` for a simple way to define arguments in your `Main`. You can check them all out [here](https://github.com/dotnet/command-line-api).

Should you really build a shopping list app from the command line? TBD

## TODO
Persist the list!!!

## Dependencies
.NET 10 SDK

## Getting Started
Run the commands from the repository root.

To get help and see all of the commands:
```
> dotnet run --project src/ShopCommandLine/ShopCommandLine.csproj -- -h
```

Once you have chosen a command, you can view more detailed help like this:
```
> dotnet run --project src/ShopCommandLine/ShopCommandLine.csproj -- add-item -h
```

To run the test suite:
```
> dotnet test src/ShopCommandLine.Tests/ShopCommandLine.Tests.csproj
```

## Examples
_Check out help for info on all of the commands. Below are examples using the `add-item` command._


Here is how you add one bag of coffee beans to your list:
```
> dotnet run --project src/ShopCommandLine/ShopCommandLine.csproj -- add-item "coffee beans"
```

Need more?
```
> dotnet run --project src/ShopCommandLine/ShopCommandLine.csproj -- add-item "coffee beans" --quantity 12
```

But wait, I thought a command could have an alias so I don't have to type?
```
> dotnet run --project src/ShopCommandLine/ShopCommandLine.csproj -- add "coffee beans" -q 12
```

If I forget to use quotes, how do I know if it will parse correctly?
```
> dotnet run --project src/ShopCommandLine/ShopCommandLine.csproj -- [parse] add coffee beans
[ ShopCommandLine [ add [ name <coffee> ] *[ --quantity <1> ] ] ]   ???--> beans
```

Want to dig in more and find out about tools like debugging and tab completion, or figure out what all the symbols in the `[parse]` directive mean?

[Checkout System.CommandLine!](https://github.com/dotnet/command-line-api/wiki)

## Colors
The Shopping List displays in color, but there are still some color issues that need to be ironed out between different terminal types and operating systems. Your mileage may vary.
