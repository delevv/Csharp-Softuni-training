namespace CommandPattern.Core.Commands
{
    using Contracts;
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            var name = args[0];

            return $"Hello, {name}";
        }
    }
}
