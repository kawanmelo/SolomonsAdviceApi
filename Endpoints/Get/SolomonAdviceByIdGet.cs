using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceApi.Repository.Consume;
using System.Data.SqlClient;
using SolomonsAdviceApi.Repository.CreateObject;

namespace SolomonsAdviceApi.Endpoints.ByIdAdvice{
    public class SolomonAdviceByIdGet{
  
        public static string TemplateAdviceById => "/advice/{Id:int}";
        public static string[] MetodoAdviceById => new string[] {HttpMethod.Get.ToString()};
        public static Delegate FuncAdviceById => AcaoAdviceById;
        public static IResult AcaoAdviceById([FromRoute] int id){
            try{
                ConsumeVerse consumeVerse = new ConsumeVerse();
                SolomonAdvice solomonAdviceFound = consumeVerse.ConsumeUniqueVerse($"SELECT * FROM dbo.Verses WHERE VerseId = {id}");
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