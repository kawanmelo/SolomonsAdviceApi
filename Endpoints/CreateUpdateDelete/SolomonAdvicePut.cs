using MeloSolution.SolomonsAdviceApi.Repository;
using MeloSolution.SolomonsAdviceApi.Entities;
using Microsoft.AspNetCore.Mvc;
using MeloSolution.authenticationAPI.Repository;


namespace SolomonsAdviceApi.Endpoints.AdvicePut{
    public class SolomonAdvicePut{
  
        private static ICud cudSolomonVerse;
        public static string TemplateAdvicePut => "/advice/";
        public static string[] MetodoAdvicePut => new string[] {HttpMethod.Put.ToString()};
        public static Delegate FuncAdvicePut => AcaoAdvicePut;
        public static IResult AcaoAdvicePut([FromBody] SolomonAdvice solomonAdvice){
            if(solomonAdvice == null){
                return Results.BadRequest();
            }
            cudSolomonVerse = new CudSolomonVerse();
            bool persistenceConference = cudSolomonVerse.CudObject("UPDATE dbo.Verses SET Advice = @Advice, Reference = @Reference WHERE VerseId = @VerseId",
                new { Advice = solomonAdvice.Advice, Reference = solomonAdvice.Reference, VerseId = solomonAdvice.Id });
                if(persistenceConference){
                    return Results.NoContent();
                }else{
                    return Results.BadRequest();
                }
                    
        }
    }
}   