using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class SliderDAO
    {
        DBBanDanContext db = null;
        public SliderDAO()
        {
            db = new DBBanDanContext();
        }

        public List<SLIDER> getList()
        {
            List<SLIDER> list = db.SLIDERs.ToList();
            return list;
        }
        public SLIDER getRow(int id)
        {
            SLIDER row = db.SLIDERs.Where(x => x.IdSlider == id).FirstOrDefault();
            return row;
        }
        public int Insert(SLIDER row)
        {
            db.SLIDERs.Add(row);
            db.SaveChanges();
            return row.IdSlider;
        }
        public int Update(SLIDER row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
            return row.IdSlider;
        }
        public int Delete(SLIDER row)
        {
            db.SLIDERs.Remove(row);
            db.SaveChanges();
            return row.IdSlider;
        }
    }
}
