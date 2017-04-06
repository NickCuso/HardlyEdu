using System;

namespace HD
{
  // Pre-req: NuGet System.ValueTuple
  public class InlineTuples
  {
    public void Run()
    {
      OldWay();
      NewHotnessUnnamedA();
      NewHotnessUnnamedB();
      NewHotnessNamedA();
      NewHotnessNamedB();
    }

    void OldWay()
    {
      Tuple<string, string, int, int> data = OldTuple("Go");
      Console.WriteLine($"{data.Item1}: {data.Item2}... {data.Item3}, {data.Item4}");
    }

    Tuple<string, string, int, int> OldTuple(string input)
    {
      switch(input)
      {
        case "Go":
          return Tuple.Create("Hi", "Hello", 1, 2);
        default:
          return Tuple.Create("Default", "case", 0, 100);
      }
    }

    #region Unnamed
    (string, string, int, int) UnnamedInlineTuple(string input)
    {
      switch(input)
      {
        case "Go":
          return ("Hi", "Hello", 1, 2);
        default:
          return ("Default", "case", 0, 100);
      }
    }

    void NewHotnessUnnamedA()
    {
      var data = UnnamedInlineTuple("Go");
      Console.WriteLine($"{data.Item1}: {data.Item2}... {data.Item3}, {data.Item4}");
    }

    void NewHotnessUnnamedB()
    {
      var (myName, myData, myA, myB) = UnnamedInlineTuple("Go");
      // or (string myName, string myData, int myA, int myB) = UnnamedInlineTuple("Go");
      // or (var myName, var myData, var myA, var myB) = UnnamedInlineTuple("Go");
      Console.WriteLine($"{myName}: {myData}... {myA}, {myB}");
    }
    #endregion

    #region Named
    (string name, string data, int a, int b) NamedInlineTuple(string input)
    {
      switch(input)
      {
        case "Go":
          return ("Hi", "Hello", a: 1, b: 2);
        default:
          return ("Default", "case", 0, 100);
      }
    }

    void NewHotnessNamedB()
    {
      string myName, myData;
      int myA, myB;
      (myName, myData, myA, myB) = NamedInlineTuple("Go");
      Console.WriteLine($"{myName}: {myData}... {myA}, {myB}");
    }

    void NewHotnessNamedA()
    {
      var data = NamedInlineTuple("Go");
      // or (string name, string data, int a, int b) data = NamedInlineTuple("Go");
      Console.WriteLine($"{data.name}: {data.data}... {data.a}, {data.b}");
    }
    #endregion
  }
}
