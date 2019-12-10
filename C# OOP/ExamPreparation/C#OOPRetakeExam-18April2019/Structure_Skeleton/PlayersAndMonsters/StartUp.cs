namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var managerController = new ManagerController(
                new PlayerRepository(),
                new PlayerFactory(),
                new CardFactory(),
                new CardRepository(),
                new BattleField());

            var engine = new Engine(reader, writer, managerController);

            engine.Run();
        }
    }
}