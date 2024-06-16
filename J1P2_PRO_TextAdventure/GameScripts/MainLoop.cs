using J1P2_PRO_TextAdventure.Assets;
using J1P2_PRO_TextAdventure.Assets.Commands;
using J1P2_PRO_TextAdventure.Assets.Environment;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class MainLoop
    {
        private readonly World world; //declares a readonly variable, private makes the variable only accessible in this class
        private readonly Command[] commands;


        public MainLoop(World _world) //constructor for mainLoop
        {
            world = _world; //assigns the value from the parameter _world to world
            commands = new Command[] //defines an array, holds all active commands in the game
            {
                new GoCommand(world, world.Player),
                new TakeCommand(world, world.Player),
                new EatCommand(world, world.Player),
                new UseCommand(world, world.Player),
                new MakeCommand(world.Player),
                new LookCommand(world, world.Player),
                new HelpCommand(world, world.Player),
            };
        }

        /// <summary>
        /// start of MainLoop
        /// </summary>
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray; //sets the consoles text color
            Console.WriteLine("hint: type \"help\" if you're stuck.");
            Console.ResetColor(); //resets the consoles color

            Loop(); //starts the loop
            EndDialogue(); //starts the end dialogue
        }

        /// <summary>
        /// gets player's input and tries to run the corresponding command
        /// </summary>
        private void Loop()
        {
            while (LoopCondition()) //checks if the condition is true it loops the code, if it is false it breaks out of the loop
            {
                string input;
                bool commandSuccess = false;

                input = GetInput("What do you want to do?"); //gets the input from the player

                foreach (Command command in commands) //loops through all commands 
                {
                    if (command.WasCalled(input)) //checks if the command was intended to be called in the input
                    {
                        command.Run(); //runs the command
                        commandSuccess = true; //sets the commands success to true
                        break; //breaks out of the foreach loop
                    }
                }

                if (commandSuccess == false) //checks if the command was not successful
                {
                    Console.WriteLine($"You don't know how to: \"{input}\"."); //writes the error message
                }
            }
        }

        /// <summary>
        /// checks if the player is on the mountain
        /// </summary>
        /// <returns><see langword="true"/> if the player's position is on a mountain tile. Otherwise <see langword="false"/></returns>
        private bool LoopCondition()
        {
            Tile playerTile = world.GetPlayerTile(); //gets the tile the player is currently located at

            if (playerTile.Type == TileType.mountain) //if the player's tile is a mountain tile
            {
                return false;
            }

            return true;
        }

        private string GetInput(string _message)
        {
            string? input; //declares a nullable string variable
            int cursorX, cursorY; //declares two variables

            Console.WriteLine($"\n{_message}"); //writes the message
            Console.Write(" > ");

            cursorX = Console.GetCursorPosition().Left; //gets the cursor's X position
            cursorY = Console.GetCursorPosition().Top; //gets the cursor's Y position

            do //does the code within
            {
                Console.SetCursorPosition(cursorX, cursorY); //sets the cursor's position
                input = Console.ReadLine(); //gets input from the user and stores it in a variable

                if (input != null) //checks if the input isn't null
                {
                    input = input.Trim(); //removes all space character in front and behind the input
                }
            }
            while (string.IsNullOrEmpty(input)); //if the condition is 'true' go back to do

            Console.SetCursorPosition(cursorX - 2, cursorY); //sets the cursor's position to where the '>' character is
            Console.WriteLine(' '); //clears the current character

            return input.ToLower(); //returns the input as lowercase
        }

        /// <summary>
        /// prints the final dialogue.
        /// </summary>
        private void EndDialogue()
        {
            Dialogue endDialogue;
            Dialogue finalDialogue;

            endDialogue = new(
                "it was a excruciating climb, but Jesse managed it just because of the beans.",
                "Jesse inspected the RV, the equipment didn't survive but luckily the built cool-box protected some food and water from the flames.",
                "Jesse started walking.",
                "and walking..",
                "and walking...",
                "after a full week of walking Jesse ran out of water",
                "Then finally, a car drove by.",
                "Jesse tried to hitch hike and the car stopped",
                "Jesse explained the situation and the person was glad to help");
            endDialogue.Start(); //starts the end dialogue


            finalDialogue = new("Finally when reaching Jesse's family, Jesse was very happy to see them and told them all about his adventure.")
            { ContinuePrompt = "the end." };

            finalDialogue.Start();
        }
    }
}
