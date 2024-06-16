using J1P2_PRO_TextAdventure.Assets.Environment;
using System.Runtime.InteropServices;

namespace J1P2_PRO_TextAdventure.GameScripts
{
    internal class Game
    {
        /// <summary>
        /// starts the game
        /// </summary>
        public void Start()
        {
            World world = new(); //defines a new world object
            MainLoop mainLoop = new(world); //defines a new MainLoop object with 'world' passed as an argument in the constructor

            Welcome(); //show the title and start dialogue
            mainLoop.Start(); //starts the game
        }

        /// <summary>
        /// show the title and start dialogue
        /// </summary>
        private void Welcome()
        {
            Dialogue dialogue; //declares a dialogue variable
            Random random = new();
            string[] dialogueLines = {
                "After waking up, Jesse started preparing for a trip to their family.",
                "Jesse stepped in the RV and drove off.",
                "The sight was beautiful here in the mountains.",
                "There were lakes and trees everywhere.",
                "While distracted, Jesse didn't see the tree he was about to crash into",
                "Suddenly, Jesse realized their impending doom.",
                "Without thinking Jesse jumped out of the RV",
                "But not realizing that Jesse was on a mountain and rolled off the cliff",
                "A few moments later Jesse heard the fiery explosion which used to be the RV",
                "Then Jesse passed out.",
                "When waking up, Jesse felt very hungry."
            };


            if (random.Next(100) < 25) //returns true a curtain percentage of the time
            {
                dialogueLines[3] = "A potoo flew by, it was so majestic."; //changes the dialogue at index 3
            }

            dialogue = new Dialogue(dialogueLines); //assigns a new dialogue object to the variable

            ShowTitle();
            Console.Clear(); //clears the whole console
            dialogue.Start();
        }

        /// <summary>
        /// shows the game's title screen
        /// </summary>
        private void ShowTitle()
        {
            ConsoleManager consoleManager = new();


            Console.Clear(); //clears the console
            Console.Title = "Jesse and the terrible crash of the recreational vehicle: " + // + concatenates the string
                "the survival outside civilization underneath the great crystal blue sky"; //sets the console window title

                WriteFromFile("./Assets/ASCII/title.txt"); //generated from https://patorjk.com/software/taag/
                Console.WriteLine("Jesse and the terrible crash of the recreational vehicle: " +
                    "the survival outside civilization underneath the great crystal blue sky");

            Console.CursorVisible = false;
            consoleManager.FlipColors(); //flips the consoles colors
            Console.WriteLine("<press any key to start>");
            Console.ResetColor(); //resets the consoles colors
            Console.ReadKey(true); //pauses the script until input is given, 'true' sets if the input is intercepted so it isn't written to the console
            Console.CursorVisible = true;
        }

        /// <summary>
        /// writes all the lines from a file to console
        /// </summary>
        /// <param name="_filePath">specifies the path that should be written from</param>
        private void WriteFromFile(string _filePath)
        {
            string[] lines = File.ReadAllLines(_filePath); //Reads all lines from the file path as an array
            string value = string.Empty; //assigns an empty string variable to title

            foreach (string line in lines) //loops through each line in the array
            {
                value += line + '\n'; //adds the value to the string
            }

            Console.WriteLine(value); //writes all lines
        }
    }
}
