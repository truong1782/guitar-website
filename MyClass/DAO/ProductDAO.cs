using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
        public class ProductDAO
        {
            DBBanDanContext db = null;
            public ProductDAO()
            {
                db = new DBBanDanContext();
            }

            public List<PRODUCT> getList()
            {
                List<PRODUCT> list = db.PRODUCTs.ToList();
                return list;
            }
            public PRODUCT getRow(int id)
            {
                PRODUCT row = db.PRODUCTs.Where(x => x.IdProduct == id).FirstOrDefault();
                return row;
            }
            public int Insert(PRODUCT row)
            {
                db.PRODUCTs.Add(row);
                db.SaveChanges();
                return row.IdProduct;
            }
            public int Update(PRODUCT row)
            {
                db.Entry(row).State = EntityState.Modified;
                db.SaveChanges();
                return row.IdProduct;
            }
            public int Delete(PRODUCT row)
            {
                db.PRODUCTs.Remove(row);
                db.SaveChanges();
                return row.IdProduct;
            }
        }
    }
