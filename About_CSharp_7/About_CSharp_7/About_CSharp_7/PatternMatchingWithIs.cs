using System;

namespace HD
{
  public abstract class Enemy { }
  public class Tank : Enemy
  {
    public void Fire()
    {
      Console.WriteLine("boom");
    }
    public bool IsReady
    {
      get
      {
        return true;
      }
    }
  }
  public class Trouper : Enemy { }


  public class PatternMatchingWithIs
  {
    internal void Run()
    {
      Enemy exampleEnemy = new Tank();

      OldWay(exampleEnemy);
      Console.WriteLine("-");

      NewHotness(exampleEnemy);
    }

    void OldWay(Enemy enemy)
    {
      if(enemy is Tank)
      {
        Tank tank = (Tank)enemy;
        if(tank.IsReady)
        {
          tank.Fire();
        }
      } 
    }

    void NewHotness(Enemy enemy)
    {
      if(enemy is Tank tank && tank.IsReady)
      {
        tank.Fire();
      }
    }
  }
}
