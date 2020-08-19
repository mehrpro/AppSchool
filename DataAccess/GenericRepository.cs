using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SchoolDataAccess
{
    public class GenericRepository<TEntity>:IRepository<TEntity>
    {
        private string schema;
        private string tableName;
        private string connectionString;
        List<PropertyModel> _propertyModels = new List<PropertyModel>();

        public GenericRepository()
        {
            var entityType = typeof(TEntity);
            var tableAttribute = entityType.GetCustomAttributes(typeof(TableAttribute), false).OfType<TableAttribute>()
                .FirstOrDefault();
            if (tableAttribute != null)
            {
                schema = tableAttribute.Schema;
                tableName = tableAttribute.Table;
            }
            else
            {
                schema = "dbo";
                tableName = entityType.Name;
            }

            foreach (var propertyInfo in entityType.GetProperties())
            {
                _propertyModels.Add(new PropertyModel()
                {
                    PropertyName = propertyInfo.Name,
                    ColumnName = propertyInfo.Name,
                    IsComputed = propertyInfo.GetCustomAttributes(typeof(ComputedColumnAttribute),false).Any(),
                    IsPrimeryKey = propertyInfo.GetCustomAttributes(typeof(PrimeryKeyAttribute),false).Any(),
                    Propertyinfo = propertyInfo

                });
            }

        }

        public GenericRepository(string _connectionString):this()
        {
            connectionString = _connectionString;
        }

        public int Add(TEntity entity)
        {
            StringBuilder insertStatment = new StringBuilder("INSERT INTO " + schema + "." + tableName + " ({columns}) VALUES ({values})");
            List<string> columnName = new List<string>();
            List<MySqlParameter> sqlParameters = new List<MySqlParameter>();
            List<string> sqlParameterName = new List<string>();
            var parameterCounter = 1;
            foreach (var property in _propertyModels)
            {
                if (property.IsComputed)
                    continue;
                columnName.Add(property.ColumnName);
                var parameterName = "Column" + parameterCounter++;
                sqlParameterName.Add(parameterName);
                var parameterValue = property.Propertyinfo.GetValue(entity);
                sqlParameters.Add(new MySqlParameter(parameterName,parameterValue));
            }

            insertStatment.Replace("{columns}",string.Join(",",columnName.Select(col=> col)));
            insertStatment.Replace("{values}", string.Join(",", sqlParameters.Select(para => "@" + para)));
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cammand = connection.CreateCommand();
                cammand.CommandText = insertStatment.ToString();
                foreach (var parameter in sqlParameters)
                {
                    cammand.Parameters.Add(parameter);
                }

                return cammand.ExecuteNonQuery();
            }
        }

        public int Remove(TEntity entity)
        {
            return 0;
        }

        public int Update(TEntity entity)
        {
            return 0;
        }
    }
}