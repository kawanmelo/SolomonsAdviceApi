using Microsoft.VisualBasic;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient
;
namespace SolomonsAdviceApi.Repository{
    public  class SolomonAdviceRepository{
        public SolomonAdvice ConsumeUniqueDataProverbsBank(string SqlQuery){
            try{
                string connectionString =  "Data Source=localhost;Initial Catalog=ProverbsDataBank;User ID=sa;Password=SQLmelo.cs;Integrated Security=False;";;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        SolomonAdvice solomonAdvice=null;
                        while(reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Advice = reader.GetString(1);
                            string Reference = reader.GetString(2);
                            solomonAdvice = new SolomonAdvice(Id, Advice, Reference);
                        }
                        return solomonAdvice;
                    }
                }
            }catch(SqlException e){
                throw new Exception("Erro ao carregar o banco de dados" + e.Message);
            }
            
        }
        public List<SolomonAdvice> ConsumeMutipleDataProverbsBank(string SqlQuery){
            try{
                string connectionString =  "Data Source=localhost;Initial Catalog=ProverbsDataBank;User ID=sa;Password=SQLmelo.cs;Integrated Security=False;";;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<SolomonAdvice> listFound = new List<SolomonAdvice>();
                        SolomonAdvice solomonAdvice=null;
                        while(reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string Advice = reader.GetString(1);
                            string Reference = reader.GetString(2);
                            solomonAdvice = new SolomonAdvice(Id, Advice, Reference);
                            listFound.Add(solomonAdvice);
                        }
                        return listFound;
                    }
                }
            }catch(SqlException e){
                throw new Exception("Erro ao carregar o banco de dados" + e.Message);
            }
            
        }
    }
}