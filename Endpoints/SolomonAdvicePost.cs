using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;


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
                    return Results.Created("https://localhost:7120/advice/",solomonAdvice);
                }else{
                    return Results.BadRequest();
                }
        }
    }
}