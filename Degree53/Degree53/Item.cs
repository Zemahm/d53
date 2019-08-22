using System;
using System.Collections.Generic;
using System.Text;

namespace Degree53
{
    class Item
    {
        private String sku, desc;
        private double unitPrice, discount;
        //number of items needed to trigger discount
        private int trigger;
        private double totalDiscount;// total when discount is triggered
        public Item(String sku, String desc, double unitPrice, int trigger, double discount)
        {
            //basic item class
            this.sku = sku;
            this.desc = desc;
            this.unitPrice = unitPrice;
            this.trigger = trigger;
            this.discount = discount;
            this.totalDiscount = (discount + (trigger * unitPrice));
        }

        public double getSetUnitPrice { get { return this.unitPrice; } set { this.unitPrice = value; } }
        public int getSetTrigger { get { return this.trigger; } set { this.trigger = value; } }
        public double getSetDiscount { get { return this.discount; } set { this.discount = value; } }
        public double getSetTotalDiscount { get { return this.totalDiscount; } set { this.totalDiscount = value; } }
        public String getSetDesc { get { return this.desc; } set { this.desc = value; } }
        public String getSetSku { get { return this.sku; } set { this.sku = value; } }

        //native toString method
        public String toString()
        {
            String stringItem = "SKU:" + getSetSku + "    item description:" + getSetDesc + "    Discount " + getSetTrigger + " for " + getSetTotalDiscount.ToString("0.00") + " Base Price: " + getSetUnitPrice;//the extra param just for format


            return stringItem;
        }

    }
}
