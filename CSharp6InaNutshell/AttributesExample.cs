using System;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;

namespace HD
{
  [Obsolete] // or [ObsoleteAttribute]
  public class MyOldClass
  {
  }


  [Serializable]
  public class AnotherClass
  {
    [XmlElement(nameof(savedIntData), Namespace = "Hd")]
    public int savedIntData;

    [Obsolete("Use " + nameof(UseThis) + " instead")]
    [System.Diagnostics.Conditional("DEBUG")]
    public void DontUseThis() {}

    public void UseThis() {}

    public void PrintCaller(
      string message,
      [CallerMemberName] string whoAreYou = null, 
      [CallerFilePath] string fromWhichFile = null,
      [CallerLineNumber] int lineNumber = 0)
    {
      Console.WriteLine($"{whoAreYou} {fromWhichFile} {lineNumber}: {message}");
    } 
  }

  public class IDAttribute : Attribute
  {
    public readonly int id;

    public IDAttribute(int id)
    {
      this.id = id;
    }
  }

  [ID(42)]
  public class IHaveAnId {
  }

  /// <summary>
  /// Attributes add custom information to code elements
  /// Can be applied to assemblies, types, members, return vars, params, generic types
  /// 
  /// May impact compile time or runtime
  /// </summary>
  public class AttributesExample
  {
    public void Run()
    {
      var myClass = new MyOldClass();


      var anotherClass = new AnotherClass();
      anotherClass.DontUseThis();
      anotherClass.UseThis();


      anotherClass.PrintCaller("Hey!");

      // See AssemblyInfo


      var idAttributes = (IDAttribute[])typeof(IHaveAnId).GetCustomAttributes(typeof(IDAttribute), false);
      if(idAttributes.Length > 0)
      {
        Console.WriteLine($"My id: {idAttributes[0].id}");
      }
    }
  }
}
