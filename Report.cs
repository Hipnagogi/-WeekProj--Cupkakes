using System;
using System.Collections.Generic;

// Klasa odpowiedzialna za generowanie rapotów sprzedaży
// 1. Roczny
// 2. Miesięczny
// 3. Tygodniowy
public  class Report
{

	List<Rekord> reportRekords = new List<Rekord>(); 

	private FromTo period;
	public FromTo Period 
	{
		get { return period; }
		set { period = Period; } 
	}
	
	//Method used to evaluate count of days in given period.



	public Report()
	{ 
	
	}
	public Report(FromTo period)
	{
		this.period = period;
	}
	
	public void GenerateReport(DataRead data, Report report, string title)
	{
		//  data is a reference to basic, delux or total
		//  it has DataTable[] properties with parsed rows from original file. 
		foreach (Rekord rekord in data.DataTable)
		{
			if (rekord.Date >= report.period.From && rekord.Date <= report.period.To)
			{
				reportRekords.Add(rekord);
			}


		}


		ScreenText.Print(reportRekords, report, title);
		if (ParseChartInput(Console.ReadLine()))
		{
			ScreenText.Print(FindMax(reportRekords), reportRekords);
		} 

		

	}


	public static bool ParseChartInput(string s)
	{
		bool result = false;
		if (s == "")
			return false;

		if (s.Substring(0, 1).ToUpper() == "Y")
			result = true;
		else
			result = false;

		return result;
	}


	public static int FindMax(List<Rekord> data) //Method used to generate chart
	{
		int max = 0;
		foreach (Rekord rkrd in data)
		{
			if (rkrd.SoldTotal > max)
				max = rkrd.SoldTotal;
		}
		return max;
	}

}







