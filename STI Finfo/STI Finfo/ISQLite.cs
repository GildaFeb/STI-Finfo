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
        // ==================== GUEST==================
        bool SaveRequest(Request request);
        List<Request> GetRequest();
        bool UpdateRequest(Request request);
        void DeleteRequest(int Id);
        //======================== NO ID =================
        bool SaveNoID(NoID request);

        List<NoID> GetNoID();

      
        void DeleteNoID(int id);

       
        //======================== ADMIN NO ID ================


        bool AdminSaveNoID(AdminNoID request);

       

        //============= ADMIN DATE SORTING ==============

        // ------ NO ID
        List<AdminNoID> GetNoIDToday();
      


    }
}