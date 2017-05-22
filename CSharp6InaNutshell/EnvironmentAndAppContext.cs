using System;

namespace HD
{
  public class EnvironmentAndAppContext
  {
    public void Run()
    {
      Console.WriteLine(Environment.CurrentDirectory);
      Console.WriteLine(Environment.ProcessorCount);
      Console.WriteLine(Environment.StackTrace);

      Console.WriteLine();
      Console.WriteLine("----------");
      Console.WriteLine();


      if(AppContext.TryGetSwitch("MyCustomSwitch", out bool isEnabled))
      {
        Console.WriteLine(isEnabled);
      }
    }
  }
}
