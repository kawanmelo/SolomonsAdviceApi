using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace SolomonsAdviceApi.Endpoints.AdvicePost{
    public class SolomonAdvicePost{
  
        public static string TemplateAdvicePost => "/advice/";
        public static string[] MetodoAdvicePost => new string[] {HttpMethod.Post.ToString()};
        public static Delegate FuncAdvicePost => AcaoAdvicePost;
        public static IResult AcaoAdvicePost([FromBody] SolomonAdvice solomonAdvice){
            if(solomonAdvice == null){
                return Results.BadRequest();
            }
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            bool persistenceConference = adviceRepository.CUDDataProverbsBank("INSERT INTO dbo.Verses (Advice, Reference) VALUES (@Advice, @Reference)",
                new { Advice = solomonAdvice.Advice, Reference = solomonAdvice.Reference});
                if(persistenceConference){
                    try{
                        int id=0;
                        string connectionString =  "Data Source=localhost;Initial Catalog=ProverbsDataBank;User ID=sa;Password=SQLmelo.cs;Integrated Security=False;";
                        using(SqlConnection connection = new SqlConnection(connectionString)){
                            connection.Open();
                            using(SqlCommand command = new SqlCommand("SELECT MAX(VerseId) FROM dbo.Verses",connection))
                            using(SqlDataReader reader = command.ExecuteReader()){
                                while(reader.Read()){
                                    id = reader.GetInt32(0);
                                }
                                SolomonAdvice solomonAdviceFound = adviceRepository.ConsumeUniqueDataProverbsBank($"SELECT * FROM dbo.Verses  WHERE VerseId = {id}");
                                return Results.Created($"https://localhost:7120/advice/{id}",solomonAdviceFound);
                            }
                        }
                    }catch(SqlException e){
                        throw new Exception($"Erro ao carregar banco de dados: {e}");
                    }
                }else{
                    return Results.BadRequest();
                }
        }
    }
}