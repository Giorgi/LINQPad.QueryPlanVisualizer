using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LINQPad;

namespace ExecutionPlanVisualizer.Helpers
{
    class DatabaseHelperFactory
    {
        public static DatabaseHelper Create<T>(DataContextBase dataContextBase, IQueryable<T> queryable)
        {
            if (dataContextBase != null)
            {
                return new LinqToSqlDatabaseHelper(dataContextBase);
            }

            var table = queryable as ITable;

            if (table != null)
            {
                return new LinqToSqlDatabaseHelper(table.Context);
            }

            var dataQueryType = typeof(DataContext).Assembly.GetType("System.Data.Linq.DataQuery`1");

            if (queryable.GetType().GetGenericTypeDefinition() == dataQueryType)
            {
                var contextField = queryable.GetType().GetField("context", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
                var context = contextField?.GetValue(queryable) as DataContext;

                if (context != null)
                {
                    return new LinqToSqlDatabaseHelper(context);
                }
            }

            return CreateEntityFrameworkDatabaseHelper(queryable);
        }

        private static DatabaseHelper CreateEntityFrameworkDatabaseHelper<T>(IQueryable<T> queryable)
        {
            var ef5query = queryable as ObjectQuery<T>;

            if (ef5query != null)
            {
                return new EntityFramework5DatabaseHelper(ef5query);
            }

            return new EntityFramework6DatabaseHelper();
        }

    }
}
