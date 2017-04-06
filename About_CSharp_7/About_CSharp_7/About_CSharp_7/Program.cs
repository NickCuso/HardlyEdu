using System;

namespace HD
{
  class Program
  {
    static void Section(string section)
    {
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine(section);
    }

    static void Main()
    {
      Section("Out Variables");
      new InlineOutVariables().Run();
      Section("Pattern Matching with IS");
      new PatternMatchingWithIs().Run();
      Section("Pattern Matching with SWITCH");
      new PatternMatchingWithSwitch().Run();
      Section("Inline Tuples");
      new InlineTuples().Run();
      Section("Custom Deconstructing");
      new CustomDeconstruct().Run();
      Section("Digital Separation");
      new DigitalSeparation().Run();
      Section("Local Functions");
      new LocalFunction().Run();
      Section("Ref returns");
      new RefReturns().Run();
      Section("More expression bodies");
      new ExpressionBodies().Run();
      Section("Throw expressions");
      new ThrowExpressions().Run();

      Console.ReadKey();
    }
  }
}
