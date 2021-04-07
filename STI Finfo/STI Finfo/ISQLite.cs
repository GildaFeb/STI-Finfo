using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
namespace STI_Finfo
{
    public interface ISQLite
    {
        SQLiteConnection GetConnectionWithCreateDatabase();

        bool SaveRequest(Request request);

        List<Request> GetRequest();

        bool UpdateRequest(Request request);
        void DeleteRequest(int Id);
    }
}