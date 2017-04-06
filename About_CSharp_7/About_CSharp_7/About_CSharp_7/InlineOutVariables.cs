using System;

namespace HD
{
  internal class InlineOutVariables
  {
    public static bool TryGetNameAndAge(out string name, out int age)
    {
      name = "Nick";
      age = 34;
      return true;
    }

    internal void Run()
    {
      OldWay();
      Console.WriteLine("-");

      UsingInlineOutVariables();
      Console.WriteLine("-");

      InlineAutoTypedVariables();
    }

    void OldWay()
    {
      string name;
      int age;
      if(TryGetNameAndAge(out name, out age))
      {
        Console.WriteLine($"{name}: {age}");
      }
    }

    void UsingInlineOutVariables()
    {
      if(TryGetNameAndAge(out string name, out int age))
      {
        Console.WriteLine($"{name}: {age}");
      }
    }

    void InlineAutoTypedVariables()
    {
      if(TryGetNameAndAge(out var name, out var age))
      {
        Console.WriteLine($"{name}: {age}");
      }
    }
  }
}