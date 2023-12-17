using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.Repository.Consume;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient;
using System.Linq;

namespace SolomonsAdviceApi.Endpoints.RandomAdvice{
    public class SolomonsAdviceGet{
        public static string TemplateAdviceRandom => "/advice";
        public static string[] MetodoAdviceRandom => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceRandom => AcaoAdviceRandom;
        public static IResult AcaoAdviceRandom(){
            Random random = new Random();
            ConsumeData consumeData = new ConsumeData();
            ConsumeVerse consumeVerse = new ConsumeVerse();
            int count = consumeData.ConsumeInfoInteger("SELECT COUNT(*) FROM dbo.Verses");
            SolomonAdvice solomonAdviceFound = consumeVerse.ConsumeUniqueVerse($"SELECT * FROM dbo.Verses WHERE VerseId = {random.Next(0,count+1)}");
          
            if(solomonAdviceFound != null){
                return Results.Ok(solomonAdviceFound);
            }else{
                return Results.NotFound();
            }
        }
    }
}