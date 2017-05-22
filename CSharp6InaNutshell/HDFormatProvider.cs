using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HD
{
  public class HDFormatProvider : IFormatProvider, ICustomFormatter
  {
    string ICustomFormatter.Format(string format, object arg, IFormatProvider formatProvider)
    {
      if(format == null)
      {
        return "null";
      }

      if(format == "c")
      {
        return $"---> {arg}";
      }

      return arg.ToString();
    }

    object IFormatProvider.GetFormat(Type formatType)
    {
      return this;
    }
  }
}
