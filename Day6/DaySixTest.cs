namespace DayFFive;

public class DaySixTest
{
    Queue<char> signalBuffer = new Queue<char>();

    private int getStreamStart(string signal)
    {
        for (var i = 0; i < signal.Length; i++)
        {
            signalBuffer.Enqueue(signal[i]);
            if (signalBuffer.Count > 14)
                signalBuffer.Dequeue();
            if (signalBuffer.Distinct().Count() == 14)
            {
                var str = String.Join("", signalBuffer.Select(p => p.ToString()));
                return signal.IndexOf(str) + 14;
            }
        }
        throw new Exception("Boom!");
    }


    [Fact]
    public void TestPart1()
    {
        var input = File.ReadAllText("../../../input.txt");
        var start = getStreamStart(input);
        Assert.Equal(3153, start);
    }



}