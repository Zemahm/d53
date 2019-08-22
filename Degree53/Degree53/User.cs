using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Degree53
{
    class User
    {
        
            private ArrayList checkoutList;
            private double balance;//as the test only covers up to the total and mvp is end goal this will not be used and current progam will just assume payment is paid

            public User()
            {
                this.checkoutList = new ArrayList();

            }
            public double getSetBal { get { return this.balance; } set { this.balance = value; } }
            public ArrayList getSetList { get { return this.checkoutList; } set { this.checkoutList = value; } }

            public String totalPrice()
            {

                ArrayList tempItems = getSetList;
                int counter = tempItems.Count - 1;
                double deduct = 0.0;
                double preDeductTotal = 0.0;
                //calculates discount
                for (int g = (tempItems.Count - 1); g >= 0; g--)
                {//reverse iteration to avoid enumeration errors

                    Item i = ((Item)tempItems[g]);
                    // Console.WriteLine(i.toString());
                    double discount = i.getSetDiscount;
                    int trigger = i.getSetTrigger;
                    int numOfInstances = 0;
                    //Console.WriteLine("check1");

                    for (int j = tempItems.Count - 1; j >= 0; j--)
                    {
                        if (((Item)tempItems[j]) == i)
                        {
                            if (numOfInstances > 0)
                            {
                                tempItems.RemoveAt(j);
                                g--;
                            }


                            //as item is now removed

                            //Console.WriteLine(trigger);
                            numOfInstances++;
                        }

                    }
                    tempItems.Remove(i);

                    if (trigger > 0 && numOfInstances > 1)
                    {
                        deduct += i.getSetDiscount * (numOfInstances / trigger);

                    }

                    preDeductTotal += (numOfInstances * i.getSetUnitPrice);
                    //Console.WriteLine( i.getSetUnitPrice);

                }
                return (deduct + preDeductTotal).ToString("0.00");
            }
            public String listAll()
            {
                String items = "";
                foreach (Item item in checkoutList)
                {
                    items = items + item.toString() + "\n";
                }
                if (items == "")
                {
                    return "There are no items present.";
                }
                return items;

            }



        }
    
}
