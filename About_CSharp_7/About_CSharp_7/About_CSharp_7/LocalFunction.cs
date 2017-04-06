using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  public class LocalFunction
  {
    public void Run()
    {
      OldWay();
      Console.WriteLine("-");
      NewHotness();
    }

    void OldWay()
    {
      var sum = 0;
      for(int i = 0; i < 3; i++)
      {
        sum += OldSquare(i);
      }
      Console.WriteLine(sum);
    }

    int OldSquare(int x)
    {
      return x * x;
    }

    void NewHotness()
    {
      var sum = 0;
      for(int i = 0; i < 3; i++)
      {
        sum += NewSquare(i);
        int NewSquare(int x)
        {
          return x * x; // FYI + i is allowed (closures)
        }
      }
      Console.WriteLine(sum);
    }
  }
}
