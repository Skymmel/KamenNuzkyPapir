using System;
using Spectre.Console;


namespace KamenNuzkyPapir
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GlobalData.Nickname = GetNickname();
            Console.ResetColor();
            while (true)
            {
                Console.Clear();
                GlobalData.PrintStatistics();
                MatchEvaluate(Attack());
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
                    .Title("Vyberte věc pro útok")
                    .PageSize(10)
                    .AddChoices(GlobalData.Weapon)
                );
            return offensiveWeapon;
        }

        private static void MatchEvaluate(string pAttack)
        {
            Random r = new Random();
            string cAttack = GlobalData.Weapon[r.Next(0, 3)];

            if (cAttack.Equals(pAttack))
            {
                GlobalData.LastEvent = "[yellow]nepřekvapil*a[/]";
                GlobalData.Undecided++;
            }
            else if
                (
                    (pAttack == "Kamen" && cAttack == "Nůžky")
                    ||
                    (pAttack == "Nůžky" && cAttack == "Papír")
                    ||
                    (pAttack == "Papír" && cAttack == "Kamen")
                )
            {
                GlobalData.LastEvent = "[green]vyhrál*a[/]";
                GlobalData.PlayerWins++;
            }
            else
            {
                GlobalData.LastEvent = "[red]prohral*a[/]";
                GlobalData.ComputerWins++;
            }
            GlobalData.TotalGames++;
        }
    }
}