    using MyClass.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace MyClass.DAO
    {
        public class CustomerDAO
        {
            DBBanDanContext db = null;
            public CustomerDAO()
            {
                db = new DBBanDanContext();
            }

            public List<USER> getList()
            {
                List<USER> list = db.USERs.Where(x => x.IdRole == 5).ToList();
                return list;
            }
            public USER getRow(int id)
            {
                USER row = db.USERs.Where(x => x.IdUser == id).FirstOrDefault();
                return row;
            }
            public int Delete(USER row)
            {
                db.USERs.Remove(row);
                db.SaveChanges();
                return row.IdUser;
            }
        }
    }

