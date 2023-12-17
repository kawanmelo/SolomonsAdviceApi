using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using SolomonsAdviceApi.Repository.Consume;
namespace SolomonsAdviceApi.Endpoints.ByTextGet{
    public class SolomonAdviceByTextGet{
        public static string TemplateAdviceByText => "/advice/{advice}";
        public static string[] MetodoAdviceByText => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceByText => AcaoAdviceByText;

        public static IResult AcaoAdviceByText([FromRoute] string advice){
            ConsumeVerse consumeVerse = new ConsumeVerse();
            List<SolomonAdvice> solomonAdviceFound = consumeVerse.ConsumeMutipleVerse($"SELECT * FROM dbo.Verses WHERE Advice LIKE '%{advice}%'");
            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}