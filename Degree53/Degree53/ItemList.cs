using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Degree53
{
    class ItemList
    {
        //this class holds multiple items as well as the list searching code, only a single instance of this is used when running
        //this class holds the code for updating prices of specific items
        // a setup method has been added to simulate already setup list, realistically the items would be loaded up through a file using System.IO.File.ReadAll
        //-using a suitable text format then parsed by using .split 
        private ArrayList existingItems;
        public ItemList()
        {
            this.existingItems = new ArrayList();
            loadData();
        }

        public ArrayList getSetExistingItems { get { return this.existingItems; } private set { existingItems = value; } }

        //this method is to load in the data and is called in the constructor

        private void loadData()
        {
            //creates numerous items then adds to arraylist
            Item item1 = new Item("AAA", "apple", 0.50, 2, -0.10);
            Item item2 = new Item("AAB", "pineapple", 2.0, 5, -0.40);
            Item item3 = new Item("AAC", "bag o' peanuts", 3.50, 4, -0.10);
            Item item4 = new Item("AAD", "mint imperials", 1.50, 3, 0.30);
            Item item5 = new Item("AAE", "bread", 4.50, 0, 0);
            Item item6 = new Item("AAF", "cereal", 3.50, 2, -1.10);
            Item item7 = new Item("AAG", "eggs", 0.50, 4, -10);
            Item item8 = new Item("AAH", "milk", 1.0, 4, -10);
            Item item9 = new Item("AAI", "cheese", 4.50, 0, 0);
            Item item10 = new Item("AAQ", "low-fat milk", 0.50, 4, -10);



            existingItems.Add(item1);
            existingItems.Add(item2);
            existingItems.Add(item3);
            existingItems.Add(item4);
            existingItems.Add(item5);
            existingItems.Add(item6);
            existingItems.Add(item7);
            existingItems.Add(item8);
            existingItems.Add(item9);
            existingItems.Add(item10);





        }

        public object searchItem(String sku)
        {
            for (int i = 0; i <= this.existingItems.Count - 1; i++)
            {
                Item item = (Item)existingItems[i];
                Console.WriteLine(this.existingItems.Count);
                if (item.getSetSku.Equals(sku, StringComparison.InvariantCultureIgnoreCase))
                {
                   
                    return item;
                }
            }
            return "No item found";


        }
        private int getIndex(String sku)
        {
            for (int i = 0; i <= this.existingItems.Count - 1; i++)
            {
                Item item = (Item)existingItems[i];
                if (item.getSetSku.Equals(sku, StringComparison.InvariantCultureIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        public String listAll()
        {
            String items = "";
            foreach (Item item in existingItems)
            {
                items = items + item.toString() + "\n";
            }
            if (items == "")
            {
                return "There are no items present.";
            }
            return items;

        }

        //update price method, this would realistically saved by a streamwriter
        public String updateDiscount(ArrayList data)
        {


            double newDiscount;
            String sku;
            int trigger;
            double basePrice;



            try
            {
                newDiscount = Convert.ToDouble(data[0]);
            }
            catch
            {
                return "A number was not entered for discount";
            }

            try
            {
                trigger = Convert.ToInt32(data[1]);

            }
            catch
            {
                return "The data entered for the trigger was not a number";
            }
            try
            {
                basePrice = Convert.ToDouble(data[2]);

            }
            catch
            {
                return "The data entered for the trigger was not a number";
            }

            sku = (String)data[3];
            if (getIndex(sku) != -1)
            {

                Item oldItem = (Item)searchItem(sku);
                Item tempItem = new Item(sku.ToUpper(), oldItem.getSetDesc, basePrice, trigger, newDiscount);
                existingItems[getIndex(sku)] = tempItem;
                return "done";

            }



            return "item wasnt found";
        }


    }

}
