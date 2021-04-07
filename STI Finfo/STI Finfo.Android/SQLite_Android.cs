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
                string sql = $"UPDATE Request SET Name='{request.LastName}',Address='{request.FirstName}',PhoneNumber='{request.MiddleName}'," +
                                $"Email='{request.Suffix}' WHERE Id={request.Id}";
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
        }
    }
}