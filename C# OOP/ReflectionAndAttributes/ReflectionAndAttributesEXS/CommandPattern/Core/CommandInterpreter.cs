namespace CommandPattern.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using Commands;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var inputArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var command = (inputArgs[0] + "Command").ToLower();
            var commandArgs = inputArgs.Skip(1).ToArray();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(n => n.Name.ToLower() == command);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var instance = Activator.CreateInstance(commandType) as ICommand;
            
            var result = instance.Execute(commandArgs);

            return result;
        }
    }
}
