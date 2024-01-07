using MeloSolution.SolomonsAdviceApi.Entities;
using System.Data.SqlClient;
using MeloSolution.authenticationAPI.Repository;

namespace MeloSolution.SolomonsAdviceApi.Repository{
    public class ConsumeVerse:IConsumeObject{
        private readonly IConfiguration configuration;
        private readonly CreateSolomonAdvice createSolomonAdvice;
        public ConsumeVerse(){
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            createSolomonAdvice = new CreateSolomonAdvice();
        }
        public object ConsumeUniqueObject(string sqlQuery, object parameters = null){
            try{
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(string.IsNullOrEmpty(connectionString)){
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
                        using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()){
                            while(sqlDataReader.Read()){
                                int Id = sqlDataReader.GetInt32(0);
                                string Advice = sqlDataReader.GetString(1);
                                string Reference = sqlDataReader.GetString(2);
                                SolomonAdvice solomonAdviceFound = createSolomonAdvice.Create(Id, Advice, Reference);
                                return solomonAdviceFound;
                            }
                        }
                    }
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public List<object> ConsumeMultipleObject(string sqlQuery, object parameters = null){
            List<object> values = new List<object>();
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
                        using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()){
                            while(sqlDataReader.Read()){
                                int Id = sqlDataReader.GetInt32(0);
                                string Advice = sqlDataReader.GetString(1);
                                string Reference = sqlDataReader.GetString(2);
                                values.Add(createSolomonAdvice.Create(Id, Advice, Reference));
                            }
                        }
                    }
                }

            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return values;
        }
    }
}