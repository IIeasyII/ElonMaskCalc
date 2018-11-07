using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.DB
{
    public class BaseRepository<T> : IEntityRepository<T> where T: class, IEntity
    {
        string connectionString;

        public BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual string TableName { get; set; }
        
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Удалить запись в таблице по Id
        /// </summary>
        /// <param name="id">Id записи</param>
        public void Delete(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    $"DELETE {TableName} WHERE Id = {id};",
                    connection);
                connection.Open();

                SqlDataReader executeCommand = command.ExecuteReader();

                executeCommand.Close();
                connection.Close();
            }
        }

        /// <summary>
        /// Получаем список всех записей таблицы
        /// </summary>
        /// <returns>Список объектов данной таблицы</returns>
        public IEnumerable<T> GetAll()
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    $"SELECT * FROM {TableName};",
                    connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var entity = Create();

                        var type = typeof(T);

                        var props = type.GetProperties();
                        

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var column = reader.GetName(i);

                            var prop = props.FirstOrDefault(p => p.Name == column);

                            if (prop != null)
                            {
                                prop.SetValue(entity, reader[i]);
                            }
                        }

                        result.Add(entity);
                    }
                }
                else
                {
                    result = null;
                }
                reader.Close();
                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Получает запись из таблицы по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Load(long id)
        {
            var result = Create();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "SELECT " + getAllProperties() + $" FROM {TableName} WHERE Id = {id};",
                    connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var type = typeof(T);

                        var props = type.GetProperties();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var column = reader.GetName(i);

                            var prop = props.FirstOrDefault(p => p.Name == column);

                            if (prop != null)
                            {
                                prop.SetValue(result, reader[i]);
                            }
                        }
                    }
                }
                else
                {
                    result = null;
                }
                reader.Close();
                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Получаем список всех свойств данной сущности
        /// </summary>
        /// <returns>Строку свойсвт</returns>
        private string getAllProperties()
        {
            string result = "";

            var type = typeof(T);

            var props = type.GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                result += props[i].Name + (i < props.Length - 1 ? "," : "");
            }

            return result;
        }

        public void Update(T entity)
        {
            var type = typeof(T);

            var props = type.GetProperties();

            Dictionary<string, string> keyValue = new Dictionary<string, string>();

            string sqlCommand = $"UPDATE {TableName} SET ";

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props.FirstOrDefault(p => p.Name == props[i].Name);

                if (prop.GetValue(entity) != null)
                {
                    //keyValue.Add(prop.Name, (prop.GetValue(entity).ToString() ? prop.GetValue(entity).GetType));
                }
            }



            /*using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    $"UPDATE {TableName} SET ",
                    connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
            }*/
        }
    }
}
