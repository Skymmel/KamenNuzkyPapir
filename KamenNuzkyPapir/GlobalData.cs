using Spectre.Console;

namespace KamenNuzkyPapir
{
    public class GlobalData
    {
        public static string Nickname;
        public static string[] Weapon = { "Kamen", "Nůžky", "Papír" };
        public static string LastEvent = "připojil*a se do hry";
        public static short TotalGames = 0;
        public static short Rounds = 1;
        public static short PlayerWins = 0;
        public static short ComputerWins = 0;
        public static short Undecided = 0;

        public static void PrintStatistics()
        {
            var stat = new Table();
            AnsiConsole.MarkupLine($"[cyan]{Nickname}[/] {LastEvent}");
            stat.AddColumn($"Kolo {Rounds}.");
            stat.AddColumn(new TableColumn($"[cyan]{Nickname}[/]").Centered());
            stat.AddColumn(new TableColumn("[red]Computer[/]").Centered());
            
            stat.AddRow("Výher", $"[green]{PlayerWins}[/]" , $"[green]{ComputerWins}[/]");
            stat.AddRow("Nerozhodně", $"[yellow]{Undecided}[/]", $"[yellow]{Undecided}[/]");
            stat.AddRow("Prohry", $"[red]{ComputerWins}[/]", $"[red]{PlayerWins}[/]");

            AnsiConsole.Write(stat);
        }

        public static void Reset()
        {
        LastEvent = "resetoval*a hru";
        TotalGames = 0;
        Rounds = 1;
        PlayerWins = 0;
        ComputerWins = 0;
        Undecided = 0;
        }
    }
    
}