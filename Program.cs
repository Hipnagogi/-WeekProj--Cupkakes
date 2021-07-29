using System;
using System.Collections.Generic;


public class Program
{
    public static FromTo Period { get; set; } = null;
    public static int ReportType { get; set; } = -1;

    public static DateTime Today { get; private set; }
    public static int CurrentMenuId { get; set; } = 0;
    static void Main(string[] args)
    {
        // Update today date
        Today = DateTime.Today;
        
        // ### GENERATE MENU Collection

        // Intro
        ScreenText.PrintLogo();
        // Load files 
        var basic = new DataRead("Basic", @"D:\Dokumenty\Programowanie\Your weekly project\1\Basic.txt",5);
        var delux = new DataRead("Delux", @"D:\Dokumenty\Programowanie\Your weekly project\1\Delux.txt",6);
        var total = new DataRead("Total", @"D:\Dokumenty\Programowanie\Your weekly project\1\Total.txt");
        DataRead[] files = { basic, delux, total };

        //Menu Creation
        Menu.GenerateMenu(); 

        bool showMenu = true;
        CurrentMenuId = 0;
        int menuItemId = 0;
        while (showMenu)
        {
            if (MenuItem.NextMenu >= 0)
                CurrentMenuId = MenuItem.NextMenu;
            ScreenText.Print(Menu.mainMenu[CurrentMenuId]);
            if (Menu.ParseInput(Console.ReadLine(), out int temp))
            {
                menuItemId = temp;
                if (Menu.mainMenu[CurrentMenuId].MenuItems[menuItemId].ShowMenu)
                {   

                    Menu.mainMenu[CurrentMenuId].MenuItems[menuItemId].Action(Menu.mainMenu[CurrentMenuId].MenuItems[menuItemId]);
                   
                    if (Period != null && ReportType != -1)
                    {
                        Report report = new Report(Period);
                        //Można generować raport.
                        switch (ReportType)
                        {
                            case 1:
                                report.GenerateReport(basic, report, "Basic");
                                break;
                            case 2:
                                report.GenerateReport(delux, report, "Delux");
                                break;
                            case 3:
                                report.GenerateReport(total, report, "Total");
                                break;
                        }
                        Console.ReadKey();
                        showMenu = false;
                    }
                }
                else
                    showMenu = false;
            }
            else
                ScreenText.Print(); // Wrong user input
           // Console.ReadKey();
        }
        //Exit
        System.Environment.Exit(0);
    }
}