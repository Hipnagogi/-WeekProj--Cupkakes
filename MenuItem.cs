﻿using System;

public class MenuItem
{
	public static int NextMenu { get; set; } = -1;
	public static int LastMenu { get; set; } = -1;

	public bool ShowMenu { get; private set; }
	public string MenuText { get; private set; }
	public int MenuId { get; private set; }

	private int actionType; // what does this menu postition do?
	// 0 change menu position
	// 1 set FromTo
	// 2 set Report Type
	// 3 custom action
	private FromTo period; // what is the period for the report generated by this menu position
	private int reportType; // Does this menu position generate basic, delux, or total report.
	// 1 - basic
	// 2 - delux
	// 3 - total
	private int nextMenuID;

	public MenuItem(int menuId, string menuText)
	{
		MenuId = menuId;
		MenuText = menuText;
		ShowMenu = false;

	}

	public MenuItem(int menuId, string menuText, int nextMenuID)
	{
		MenuId = menuId;
		MenuText = menuText;
		ShowMenu = true;
		this.actionType = 0;
		this.nextMenuID = nextMenuID; // if next menu Id == -1 then we check last menu properties
	}

	public MenuItem(int menuId, string menuText, bool showMenu,  FromTo period)
	{
		MenuId = menuId;
		MenuText = menuText;
		ShowMenu = showMenu;
		this.actionType = 1;
		this.period = period;
		this.nextMenuID = 2;
	}
	public MenuItem(int menuId, string menuText, bool showMenu, int reportType)
	{
		MenuId = menuId;
		MenuText = menuText;
		ShowMenu = showMenu;
		this.actionType = 2;
		this.reportType = reportType;
	}
	public MenuItem(int menuId, string menuText, bool showMenu)
	{
		MenuId = menuId;
		MenuText = menuText;
		ShowMenu = showMenu;
		this.actionType = 3;
		this.nextMenuID = 2;
	}
	public void Action(MenuItem item) 
	{
		switch (item.actionType)
		{
			// 0 change menu position
			// 1 set FromTo
			// 2 set Report Type
			// 3 custom action
			case 0:
				if (item.nextMenuID == -1)
				{
					NextMenu = LastMenu;
					LastMenu = Program.CurrentMenuId;
				}
				else
				{
					NextMenu = item.nextMenuID;
					LastMenu = Program.CurrentMenuId;
				}
					
				break;
			case 1:
				Program.Period = item.period;
				NextMenu = item.nextMenuID;
				LastMenu = Program.CurrentMenuId;
				break;
			case 2:
				Program.ReportType = item.reportType;
				break;
			case 3:
				CustomAction();
				NextMenu = item.nextMenuID;
				LastMenu = Program.CurrentMenuId;
				break;
		}
	}
	private void CustomAction()
	{ 
		///
	}


}
