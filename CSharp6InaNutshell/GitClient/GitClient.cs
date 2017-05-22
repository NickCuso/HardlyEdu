using System;
using System.Diagnostics;
using System.IO;

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
      Console.WindowWidth = Console.LargestWindowWidth / 2;
      Console.WindowHeight = Console.LargestWindowHeight / 2;

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.BackgroundColor = ConsoleColor.DarkGray;

      ExecuteAndPrint("Step 1 of 3: Add untracked files", "add --all");
      ExecuteAndPrint("Step 2 of 3: Commit all", "commit -a -m \"Test\"");
      ExecuteAndPrint("Step 3 of 3: Push!", "push");
    }

    static void ExecuteAndPrint(
      string stepDescription, 
      string gitCommand)
    {
      Console.Write(stepDescription.PadRight(20));
      string step1Result = Execute(gitCommand);
      Console.CursorLeft = 0;

      //Console.WriteLine(step1Result);
    }

    static string Execute(
      string command)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo
      {
        FileName = "git",
        Arguments = command,
        RedirectStandardOutput = true,
        UseShellExecute = false
      };


      using(TextWriter writer = new StringWriter())
      {
        TextWriter oldOut = Console.Out;
        Console.SetOut(writer);
        Console.SetError(writer);
        Process gitProcess = Process.Start(startInfo);
        Console.SetOut(oldOut);
        Console.SetError(oldOut);
        return writer.ToString();
      }
    }
  }
}
