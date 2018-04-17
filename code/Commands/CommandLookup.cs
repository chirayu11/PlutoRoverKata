using System.Collections.Generic;

namespace Rover
{
    public static class CommandLookup
    {
        public static IDictionary<char, IRoverCommand> Get(Terrain terrain)
        {
            var lookup = new Dictionary<char, IRoverCommand>();
            lookup.Add('F', new ForwardCommand());
            lookup.Add('B', new BackwardCommand());
            lookup.Add('L', new TurnLeftCommand());
            lookup.Add('R', new TurnRightCommand());
            lookup.Add('W', new WrapCommand(terrain));
            return lookup;
        }
    }
}