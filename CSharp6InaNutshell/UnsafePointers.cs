using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  struct MyCustomStruct
  {
    public readonly int x;

    public MyCustomStruct(int x )
    {
      this.x = x;
    }
  }


  // Step 1: Update project to support unsafe
  public class UnsafePointers
  {
    public void Run()
    {
      Example();

      //Example2();
    }

    unsafe void Example()
    {
      int[] mySourceData = new int[] { 1, 2, 3, 9, 8, 8, 8, 8, 8, 8, };

      fixed (int* array = mySourceData) // Fixed here tells the garbage collector to Pin the object (do not move 'mySourceData')
      {
        int* pointer = array; // This is another pointer, but now it's one that can move
        for(int i = 0; i < mySourceData.Length; i++)
        {
          Console.WriteLine(*pointer); // Net net, this is faster than using safe arrays b/c no bounds checks
          pointer++;
        }
      } // At the end, garbage collector is free to do its thing again
    }

    unsafe void Example2()
    {
      MyCustomStruct customStruct = new MyCustomStruct(100); // Don't need to pin this because it's allocated to the stack
      MyCustomStruct* myPointer = &customStruct;
      Console.WriteLine(myPointer->x);
      Console.WriteLine((*myPointer).x);



      void* myVoidPointer = myPointer;
      MyCustomStruct* andBack = (MyCustomStruct*)myVoidPointer;
    }
  }
}
