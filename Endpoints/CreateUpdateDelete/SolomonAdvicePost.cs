using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using SolomonsAdviceApi.Repository.CUD;
using SolomonsAdviceApi.Repository.Consume;


namespace SolomonsAdviceApi.Endpoints.AdvicePost{
    public class SolomonAdvicePost{
  
        public static string TemplateAdvicePost => "/advice/";
        public static string[] MetodoAdvicePost => new string[] {HttpMethod.Post.ToString()};
        public static Delegate FuncAdvicePost => AcaoAdvicePost;
        public static IResult AcaoAdvicePost([FromBody] SolomonAdvice solomonAdvice){
            if(solomonAdvice == null){
                return Results.BadRequest();
            }
            CudSolomonVerse cudSolomonVerse = new CudSolomonVerse();
            ConsumeData consumeData = new ConsumeData();
            ConsumeVerse consumeVerse = new ConsumeVerse();
            bool persistenceConference = cudSolomonVerse.CudObject("INSERT INTO dbo.Verses (Advice, Reference) VALUES (@Advice, @Reference)",
                new { Advice = solomonAdvice.Advice, Reference = solomonAdvice.Reference});
                if(persistenceConference){
                    try{
                        int id = consumeData.ConsumeInfoInteger("SELECT MAX(VerseId) FROM dbo.Verses");
                        SolomonAdvice solomonAdviceFound = consumeVerse.ConsumeUniqueVerse($"SELECT * FROM dbo.Verses  WHERE VerseId = {id}");
                        return Results.Created($"https://localhost:7120/advice/{id}",solomonAdviceFound);
                            
                    }catch(SqlException e){
                        throw new Exception($"Erro ao carregar banco de dados: {e}");
                    }
                }else{
                    return Results.BadRequest();
                }
        }
    }
}