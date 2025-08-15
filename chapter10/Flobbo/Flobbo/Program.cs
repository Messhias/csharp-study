var f = new Flobbo("blue yellow");
var sw = f.Snobbo();
f.Blobbo(f.Blobbo(f.Blobbo(sw), sw), sw);

public class Flobbo
{
    private string _zap;

    public Flobbo(string zap)
    {
        _zap = zap;
    }

    public bool Blobbo(StreamWriter sw)
    {
        sw.WriteLine(_zap);
        _zap = "green purple";
        return false;
    }

    public bool Blobbo(bool Already, StreamWriter sw)
    {
        if (Already)
        {
            sw.WriteLine(_zap);
            sw.Close();
            return false;
        }

        sw.WriteLine(_zap);
        _zap = "red orange";
        return true;
    }

    public StreamWriter Snobbo()
    {
        return new StreamWriter("macaw.txt");
    }
}