using Spectre.Console;
class Program
{
   public static void Main(string[] args)
   {
      
      AnsiConsole.Markup("Hello :globe_showing_europe_africa:!");
      AnsiConsole.Progress()
      .Start(ctx =>
      {
         var task1 = ctx.AddTask("[green]Reticulating splines[/]");
         var task2 = ctx.AddTask("[green]Folding space[/]");

         while (!ctx.IsFinished)
         {
            task1.Increment(1.5);
            task2.Increment(0.5);
         }
      });
   }
}
