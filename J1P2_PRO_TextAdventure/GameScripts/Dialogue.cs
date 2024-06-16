namespace J1P2_PRO_TextAdventure.GameScripts
{
    /// <summary>
    /// used for creating and going through dialogue chains
    /// </summary>
    internal class Dialogue
    {
        private readonly string[] dialogueLines; //declares a readonly variable which can only be assigned in the constructor
        private string continuePrompt; //declares a private string variable which means it can only be accessed in this class
        private int indent;

        /// <summary>
        /// the prompt that appears when asked to continue.
        /// </summary>
        public string ContinuePrompt //defines a property
        {
            get => continuePrompt; //is called upon getting a value from the property
            set => continuePrompt = value; //is called upon assigning a value to the property
        }


        /// <summary>
        /// sets the amount of spaces the dialogue should be from the edge
        /// </summary>
        public void SetIndent(int _value)
        {
            if (_value < 0) //runs the code below if _value is below 0
            { throw new ArgumentOutOfRangeException($"{nameof(_value)}", _value, $"{nameof(_value)} cannot be below 0"); } //throws an exception, nameof gets the literal name of a variable, class or method

            indent = _value; //assigns a value to a variable
        }


        /// <summary>
        /// initializes the dialogue object
        /// </summary>
        /// <param name="_dialogueLines">sets the lines of the dialogue chain</param>
        public Dialogue(params string[] _dialogueLines) //defines a constructor for the class Dialogue, the params keyword 
        {
            dialogueLines = _dialogueLines;
            continuePrompt = "<press any key to continue>";
            indent = 1; //sets the default indentation what 
        }

        public void Start()
        {
            ConsoleManager consoleManager = new();

            
            Console.CursorVisible = false; //hides the cursor in the console

            foreach (string line in dialogueLines) //loops through each item in the array
            {
                consoleManager.WriteAtColumn(indent, line + '\n'); //concatenates the string so newline (\n), is at the end


                consoleManager.FlipColors(); //flip's the console's colors
                consoleManager.WriteAtColumn(indent, continuePrompt); //writes to console
                Console.ResetColor(); //resets the console's color


                Console.ReadKey(true); //halts the thread until the user gives input, this input is intercepted to be empty

                consoleManager.ClearLine(); //clears the current line in the console.
            }

            Console.CursorVisible = true; //shows the cursor in the console
        }
    }
}
