using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Tournament
{
    static readonly int[] win = { 1, 1, 0, 0, 3 };
    static readonly int[] draw = { 1, 0, 1, 0, 1 };
    static readonly int[] loss = { 1, 0, 0, 1, 0 };
    static void process(Dictionary<string, int[]> s, int r, string t) =>
        s[t] = r == 0 ? s[t].Zip(draw, (x, y) => x + y).ToArray() :
               r == 1 ? s[t].Zip(win, (x, y) => x + y).ToArray() :
                        s[t].Zip(loss, (x, y) => x + y).ToArray();
    public static void Tally(Stream inStream, Stream outStream)
    {
        // int[5] indicates [match played ,win, draw, loss, points]
        Dictionary<string, int[]> teamStats = new Dictionary<string, int[]>();
        using (var reader = new StreamReader(inStream))
        {
            for (var record = default(string); (record = reader.ReadLine()) != null;)
            {
                string[] entries = record.Split(';');
                string team1 = entries[0];
                string team2 = entries[1];
                int result = entries[2] == "draw" ? 0 : entries[2] == "win" ? 1 : -1;
                if (!teamStats.ContainsKey(team1)) teamStats[team1] = new int[5];
                if (!teamStats.ContainsKey(team2)) teamStats[team2] = new int[5];
                process(teamStats, result, team1);
                process(teamStats, -result, team2);
            }
        }
        string formatter = @"{0,-30} | {1,2} | {2,2} | {3,2} | {4,2} | {5,2}";
        using (var writer = new StreamWriter(outStream))
        {
            writer.WriteLine(string.Format(formatter, "Team", "MP", "W", "D", "L", "P"));
            foreach (var team in teamStats.OrderByDescending(t => t.Value[4]).ThenBy(t => t.Key))
                writer.WriteLine(string.Format(formatter, team.Key, team.Value[0], team.Value[1], team.Value[2], team.Value[3], team.Value[4]));
        }
    }
}
