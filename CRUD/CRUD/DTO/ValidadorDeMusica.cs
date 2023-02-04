namespace CRUD.DTO
{
    public class ValidadorDeMusica
    {       
        public bool Status { get; set; }
        public string Mensagem { get; set; }
        public ValidadorDeMusica(bool _status, string _parametro)
        {
            Status = _status;
            Mensagem = _parametro;
        }
        public ValidadorDeMusica()
        {

        }
        public ValidadorDeMusica(bool _status)
        {

        }
       
    }
}
