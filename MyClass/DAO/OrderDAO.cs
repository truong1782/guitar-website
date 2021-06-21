using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class OrderDAO
    {
        DBBanDanContext db = null;
        public OrderDAO()
        {
            db = new DBBanDanContext();
        }

        public List<ORDER> GetList()
        {
            List<ORDER> list = db.ORDERs.Include("ORDER_DETAIL").ToList();
            return list;
        }
        public List<ORDER_DETAIL> GetOrder_detail()
        {
            List<ORDER_DETAIL> list = db.ORDER_DETAIL.ToList();
            return list;
        }
        public ORDER GetRow(int id)
        {
            ORDER row = db.ORDERs.Include("ORDER_DETAIL.PRODUCT").Where(x => x.IdOrder == id).FirstOrDefault();
            return row;
        }
        public int Insert(ORDER row)
        {
            db.ORDERs.Add(row);
            db.SaveChanges();
            return row.IdOrder;
        }
        public int Update(ORDER row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
            return row.IdOrder;
        }
        public int Delete(ORDER row)
        {
            db.ORDERs.Remove(row);
            db.SaveChanges();
            return row.IdOrder;
        }
    }
}
