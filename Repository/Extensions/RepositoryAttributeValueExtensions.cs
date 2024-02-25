using Entities.Models;
using Repository.Utility;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryAttributeValueExtensions
    {
        public static IQueryable<AttributeValue> Sort(this IQueryable<AttributeValue> attributeValues, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return attributeValues.OrderBy(e => e.AttributeId);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<AttributeValue>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return attributeValues.OrderBy(e => e.AttributeId);

            return attributeValues.OrderBy(orderQuery);
        }

    }
}
