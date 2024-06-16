namespace J1P2_PRO_TextAdventure.CommandInput
{
    /// <summary>
    /// this is used to check if a command is in a curtain string
    /// </summary>
    internal class Command
    {
        public readonly string keyword;
        private readonly string[] arguments;


        /// <summary>
        /// defines a command with no argument
        /// </summary>
        /// <param name="_keyword">the keyword that is used to call the command</param>
        public Command(string _keyword)
        {
            keyword = _keyword;
            arguments = Array.Empty<string>();
        }

        /// <summary>
        /// defines a command with an argument
        /// </summary>
        /// <param name="_keyword">the keyword that is used to call the command</param>
        /// <param name="_arguments">all the available argument options in an array</param>
        public Command(string _keyword, string[] _arguments)
        {
            keyword = _keyword;
            arguments = _arguments;
        }


        /// <summary>
        /// checks if the value is attempting to run this command
        /// </summary>
        /// <param name="_value">the value to check</param>
        /// <returns>true if the command was tried to be ran, false if it is not</returns>
        public bool IsThisCommand(string _value)
        {
            return GetWords(_value).Contains(keyword);
        }

        /// <summary>
        /// checks if the value is attempting to run this command
        /// </summary>
        /// <param name="_valueWords">the valued to check</param>
        /// <returns>true if the command was tried to be ran, false if it is not</returns>
        public bool IsThisCommand(string[] _valueWords)
        {
            return _valueWords.Contains(keyword);
        }

        /// <summary>
        /// Gets the argument. ArgumentException is thrown if the string does not contain the command or if the command does not have any arguments
        /// </summary>
        /// <param name="_value">the value to be checked</param>
        /// <param name="_ignoredWords">sets the words to ignore</param>
        /// <returns>the argument, null if none was found</returns>
        /// <exception cref="ArgumentException"></exception>
        public string? GetArgument(string _value, string[] _ignoredWords)
        {
            int commandIndex, argumentStartIndex;
            string[] words;

            if (IsThisCommand(_value) == false)
                throw new ArgumentException($"{nameof(_value)}, The value must contain the command");

            if (arguments.Length == 0)
                throw new ArgumentException($"{nameof(_value)}, This command has no arguments");


            words = GetWords(_value);
            commandIndex = GetCommandIndex(words);
            argumentStartIndex = commandIndex + 1;

            for (int index = argumentStartIndex; index < words.Length; index++)
            {
                string word = words[index];

                if (arguments.Contains(word))
                    return word;
                else if (_ignoredWords.Contains(word))
                    continue;
                else break;
            }

            return null;
        }


        private int GetCommandIndex(string[] _words)
        {
            if (IsThisCommand(_words) == false)
                throw new ArgumentException("The value must contain the command");

            return _words.ToList().IndexOf(keyword);
        }

        /// <summary>
        /// gets the words from a given string
        /// </summary>
        /// <param name="_value">sets the value to be decided</param>
        /// <returns>the value as words</returns>
        private string[] GetWords(string _value)
        {
            return _value.Split(' ');
        }
    }
}