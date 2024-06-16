namespace J1P2_PRO_TextAdventure.Assets
{
    internal abstract class Command //defines abstract class, abstract classes can't make objects
    {
        private readonly string keyword;
        private readonly string[]? arguments;
        private string? argument;

        /// <summary>
        /// is <see langword="null"/> if no arguments have been assigned yet,<br />
        /// if an argument match was found this will be that value
        /// </summary>
        protected string? Argument { get => argument; }


        /// <summary>
        /// defines a regular command
        /// </summary>
        /// <param name="_keyword">the keyword that needs to be found</param>
        public Command(string _keyword)
        {
            keyword = _keyword;
            arguments = null;
            argument = null;
        }

        /// <summary>
        /// defines a command with arguments
        /// </summary>
        /// <param name="_keyword">the keyword that needs to be found</param>
        /// <param name="_arguments">the arguments that need to be found</param>
        public Command(string _keyword, params string[] _arguments)
        {
            keyword = _keyword;
            arguments = _arguments;
            argument = null;
        }

        /// <summary>
        /// checks if this was called in the string
        /// </summary>
        /// <param name="_value">the string to be checked</param>
        /// <returns>
        /// <see langword="true"/> if the command was meant to be called in <paramref name="_value"/>,<br />
        /// otherwise <see langword="false"/>
        /// </returns>
        public bool WasCalled(string _value)
        {
            if (_value.Contains(keyword) && arguments == null) //if the value contains the keyword and there were no arguments given
            {
                return true;
            }
            else if (_value.Contains(keyword)) //else if the value contains the keyword
            {
                argument = GetArgument(_value); //tries to get the argument

                if (argument != null) //if the argument is not null
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// checks <paramref name="_value"/> if it contains an argument from <see cref="arguments"/>
        /// </summary>
        /// <param name="_value">the value to be checked</param>
        /// <returns>the argument if one was found, <see langword="null"/> is returned if none was found</returns>
        /// <exception cref="ArgumentNullException" />
        private string? GetArgument(string _value)
        {
            if (arguments == null) //checks if arguments were given
            {
                throw new ArgumentNullException(nameof(arguments), "you need to assign this command arguments during construction to get an argument"); //throws exception
            }

            foreach (string argument in arguments) //goes through all available 
            {
                if (_value.Contains(argument)) //if the value contains the argument
                {
                    return argument; //return the argument
                }
            }

            return null; //return null if no argument was found
        }

        /// <summary>
        /// runs the command
        /// </summary>
        public abstract void Run();
    }
}
