using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        // int[5] indicates [match played ,win, draw, loss, points]
        Dictionary<string, int[]> teamStats = new Dictionary<string, int[]>();

        using (var reader = new StreamReader(inStream))
        {
            // process input
            for (var record = default(string); (record = reader.ReadLine()) != null;)
            {

                string[] entries = record.Split(';');
                string team1 = entries[0];
                string team2 = entries[1];
                string result = entries[2];

                // Add new teams to teamStats
                if (!teamStats.ContainsKey(team1)) teamStats.Add(team1, new int[5]);
                if (!teamStats.ContainsKey(team2)) teamStats.Add(team2, new int[5]);

                switch (result)
                {
                    case "win":
                        teamStats[team1][1]++;
                        teamStats[team2][3]++;
                        break;
                    case "loss":
                        teamStats[team1][3]++;
                        teamStats[team2][1]++;
                        break;
                    case "draw":
                        teamStats[team1][2]++;
                        teamStats[team2][2]++;
                        break;
                    default:
                        break;
                }
            }
        }

        // caulculate points
        teamStats.ToList().ForEach(t =>
        {
            t.Value[0] = t.Value[1] + t.Value[2] + t.Value[3];  //matches played
            t.Value[4] = t.Value[1] * 3 + t.Value[2];           //points
        });

        var teams = teamStats.OrderByDescending(t => t.Value[4]).ThenBy(t => t.Key);

        string formatter = @"{0,-30} | {1,2} | {2,2} | {3,2} | {4,2} | {5,2}";

        using (var writer = new StreamWriter(outStream))
        {
            writer.WriteLine(string.Format(formatter, "Team", "MP", "W", "D", "L", "P"));
            foreach (var team in teams)
            {
                writer.WriteLine(string.Format(formatter, team.Key, team.Value[0], team.Value[1], team.Value[2], team.Value[3], team.Value[4]));
            }
        }
    }
}
