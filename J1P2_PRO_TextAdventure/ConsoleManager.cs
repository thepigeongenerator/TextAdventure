namespace J1P2_PRO_TextAdventure
{
    //utility classes can use static? look into this.
    internal class ConsoleManager
    {
        /// <summary>
        /// clears the current line
        /// </summary>
        public void ClearLine()
        {
            int line = Console.GetCursorPosition().Top; //gets the cursor position perpendicular to the top face

            Console.SetCursorPosition(0, line); //set's the cursor in the current line at position 0
            Console.Write(new string(' ', Console.BufferWidth)); //writes the space character over the entire width of the console
            Console.SetCursorPosition(0, line); //reset's the console's cursor position
        }

        /// <summary>
        /// flips the console's colors
        /// </summary>
        public void FlipColors()
        {
            (Console.ForegroundColor, Console.BackgroundColor) = (Console.BackgroundColor, Console.ForegroundColor); //sets foreground and background colors using a tuple
        }

        /// <summary>
        /// writes at a column in the console
        /// </summary>
        /// <param name="_column">sets the character position that should be written at</param>
        /// <param name="_value">the value to be written</param>
        public void WriteAtColumn(int _column, string _value)
        {
            int line = Console.GetCursorPosition().Top; //gets what row the cursor is on

            Console.SetCursorPosition(_column, line); //set's the cursor position in the console
            Console.Write(_value); //Writes to console without newline
        }
    }
}
