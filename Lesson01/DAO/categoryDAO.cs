using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lesson01.Models.Data;
namespace Lesson01.DAO
{
    public class categoryDAO
    {
        DBBanDanContext db = null;

        public categoryDAO()
        {
            db = new DBBanDanContext();
        }

        public List<CATEGORY> getlist()
        {
            List<CATEGORY> list = db.CATEGORies.ToList();
            return list;
        }
    }
}