using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using ServerSide.HelperLibrabries;

namespace ServerSide
{
    public class Datahandler
    {
        private static Datahandler data = new Datahandler();
        private string connectionStringPrime;
        private string DbProvider;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;
        private Datahandler(string connectionStringParam = "default",string provider= "System.Data.SqlClient")
        {
            connectionStringPrime = ConfigurationManager.ConnectionStrings[connectionStringParam].ConnectionString;
            DbProvider = provider;
        }

        public static Datahandler getData()
        {
            return data;
        }

        public bool runQuery(string target,string queryType, Dictionary<string,string[]> values,string condition="")
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(DbProvider);
                DbConnection conn = factory.CreateConnection();
                DataTable table = new DataTable();
                conn.ConnectionString = connectionStringPrime;
                using (conn)
                {
                    string queryString = "SELECT * FROM "+target;

                    DbCommand dbcommand = factory.CreateCommand();
                    dbcommand.CommandText = queryString;
                    dbcommand.Connection = conn;

                    DbDataAdapter adapter = factory.CreateDataAdapter();
                    adapter.SelectCommand = dbcommand;

                    DbCommandBuilder builder = factory.CreateCommandBuilder();
                    builder.DataAdapter = adapter;

                    adapter.InsertCommand = builder.GetInsertCommand();
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    adapter.DeleteCommand = builder.GetDeleteCommand();

                    adapter.Fill(table);

                    if (queryType=="INSERT")
                    {
                        DataRow newRow = table.NewRow();
                        foreach (var item in values)
                        {
                            if (item.Value[0]=="STRING")
                            {
                                newRow[item.Key] = item.Value[1]; 
                            }
                            else if (item.Value[0] == "DOUBLE")
                            {
                                newRow[item.Key] = Convert.ToDouble(item.Value[1]);
                            }
                            else if (item.Value[0] == "INT")
                            {
                                newRow[item.Key] = Convert.ToInt32(item.Value[1]);
                            }
                            else if (item.Value[0] == "DATETIME")
                            {
                                newRow[item.Key] = Convert.ToDateTime(item.Value[1]);
                            }
                            else if (item.Value[0] == "BOOL")
                            {
                                newRow[item.Key] = Convert.ToBoolean(item.Value[1]);
                            }
                            
                        }
                        table.Rows.Add(newRow);
                        adapter.Update(table);
                    }
                    else if (queryType=="UPDATE")
                    {
                        DataRow[] editRow = table.Select(condition);
                        int length = editRow.Length;
                        for (int i = 0; i < length; i++)
                        {
                            foreach (var item in values)
                            {
                                if (item.Value[0] == "STRING")
                                {
                                    editRow[i][item.Key] = item.Value[1];
                                }
                                else if (item.Value[0] == "DOUBLE")
                                {
                                    editRow[i][item.Key] = Convert.ToDouble(item.Value[1]);
                                }
                                else if (item.Value[0] == "INT")
                                {
                                    editRow[i][item.Key] = Convert.ToInt32(item.Value[1]);
                                }
                                else if (item.Value[0] == "DATETIME")
                                {
                                    editRow[i][item.Key] = Convert.ToDateTime(item.Value[1]);
                                }
                                else if (item.Value[0] == "BOOL")
                                {
                                    editRow[i][item.Key] = Convert.ToBoolean(item.Value[1]);
                                }
                                
                            }
                        }
                        adapter.Update(table);
                    }
                    else if (queryType=="DELETE")
                    {
                        DataRow[] deleteRow = table.Select(condition);
                        foreach (DataRow row in deleteRow)
                        {
                            row.Delete();
                        }
                        adapter.Update(table);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorHandler e = new ErrorHandler(ex);
                e.PrintError();
                return false;
            }
        }

        public bool runStoredProcedure(string procName,Dictionary<string,string[]>values)
        {
            //try
            //{
                connection = new SqlConnection(connectionStringPrime);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new SqlCommand(procName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var item in values)
                {
                    if (item.Value[0] == "STRING")
                    {
                        command.Parameters.Add(new SqlParameter(item.Key, item.Value[1]));
                    }
                    else if (item.Value[0] == "DOUBLE")
                    {
                        command.Parameters.Add(new SqlParameter(item.Key, Convert.ToDouble(item.Value[1])));
                    }
                    else if (item.Value[0] == "INT")
                    {
                        command.Parameters.Add(new SqlParameter(item.Key, Convert.ToInt32(item.Value[1])));
                    }
                    else if (item.Value[0] == "DATETIME")
                    {
                        command.Parameters.Add(new SqlParameter(item.Key, Convert.ToDateTime(item.Value[1])));
                    }
                    else if (item.Value[0] == "BOOL")
                    {
                        command.Parameters.Add(new SqlParameter(item.Key, Convert.ToBoolean(item.Value[1])));
                    }     
                }
                command.ExecuteNonQuery();
                return true;
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler e = new ErrorHandler(ex);
            //    e.PrintError();
            //    return false;
            //}
            //finally
            //{
            //    connection.Close();
            //}
        }

        public DataTable readDataFromDB(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionStringPrime);
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                command = new SqlCommand(query, connection);
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                ErrorHandler e = new ErrorHandler(ex);
                e.PrintError();
            }
            finally
            { connection.Close(); }
            return dataTable;
            //DataTable table = new DataTable();

            //try
            //{
            //    DbProviderFactory factory = DbProviderFactories.GetFactory(DbProvider);
            //    DbConnection conn = factory.CreateConnection();
            //    conn.ConnectionString = connectionStringPrime;
            //    using (conn)
            //    {
            //        string queryString = query;

            //        DbCommand dbcommand = factory.CreateCommand();
            //        dbcommand.CommandText = queryString;
            //        dbcommand.Connection = conn;
            //        conn.Open();
            //        DbDataAdapter adapter = factory.CreateDataAdapter();
            //        adapter.SelectCommand = dbcommand;

            //        adapter.Fill(table);


            //    }
            //}
            //catch { }
            //return table;
        }

        
    }
}
