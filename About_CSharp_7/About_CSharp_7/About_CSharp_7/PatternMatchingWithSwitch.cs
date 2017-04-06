using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  abstract class Shape { }
  class Rect : Shape { }
  class Circle : Shape
  {
    public void DoCircleStuff()
    {
      Console.WriteLine("Circle stuff");
    }
  }
  class Square : Shape
  {
    public bool IsBlack
    {
      get
      {
        return true;
      }
    }
    public void DoWhiteSquareStuff()
    {
      Console.WriteLine("White square stuff");
    }
    public void DoBlackSquareStuff()
    {
      Console.WriteLine("Black square stuff");
    }
  }

  public class PatternMatchingWithSwitch
  {
    internal void Run()
    {
      Shape exampleShape = new Square();

      OldWay(exampleShape);
      Console.WriteLine("-");

      NewHotness(exampleShape);



      Console.WriteLine("About null..");
      Square nullSquare = null;
      NewHotness(nullSquare);
    }

    void OldWay(Shape shape)
    {
      if(shape is Circle)
      {
        Circle circle = (Circle)shape;
        circle.DoCircleStuff();
      } else if(shape is Square)
      {
        Square square = (Square)shape;
        if(square.IsBlack)
        {
          square.DoBlackSquareStuff();
        } else
        {
          square.DoWhiteSquareStuff();
        }
      }
    }

    void NewHotness(Shape shape)
    {
      switch(shape)
      {
        default:
          Console.WriteLine("Always evaluated last");
          break;
        case Circle circle:
          circle.DoCircleStuff();
          break;
        case Square square when square.IsBlack:
          square.DoBlackSquareStuff();
          break;
        case Square square:
          square.DoWhiteSquareStuff();
          break;
        case null:
          Console.WriteLine("Null");
          break;
      }
    }
  }
}
