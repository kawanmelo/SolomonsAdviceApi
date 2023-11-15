namespace SolomonsAdviceApi.SolomonAdviceClass{
    public class SolomonAdvice{
        public string Advice{
            get; set;
        }
        public string Reference{
            get; set;
        }
        public int Id{
            get; set;
        }

        public SolomonAdvice(string Advice, string Reference,int Id){
            this.Advice = Advice;
            this.Reference = Reference;
            this.Id = Id;
        }
    }
}