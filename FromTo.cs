using System;

public class FromTo
{
	public DateTime From { get; set; }
	public DateTime To { get; set; }


	public FromTo(DateTime from, DateTime to )
	{
		this.From = from;
		this.To = to;
	}

	public static DateTime FirstDayOfWeek(DateTime date)
	{
		int days = 0;
		if (date.DayOfWeek == 0)
		{
			days = -6;
		}
		else
		{
			days = -((int)date.DayOfWeek - 1);
		}

		
		DateTime firstDWeek = date.AddDays(days);
		return firstDWeek;
	}
	public static DateTime FirstDayOfMonth(DateTime date)
	{
		DateTime firstDMonth = new DateTime(date.Year, date.Month, 1);
		return firstDMonth;
	}
	public static DateTime FirstDayOfYear(DateTime date)
	{
		DateTime firstDYear = new DateTime(date.Year, 1, 1);
		return firstDYear;
	}

	public static DateTime LastDayOfYear(DateTime date)
	{
		DateTime lastDYear = (new DateTime(date.Year + 1, 1, 1)).AddDays(-1);
		return lastDYear;
	}

	public static DateTime LastDayOfMonth(DateTime date)
	{
		DateTime lastDMonth;
		if (date.Month == 12)
		{
			lastDMonth = new DateTime(date.Year, 12, 31);
		}
		else
			lastDMonth = (new DateTime(date.Year, date.Month + 1, 1)).AddDays(-1);
		
				
		return lastDMonth;
	}
	public static DateTime LastDayOfWeek(DateTime date)
	{
		int add = 7 - (int)date.DayOfWeek;
		return date.AddDays(add);
	}

	public static bool CustomReportParse(string s, out FromTo customPeriod)
	{
		bool loop = true;
		s = s.Trim(' ');
		try
		{
			DateTime[] customDates = new DateTime[2];
			string[] str = s.Split('-');
			for (int i = 0; i < 2; i++)
			{
				string[] dataString = str[i].Split('/');
				customDates[i] = new DateTime(Int32.Parse(dataString[0]), Int32.Parse(dataString[1]), Int32.Parse(dataString[2]));
			}

			customPeriod = new FromTo(customDates[0],customDates[1]);
			ScreenText.Print($"Period: {customPeriod.From} - {customPeriod.To}");
			loop = false;
		}
		catch
		{
			ScreenText.Print("Wrong Input");
			customPeriod = null;
			loop = true;
		}


		return loop;
	}

}
