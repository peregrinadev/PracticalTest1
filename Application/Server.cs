using System;
using System.Collections.Generic;

namespace Application
{
    public class Server : IServer
    {
        private readonly IDishManager _dishManager;

        private string horario;

        public Server(IDishManager dishManager)
        {
            _dishManager = dishManager;
        }
        
        public string TakeOrder(string unparsedOrder)
        {
            try
            {
                Order order = ParseOrder(unparsedOrder);
                List<Dish> dishes = _dishManager.GetDishes(order, horario);
                string returnValue = FormatOutput(dishes);
                return returnValue;
            }
            catch (ApplicationException)
            {
                return "error";
            }
        }


        private Order ParseOrder(string unparsedOrder)
        {
            var returnValue = new Order
            {
                Dishes = new List<int>()
            };

            try
            {
                horario = unparsedOrder.Substring(0, unparsedOrder.IndexOf(",")).Trim();
            }
            catch
            {
                throw new ApplicationException("Formato incorreto");
            }

            if (!horario.Equals("manha", StringComparison.InvariantCultureIgnoreCase) &&
                !horario.Equals("manhã", StringComparison.InvariantCultureIgnoreCase) &&
                !horario.Equals("noite", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ApplicationException("É necessário definir o horario (manhã ou noite) antes de inserir o número dos pedidos");
            }

            var orderItems = unparsedOrder.Remove(0, unparsedOrder.IndexOf(",") + 1).Split(',');
            foreach (var orderItem in orderItems)
            {
                if (int.TryParse(orderItem, out int parsedOrder))
                {
                    returnValue.Dishes.Add(parsedOrder);
                }
                else
                {
                    throw new ApplicationException("Order needs to be comma separated list of numbers");
                }
            }
            return returnValue;
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var returnValue = "";

            foreach (var dish in dishes)
            {
                returnValue = returnValue + string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }

            if (returnValue.StartsWith(","))
            {
                returnValue = returnValue.TrimStart(',');
            }

            return returnValue;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
            {
                return string.Format("(x{0})", count);
            }
            return "";
        }
    }
}
