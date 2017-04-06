using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  public class RefReturns
  {
    int[] numbersForOldExample = new[] { 1, 2, 3 };
    int[] numbersForNewExample = new[] { 1, 2, 3 };

    public void Run()
    {
      OldWay();
      Console.WriteLine("-");
      NewHotness();
    }

    void OldWay()
    {
      int index = GetIndexForExample();
      int value = numbersForOldExample[index];
      if(value > 1)
      {
        numbersForOldExample[index] = 0;
      }

      Console.WriteLine(numbersForOldExample[1]);
    }

    int GetIndexForExample()
    {
      return 1;
    }

    void NewHotness()
    {
      ref int number = ref GetExample();
      if(number > 1)
      {
        number = 0;
      }

      // FYI can use as non-ref as well
      int nonRefNumber = GetExample();
      nonRefNumber = 10000;

      Console.WriteLine(numbersForNewExample[1]);
    }

    ref int GetExample()
    {
      return ref numbersForNewExample[1];
    }
  }
}
