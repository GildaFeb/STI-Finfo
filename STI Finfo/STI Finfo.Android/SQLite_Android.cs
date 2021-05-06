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
            bool res = false;
            try
            {
                string sql = $"UPDATE Request SET LastName='{request.LastName}',Firstname='{request.FirstName}',MiddleName='{request.MiddleName}'," +
                                $"Suffix='{request.Suffix}', Age='{request.Age}',Number='{request.Number}',Address='{request.Address}' " +
                                $"Email='{request.Email}',Department='{request.Department}', Transaction='{request.Transaction}'" +
                                $"TimeIn='{request.TimeIn}',TimeOut='{request.TimeOut}' WHERE Id={request.Id}";
                con.Execute(sql);
                res = true;
            }
            catch (Exception)
            {

            }
            return res;
        }
        public void DeleteRequest(int Id)
        {
            string sql = $"DELETE FROM Request WHERE Id={Id}";
            con.Execute(sql);
            return;
        }  
       

        // no id

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
       
        // --------------------- GET STUDENT WITH NO ID TODAY -------------



        // TODAYYYYYYY
        public List<AdminNoID> GetNoIDToday()
        {
            var GetDate= DateTime.Now.ToString("yyyy/M/d HH:mm:ss");
            string sql = "SELECT * FROM AdminNoID WHERE AdminDateNoID >= CAST('"+GetDate+"' AS DATE) ORDER BY AdminDateNoID DESC";
            List<AdminNoID> NoId = con.Query<AdminNoID>(sql);
            return NoId;
        }


       



    }
}