using System;

internal class DateTimeExamples
{
  internal void Run()
  {
    //TimeExamples();
    //DateExamples();
    //DateComparisions();
    //MathExamples();
    //Formatting();
    TimeZoneInfoExamples();
  }

  void TimeExamples()
  {
    TimeSpan a = new TimeSpan(hours: 2, minutes: 0, seconds: 10);
    TimeSpan b = TimeSpan.FromDays(2.001);
    TimeSpan c = DateTime.Now - DateTime.Now.Date;
    TimeSpan d = a - b;

    Console.WriteLine(a);
    Console.WriteLine(b);
    Console.WriteLine(c);
    Console.WriteLine(d);

    Console.WriteLine("--");

    Console.WriteLine(a.Minutes);
    Console.WriteLine(a.TotalMinutes); // (same for the DateTimes)
  }

  void DateExamples()
  {
    // Stores timezone as a flag 'Kind' - Local/Unspecified/Utc
    // 62-bits for tick count since 1/1/0001 (tick = 100ns) + 2 bits for the kind
    DateTime now = DateTime.Now;
    DateTime dateTimeExampleA = new DateTime(year: 2017, month: 3, day: 24);
    DateTime nowInUtc = now.ToUniversalTime();

    Console.WriteLine(now.Kind); // Local
    Console.WriteLine(dateTimeExampleA.Kind);   // Unspecified
    Console.WriteLine(nowInUtc.Kind); // Utc

    Console.WriteLine($"{nameof(now)}: {now}");
    Console.WriteLine($"{nameof(dateTimeExampleA)}: {dateTimeExampleA}");
    Console.WriteLine($"{nameof(nowInUtc)}: {nowInUtc}");

    // Stores as DateTime plus timezone as a short (16-bit) in minutes from UTC
    DateTimeOffset nowOffset = DateTimeOffset.Now;
    DateTimeOffset nowOffsetInUtc = nowOffset.ToUniversalTime();

    Console.WriteLine($"{nameof(nowOffset)}: {nowOffset}");
    Console.WriteLine($"{nameof(nowOffsetInUtc)}: {nowOffsetInUtc}");


    // Other cases..
    DateTime hebrew = new DateTime(5500, 1, 1,
      calendar: new System.Globalization.HebrewCalendar());
    Console.WriteLine($"{nameof(hebrew)}: {hebrew}");
    Console.WriteLine($"{nameof(hebrew.Kind)}: {hebrew.Kind}");

    DateTimeOffset offsetFromDateTime = new DateTimeOffset(dateTimeExampleA);
    DateTimeOffset orByCast = dateTimeExampleA;
    DateTime andBack = orByCast.DateTime;

    // Options when date is unassigned...
    DateTime minValue = DateTime.MinValue; // or max
    DateTime? nullableDate = null;
  }

  void DateComparisions()
  {
    DateTime a = new DateTime(year: 2017, month: 3, day: 24, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc);
    DateTime b = new DateTime(year: 2017, month: 3, day: 24, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Local);
    DateTime c = b.ToUniversalTime();

    Console.WriteLine(a);
    Console.WriteLine(b);
    Console.WriteLine(c);
    // Compares the ticks, not the kinds
    Console.WriteLine(a == b); // Different times due to the timezone, but true...
    Console.WriteLine(b == c); // Same point in time, but false...


    // This works
    Console.WriteLine(a.ToUniversalTime() == b.ToUniversalTime()); // false
    Console.WriteLine(b.ToUniversalTime() == c.ToUniversalTime()); // true

    DateTimeOffset aOffset = new DateTimeOffset(year: 2017, month: 3, day: 24, hour: 0, minute: 0, second: 0, offset: TimeSpan.FromHours(0));
    DateTimeOffset bOffset = new DateTimeOffset(year: 2017, month: 3, day: 24, hour: 0, minute: 0, second: 0, offset: TimeSpan.FromHours(8.5));
    DateTimeOffset cOffset = bOffset.ToUniversalTime();
    
    // This also compares as expected
    Console.WriteLine(aOffset == bOffset); // false
    Console.WriteLine(bOffset == cOffset); // true

    Console.WriteLine(bOffset.EqualsExact(cOffset)); // false b/c time zones are different
  }

  void MathExamples()
  {
    TimeSpan timeSpanA = TimeSpan.FromDays(1);
    TimeSpan timeSpanB = TimeSpan.FromDays(2);
    TimeSpan timeSpanC = timeSpanA + timeSpanB;

    DateTime dateA = DateTime.Now;
    DateTime dateLater = dateA + timeSpanC;
    DateTime dateOr = dateA.AddMonths(1);
  }

  void Formatting()
  {
    // default is Short date and Long time (plus offset if DateTimeOffset)
    // style is culture specific by default (os settings)
    DateTime now = DateTime.Now;
    Console.WriteLine(now.ToString("o")); // ignore culture. maybe serialize/deserialize 
  }

  void TimeZoneInfoExamples()
  {
    TimeZoneInfo localInfo = TimeZoneInfo.Local;
    Console.WriteLine(localInfo);
    Console.WriteLine(localInfo.StandardName);

    TimeZoneInfo aus = TimeZoneInfo.FindSystemTimeZoneById("W. Australia Standard Time");
    Console.WriteLine(aus);
    Console.WriteLine(aus.SupportsDaylightSavingTime);
    Console.WriteLine(aus.IsDaylightSavingTime(DateTime.Now));

    aus.IsAmbiguousTime(DateTime.Now); // true if a time which was repeated for daylight savings
    aus.IsInvalidTime(DateTime.Now); // true if the time was skipped due to day light sayings
    // aus.GetAmbiguousTimeOffsets(DateTime.Now); throws exception if not ambiguous
 


    // Comparisions that rely on timemoving forward will break if they use local datetime
    Console.WriteLine(DateTime.Now.IsDaylightSavingTime());

    System.Globalization.DaylightTime time = TimeZone.CurrentTimeZone.GetDaylightChanges(2017);
    Console.WriteLine(time.Start);
    Console.WriteLine(time.End);
    Console.WriteLine(time.Delta);

    DateTime forComparing = DateTime.UtcNow;
    Console.WriteLine(forComparing.ToLocalTime());
  }
}