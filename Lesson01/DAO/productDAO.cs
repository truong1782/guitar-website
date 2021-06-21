using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lesson01.Models.Data;
namespace Lesson01.DAO
{
    public class productDAO
    {
        DBBanDanContext db = null;

        public productDAO()
        {
            db = new DBBanDanContext();
        }

        public List<PRODUCT> getlist(string slug)
        {
            List<PRODUCT> list = db.PRODUCTs.Where(p => p.CATEGORY.Slug == slug).ToList();
            return list;
        }
    }
}