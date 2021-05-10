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
        bool UpdateNoID(NoID noId);

        void DeleteNoID(int id);

       
        //======================== ADMIN NO ID ================


        bool AdminSaveNoID(AdminNoID request);
        
        List<AdminNoID> AdminGetNoID();


        //============= ADMIN DATE SORTING ==============

        // ------ NO ID
        List<AdminNoID> GetNoIDToday();
        List<AdminNoID> GetNoIDYesterday();
        List<AdminNoID> GetNoIDLASTWEEK();
        List<AdminNoID> GetNoIDLASTMONTH();

        // ============ ADMIN DATE: GUEST ==================

        bool AdminSaveGuest(AdminRequest request);
        List<AdminRequest> GetGuestToday();
        List<AdminRequest> GetGuestYesterday();
    }
}