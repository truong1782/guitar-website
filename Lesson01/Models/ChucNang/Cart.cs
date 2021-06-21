using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lesson01.Models.Data;
using Lesson01.Controllers;
namespace Lesson01.Controllers
{
    public class Cart
    {
        private PRODUCT product = new PRODUCT();
        public int quantity { get; set; }

        public PRODUCT PRODUCT { get => product; set => product = value; }

        public Cart(){}

        public Cart(PRODUCT product, int quantity)
        {
            this.PRODUCT = product;
            this.quantity = quantity;
        }
    }
}