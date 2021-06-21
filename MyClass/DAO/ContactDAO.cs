using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class ContactDAO
    {
        DBBanDanContext db = null;
        public ContactDAO()
        {
            db = new DBBanDanContext();
        }

        public List<CONTACT> getList()
        {
            List<CONTACT> list = db.CONTACTs.ToList();
            return list;
        }
        public CONTACT getRow(int id)
        {
            CONTACT row = db.CONTACTs.Where(x => x.IdContact == id).FirstOrDefault();
            return row;
        }
        public int Insert(CONTACT row)
        {
            db.CONTACTs.Add(row);
            db.SaveChanges();
            return row.IdContact;
        }
        public int Update(CONTACT row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
            return row.IdContact;
        }
        public int Delete(CONTACT row)
        {
            db.CONTACTs.Remove(row);
            db.SaveChanges();
            return row.IdContact;
        }
    }
}
