using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Spectre.Console;

class ModdingTool
{
    static string godotExe = "Godot_v4.2.2-stable_win64.exe";

    static void Main()
    {
        Console.Title = "Terraria Reborn Modding Tool";
        AnsiConsole.Markup("[bold blue]=== Terraria Reborn Tool v1.0 ===[/]\n");

        // Анимация запуска
        AnsiConsole.Status()
            .Start("Starting Modding Tool...", ctx =>
            {
                Thread.Sleep(2000);
                ctx.Status("Checking for updates...");
                Thread.Sleep(2000);
            });

        // Имитация загрузки патчей с прогресс-баром
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask("[green]Downloading patches...[/]");

                while (!task.IsFinished)
                {
                    Thread.Sleep(2500);
                    task.Increment(33.3);
                }
            });

        AnsiConsole.Markup("[bold green]Patches applied successfully![/]\n");

        // Таблица логов
        var table = new Table();
        table.AddColumn("Step");
        table.AddColumn("Status");

        table.AddRow("Checking files", "[green]✔[/]");
        table.AddRow("Downloading patches", "[green]✔[/]");
        table.AddRow("Applying updates", "[green]✔[/]");

        AnsiConsole.Render(table);

        // Запуск Godot
        if (File.Exists(godotExe))
        {
            AnsiConsole.Markup("[bold cyan]Launching Godot...[/]\n");
            Process.Start(godotExe);
        }
        else
        {
            AnsiConsole.Markup("[bold red]Error: Godot executable not found![/]\n");
        }

        // Оставляем консоль открытой
        AnsiConsole.Markup("\n[bold yellow]Modding Tool is running... Press Ctrl + C to exit.[/]");
        while (true)
        {
            Thread.Sleep(1000);
        }
    }
}
