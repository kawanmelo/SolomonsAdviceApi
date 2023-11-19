using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;


namespace SolomonsAdviceApi.Endpoints.AdvicePut{
    public class SolomonAdvicePut{
  
        public static string TemplateAdvicePut => "/advice/";
        public static string[] MetodoAdvicePut => new string[] {HttpMethod.Put.ToString()};
        public static Delegate FuncAdvicePut => AcaoAdvicePut;
        public static IResult AcaoAdvicePut([FromBody] SolomonAdvice solomonAdvice){
            if(solomonAdvice == null){
                return Results.BadRequest();
            }
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            bool persistenceConference = adviceRepository.CUDDataProverbsBank("UPDATE dbo.Verses SET Advice = @Advice, Reference = @Reference WHERE VerseId = @VerseId",
                new { Advice = solomonAdvice.Advice, Reference = solomonAdvice.Reference, VerseId = solomonAdvice.Id });
                if(persistenceConference){
                    return Results.NoContent();
                }else{
                    return Results.BadRequest();
                }
                    
        }
    }
}   