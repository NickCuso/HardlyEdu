using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  public abstract class Animal {}
  public class Bear : Animal {}
  public class Dog : Animal { }

  public static class DynamicMath
  {
    public static dynamic Sum(dynamic a, dynamic b)
    {
      return a + b;
    }

    public static dynamic Difference(dynamic a, dynamic b)
    {
      return a - b;
    }

    public static void Print(this int a)
    {
      Console.WriteLine(a);
    }
  }

  public class DynamicBinding
  {
    public static int count;

    public void Run()
    {
      dynamic a = 100;
      a.Print();
      //DynamicMath.Print(a);

      //AsInt();
      //AsDouble();
      //AsString();

      //Conversions();

      //CompilerTriesToHelp();

      //UseCaseWithInheritence();


      // NOT supported
      // - Extension methods
      // - Explicit interface implementations (implicit okay)



      
    }

   
    private void AsString()
    {
      string a = "Hello";
      string b = "!!!!";

      Console.WriteLine(DynamicMath.Sum(a, b));
      //Console.WriteLine(DynamicMath.Difference(a, b)); //throws RuntimeBinderException
    }

    private void AsDouble()
    {
      double a = 100.002;
      double b = 201.0105;

      Console.WriteLine(DynamicMath.Sum(a, b));
      Console.WriteLine(DynamicMath.Difference(a, b));
    }

    private void AsInt()
    {
      int a = 100;
      int b = 201;

      Console.WriteLine(DynamicMath.Sum(a, b));
      Console.WriteLine(DynamicMath.Difference(a, b));
    }

    private void Conversions()
    {
      int a = 1000;
      dynamic b = a;
      int c = b;

      string d = "Hello";
      dynamic e = d;
      //int f = e; //throws RuntimeBinderException


      var g = b * 3; // g is dynamic
    }

    private void CompilerTriesToHelp()
    {
      dynamic a = 10;
      dynamic b = 20102;

       //Console.WriteLine(IntSum(a));  // obvious fail cases like this are compile errors
       //Console.WriteLine(IntSum(a, b, 1));

      int IntSum(int x, int y)
      {
        return x + y;
      }
    }


    public static void Wash(Dog dog)
    {
      Console.WriteLine("Washing the dog");
    }

    public static void Wash(Bear bear)
    {
      Console.WriteLine("Washing a bear, whoa...");
    }

    public static void Wash(Animal animal)
    {
      Console.WriteLine("I'm not sure what this is...");
    }

    void UseCaseWithInheritence()
    {
      Animal dog = new Dog();
      Wash(dog);
      Wash((dynamic)dog);
    }
  }
}
