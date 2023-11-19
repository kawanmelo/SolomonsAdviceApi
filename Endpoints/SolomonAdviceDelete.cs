using SolomonsAdviceApi.Repository;
using SolomonsAdviceApi.SolomonAdviceClass;
using Microsoft.AspNetCore.Mvc;


namespace SolomonsAdviceApi.Endpoints.AdviceDelete{
    public class SolomonAdviceDelete{
  
        public static string TemplateAdviceDelete => "/advice/{Id:int}";
        public static string[] MetodoAdviceDelete => new string[] {HttpMethod.Delete.ToString()};
        public static Delegate FuncAdviceDelete => AcaoAdviceDelete;
        public static IResult AcaoAdviceDelete([FromRoute] int id){
            SolomonAdviceRepository adviceRepository = new SolomonAdviceRepository();
            bool persistenceConference = adviceRepository.CUDDataProverbsBank("DELETE FROM dbo.Verses WHERE VerseId = @IdVerse", new {IdVerse = id});
            if(persistenceConference){
                return Results.NoContent();
            }else{
                return Results.BadRequest();
            }
        }
    }
}   