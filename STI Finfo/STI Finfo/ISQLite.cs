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
        // GUEST
        bool SaveRequest(Request request);
        List<Request> GetRequest();
        bool UpdateRequest(Request request);
        void DeleteRequest(int Id);
        // NO ID
        bool AdminSaveNoID(NoID request);

        List<NoID> GetNoID();

        bool UpdateNoID(NoID noID);
        void DeleteNoID(int id);

        bool DeleteNoIDss(NoID noID);
        // ADMIN NO ID


        bool AdminSaveNoID(AdminNoID request);

        List<AdminNoID> AdminGetNoID();

        bool AdminUpdateNoID(AdminNoID noID);
        void AdminDeleteNoID(int id);


    }
}