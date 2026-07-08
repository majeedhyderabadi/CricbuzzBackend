namespace MatchApi.Domain.Common;

public class Score
{
    public int Runs { get; private set; }
    public int? Wickets { get; private set; }

    private Score()
    {
    }

    public static Score Zero(bool tracksWickets) => new()
    {
        Runs = 0,
        Wickets = tracksWickets ? 0 : null
    };

    public void Apply(int runsDelta, int wicketsDelta)
    {
        Runs += runsDelta;

        if (wicketsDelta != 0)
        {
            Wickets = (Wickets ?? 0) + wicketsDelta;
        }
    }
}
