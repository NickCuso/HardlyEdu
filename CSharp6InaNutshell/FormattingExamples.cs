using System;

internal class FormattingExamples
{
  internal void Run()
  {
    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("de-de");
    // Agenda..

    //Parse();
    //FormatInfo();
    //Invariant();
    //FormatsAndParsing();
    //FormatStrings();
    //CustomFormatProvider();
    //DateStrings();
    //DateStyles(); 
    //ConvertClass();
    //XmlConvertExample();
    //TypeConverters();
    BitConverterExample();

    // Globalization checklist 257
  }

  void Parse()
  {
    string t = "true";
    bool b = bool.Parse(t); // If t is not a valid format, throw exception

    if(bool.TryParse(t, out b))
    {
      Console.WriteLine(b);
    }
    // else b == false / default(T)

    Console.WriteLine(double.Parse("1.234")); // prints 1.234
    Console.WriteLine(double.Parse("1.234", System.Globalization.CultureInfo.GetCultureInfo("de-de"))); // prints 1234
  }

  void FormatInfo()
  {
    System.Globalization.NumberFormatInfo formatInfo = new System.Globalization.NumberFormatInfo()
    {
      CurrencySymbol = "!!$!!"
    };

    int number = 3;
    Console.WriteLine(number.ToString("C", formatInfo));

    // Also available DateTimeFormatInfo and CultureInfo

    System.Globalization.DateTimeFormatInfo dateFormat = 
      (System.Globalization.DateTimeFormatInfo)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.Clone();
    dateFormat.TimeSeparator = "-";

    Console.WriteLine(DateTime.Now.ToString(dateFormat));
  }

  void Invariant()
  {
    System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.InvariantCulture;
    Console.WriteLine(3.12.ToString("C", culture));

    // Invariant = American except for
    // Currency symbol (a sun symbol instead)
    // DateTime has leading 0s
    // Time is 24 hr (vs am/pm)
  }

  void FormatsAndParsing()
  {
    //int a = int.Parse("(10)"); // throws format exception
    int a = int.Parse("(10)", System.Globalization.NumberStyles.AllowParentheses);

    Console.WriteLine(a);
    // Can use Culture and FormatInfo as well

    // When parsing, o and CurrentCulture are accepted by default
  }

  void FormatStrings()
  {
    // Standard
    Console.WriteLine(2000.ToString("N0"));
    Console.WriteLine(2000.ToString()); // Assumes "G" for general
    // - Numbers smaller than 10^-4 scientific notation
    // - Decimals are rounded to 2 places from the limit of the float's percision (very minor)
    // --- use G17 for 'round trip' (to string then back to number)

    // Custom
    Console.WriteLine(2000.ToString("$#,#")); // You can include any other chars as well
  }

  void CustomFormatProvider()
  {
    // You can implement your own behaviour for format strings (like c for currency).
    // But you cannot create new format strings

    Console.WriteLine(3.ToString("c", new HD.HDFormatProvider()));
  }

  void DateStrings()
  {
    Console.WriteLine(DateTime.Now.ToString());

    Console.WriteLine(DateTime.Now.ToString("D"));
    Console.WriteLine(DateTime.Now.ToString("t"));
    Console.WriteLine(DateTime.Now.ToString("f")); // f == D t  (you can't create your own combinations)

    Console.WriteLine(DateTime.Now.ToString("u")); // formats like UTC, but does not actually convert
    Console.WriteLine(DateTime.Now.ToString("U")); // Converts and formats
  }

  void DateStyles()
  {
    Console.WriteLine(DateTime.Parse("2017-03-31"));

    Console.WriteLine(DateTime.Parse("2017-03-31",
      System.Globalization.CultureInfo.CurrentCulture,
      System.Globalization.DateTimeStyles.AssumeUniversal));

    // Also some Enum format strings: g, f (flags), d (number), x (hex)
  }

  void ConvertClass()
  {
    // Base types are bool, char, string, DateTime, DateTimeOffset, and numbers
    // All base types have convertions to/from every other base type
    // ...most fail.

    double d = 121.1212;
    Console.WriteLine(Convert.ToInt32(d));

    int number = 100;
    string binary = Convert.ToString(number, 2); // Only works for base 2, 8, 10, 16
    Console.WriteLine(binary);
    int andBack = Convert.ToInt32(binary, 2);
    Console.WriteLine(andBack);


    Type dataType = typeof(int);
    object a = "42";
    Console.WriteLine(Convert.ChangeType(a, dataType));

    string base64 = Convert.ToBase64String(new byte[] { 0, 0, 1 });
    Console.WriteLine(base64);
  }

  void XmlConvertExample()
  {
    Console.WriteLine(System.Xml.XmlConvert.ToString(true));
    Console.WriteLine(true);

    // Will format/case/etc for you - e.g. in XML it's "true" but true.ToString would be "True"
  }

  void TypeConverters()
  {
    System.ComponentModel.TypeConverter testConverter 
      = System.ComponentModel.TypeDescriptor.GetConverter(typeof(System.Drawing.Color));

    System.Drawing.Color result = (System.Drawing.Color)testConverter.ConvertFrom("cyan");
    var alt = System.Drawing.Color.FromName("cyan");

    Console.WriteLine(result);
    Console.WriteLine(alt == result);
  }

  void BitConverterExample()
  {
    double number = 10012.1212;

    byte[] data = BitConverter.GetBytes(number);
    Console.WriteLine(data.Length);
    double andBack = BitConverter.ToDouble(data, 0);
  }
}