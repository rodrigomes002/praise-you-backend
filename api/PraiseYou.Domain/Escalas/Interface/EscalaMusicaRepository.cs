namespace PraiseYou.Domain.Escalas.Interface
{
    public interface EscalaMusicaRepository
    {
        void Cadastrar(EscalaMusica musica);
        void Deletar(EscalaMusica musica);
    }
}
