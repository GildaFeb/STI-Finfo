using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using STI_Finfo.Droid;
using SQLite;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLite_Android))]
namespace STI_Finfo.Droid
{
    class SQLite_Android : ISQLite
    {
     SQLiteConnection con;
        public SQLiteConnection GetConnectionWithCreateDatabase()
        {
            string fileName = "finfodb.db";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<Request>();
            con.CreateTable<NoID>();
            con.CreateTable<AdminNoID>();
            con.CreateTable<AdminRequest>();
            return con;
        }
        public bool SaveRequest(Request request)
        {
            bool res;
            try
            {
                con.Insert(request);
                res = true;
            }
            catch 
            {
                res = false;
            }
            return res;
        }
        public List<Request> GetRequest()
            
        {
            string sql = "SELECT * FROM Request";
            List<Request> request = con.Query<Request>(sql);
            return request;
        }



        public bool UpdateRequest(Request request)
        {
            bool res;
            try
            {
                string sql = $"UPDATE Request SET LastName='{request.LastName}',Firstname='{request.FirstName}',MiddleName='{request.MiddleName}', Suffix='{request.Suffix}', Age='{request.Age}',Address='{request.Address}', Email='{request.Email}',  Department='{request.Department}', TimeIn='{request.TimeIn}',  TimeOut='{request.TimeOut}',  sac='{request.sac}'   WHERE Id={request.Id}";
                con.Execute(sql);
                res = true;
                return res;
            }
            catch (Exception)
            {
                res = false;
                return res;
            }
            
        }
        public void DeleteRequest(int Id)
        {
            string sql = $"DELETE FROM Request WHERE Id={Id}";
            con.Execute(sql);
            return;
        }

        //============= ADMIN GUESTS =================

        public bool AdminSaveGuest(AdminRequest request)
        {
            bool res;
            try
            {
                con.Insert(request);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }


        // ================== NO ID
        public bool UpdateNoID(NoID request)
        {
            bool res;
            try
            {
                string sql = $"UPDATE NoID SET StudentNumber='{request.StudentNumber}',Account='{request.Account}',Reasons='{request.Reasons}' WHERE NoId={request.NoId}";
                con.Execute(sql);
                res = true;
                return res;
            }
            catch (Exception)
            {
                res = false;
                return res;
            }

        }
        public bool SaveNoID(NoID noID)
        {
            bool res;
            try
            {
                con.Insert(noID);
                res = true;
            }
            catch
            {
                res = false;
            }
            return res;
        }
        public List<NoID> GetNoID()
        {
            string sql = "SELECT * FROM NoID";
            List<NoID> noID = con.Query<NoID>(sql);
            return noID;
        }
      



        public void DeleteNoID(int Id)
        {
            string sql = "DELETE FROM NoID WHERE NoId='"+Id+"'";
            con.Execute(sql);
            return;
        }

      




        // ------------------ ADMIN -------------------


        public bool AdminSaveNoID(AdminNoID noID)
        {
            bool res;
            try
            {
                con.Insert(noID);
                res = true;
            }
            catch
            {
                res = false;
               
            }
            return res;
        }


        public List<AdminNoID> AdminGetNoID()
        {
            
            string sql = "SELECT * FROM AdminNoID ";
            List<AdminNoID> NoId = con.Query<AdminNoID>(sql);
            return NoId;
        }
        // --------------------- GET STUDENT BY DATE -------------



        // TODAYYYYYYY
        public List<AdminNoID> GetNoIDToday()
        {
            
            var GetDate = DateTime.Now.ToString("yyyy/M/d");
            string sql = "SELECT * FROM AdminNoID WHERE AdminDateNoID = '"+GetDate+ "'   ";
            List<AdminNoID> NoId = con.Query<AdminNoID>(sql);
            return NoId;
        }

        // YESTERDAYYYYYY

        public List<AdminNoID> GetNoIDYesterday()
        {


            var GetDateS = DateTime.Now.AddDays(-1).ToString("yyyy/M/d");
            
            string sql = "SELECT * FROM AdminNoID WHERE AdminDateNoID = '" + GetDateS + "'  "; 
            List<AdminNoID> NoId = con.Query<AdminNoID>(sql);
            return NoId;
        }
        // LAST WEEK

        public List<AdminNoID> GetNoIDLASTWEEK()
        {


            var GetDateS = DateTime.Now.AddDays(-7).ToString("yyyy/M/d");
            var GetDateSs = DateTime.Now.AddDays(-14).ToString("yyyy/M/d");
            string sql = "SELECT * FROM AdminNoID WHERE AdminDateNoID BETWEEN '" + GetDateSs + "' AND '" + GetDateS + "'  ";
            List<AdminNoID> NoId = con.Query<AdminNoID>(sql);
            return NoId;
        }
        //LAST MONTH
        public List<AdminNoID> GetNoIDLASTMONTH()
        {


            var GetDateS = DateTime.Now.AddDays(-30).ToString("yyyy/M/d");
            var GetDateSs = DateTime.Now.AddDays(-60).ToString("yyyy/M/d");
            string sql = "SELECT * FROM AdminNoID WHERE AdminDateNoID BETWEEN '" + GetDateS + "'  AND '" + GetDateSs + "'  ";
            List<AdminNoID> NoId = con.Query<AdminNoID>(sql);
            return NoId;
        }
        //------------------ GET GUEST BY DATE ------------------

        // TODAYYYYYYY
        public List<AdminRequest> GetGuestToday()
        {
            var GetDate = DateTime.Now.ToString("yyyy/M/d HH:mm:ss");
            string sql = "SELECT * FROM AdminRequest WHERE TimeOut >= CAST('" + GetDate + "' AS DATE) ORDER BY TimeOut DESC";
            List<AdminRequest> NoId = con.Query<AdminRequest>(sql);
            return NoId;
        }

        // YESTERDAYYYYYY
        public List<AdminRequest> GetGuestYesterday()
        {
            var GetDate = DateTime.Now.ToString("yyyy/M/d HH:mm:ss");

            string sql = "SELECT * FROM AdminRequest WHERE TimeOut >= CAST('" + GetDate + "' AS DATE) ORDER BY TimeOut DESC";
            List<AdminRequest> NoId = con.Query<AdminRequest>(sql);
            return NoId;
        }

    }
}