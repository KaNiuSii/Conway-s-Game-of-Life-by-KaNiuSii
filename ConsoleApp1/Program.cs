using ConsoleApp1;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Runtime.InteropServices;

internal class Program
{
    public static void ResizeScreen(ref GameScreen gameScreen)
    {
        Console.ResetColor();
        Console.WriteLine("Enter new size:");
        Console.Write("X Y: ");
        int x, y;
        var input = Console.ReadLine();
        if (input == null)
            return;
        string[] parts = input.Split(' ');
        if (parts.Length < 2 || !int.TryParse(parts[0], out x) || !int.TryParse(parts[1], out y))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        if (x == -1 || y == -1 || x >= 101 || y >= 101)
        {
            Console.WriteLine("Invalid size");
            return;
        }
        gameScreen = new GameScreen(x, y);
    }


    public static void DisplayColorSetting(GameScreen gameScreen)
    {
        Console.ResetColor();
        Console.WriteLine("Themes : \n");
        Console.WriteLine("\n1. Basic");
        Console.ResetColor();
        GameScreen basicTheme = new GameScreen(5,5);
        basicTheme.ShuffleScreen(5);
        basicTheme.DisplayScreen();
        Console.ResetColor();
        Console.WriteLine("\n2. RGB");
        GameScreen rgbTheme = new GameScreen(5, 5);
        rgbTheme.ShuffleScreen(5);
        rgbTheme.RGBTheme();
        rgbTheme.DisplayScreen();
        Console.ResetColor();
        Console.WriteLine("\n3. Nature");
        GameScreen natureTheme = new GameScreen(5, 5);
        natureTheme.ShuffleScreen(5);
        natureTheme.NatureTheme();
        natureTheme.DisplayScreen();
        Console.ResetColor();
        Console.WriteLine("\n4. Royal");
        GameScreen royalTheme = new GameScreen(5, 5);
        royalTheme.ShuffleScreen(5);
        royalTheme.RoyalTheme();
        royalTheme.DisplayScreen();
        Console.ResetColor();
        Console.Write("\n\nId (-1 to quit) : ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            return;
        }
        if (id < 1 || id > 4) return;
        if (id == 1) gameScreen.BasicTheme();
        if (id == 2) gameScreen.RGBTheme();
        if (id == 3) gameScreen.NatureTheme();
        if (id == 4) gameScreen.RoyalTheme();
        return;
    }

    public static void DisplayRandom(GameScreen gameScreen)
    {
        Console.Clear();
        gameScreen.DisplayScreen();
        Console.ResetColor();
        Console.Write("\nProvide amount of Frames to be randomize : ");
        int framesCount;
        while (!int.TryParse(Console.ReadLine(), out framesCount))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Provide amount of Frames to be randomize : ");
        }
        if (framesCount < 0) return;
        gameScreen.ShuffleScreen(framesCount);
        return;
    }
    public static int DisplayAnimation(GameScreen gameScreen)
    {
        Console.ResetColor();
        Console.WriteLine("\nProvide amount of Frames and duration (ms) you want to animate with :");
        Console.Write("Frames Count : ");
        int framesCount;
        while (!int.TryParse(Console.ReadLine(), out framesCount))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Frames Count : ");
        }
        if (framesCount < 0) return -2;
        Console.Write("Duration : ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Duration : ");
        }
        if (duration < 0) return -2;
        gameScreen.AnimationScreen(framesCount, duration);
        return 0;
    }
    public static int DisplayAddingCell(GameScreen gameScreen)
    {
        Console.ResetColor();
        Console.WriteLine("\nProvide with X and Y of a cell ( \"-1 -1\" to exit) :");
        Console.Write("\nX Y : ");
        int x, y;
        var input = Console.ReadLine();
        if (input == null)
            return 0;
        string[] parts = input.Split(' '); // split the input string into an array of strings
        if (parts.Length < 2)
        {
            Console.WriteLine("Invalid input");
        }
        else if (int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y))
        {
            if (x == -1 || y == -1)
                return -1;
            if (x >= gameScreen.Width && y >= gameScreen.Height)
                return -2;
            gameScreen.ChangeCell(y, x);
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
        return 0;
    }

    public static int DisplayMenu()
    {
        Console.WriteLine($"\nInsert id of an action:\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"1. Add/Remove Cells");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"2. Set Animation");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"3. Next Frame");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"4. Reset");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"5. Random cells");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"6. Colour Settings");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"7. Resize Grid");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"8. Quit");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n9. ? WHAT IS THIS ALL ABOUT with examples ?\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"Id : ");

        // Read user input and convert to integer
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Id : ");
        }
        if (input < 1 || input > 9) return -1;
        // Return user input
        Console.WriteLine($"Selected action: {input}\n");
        Console.ResetColor();
        return input;
    }
    public static void DisplayStart()
    {
        ConsoleColor[] colors = new ConsoleColor[]
        {
            ConsoleColor.Yellow, 
            ConsoleColor.Cyan,
            ConsoleColor.Magenta
        };

        string asciiArt = @"     _____                                      _                                           __   _ _  __     
    /  __ \                                    ( )                                         / _| | (_)/ _|    
    | /  \/ ___  _ __   _____      ____ _ _   _|/ ___    __ _  __ _ _ __ ___   ___    ___ | |_  | |_| |_ ___ 
    | |    / _ \| '_ \ / _ \ \ /\ / / _` | | | | / __|  / _` |/ _` | '_ ` _ \ / _ \  / _ \|  _| | | |  _/ _ \
    | \__/\ (_) | | | | (_) \ V  V / (_| | |_| | \__ \ | (_| | (_| | | | | | |  __/ | (_) | |   | | | ||  __/
     \____/\___/|_| |_|\___/ \_/\_/ \__,_|\__, | |___/  \__, |\__,_|_| |_| |_|\___|  \___/|_|   |_|_|_| \___|
                                           __/ |         __/ |                                               
                                          |___/         |___/                                                
                                _                _   __      _   _ _       _____ _ _                         
                               | |              | | / /     | \ | (_)     /  ___(_|_)                        
                               | |__  _   _     | |/ /  __ _|  \| |_ _   _\ `--. _ _                         
                               | '_ \| | | |    |    \ / _` | . ` | | | | |`--. \ | |                        
                               | |_) | |_| |    | |\  \ (_| | |\  | | |_| /\__/ / | |                        
                               |_.__/ \__, |    \_| \_/\__,_\_| \_/_|\__,_\____/|_|_|                        
                                       __/ |                                                                 
                                      |___/                                                                  
                                                                                                             
                                                                                                             
                                                                                                             
                                                                                                             
                                                                                                             
                                                                                                             
                                                                                                             
                                                                                                             ";
        Console.ForegroundColor = colors[0];

        foreach (string line in asciiArt.Split('\n'))
        {
            Console.WriteLine(line);
            Console.ForegroundColor = colors[(Array.IndexOf(asciiArt.Split('\n'), line) + 1) % colors.Length];
        }
        Console.ForegroundColor = colors[(1 % colors.Length)];
        Console.WriteLine("                                                  Press any key");
        Console.ResetColor();
        Console.ReadKey();
    }



    private static void Main(string[] args)
    {
        DisplayStart();
        Console.Clear();
        GameScreen gameScreen = new GameScreen(20,20);
        while(true)
        {
            Console.Clear();
            gameScreen.DisplayScreen();
            int choice = DisplayMenu();
            switch (choice)
            {
                case 1:
                    {
                        while(true)
                        {
                            Console.Clear();
                            gameScreen.DisplayScreen();
                            var check = DisplayAddingCell(gameScreen);
                            if (check == -2) continue;
                            if (check == -1) break;
                        }
                        break;
                    }
                case 2:
                    {
                        while (true)
                        {
                            Console.Clear();
                            gameScreen.DisplayScreen();
                            var check = DisplayAnimation(gameScreen);
                            if (check == -2) continue;
                            else break;
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        gameScreen.NextFrame();

                        break;
                    }
                case 4:
                    {
                        gameScreen.ResetScreen();
                        break;
                    }
                case 5:
                    {
                        DisplayRandom(gameScreen);
                        Console.Clear();

                        break;
                    }
                case 6:
                    {
                        Console.Clear();
                        DisplayColorSetting(gameScreen);
                        break;
                    }
                case 7:
                    {
                        Console.Clear();
                        ResizeScreen(ref gameScreen);
                        break;
                    }
                case 8:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                case 9:
                    {
                        string url = "https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life";
                        try
                        {
                            Process.Start(url);
                        }
                        catch
                        {
                            // hack because of this: https://github.com/dotnet/corefx/issues/10361
                            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                            {
                                url = url.Replace("&", "^&");
                                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                            }
                            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                            {
                                Process.Start("xdg-open", url);
                            }
                            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                            {
                                Process.Start("open", url);
                            }
                            else
                            {
                                throw;
                            }
                        }
                        break;
                    }
                default:
                    {
                        //nothing
                        break;
                    }
            }
        }
    }
}
