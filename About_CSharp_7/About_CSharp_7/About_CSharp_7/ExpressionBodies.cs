using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  class PersonTheOldWay
  {
    static Dictionary<int, string> names = new Dictionary<int, string>();
    int id = 1;

    public PersonTheOldWay(string name)
    {
      names.Add(id, name);
    }

    ~PersonTheOldWay()
    {
      names.Remove(id);
    }

    public string Name
    {
      get
      {
        return names[id];
      }
      set
      {
        names[id] = value;
      }
    }
  }
  class PersonNewHotness
  {
    static Dictionary<int, string> names = new Dictionary<int, string>();
    int id = 1;

    public PersonNewHotness(string name) => names.Add(id, name);

    ~PersonNewHotness() => names.Remove(id);

    public string Name
    {
      get => names[id];
      set => names[id] = value;
    }
  }

  public class ExpressionBodies
  {
    public void Run()
    {
      // Note these are the same, just using each of the classes above
      OldWay();
      NewWay();
    }

    void OldWay()
    {
      PersonTheOldWay person = new PersonTheOldWay("Bob");
      Console.WriteLine(person.Name);
    }

    void NewWay()
    {
      PersonNewHotness person = new PersonNewHotness("Bob");
      Console.WriteLine(person.Name);
    }
  }
}
