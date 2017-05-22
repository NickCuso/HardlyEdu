//#define TESTING
#undef DEBUG

using System;

namespace HD
{
  public class PreprocessorDirectives
  {
    public void Run()
    {
      //PrintStuff();

      //InDebugMode(Math.Sqrt(8881));

      CustomDirectives();
    }

    #region Example 1
    void PrintStuff()
    {
      Console.WriteLine("hi");
#if DEBUG
      Console.WriteLine("In Debug mode!");
#endif
    }
    #endregion

    #region Example 2
#if DEBUG
    public int callCount;
#endif

    [System.Diagnostics.Conditional("DEBUG")]
    void InDebugMode(double number)
    {
#if DEBUG
      callCount++;
#endif
    }
    #endregion

    #region Example 3
    void CustomDirectives()
    {
#if DEBUG && !TESTING // || also supported
      Console.WriteLine("Debug and not testing");
#elif TESTING
      Console.WriteLine("Testing");
#else


      Console.WriteLine("Not testing or DEBUG");
#warning "Oh No"


#endif
    }
    #endregion

    #region Example 4
#pragma warning disable 414
    static string message = "I'm not used anywhere";
#pragma warning restore 414
    #endregion
  }
}
