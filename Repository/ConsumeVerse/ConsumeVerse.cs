using SolomonsAdviceApi.Repository.CreateObject;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient;

namespace SolomonsAdviceApi.Repository.Consume{
    public class ConsumeVerse:IConsumeVerse{
        private readonly IConfiguration configuration;
        private readonly CreateSolomonAdvice createSolomonAdvice;
        public ConsumeVerse(){
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            createSolomonAdvice = new CreateSolomonAdvice();
        }
        public SolomonAdvice ConsumeUniqueVerse(string sqlQuery, object parameters = null){
            try{
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(string.IsNullOrEmpty(connectionString)){
                    throw new Exception("String de conexão vazia.");
                }
                using(SqlConnection sqlConnection = new SqlConnection(connectionString)){
                sqlConnection.Open();
                    using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection)){
                        using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()){
                            if(parameters != null){
                                foreach(var prop in parameters.GetType().GetProperties()){
                                    sqlCommand.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
                                }
                            }
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
            Console.WriteLine("Bullshit");
            return null;
        }
        public List<SolomonAdvice> ConsumeMutipleVerse(string sqlQuery, object parameters = null){
            List<SolomonAdvice> values = new List<SolomonAdvice>();
            try{
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(String.IsNullOrEmpty(connectionString)){
                    throw new Exception("String de conexão vazia.");
                }
                using(SqlConnection sqlConnection = new SqlConnection(connectionString)){
                    sqlConnection.Open();
                    using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection)){
                        using(SqlDataReader sqlDataReader = sqlCommand.ExecuteReader()){
                            if(parameters != null){
                                foreach(var prop in parameters.GetType().GetProperties()){
                                    sqlCommand.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
                                }
                            }
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