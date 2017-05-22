using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  unsafe struct FixedSizeBuffer
  {
    public fixed int myDataArray[10];
  }

  public class UnsafeArrays
  {
    public void Run()
    {
      StackAlloc();

      FixedBufferExample();
    }

    public unsafe void StackAlloc()
    {
      int* myArray = stackalloc int[10];
      for(int i = 0; i < 10; i++)
      {
        Console.WriteLine(myArray[i]);
      }
    }

    public void FixedBufferExample()
    {
      FixedSizeBuffer myBuffer = new FixedSizeBuffer();
      for(int i = 0; i < 10; i++)
      {
        unsafe
        {
          Console.WriteLine(myBuffer.myDataArray[i]);
        }
      }
    }
  }
}
