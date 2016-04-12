using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace ExecutionPlanVisualizer.Helpers
{
    public class EntityFramework5DatabaseHelper : DatabaseHelper
    {
        private ObjectParameterCollection parameters;

        public EntityFramework5DatabaseHelper(ObjectQuery objectQuery)
        {
            Connection = (objectQuery.Context.Connection as EntityConnection)?.StoreConnection;
            parameters = objectQuery.Parameters;//.Dump("params");
        }

        protected override DbCommand CreateCommand(IQueryable queryable)
        {
            var command = Connection.CreateCommand();
            command.CommandText = ((ObjectQuery)queryable).ToTraceString();//.Dump("command text");

            var copiedParameters = parameters.Select(parameter =>
            {
                var parameterCopy = command.CreateParameter();
                parameterCopy.ParameterName = parameter.Name;
                parameterCopy.Value = parameter.Value;
                return parameterCopy;
            }).ToArray();

            command.Parameters.AddRange(copiedParameters);

            return command;
        }
    }
}