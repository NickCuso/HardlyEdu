using System;
using System.Collections.Generic;



using System.Globalization;

namespace HD
{
  internal class MoreThanYouEverWantedToKnowAboutStrings
  {
    public void Run()
    {
      // Today's agenda..
      Characters();
      Strings();
      CreatingStrings();
      StringSplitJoin();
      Format();
      Equals();
      Sort();
      StringBuilder();
      Encodings();
      SurrogatePairs();
    }

    void Characters()
    {
      char c = 'a';
      System.Char newLine = '\n';

      Console.WriteLine(Char.ToUpper(c, CultureInfo.InvariantCulture)); 
      // invariant == english
      //Console.WriteLine(System.Char.ToUpperInvariant(c));

      Console.WriteLine(Char.IsWhiteSpace(newLine));
      Console.WriteLine(Char.GetUnicodeCategory(newLine));

      char iCharacter = 'i';
      Console.WriteLine(Char.ToUpper(iCharacter, CultureInfo.GetCultureInfo("tr-TR")) == 'I');
      Console.WriteLine(Char.ToUpper(iCharacter, CultureInfo.CurrentCulture) == 'I');
    }

    void Strings()
    {
      string hello = "Hello";
      System.String hi = "hi";

      string stars = new string('*', 100);
      Console.WriteLine(stars);

      char[] starCharacterList = stars.ToCharArray();
      string andBack = new string(starCharacterList);

      string unsafeString;
      unsafe
      {
        char* cStyleString = stackalloc char[10];
        for(int i = 0; i < 9; i++)
        {
          cStyleString[i] = (char)(i + (int)'a');
        }
        cStyleString[9] = (char)0;
        unsafeString = new string(cStyleString);
      }
      Console.WriteLine(unsafeString);

      string emptyString = string.Empty; // ""
      Console.WriteLine(string.IsNullOrEmpty(emptyString));
      Console.WriteLine(string.IsNullOrWhiteSpace(emptyString));

      for(int i = 0; i < hello.Length; i++)
      {
        Console.WriteLine(hello[i]);
      }
      foreach(var character in hello)
      {
        Console.WriteLine(character);
      }
      
      Console.WriteLine(hello.StartsWith("H", StringComparison.Ordinal)); // Ordinal means numeric (i.e. fast)
      Console.WriteLine(hello.EndsWith("O", StringComparison.OrdinalIgnoreCase));
      Console.WriteLine(hello.IndexOf("H", StringComparison.CurrentCultureIgnoreCase));
      Console.WriteLine(hello.LastIndexOfAny(new[] { 'H', 'J', 'X' }));
    }

    void CreatingStrings()
    {
      // immutable
      string mid = "12345".Substring(1, 3);
      Console.WriteLine(mid);

      string biggerString = "Hello!".Insert(5, ", Nick");
      Console.WriteLine(biggerString);

      Console.WriteLine("12".PadLeft(10, '_'));

      string messageWithWhitespace = "    hi  ";
      Console.WriteLine(messageWithWhitespace.Trim() == "hi");

      Console.WriteLine(messageWithWhitespace.Replace(' ', '_'));
      Console.WriteLine(messageWithWhitespace.Replace(" ", "_____"));
    }

    void StringSplitJoin()
    {
      string message = "Fox jumps over the moon";
      string[] words = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      for(int i = 0; i < words.Length; i++)
      {
        Console.WriteLine(words[i]);
      }

      string newMessage = string.Join("__", words);
      Console.WriteLine(newMessage);
    }

    void Format()
    {
      string hello = "hello";
      double number = 10_000.979_917_817_236_7;

      Console.WriteLine($@"{hello}
                          About 
                          Strings...{number,1000:N2} 
"); // , min width  : formatting

      Console.WriteLine(string.Format(
"{0}\r\n                          About\r\n                          Strings...{1,1000:N2}", hello, number));

    }

    void Equals()
    {
      string a = "a";
      string a2 = "A".ToLower();
      Console.WriteLine(a == a2); // value comparison

      object o = a;
      object o2 = a2;
      Console.WriteLine(o == o2); // reference comparison

      Console.WriteLine(o.Equals(o2));
    }

    void Sort()
    {
      List<string> words = new List<string>{ "M1", "dog", "m9", "m1", "M9" };
      words.Sort();
      foreach(string w in words)
      {
        Console.WriteLine(w);
      }

      Console.WriteLine();

      words.Sort(new Comparison<string>((a, b) => b.CompareTo(a))); // CompareTo return -1, 0, 1
      foreach(string w in words)
      {
        Console.WriteLine(w);
      }
    }

    void StringBuilder()
    {
      System.Text.StringBuilder builder = new System.Text.StringBuilder();
      builder.Append("Hi");
      builder.AppendFormat("{0,10:N0} blah", 100);

      Console.WriteLine(builder.ToString());

      builder.Length = 0; // Clears but never gets smaller..
    }

    void Encodings()
    {
      // ASCII (1 byte, limited char set), UTF-8 (1-4 bytes), UTF-16 (1-2 16-bit words), UTF-32 (32-bits)
      // GB18030 (chinese)

      // .NET uses UTF-16 for storage
      // Default for streams (and files) is UTF-8

      System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
      encoding = System.Text.Encoding.UTF8;

      byte[] data = encoding.GetBytes("Hello");
      string andBack = encoding.GetString(data);
    }

    void SurrogatePairs()
    {
      string test = "諭";

      Console.WriteLine(test);
      Console.WriteLine(test[0]);
      Console.WriteLine(test[1]);

      Console.WriteLine(test.Length);
      Console.WriteLine(System.Char.IsSurrogate(test[0]));

      int asNumber = System.Char.ConvertToUtf32(test[0], test[1]);
      Console.WriteLine(asNumber);
      string backAsString = System.Char.ConvertFromUtf32(asNumber);

      Console.WriteLine(backAsString == test);
    }
  }
}