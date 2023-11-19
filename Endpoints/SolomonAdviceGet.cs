using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient;
using System.Linq;

namespace SolomonsAdviceApi.Endpoints.RandomAdvice{
    public class SolomonsAdviceGet{
        public static string TemplateAdviceRandom => "/advice";
        public static string[] MetodoAdviceRandom => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceRandom => AcaoAdviceRandom;
        public static IResult AcaoAdviceRandom(){
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            Random random = new Random();
            int count=0;
            string connectionString =  "Data Source=localhost;Initial Catalog=ProverbsDataBank;User ID=sa;Password=SQLmelo.cs;Integrated Security=False;";;
                using (SqlConnection connection = new SqlConnection(connectionString)){
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Verses", connection))
                    using(SqlDataReader reader = command.ExecuteReader()){
                        while(reader.Read()){
                            count = reader.GetInt32(0);
                        }
                    }
                }
            SolomonAdvice solomonAdviceFound = adviceRepository.ConsumeUniqueDataProverbsBank($"SELECT * FROM dbo.Verses WHERE VerseId = {random.Next(0,count+1)}");
            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}