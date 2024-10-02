namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private readonly decimal _desconto = 0.1m;
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A suite escolhida não possui capacidade para acomodar a quantidade de hóspedes desejada.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor = CalcularDesconto(valor);
            }

            return valor;
        }

        public decimal CalcularDesconto(decimal valor)
        {
            decimal desconto = valor * _desconto;
            return valor - desconto;
        }
    }
}