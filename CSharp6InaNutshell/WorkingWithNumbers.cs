using System;

internal class WorkingWithNumbers
{
  internal void Run()
  {
    //MathExample();
    //BigIntExample();
    //ComplexExample();
    //RandomExample();
    //TupleExample();
    //GuidExample();
    EqualsExample();
  }

  void MathExample()
  {
    Console.WriteLine(Math.Round(3.2));     // 3
    Console.WriteLine(Math.Truncate(3.2));  // 3
    Console.WriteLine(Math.Floor(3.2));     // 3
    Console.WriteLine(Math.Ceiling(3.2));   // 4

    Console.WriteLine();

    Console.WriteLine(Math.Round(-3.2));          // -3
    Console.WriteLine(Math.Round(-3.2178128, 2, MidpointRounding.ToEven)); // -3.22
    Console.WriteLine(Math.Truncate(-3.2));       // -3
    Console.WriteLine(Math.Floor(-3.2));          // -4
    Console.WriteLine(Math.Ceiling(-3.2));        // -3

    Console.WriteLine();

    Console.WriteLine(Math.Min(1,2));   // 1
    Console.WriteLine(Math.Max(1,2));   // 2
    Console.WriteLine(Math.Abs(-1));    // 1
    Console.WriteLine(Math.Sign(-100)); // -1
    Console.WriteLine(Math.Sqrt(100));  // 10
    Console.WriteLine(Math.Pow(2, 7));  // 128
    Console.WriteLine(Math.Exp(2));     // 7.3
    Console.WriteLine(Math.Log(5));     // 1.6
    Console.WriteLine(Math.Log(5, 10)); // .69
    Console.WriteLine(Math.Log10(5));   // .69

    Console.WriteLine();

    Console.WriteLine(Math.Sin(2));   // .9
    Console.WriteLine(Math.Cos(2));   // -.4
    Console.WriteLine(Math.Tan(2));   // -2.1
    Console.WriteLine(Math.Sinh(2));  // 3.6
    Console.WriteLine(Math.Cosh(2));  // 3.7
    Console.WriteLine(Math.Tanh(2));  // .9
    Console.WriteLine(Math.Asin(.5)); // .5
    Console.WriteLine(Math.Acos(.5)); // 1
    Console.WriteLine(Math.Atan(.5)); // .4

    Console.WriteLine();
  }

  // Requires a numerics
  void BigIntExample()
  {
    System.Numerics.BigInteger bigInt = 10000;
    bigInt = System.Numerics.BigInteger.Pow(bigInt, 1999);
    bigInt++;
    Console.WriteLine(bigInt);
  }

  void ComplexExample()
  {
    System.Numerics.Complex c1 = new System.Numerics.Complex(2, 3.5);
    Console.WriteLine(c1.Phase);      // 1.05165021254837
    Console.WriteLine(c1.Magnitude);  // 4.03112887414927


    System.Numerics.Complex polar = System.Numerics.Complex.FromPolarCoordinates(4.03112887414927, 1.05165021254837);
    Console.WriteLine(polar.Real);      // 2
    Console.WriteLine(polar.Imaginary); // 3.49
  }

  void RandomExample()
  {
    {
      Random rng = new Random();
      Console.WriteLine(rng.Next().ToString());
      Console.WriteLine(rng.Next().ToString());
      Console.WriteLine(rng.Next().ToString());
    }

    Console.WriteLine();

    for(int i = 0; i < 2; i++)
    {
      Random rngSeed = new Random(1); // Pro = reproducablility 
      Console.WriteLine(rngSeed.Next().ToString());
      Console.WriteLine(rngSeed.Next().ToString());

      Console.WriteLine("-");
    }

    Console.WriteLine();

    for(int i = 0; i < 100; i++)
    { // Approx 10 ms between need Random seeds
      Console.WriteLine(new Random().Next().ToString());
    }

    Console.WriteLine();

    System.Security.Cryptography.RandomNumberGenerator rngPlusPlus 
      = System.Security.Cryptography.RandomNumberGenerator.Create();
    byte[] randomData = new byte[4];
    Console.WriteLine(randomData[0]);
    rngPlusPlus.GetBytes(randomData);
    Console.WriteLine(randomData[0]);
  }

  // Requires ValueTuple nuget (if using Unity or .net 3.5 see other youtube video)
  void TupleExample()
  {
    Tuple<string, int> tuple = Tuple.Create("Bob", 42);
    Console.WriteLine(tuple.Item1);
    Console.WriteLine(tuple.Item2);

    (string name, int age, int pets) = ("Bob", 42, 3);
    Console.WriteLine(name);
    Console.WriteLine(age);
    Console.WriteLine(pets);

    var (nickName, nickAge) = GetMyInfo();
    Console.WriteLine(nickName);
    Console.WriteLine(nickAge);
  }

  (string name, int age) GetMyInfo()
  {
    return ("Nick", 35);
  }

  void GuidExample()
  {
    Guid guid = Guid.NewGuid();
    Console.WriteLine(guid);
  }

  void EqualsExample()
  {
    // == is compile time, equals is runtime (impact on generics)
    // equals defaults to reference comparision for references

    string a1 = "hello";
    object b1 = "HELLO".ToLower();
    Console.WriteLine(a1 == b1);
    Console.WriteLine(a1.Equals(b1));

    // When == and Equal don't equal..
    double a = double.NaN;
    double b = double.NaN;
    Console.WriteLine(a == b);
    Console.WriteLine(a.Equals(b));

    // Why override Equals - Change the meaning of equality, perf with structs (unncessary value comparisions / hash)
    // 1) Override GetHashCode and Equals()
    // Optional 2) overlap != and ==
    // Optional 3) implement IEquatable<T>

    // When to overload == and !=... only when a consumer would never want referantial equality (immutable classes:string)
  }

  public struct Area : IEquatable<Area>
  {
    public readonly int measure1, measure2;

    public Area(int m1, int m2)
    {
      measure1 = m1;
      measure2 = m2;
    }

    // Equals
    // - Cannot equal null (unless a nullable type)
    // - Reflective (a.Equals(a))
    // - Commutative (if a.Equals(b) then b.Equals(a))
    // - Transitive (if a.Equals(b) and b.Equals(c) then a.Equals(c))
    // Cannot throw an exception
    // Must return same value every time called for the same object

    // Same as default implementation
    public override bool Equals(object other)
    {
      if(other is Area == false)
      {
        return false;
      }

      return Equals((Area)other);
    }

    // IEquatable<T> (no boxing required)
    public bool Equals(Area other)
    {
      return measure1 == other.measure1 && measure2 == other.measure2;
    }

    // Hash - for Dictionary and Hashtable
    // Must return save value on options whare are .Equal()==true
    // Cannot throw an exception
    // Must return same value every time called for the same object
    // By default, based on a token for reference types / structs combine fields
    public override int GetHashCode()
    {
      return measure2 * 31 + measure1; // 31 is some prime number
    }

    // structs don't have == by default
    public static bool operator ==(Area a1, Area a2)
    {
      return Equals(a1, a2);
    }

    public static bool operator !=(Area a1, Area a2)
    {
      return Equals(a1, a2) == false;
    }
  }
}