using Microsoft.AspNetCore.Mvc;
using MeloSolution.SolomonsAdviceApi.Repository;
using MeloSolution.authenticationAPI.Repository;

namespace SolomonsAdviceApi.Endpoints.ByTextGet{
    public class SolomonAdviceByTextGet{

        private static IConsumeObject consumeVerse;
        public static string TemplateAdviceByText => "/advice/{advice}";
        public static string[] MetodoAdviceByText => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceByText => AcaoAdviceByText;

        public static IResult AcaoAdviceByText([FromRoute] string advice){
            consumeVerse = new ConsumeVerse();
            var solomonAdviceFound = consumeVerse.ConsumeMultipleObject($"SELECT * FROM dbo.Verses WHERE Advice LIKE '%{advice}%'");
            if(solomonAdviceFound.Count >= 1 ){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}