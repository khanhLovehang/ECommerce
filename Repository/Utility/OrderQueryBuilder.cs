using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.Utility
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderQuery<T>(string orderByQueryString)
        {
            // Splitting our query string to get the individual fields
            var orderParams = orderByQueryString.Trim().Split(',');

            // Using a bit of reflection to prepare the list of PropertyInfo
            // objects that represent the properties of our Attribute class
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                // Run through all the parameters and check for their existence
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];

                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                // If we don’t find such a property, we skip the step in the foreach loop and
                // go to the next parameter in the list
                if (objectProperty == null)
                    continue;

                // If we do find the property, we return it and additionally check if our
                // parameter contains “desc” at the end of the string.We use that to decide
                // how we should order our property
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                // We use the StringBuilder to build our query with each loop
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }

            // Removing excess commas
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
