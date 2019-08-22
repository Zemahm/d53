using System;
using System.Collections;

namespace Degree53
{
    //This class aggregates the main classes needed so the full program can work
    class Program
    {
        static void Main(string[] args)
        {
            ItemList availableItem = new ItemList();
            User user = new User();
            bool mainLoop = true;

            while (mainLoop)
            {
                // bool adminLoop = true;    
                Console.WriteLine("type shop to start or end to close the program");//or admin to edit trigger and discount/view items
                String input = Console.ReadLine();
                Console.WriteLine("All items \n" + availableItem.listAll());


                if (input.Equals("admin", StringComparison.InvariantCultureIgnoreCase)){//lengthy but deals with null values too
                    ArrayList val = new ArrayList();
                    while (true)
                    {
                        Console.WriteLine(" First press enter to start or cancel to cancel");

                        input = Console.ReadLine();
                        if (input.Equals("cancel", StringComparison.InvariantCultureIgnoreCase))
                        {
                            break;
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Enter discount (example -0.30)");
                                input = Console.ReadLine();
                                val.Add(input.Replace(" ", ""));//.replace used to get rid of white space so search doesnt fail
                                Console.WriteLine("Now enter the new trigger (number needed for discount to set off)");
                                input = Console.ReadLine();
                                val.Add(input.Replace(" ", ""));
                                Console.WriteLine("Now enter the base price");
                                input = Console.ReadLine();
                                val.Add(input.Replace(" ", ""));
                                Console.WriteLine("Now enter SKU");
                                input = Console.ReadLine();
                                val.Add(input.Replace(" ", ""));


                                String output = availableItem.updateDiscount(val);//returns output also
                                if (output.Equals("done", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    Console.WriteLine(output);
                                    Console.WriteLine("Discount updated \n All items \n" + availableItem.listAll());


                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(output);
                                }
                            }
                        }
                    }
                }

                else if (input.Equals("shop", StringComparison.InvariantCultureIgnoreCase))
                {
                    while (true)
                    {
                        Console.WriteLine("Enter a product code or type finish to checkout");
                        String sku = Console.ReadLine();
                        if (sku.Equals("finish", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (user.getSetList.Count > 0)
                            {
                                Console.WriteLine("Total price including discount: " + user.totalPrice());
                            }
                            else
                            {
                                Console.WriteLine("There are no items added to list");
                            }
                            break;
                        }
                        Object result = availableItem.searchItem(sku);
                        if (result.GetType() == typeof(Item))
                        {
                            user.getSetList.Add(result);
                            Console.WriteLine(user.listAll());
                        }




                    }

                }

                else if (input.Equals("end", StringComparison.InvariantCultureIgnoreCase))
                {
                    mainLoop = false;
                }

            }

        }
    }
}
