using System;
using System.Diagnostics;

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
      Console.WindowWidth = Console.LargestWindowWidth;
      Console.WindowHeight = Console.LargestWindowHeight / 2;

      Console.WriteLine(Execute("add --all"));
      Console.WriteLine(Execute("commit -a -m \"Test\""));
      Console.WriteLine(Execute("push"));
    }

    private static string Execute(string command)
    {
      ProcessStartInfo startInfo = new ProcessStartInfo
      {
        FileName = "git",
        Arguments = command,
        RedirectStandardOutput = true,
        UseShellExecute = false
      };

      Process gitProcess = Process.Start(startInfo);
      string result = gitProcess.StandardOutput.ReadToEnd();
      return result;
    }
  }
}
