using System;
using Spectre.Console;


namespace KamenNuzkyPapir
{
    internal class Program
    {
        // GlobalData gd = new GlobalData();

        public static void Main(string[] args)
        {
            while (true)
            {
                MatchEvaluate(Attack());
                Console.Clear();
            }
        }
        

        private static string GetNickname()
        {
            AnsiConsole.MarkupLine("What's your name?");
            AnsiConsole.Markup("My name is ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine()?.Trim();
        }

        private static string Attack()
        {
            var offensiveWeapon = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Vyberte věc pro útok:")
                    .PageSize(4)
                    .AddChoices(GlobalData.Weapon)
                );
            return offensiveWeapon;
        }
        private static void PrintStats(byte lives)
        {
            for (int i = 0; i < lives; i++)
            {
                AnsiConsole.Markup("[red]♥ [/]");
            }
        }

        private static void MatchEvaluate(string attack)
        {
            Random r = new Random();
            string cAttack = GlobalData.Weapon[r.Next(0, 3)];

            if (cAttack.Equals(attack))
            {
                AnsiConsole.MarkupLine("[yellow]Nerozhodne[/]");
            }
            else if
                (
                    (attack == "Kamen" && cAttack == "Nůžky")
                    ||
                    (attack == "Nůžky" && cAttack == "Papír")
                    ||
                    (attack == "Papír" && cAttack == "Kamen")
                )
            {
                AnsiConsole.MarkupLine("[green]Vyhral jsi[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Prohral jsi[/]");
            }
            Console.ReadKey();
        }
    }
}