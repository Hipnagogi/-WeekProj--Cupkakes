using System;
using System.Collections.Generic;

// plik z danymi z pojedynczego pliku txt
public class DataRead
{
    
   
    public string Name { get; set; } //nazwa zaczytanego pliku
    public string FileDir { get; set; } // Ścieżka pliku
    public int Price { get; private set; } // // cena
    public Rekord[] DataTable 
    {
        get 
        {
            return dataTable;
        }
        private set
        {
            dataTable = DataTable;
        }
    }
    private Rekord[] dataTable;
    

    public DataRead(string name, string fileDir,int price)
	{
        Name = name;
        FileDir = fileDir;
        Price = price;
        ReadData();
	}

    public DataRead(string name, string fileDir)
    {
        Name = name;
        FileDir = fileDir;
        Price = 1;
        ReadData();
    }
    public DataRead()
    {
        Price = 1;
    }



    public void ReadData() // Metoda do parsowania danych
    {
      string[] dataLines =  System.IO.File.ReadAllLines(FileDir);


      dataTable = new Rekord[dataLines.Length-1];

        for (int i = 1; i < dataLines.Length; i++)
        {

            int revenue = 0;
            Int32.TryParse(dataLines[dataLines.Length- i],out revenue);
            dataTable[i-1] = new Rekord(i, Price, revenue, Program.Today.AddDays(-i+1));
        }
    }
}
