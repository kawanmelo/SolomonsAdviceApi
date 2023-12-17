using SolomonsAdviceApi.Repository.CUD;
using System.Data.SqlClient;

namespace SolomonsAdviceApi.Repository.CUD{
    public class CudSolomonVerse:ICud{
        private readonly IConfiguration configuration;
        public CudSolomonVerse(){
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        }
        public bool CudObject(string sqlQuery, object parameters = null){
            try{
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(String.IsNullOrEmpty(connectionString)){
                    throw new Exception("String de conexão vazia.");
                }
                using(SqlConnection sqlConnection = new SqlConnection(connectionString)){
                    sqlConnection.Open();
                    using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection)){
                        if(parameters != null){
                            foreach(var prop in parameters.GetType().GetProperties()){
                                sqlCommand.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
                            }
                        }
                        if(sqlCommand.ExecuteNonQuery() < 1){
                            return false;
                        }else{
                            return true;
                        }
                    }
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return false;          
        }
    }
}