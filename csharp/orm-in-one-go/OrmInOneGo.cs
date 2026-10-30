public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        using var db = database;
        db.BeginTransaction();
        db.Write(data);
        db.EndTransaction();
        
    }

    public bool WriteSafely(string data)
    {
        using var db = database;
        try
        {
            db.BeginTransaction();
            db.Write(data);
            db.EndTransaction();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
