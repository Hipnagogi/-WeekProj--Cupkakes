using System;
using System.Collections.Generic;


public static class ScreenText
{
	//Print Logo Intro
	public static void PrintLogo()
	{
		Console.WriteLine(" $$$$$$\\                       $$$$$$\\            $$\\							");
		Console.WriteLine("$$  __$$\\                     $$  __$$\\           $$ |					");
		Console.WriteLine("$$ /  \\__ |$$\\   $$\\  $$$$$$\\  $$ /  \\__ | $$$$$$\\  $$ |  $$\\  $$$$$$\\  ");
		Console.WriteLine("$$ |      $$ |  $$ |$$  __$$\\ $$ |       \\____$$\\ $$ | $$  |$$  __$$\\ ");
		Console.WriteLine("$$ |      $$ |  $$ |$$ /  $$ |$$ |       $$$$$$$ |$$$$$$  / $$$$$$$$ |");
		Console.WriteLine("$$ |  $$\\ $$ |  $$ |$$ |  $$ |$$ |  $$\\ $$  __$$ |$$  _$$<  $$   ____|");
		Console.WriteLine("\\$$$$$$  |\\$$$$$$  |$$$$$$$  |\\$$$$$$  |\\$$$$$$$ |$$ | \\$$\\ \\$$$$$$$\\ ");
		Console.WriteLine(" \\______ /  \\______/ $$  ____/  \\______/  \\_______|\\__|  \\__| \\_______|");
		Console.WriteLine("                    $$ |                                              ");
		Console.WriteLine("                    $$ |                                              ");
		Console.WriteLine("                    \\__ |                                              ");
		Console.WriteLine("");
		Console.WriteLine("$$$$$$$\\                      $$\\             ");
		Console.WriteLine("$$  __$$\\                     \\__|               ");
		Console.WriteLine("$$ |  $$ |$$\\   $$\\  $$$$$$$\\ $$\\ $$$$$$$\\   $$$$$$\\   $$$$$$$\\  $$$$$$$\\ ");
		Console.WriteLine("$$$$$$$\\ |$$ |  $$ |$$  _____|$$ |$$  __$$\\ $$  __$$\\ $$  _____|$$  _____|");
		Console.WriteLine("$$  __$$\\ $$ |  $$ |\\$$$$$$\\  $$ |$$ |  $$ |$$$$$$$$ |\\$$$$$$\\  \\$$$$$$\\  ");
		Console.WriteLine("$$ |  $$ |$$ |  $$ | \\____$$\\ $$ |$$ |  $$ |$$   ____| \\____$$\\  \\____$$\\ ");
		Console.WriteLine("$$$$$$$  |\\$$$$$$  |$$$$$$$  |$$ |$$ |  $$ |\\$$$$$$$\\ $$$$$$$  |$$$$$$$  |");
		Console.WriteLine("\\_______ /  \\______/ \\_______/ \\__|\\__|  \\__| \\_______|\\_______/ \\_______/ ");
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("PRESS ANY KEY TO BEGIN....");
		Console.ReadKey();
	}

	//Print MenuHeader
	private static void PrintMenuHeader()
	{
		Console.WriteLine("===========================================================================");
		Console.WriteLine($"|| Today Date: {Program.Today.Date}");
		Console.WriteLine("===========================================================================");
		Console.WriteLine("                   MAIN MENU");
		Console.WriteLine("-------------------------------------------------------");
		Console.WriteLine("Press key corresponding to given option and press ENTER");
		Console.WriteLine("-------------------------------------------------------");
	}

	//Print report
	public static void Print(List<Rekord> reporeportRekord, Report report, string title)
	{

		int cupcakeTotal = 0;
		int revenue = 0;

		//  I should use Linq here!
		foreach (var r in reporeportRekord)
		{
			cupcakeTotal += r.SoldTotal;
			revenue += r.TotalCash;
		}

		
		FromTo okres = report.Period;
		string type = title;

		Console.WriteLine($"Report from: {okres.From} - to: {okres.To}");
		Console.WriteLine($"Number of {type} sold:  {cupcakeTotal}|  Total revenue:  {revenue} ");
		Console.WriteLine();
		Console.WriteLine("Show graph mode Y/N?");
	}



	// Print Chart
	public static void Print(int max, List<Rekord> data) //   będzie trzeba dodać obsługę okresu
	{

		foreach (Rekord rekord in data)
		{
			int xCount = 0;
			if (max != 0)
				xCount = rekord.SoldTotal * 100 / max;



			Console.Write($"| {rekord.Date.ToString("dd/mm/yyyy")} | {rekord.TotalCash} |");
			for (int i = 0; i < xCount; i++)
			{
				Console.Write("x");
			}
			Console.Write($"| {xCount}%");
			Console.WriteLine();
		}


	}
	// Print Unrecognised Command
	public static void Print()  
	{
		Console.WriteLine("Unrecognised command - press any key and try again");
		Console.ReadKey();
		Console.Clear();
	}
	public static void Print(Menu menu)
	{
		Console.Clear();
		PrintMenuHeader();
		foreach (var item in menu.MenuItems)
			Print(item.Value.MenuId, item.Value.MenuText);
	}
	
	// Print MenuItem
	public static void Print(int id, string tekst)
	{
		Console.WriteLine($"Press {id} to choose {tekst}");
	}
}
