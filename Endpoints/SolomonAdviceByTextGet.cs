using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;

namespace SolomonsAdviceApi.Endpoints.ByTextGet{
    public class SolomonAdviceByTextGet{
        public static string TemplateAdviceByText => "/advice/{advice}";
        public static string[] MetodoAdviceByText => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceByText => AcaoAdviceByText;

        public static IResult AcaoAdviceByText([FromRoute] string advice){
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            var solomonAdviceFound = adviceRepository.ConsumeMutipleDataProverbsBank($"SELECT * FROM dbo.Verses WHERE Advice LIKE '%{advice}%' ");

            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}