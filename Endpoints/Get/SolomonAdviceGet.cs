using Microsoft.AspNetCore.Mvc;
using MeloSolution.SolomonsAdviceApi.Repository;
using MeloSolution.authenticationAPI.Repository;

namespace SolomonsAdviceApi.Endpoints.RandomAdvice{
    public class SolomonsAdviceGet{

        private static Random random;
        private static IConsumeData consumeData;
        private static IConsumeObject consumeVerse;
        public static string TemplateAdviceRandom => "/advice";
        public static string[] MetodoAdviceRandom => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceRandom => AcaoAdviceRandom;
        public static IResult AcaoAdviceRandom(){
            random = new Random();
            consumeData = new ConsumeData();
            consumeVerse = new ConsumeVerse();
            int count = consumeData.ConsumeInfoInteger("SELECT COUNT(*) FROM dbo.Verses");
            var solomonAdviceFound = consumeVerse.ConsumeUniqueObject("SELECT * FROM dbo.Verses WHERE VerseId = @VerseId",
            new { VerseId = random.Next(0,count+1) });
            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}