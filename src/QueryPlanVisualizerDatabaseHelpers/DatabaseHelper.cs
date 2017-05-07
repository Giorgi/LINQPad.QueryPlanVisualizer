using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionPlanVisualizer.Helpers
{
    public abstract class DatabaseHelper
    {
        private DbConnection _dbConnection;

      

        public DbConnection Connection
        {
            get
            {
                if (_dbConnection == null)
                {
                    throw new InvalidOperationException("Connection has not been set.");
                }
                return _dbConnection;
            }
            set { _dbConnection = value; }
        }

        public virtual string GetSqlServerQueryExecutionPlan<T>(IQueryable<T> queryable)
        {
            using (var command = CreateCommand(queryable))
            {
                try
                {
                    if (Connection.State != ConnectionState.Open)
                    {
                        Connection.Open();
                    }

                    using (var setStatisticsCommand = Connection.CreateCommand())
                    {
                        setStatisticsCommand.CommandText = "SET STATISTICS XML ON";
                        setStatisticsCommand.ExecuteNonQuery();
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.NextResult())
                        {
                            if (reader.GetName(0) == "Microsoft SQL Server 2005 XML Showplan")
                            {
                                reader.Read();
                                return reader.GetString(0);
                            }
                        }
                    }

                    return null;
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        public virtual async Task CreateIndexAsync(string script)
        {
            try
            {
                await Connection.OpenAsync();

                using (var command = Connection.CreateCommand())
                {
                    command.CommandText = script;
                    var result = await command.ExecuteNonQueryAsync();
                }
            }
            finally
            {
                Connection.Close();
            }
        }

        protected abstract DbCommand CreateCommand(IQueryable queryable);
    }
}