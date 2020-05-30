using SQLite;

namespace CollegePortalApplication
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

