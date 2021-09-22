using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order, string horario)
        {
            var returnValue = new List<Dish>();
            order.Dishes.Sort();
            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(dishType, horario, returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// Takes an int, representing an order type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="order">int, represents a dishtype</param>
        /// <param name="returnValue">a list of dishes, - get appended to or changed </param>
        private void AddOrderToList(int order, string horario, List<Dish> returnValue)
        {
            string orderName = GetOrderName(order, horario);
            var existingOrder = returnValue.SingleOrDefault(x => x.DishName == orderName);
            if (existingOrder == null)
            {
                returnValue.Add(new Dish
                {
                    DishName = orderName,
                    Count = 1
                });
            } else if (IsMultipleAllowed(order, horario))
            {
                existingOrder.Count++;
            }
            else
            {
                throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", orderName));
            }
        }

        private string GetOrderName(int order, string horario)
        {
            if (horario.Equals("noite", StringComparison.InvariantCultureIgnoreCase))
            {
                switch (order)
                {
                    case 1:
                        return "carne";
                    case 2:
                        return "batata";
                    case 3:
                        return "vinho";
                    case 4:
                        return "bolo";
                    default:
                        throw new ApplicationException("Order does not exist");

                }
            }
            else
            {
                switch (order)
                {
                    case 1:
                        return "ovos";
                    case 2:
                        return "torrada";
                    case 3:
                        return "café";
                    default:
                        throw new ApplicationException("Order does not exist");

                }
            }
        }


        private bool IsMultipleAllowed(int order,string horario)
        {
            if (horario.Equals("noite", StringComparison.InvariantCultureIgnoreCase))
            {
                switch (order)
                {
                    case 2:
                        return true;
                    default:
                        return false;

                }
            }
            else
            {
                switch(order)
                {
                    case 3:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}