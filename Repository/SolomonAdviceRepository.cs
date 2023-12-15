using Microsoft.VisualBasic;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SolomonsAdviceApi.Repository{
    public  class SolomonAdviceRepository{
        private readonly IConfiguration configuration;
        public SolomonAdviceRepository(){
            configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        }
        
        public SolomonAdvice ConsumeUniqueDataProverbsBank(string SqlQuery, object parameters = null){
            try{
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(string.IsNullOrEmpty(connectionString)){
                    throw new Exception("String de conexão vazia");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (parameters != null)
                        {
                            foreach (var prop in parameters.GetType().GetProperties())
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
                            }
                        }
                        while(reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Advice = reader.GetString(1);
                            string Reference = reader.GetString(2);
                            return new SolomonAdvice(Id, Advice, Reference);
                        }
                    }
                }
            }catch(SqlException e){
                throw new Exception("Erro ao carregar o banco de dados" + e.Message);
            }
            return null;
        }
        public List<SolomonAdvice> ConsumeMutipleDataProverbsBank(string SqlQuery, object parameters = null){
            List<SolomonAdvice> listFound = new List<SolomonAdvice>();
            try{
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(string.IsNullOrEmpty(connectionString)){
                    throw new Exception("String de conexão vazia");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Advice = reader.GetString(1);
                            string Reference = reader.GetString(2);
                            listFound.Add(new SolomonAdvice(Id, Advice, Reference));
                        }
                    }
                }
            }catch(SqlException e){
                throw new Exception("Erro ao carregar o banco de dados" + e.Message);
            }
            return listFound;
        }
        public bool CUDDataProverbsBank(string sqlQuery, object parameters = null){
            try
            {
                string connectionString = configuration.GetConnectionString("ProverbsDataBankConnection");
                if(string.IsNullOrEmpty(connectionString)){
                    throw new Exception("String de conexão vazia");
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var prop in parameters.GetType().GetProperties())
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(parameters));
                            }
                        }
                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected > 0){
                            return true;
                        }else{
                            return false;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw new Exception("Erro ao carregar o banco de dados: " + e.Message);
            }
        }
    }
}