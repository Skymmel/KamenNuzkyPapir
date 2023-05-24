using System;
using Spectre.Console;
using static System.Console;
using static KamenNuzkyPapir.GlobalData;


namespace KamenNuzkyPapir
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool doCycle = true;
            short counter = 0; 
            Nickname = GetNickname();
            ResetColor();
            while (doCycle)
            {
                counter++;
                Clear();
                PrintStatistics();
                MatchEvaluate(Attack());

                if (counter == 5)
                {
                    Rounds++;
                    counter = 0;
                    AnsiConsole.MarkupLine(
                        "Stiskněte klavesu [cyan bold]ENTER[/] pokračování, jestli-že nechcete pokračovat napište [cyan bold]NE[/]");
                    AnsiConsole.MarkupLine("  [grey]Pro vyresetování statisticky napište [underline]RESET[/].[/]");
                    switch (ReadLine().Trim().ToLower())
                    {
                        case "ne":
                        {
                            Priting("Ukončuji", "[red]Ukončeno[/]");
                            doCycle = false;
                            break;
                        }
                        case "reset":
                        {
                            Priting("Resetování", "[yellow]Resetováno[/]");
                            System.Threading.Thread.Sleep(500);
                            counter = 0;
                            Reset();
                            break;
                        }
                    }
                }
            }
        }

        private static void Priting(string before, string last, short times = 3)
        {
            for (short i = 0; i < times; i++)
            {
                AnsiConsole.MarkupLine($"[grey]{before} za {i}[/]");
                System.Threading.Thread.Sleep(100);
            }
            AnsiConsole.MarkupLine(last);
            System.Threading.Thread.Sleep(500);
        }

        private static string GetNickname()
        {
            AnsiConsole.MarkupLine("What's your name?");
            AnsiConsole.Markup("My name is ");
            ForegroundColor = ConsoleColor.Cyan;
            return ReadLine()?.Trim();
        }

        private static string Attack()
        {
            var offensiveWeapon = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Vyberte věc pro útok")
                    .PageSize(10)
                    .AddChoices(Weapon)
                );
            return offensiveWeapon;
        }

        private static void MatchEvaluate(string pAttack)
        {
            Random r = new Random();
            string cAttack = Weapon[r.Next(0, 3)];

            if (cAttack.Equals(pAttack))
            {
                LastEvent = "[yellow]remízoval*a[/]";
                Undecided++;
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
                LastEvent = "[green]vyhrál*a[/]";
                PlayerWins++;
            }
            else
            {
                LastEvent = "[red]prohral*a[/]";
                ComputerWins++;
            }
            TotalGames++;
        }
    }
}