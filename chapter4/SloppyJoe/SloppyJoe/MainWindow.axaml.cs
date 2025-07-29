using Avalonia.Controls;

namespace SloppyJoe;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MakeMenu();
    }

    private void MakeMenu()
    {
        MenuItem[] menuItems = new MenuItem[5];
        string guacamolePrice;

        for (int i = 0; i < 5; i++)
        {
            menuItems[i] = new MenuItem();
            menuItems[i].Generate();

            if (i >= 3)
            {
                menuItems[i].Breads = new[]
                {
                    "plain bagel", "onion bagel", "pumpernickel bagel", "everything bagel",
                };
                menuItems[i].Generate();
            }
        }
        Item1.Text = menuItems[0].Description;
        Price1.Text =  menuItems[0].Price;

        Item2.Text = menuItems[1].Description;
        Price2.Text =  menuItems[1].Price;

        Item3.Text = menuItems[2].Description;
        Price3.Text =  menuItems[2].Price;

        Item4.Text = menuItems[3].Description;
        Price4.Text =  menuItems[3].Price;

        Item5.Text = menuItems[4].Description;
        Price5.Text =  menuItems[4].Price;

        MenuItem specialItem = new MenuItem
        {
            Proteins = new[]
            {
                "Organic Ham", "Mushroom Patty", "Mortadella",
            },
            Breads = new[]
            {
                "a glutten free roll", "a wrap", "pita",
            },
            Condiments = new[]
            {
                "dijon mustard", "miso dressing", "au jus",
            },
        };
        specialItem.Generate();
            
            
        Item6.Text = specialItem.Description;
        Price6.Text =  specialItem.Price;

        MenuItem guacamoleMenuItem = new MenuItem();
        guacamoleMenuItem.Generate();
        guacamolePrice = guacamoleMenuItem.Price;

        Guacamole.Text = guacamolePrice;
    }
}