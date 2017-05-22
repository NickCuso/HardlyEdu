using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace HD
{
  /// <summary>
  /// git add --all
  /// git commit -a -m "Test"
  /// git push
  /// </summary>
  public class GitClient
  {
    public void Run()
    {
      Console.WindowWidth = Console.LargestWindowWidth ;
      Console.WindowHeight = Console.LargestWindowHeight ;

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.BackgroundColor = ConsoleColor.DarkGray;

      ExecuteAndPrint("Step 1 of 3: Add untracked files", "add --all");
      ExecuteAndPrint("Step 2 of 3: Commit all", "commit -a -m \"Test\"");
      ExecuteAndPrint("Step 3 of 3: Push!", "push");

      UpdateBottomStatus("All done \\o/");
    }

    static void ExecuteAndPrint(
      string stepDescription,
      string gitCommand)
    {
      UpdateBottomStatus(stepDescription);
      Execute(gitCommand);
    }

    static void UpdateBottomStatus(string stepDescription)
    {
      Console.CursorTop = Console.WindowHeight - 1;
      Console.CursorLeft = 0;
      Console.Write(stepDescription.PadRight(Console.WindowWidth));
      Console.CursorTop = 0;
      Console.CursorLeft = 0;
    }

    static void Execute(
      string command)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo
      {
        FileName = "git",
        Arguments = command,
        RedirectStandardOutput = true,
        UseShellExecute = false,
      };

      Process gitProcess = Process.Start(startInfo);
      Console.WriteLine(gitProcess.StandardOutput.ReadToEnd());

      Thread.Sleep(TimeSpan.FromSeconds(3));
    }
  }
}
