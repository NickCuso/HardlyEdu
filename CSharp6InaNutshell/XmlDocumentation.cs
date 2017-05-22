using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
  /// <summary>
  /// Why XML?
  ///  - Intellisence
  ///  - Auto generated docs
  /// </summary>
  public class XmlDocumentation
  {
    /// <summary>
    /// A GUID for this user
    /// </summary>
    public readonly int id;

    /// <summary>
    /// My name is very important to me.
    /// </summary>
    public readonly string name;

    /// <summary>
    /// Creates an Example! :)
    /// 
    /// ... yup.
    /// </summary>
    /// <param name="id">A unique ID for yourself.  Note that renames will stay in sync</param>
    /// <param name="name">Your name</param>
    /// <remarks>
    /// Everything you ever wanted to know... 
    /// about
    /// stuff.
    /// </remarks>
    /// <MyCustomXMLTag>For something neat!</MyCustomXMLTag>
    public XmlDocumentation(int id, string name)
    {
    }
  }
}
