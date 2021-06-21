using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class CategoryDAO
    {
        DBBanDanContext db = null;
        public CategoryDAO()
        {
            db = new DBBanDanContext();
        }

        public List<CATEGORY> getList()
        {
            List<CATEGORY> list = db.CATEGORies.ToList();
            return list;
        }
        public CATEGORY getRow(int id)
        {
            CATEGORY row = db.CATEGORies.Where(x => x.IdCategory == id).FirstOrDefault();
            return row;
        }
        public int Insert(CATEGORY row)
        {
            db.CATEGORies.Add(row);
            db.SaveChanges();
            return row.IdCategory;
        }
        public int Update(CATEGORY row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
            return row.IdCategory;
        }
        public int Delete(CATEGORY row)
        {
            db.CATEGORies.Remove(row);
            db.SaveChanges();
            return row.IdCategory;
        }
    }
}
