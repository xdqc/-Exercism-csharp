using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        StreamReader reader = new StreamReader(inStream);
        string input = reader.ReadToEnd();
        string[] records = input.Split(Environment.NewLine);

        // int[5] indicates [match played ,win, draw, loss, points]
        Dictionary<string, int[]> teamStats = new Dictionary<string, int[]>();

        // process input
        foreach (var record in records)
        {
            if (record == "")
                continue;

            string[] entries = record.Split(';');
            string team1 = entries[0];
            string team2 = entries[1];
            string result = entries[2];

            // Add new teams to teamStats
            if (!teamStats.ContainsKey(team1))
            {
                teamStats.Add(team1, new int[5]);
            }
            if (!teamStats.ContainsKey(team2))
            {
                teamStats.Add(team2, new int[5]);
            }

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

        // caulculate points
        teamStats.ToList()
            .ForEach(t =>
            {
                t.Value[0] = t.Value[1] + t.Value[2] + t.Value[3];
                t.Value[4] = t.Value[1] * 3 + t.Value[2];
            });
        var teams = teamStats.OrderByDescending(t => t.Value[4]).ThenBy(t => t.Key);

        // output
        string output = "Team                           | MP |  W |  D |  L |  P" + Environment.NewLine;
        foreach (var team in teams)
        {
            output += $"{team.Key.PadRight(31)}|  {team.Value[0]} |  {team.Value[1]} |  {team.Value[2]} |  {team.Value[3]} |  {team.Value[4]}" + Environment.NewLine;
        }
        StreamWriter writer = new StreamWriter(outStream);
        writer.Write(output);
        writer.Flush();
        outStream.Position = 0;
    }  
}

