namespace Factory06
{
    public class MyBot : Bot
    {
        public override void Start(Game game)
        {
            game.Build(MachineType.Hat);
            game.Build(MachineType.Coat);
        }

        // TODO
        public override void Update(Game game)
        {
            game.UpdateMoneyAll();
        }

        public override void End(Game game)
        {
        }

    }
}
