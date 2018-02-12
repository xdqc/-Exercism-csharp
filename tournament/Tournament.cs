using System.IO;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

public static class Tournament
{
    static readonly Vector<float> win = Vector<float>.Build.Dense(new float[] { 1, 1, 0, 0, 3 });
    static readonly Vector<float> draw = Vector<float>.Build.Dense(new float[] { 1, 0, 1, 0, 1 });
    static readonly Vector<float> loss = Vector<float>.Build.Dense(new float[] { 1, 0, 0, 1, 0 });
    static Vector<float> process(Dictionary<string, Vector<float>> s, int r, string t)
    {
        if (!s.ContainsKey(t)) s[t] = Vector<float>.Build.Sparse(5);
        return r == 0 ? s[t].Add(draw) : r == 1 ? s[t].Add(win) : s[t].Add(loss);
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        // float[5] indicates [match played ,win, draw, loss, pofloats]
        var teamStats = new Dictionary<string, Vector<float>>();
        using (var reader = new StreamReader(inStream))
        {
            for (var record = default(string); (record = reader.ReadLine()) != null;)
            {
                string[] entries = record.Split(';');
                string team1 = entries[0];
                string team2 = entries[1];
                int result = entries[2] == "draw" ? 0 : entries[2] == "win" ? 1 : -1;
                teamStats[team1] = process(teamStats, result, team1);
                teamStats[team2] = process(teamStats, -result, team2);
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
