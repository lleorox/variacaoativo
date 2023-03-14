namespace VariacaoAtivo.Models
{
    public class Ativos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal VariacaoPerc { get; set; }
    }
}
