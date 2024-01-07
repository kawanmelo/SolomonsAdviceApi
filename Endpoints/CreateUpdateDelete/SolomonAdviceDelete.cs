using MeloSolution.authenticationAPI.Repository;
using MeloSolution.SolomonsAdviceApi.Repository;
using Microsoft.AspNetCore.Mvc;


namespace SolomonsAdviceApi.Endpoints.AdviceDelete{
    public class SolomonAdviceDelete{

        private static ICud cudSolomonVerse;
        public static string TemplateAdviceDelete => "/advice/{Id:int}";
        public static string[] MetodoAdviceDelete => new string[] {HttpMethod.Delete.ToString()};
        public static Delegate FuncAdviceDelete => AcaoAdviceDelete;
        public static IResult AcaoAdviceDelete([FromRoute] int id){
            cudSolomonVerse = new CudSolomonVerse();
            bool persistenceConference = cudSolomonVerse.CudObject("DELETE FROM dbo.Verses WHERE VerseId = @IdVerse",
            new {IdVerse = id});
            if(persistenceConference){
                return Results.NoContent();
            }else{
                return Results.BadRequest();
            }
        }
    }
}   