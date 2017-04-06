using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  public class Vector3
  {
    public readonly double x, y, z;

    public Vector3(double x, double y, double z)
    {
      this.x = x;
      this.y = y;
      this.z = z;
    }

    // Option 1
    public void Deconstruct(out double x, out double y, out double z)
    {
      x = this.x;
      y = this.y;
      z = this.z;
    }
  }

  public static class Vector3Extensions
  {
    // Option 2
    //public static void Deconstruct(this Vector3 vector, out double x, out double y, out double z)
    //{
    //  x = vector.x;
    //  y = vector.y;
    //  z = vector.z;
    //}
  }

  public class CustomDeconstruct
  {
    public void Run()
    {
      Vector3 vector = new Vector3(10, 3, 20);

      OldWay(vector);
      NewWay(vector);
    }

    static void OldWay(Vector3 vector)
    {
      double x, y, z;
      vector.Deconstruct(out x, out y, out z);
      Console.WriteLine(z);
    }

    static void NewWay(Vector3 vector)
    {
      var (x, y, z) = vector;
      // or (double x, double y, double z) = vector;
      // or (var x, var y, var z) = vector;
      Console.WriteLine(z);
    }
  }
}
