using System;

namespace HD
{
  public class ThrowExpressions
  {
    public void Run()
    {
      string name = null;

      try
      {
        OldWay(name);
      }
      catch { }
      try
      {
        NewHotness(name);
      }
      catch { }
    }

    void OldWay(string name)
    {
      if(name == null)
      {
        throw new NullReferenceException();
      }
      Console.WriteLine(name);
    }

    void NewHotness(string name)
    {
      Console.WriteLine(name ?? throw new NullReferenceException());
    }
  }
}