using System;

public class Rekord
{
	public int LP { get; private set; }
	public DateTime Date { get; private set; }
	private int price;
	public int SoldTotal { get; private set; }
	public int TotalCash { get; private set; }
	public Rekord(int lP, int price, int soldTotal, DateTime date )
	{
		LP = lP;
		this.price = price;
		SoldTotal = soldTotal;
		Date = date;
		TotalCash = this.price * SoldTotal;
	}




}
