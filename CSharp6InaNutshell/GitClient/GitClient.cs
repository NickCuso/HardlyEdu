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
      ProcessStartInfo startInfo = new ProcessStartInfo
      {
        FileName = "git",
        Arguments = "commit -a -m \"Test\"",
        RedirectStandardOutput = true,
        UseShellExecute = false
      };

      Process gitProcess = Process.Start(startInfo);
      string result = gitProcess.StandardOutput.ReadToEnd();
      Console.WriteLine(result);
    }
  }
}
