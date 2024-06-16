using System.Security.AccessControl;
using System.Security.Cryptography;

namespace J1P2_PRO_TextAdventure.CommandInput
{
    internal class CommandRunner
    {
        private readonly Dictionary<int, Command> commands;
        private readonly Dictionary<int, Func<string bool>> commandFunctions;


        public CommandRunner()
        {
            commands = new Dictionary<int, Command>();
            commandFunctions = new Dictionary<int, Func<bool>>();
        }


        /// <summary>
        /// get's the command key
        /// </summary>
        /// <param name="_input"></param>
        /// <returns>null if none is found, if one is found the key is returned</returns>
        public (int?, string) GetCommandKey(string _input)
        {
            for (int index = 0; index < commands.Count; index++)
            {
                if (commands[index].IsThisCommand(_input) == true)
                {
                    return (index, commands[index].GetArgument());
                }
            }

            return null;
        }

        /// <summary>
        /// runs the command at the index
        /// </summary>
        /// <param name="_commandKey">sets the index for the command to run</param>
        /// <returns>true/false based on the command's success</returns>
        public bool RunCommand(int _commandKey, string _argument)
        {
            return commandFunctions[_commandKey](_argument);
        }

        /// <summary>
        /// adds a command
        /// </summary>
        /// <param name="_command">sets the command to be added</param>
        /// <param name="_function">sets the function to be ran upon running the command</param>
        public void AddCommand(Command _command, Func<string, bool> _function)
        {
            int newIndex = commands.Count;

            commands.Add(newIndex, _command);
            commandFunctions.Add(newIndex, _function);
        }
    }
}
