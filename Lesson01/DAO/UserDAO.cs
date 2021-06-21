using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lesson01.Models.Data;
namespace Lesson01.DAO
{
    public class UserDAO
    {
        DBBanDanContext db = null;
        public UserDAO()
        {
            db = new DBBanDanContext();
        }

        public USER getRow(string tdn,string mk)
        {
            USER row = db.USERs
                .Where(u => u.IdRole == 5 && (u.UserName == tdn || u.Email == tdn) && u.Password == mk)
                .FirstOrDefault();
            return row;
        }
    }
}