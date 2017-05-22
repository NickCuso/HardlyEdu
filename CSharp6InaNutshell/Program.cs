using System;

namespace HD
{
  class P
  {
    static void Main()
    {
      AppContext.SetSwitch("MyCustomSwitch", isEnabled: false);


      new GitClient().Run();
      //new EnvironmentAndAppContext().Run();

      Console.ReadKey();
    }
  }
}
