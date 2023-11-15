using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Linq;

namespace SolomonsAdviceApi.RandomAdvice.Endpoints{
    public class SolomonsAdviceGet{
        public static string TemplateAdviceRandom => "/advice";
        public static string[] MetodoAdviceRandom => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceRandom => AcaoAdviceRandom;
        public static IResult AcaoAdviceRandom(){
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            Random random = new Random();
            SolomonAdvice solomonAdviceFound = adviceRepository.ProverbsBank[random.Next(0, adviceRepository.ProverbsBank.Count)];
            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}