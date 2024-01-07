using Microsoft.AspNetCore.Mvc;
using MeloSolution.SolomonsAdviceApi.Repository;
using MeloSolution.authenticationAPI.Repository;

namespace SolomonsAdviceApi.Endpoints.ByIdAdvice{
    public class SolomonAdviceByIdGet{
  
        private static IConsumeObject consumeVerse;
        public static string TemplateAdviceById => "/advice/{Id:int}";
        public static string[] MetodoAdviceById => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceById => AcaoAdviceById;
        public static IResult AcaoAdviceById([FromRoute] int id){
            try{
                consumeVerse = new ConsumeVerse();
                var solomonAdviceFound = consumeVerse.ConsumeUniqueObject("SELECT * FROM dbo.Verses WHERE VerseId = @VerseId",
                new{ VerseId = id });
                if(solomonAdviceFound != null){
                    return Results.Ok(solomonAdviceFound);
                }else{
                    return Results.NotFound();
                }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return Results.BadRequest();
        }
    }
}