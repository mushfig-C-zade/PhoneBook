using System.Linq.Expressions;

namespace PhoneBook.Extentions;

public static class LinqExtentions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition,
            Expression<Func<T, bool>> predicate)
    {
        if (condition)
        {
            query = query.Where(predicate);
        }

        return query;
    }
}

