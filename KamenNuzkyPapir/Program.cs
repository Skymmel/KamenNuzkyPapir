using System;
using Spectre.Console;


namespace KamenNuzkyPapir
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string nickname = GetNickname();
            Console.Clear();
            Random r = new Random();

            int randomSelector = r.Next(0, 3);
            var fruit = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What's your [green]favorite fruit[/]?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
                        "Apple", "Apricot", "Avocado", 
                        "Banana", "Blackcurrant", "Blueberry",
                        "Cherry", "Cloudberry", "Cocunut",
                    }));
            
        }

        private static string GetNickname()
        {
            AnsiConsole.MarkupLine("What's your name?");
            AnsiConsole.Markup("My name is ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine()?.Trim();
        }
    }
}