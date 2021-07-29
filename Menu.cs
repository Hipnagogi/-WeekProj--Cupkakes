using System;
using System.Collections.Generic;

public struct Menu
{   
    public int MenuId { get; private set; }
    private string menuTitle;
    private Dictionary<int,MenuItem> menuItems;
    public Dictionary<int, MenuItem> MenuItems 
    {
        get { return menuItems; }

        set { menuItems = MenuItems; } 
    }

    public static List<Menu> mainMenu = new List<Menu>();
    public static void GenerateMenu()
    {
        mainMenu.Add(GenerateMainMenu());
        mainMenu.Add(GenerateSecondaryMenu());
        mainMenu.Add(GenerateReportMenu());

    }
    private static Menu GenerateMainMenu()
    {
        Menu menu = new Menu();
        menu.MenuId = 0;
        menu.menuTitle = "Choose report period" + System.Environment.NewLine + "####################" + System.Environment.NewLine;
        // Add MenuItems   
        menu.menuItems = new Dictionary<int, MenuItem>(); 
        menu.menuItems.Add (1,new MenuItem(1, "report for Present Year", true, new FromTo(FromTo.FirstDayOfYear(DateTime.Now),DateTime.Now))); 
        menu.menuItems.Add (2,new MenuItem(2, "report for Present Month", true, new FromTo(FromTo.FirstDayOfMonth(DateTime.Now),DateTime.Now))); 
        menu.menuItems.Add (3,new MenuItem(3, "report for Present Week", true, new FromTo(FromTo.FirstDayOfWeek(DateTime.Now),DateTime.Now))); 
        menu.menuItems.Add (4,new MenuItem(4, "More Options", 1)); 
        menu.menuItems.Add (0,new MenuItem(0, "EXIT")); 
        return menu;
    }

    
    private static Menu GenerateSecondaryMenu()
    {
        Menu menu = new Menu();
        menu.MenuId = 1;
        menu.menuTitle = "Choose report period" + System.Environment.NewLine + "####################" + System.Environment.NewLine;
        // Add MenuItems   
        menu.menuItems = new Dictionary<int, MenuItem>();
        menu.menuItems.Add(1,new MenuItem(1, "report for Last Year", true,new FromTo(FromTo.FirstDayOfYear(DateTime.Now.AddYears(-1)),FromTo.LastDayOfYear(DateTime.Now.AddYears(-1)))));
        menu.menuItems.Add(2,new MenuItem(2, "report for Last Month", true,new FromTo(FromTo.FirstDayOfMonth(DateTime.Now.AddMonths(-1)), FromTo.LastDayOfMonth(DateTime.Now.AddMonths(-1)))));
        menu.menuItems.Add(3,new MenuItem(3, "report for Last Week", true, new FromTo(FromTo.FirstDayOfWeek(DateTime.Now.AddDays(-7)),FromTo.LastDayOfWeek(DateTime.Now.AddDays(-7)))));
        menu.menuItems.Add(4,new MenuItem(4, "report for Custom Period", true));
        menu.menuItems.Add(0,new MenuItem(0, "Back to previouse menu", -1));
        return menu;
    }
    private static Menu GenerateReportMenu()
    {
        Menu menu = new Menu();
        menu.MenuId = 2;
        menu.menuTitle = "Choose Basic, Delux or Total Revenue report" + System.Environment.NewLine + "####################" + System.Environment.NewLine;
        // Add MenuItems   
        menu.menuItems = new Dictionary<int, MenuItem>();
        menu.menuItems.Add(1,new MenuItem(1, "report for Basic Cupcakes Sum and Revenue", true,1));
        menu.menuItems.Add(2,new MenuItem(2, "report for Delux Cupcakes Sum and Revenue", true,2));
        menu.menuItems.Add(3,new MenuItem(3, "report for Total Cupcakes Sum an Revenue", true,3));
        menu.menuItems.Add(4,new MenuItem(0, "Back to previouse menu", -1));
        return menu;
    }
    public static bool ParseInput(string input, out int i) // method to parse user input
    {
        int j = 0;
        bool parsSuccess = false;
        if (input != "")
        {
            parsSuccess = Int32.TryParse(input.Substring(0, 1), out j);
            parsSuccess = IsInputCorrectForSubMenu(j);
        }
        i = j;
        return parsSuccess;
    }
    private static bool IsInputCorrectForSubMenu(int i)
    {
        bool result = false;
        try
        {
            // put the code here that may raise exceptions
            if (mainMenu[Program.CurrentMenuId].MenuItems.Count > i)
                result = true;
        }
        catch
        {
            // handle exception here
            result = false;
        }
        return result; 
    }






}
