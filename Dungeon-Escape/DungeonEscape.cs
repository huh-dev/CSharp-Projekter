namespace DungeonEscape
{
    using System.Text.RegularExpressions;

    internal class DungeonEscape2
    {

        private static int[,] Map = new int[10,30];
        private static string[,] Game = new string[10,30];



        //MARK: Setup Game
        public static void SetupGame()
        {
            Console.WriteLine("Welcome to Dungeon Escape!");
            GenerateMap();
            
            // Simple game loop
            while (true)
            {
                Console.Clear();
                DisplayMap();
                MovePlayer();
            }
        }

        //MARK: Generate And Display Map
        private static void GenerateMap()
        {
            // Small front end loading screen
            Console.WriteLine("Generating Map...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            // Generate Map (Nested for loops to get the matrix correctly for the map)
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    // Set the top and bottom walls
                    if (i == 0 || i == Map.GetLength(0) - 1)
                    {
                        Map[i,j] = 1;
                    }
                    // Set the left and right walls
                    else if (j == 0 || j == Map.GetLength(1) - 1) 
                    {
                        Map[i,j] = 1;
                    }
                    // Lastly we set some empty space inside - to give the illusion of a dungeon
                    else
                    {
                        Map[i,j] = 0;
                    }
                }
            }
            
            // Set player start position
            Game[1,1] = "P";
        }

        private static void DisplayMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    // Check if there's a player at this position
                    if (Game[i,j] == "P")
                    {
                        Console.Write("P");
                    }
                    // Otherwise display wall or empty space
                    else
                    {
                        Console.Write(Map[i,j] == 1 ? "#" : " ");
                    }
                }
                // New line for the next row
                Console.WriteLine();
            }
        }


        private static void MovePlayer()
        {
            // Find current player position
            int playerRow = 0, playerCol = 0;

            // Nested for loops to find the player's position
            for (int i = 0; i < Game.GetLength(0); i++)
            {
                for (int j = 0; j < Game.GetLength(1); j++)
                {
                    if (Game[i,j] == "P")
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }
            
            Console.WriteLine("Where do you want to move? (W, A, S, D)");

            // Get user input and convert it to uppercase
            string input = Console.ReadLine().ToUpper();
            
            // Variables to store the new position
            int newRow = playerRow;
            int newCol = playerCol;
            
            // Calculate new position
            switch (input)
            {
                case "W":
                    newRow--;
                    break;
                case "A":
                    newCol--;
                    break;
                case "S":
                    newRow++;
                    break;
                case "D":
                    newCol++;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    break;
            }
            
            // Only move if within bounds - and stop it from moving into the game walls
            if (newRow >= 0 && newRow < Game.GetLength(0) && 
                newCol >= 0 && newCol < Game.GetLength(1) && 
                Map[newRow, newCol] != 1)  
            {
                Game[playerRow, playerCol] = null;  
                Game[newRow, newCol] = "P";        
            }
        }
    }
}