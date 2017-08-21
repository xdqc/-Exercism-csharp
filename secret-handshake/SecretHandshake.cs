using System;
using System.Linq;
using System.Collections.Generic;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var action = new Dictionary<byte, string>{
            [0b1] = "wink",
            [0b10] = "double blink",
            [0b100] = "close your eyes",
            [0b1000] = "jump"
        };

        var bin = Convert.ToByte(commandValue);

        var commands = action.Where(a => (a.Key & bin) != 0)
                             .Select(a => a.Value)
                             .ToArray();

        return (bin & 0b10000) == 0
            ? commands
            : commands.Reverse().ToArray();

    }
}
