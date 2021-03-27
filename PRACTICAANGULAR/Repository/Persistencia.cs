

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PRACTICAANGULAR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PRACTICAANGULAR.Repository
{
    public class Persistencia
    {
        
        string strcon = string.Empty;
        public Persistencia(IConfiguration configuration)
        {
            strcon = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<Value>> GetValues()
        {
            List<Value> lista = null;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllValues", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        lista = new List<Value>();
                        while (await reader.ReadAsync())
                        {
                            lista.Add(MapToValue(reader));
                        }
                    }

                    return lista;
                }
            }
        }

        public async Task<Value> GetValueId(int id)
        {
            Value obj = null;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("GetValueId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            obj = MapToValue(reader);
                        }

                        return obj;
                    }
                }
            }
        }

        public async Task<int> InsertarValue(Value valor)
        {
            int valorReturn = 0;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("InsertValue", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();

                    cmd.Parameters.Add("@Value1", SqlDbType.VarChar, 50).Value = valor.Value1;
                    cmd.Parameters.Add("@Value2", SqlDbType.VarChar, 50).Value = valor.Value2;
                    SqlParameter paramOutput = new SqlParameter();
                    paramOutput.ParameterName = "@Return";
                    paramOutput.Direction = ParameterDirection.Output;
                    paramOutput.DbType = DbType.Int32;
                    cmd.Parameters.Add(paramOutput);

                    int results = await cmd.ExecuteNonQueryAsync();

                    if (results > 0) {
                        valorReturn = (int)cmd.Parameters["@Return"].Value;
                    }

                    return valorReturn;
                }
            }
        }

        public async Task<int> DeleteValue(int id)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteValue", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<int> UpdateValue(Value valor)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateValue", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await con.OpenAsync();
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = valor.Id;
                    cmd.Parameters.Add("@Value1", SqlDbType.VarChar, 50).Value = valor.Value1;
                    cmd.Parameters.Add("@Value2", SqlDbType.VarChar, 50).Value = valor.Value2;

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        Value MapToValue(SqlDataReader reader)
        {
            return new Value
            {
                Id = (int)reader["Id"],
                Value1 = (string)reader["Value1"],
                Value2 = (string)reader["Value2"]
            };
        }
    }
}
