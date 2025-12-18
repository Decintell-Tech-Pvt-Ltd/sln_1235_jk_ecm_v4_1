using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace api_1235_jk_ecm_v4.DAL
{
    public class DBManager
    {
        public async Task<string> JsonDataFromSqlAsync(string connString, string spName)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(spName, connection);
                connection.Open();
                // Set command object as a stored procedure
                command.CommandType = CommandType.StoredProcedure;
                //command.CommandTimeout = 300;
                //// Add parameter that will be passed to stored procedure
                //command.Parameters.Add(new SqlParameter("@json", jsonParameter));
                //command.Parameters.Add(new SqlParameter("@ERROR", ""));
                // Assuming the query returns JSON data, execute the command and read the JSON result

                using (var reader = await command.ExecuteReaderAsync())
                {
                    StringBuilder jsonResult = new StringBuilder();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }
                    //sometimes SP will send json as NULL (specially when SPs using set @json=(select * from #tmp for json path, include_null_values); select @json
                    //this kind of select @json will return NULL in a nameless column and hence below line is needed
                    //added by satish on 04nov23
                    if (jsonResult.Length == 0) { jsonResult.Append("[]"); }
                    return jsonResult.ToString();
                }
            }
            
        }

        public async Task<string> JsonDataFromSqlAsync(string connString, string spName, string jsonParameter)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(spName, connection);
                connection.Open();
                // Set command object as a stored procedure
                command.CommandType = CommandType.StoredProcedure;
                //command.CommandTimeout = 300;

                // Add parameter that will be passed to stored procedure
                command.Parameters.Add(new SqlParameter("@json", jsonParameter));
                command.Parameters.Add(new SqlParameter("@ERROR", ""));
                // Assuming the query returns JSON data, execute the command and read the JSON result
                using (var reader = await command.ExecuteReaderAsync())
                {
                    StringBuilder jsonResult = new StringBuilder();
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }


                    }
                    //sometimes SP will send json as NULL (specially when SPs using set @json=(select * from #tmp for json path, include_null_values); select @json
                    //this kind of select @json will return NULL in a nameless column and hence below line is needed
                    //added by satish on 04nov23
                    if (jsonResult.Length == 0) { jsonResult.Append("[]"); }
                    return jsonResult.ToString();
                }
            }

         
        }
    
    }

}
