using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;

namespace SolomonsAdviceApi.ByIdAdvice.Endpoints{
    public class SolomonAdviceByIdGet{
  
        public static string TemplateAdviceById => "/advice/{Id:int}";
        public static string[] MetodoAdviceById => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceById => AcaoAdviceById;
        public static IResult AcaoAdviceById([FromRoute] int Id){
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            SolomonAdvice solomonAdviceFound = adviceRepository.ConsumeDataProverbsBank($"SELECT * FROM dbo.Customers  WHERE CustomerId = {Id}");

            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}