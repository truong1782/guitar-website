using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.DAO
{
    public class UserDAO
    {
        DBBanDanContext db = null;
        public UserDAO()
        {
            db = new DBBanDanContext();
        }
        public USER getRow(string username, string password)
        {
            USER row = db.USERs.Where(x => x.UserName == username && x.Password == password &&
                                        x.IdRole != 5).FirstOrDefault();
            return row;
        }
    }
}
