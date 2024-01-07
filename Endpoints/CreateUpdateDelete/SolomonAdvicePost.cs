using MeloSolution.SolomonsAdviceApi.Repository;
using MeloSolution.SolomonsAdviceApi.Entities;
using MeloSolution.authenticationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace SolomonsAdviceApi.Endpoints.AdvicePost{
    public class SolomonAdvicePost{

        private static ICud cudSolomonVerse;
        private static IConsumeData consumeData;
        private static IConsumeObject consumeVerse;
        public static string TemplateAdvicePost => "/advice/";
        public static string[] MetodoAdvicePost => new string[] {HttpMethod.Post.ToString()};
        public static Delegate FuncAdvicePost => AcaoAdvicePost;
        public static IResult AcaoAdvicePost([FromBody] SolomonAdvice solomonAdvice){
            if(solomonAdvice == null){
                return Results.BadRequest();
            }
            cudSolomonVerse = new CudSolomonVerse();
            consumeData = new ConsumeData();
            consumeVerse = new ConsumeVerse();
            bool persistenceConference = cudSolomonVerse.CudObject("INSERT INTO dbo.Verses (Advice, Reference) VALUES (@Advice, @Reference)",
                new { Advice = solomonAdvice.Advice, Reference = solomonAdvice.Reference});
                if(persistenceConference){
                    try{
                        int id = consumeData.ConsumeInfoInteger("SELECT MAX(VerseId) FROM dbo.Verses");
                        var solomonAdviceFound = consumeVerse.ConsumeUniqueObject("SELECT * FROM dbo.Verses  WHERE VerseId = @VerseId",
                        new{ VerseId = id });
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