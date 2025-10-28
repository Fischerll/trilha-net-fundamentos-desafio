namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa e o nome do carro (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI* FEITO
             Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            Console.WriteLine("Digite o nome do carro:");
            string nomeCarro = Console.ReadLine();

            veiculos.Add($"{placa.ToUpper()} - {nomeCarro}");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine()?.Trim();

            // Verifica se o veículo existe (compara apenas o início da string armazenada: "PLACA - Nome")
            if (!string.IsNullOrEmpty(placa) && veiculos.Any(x => x.ToUpper().StartsWith(placa.ToUpper())))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("Número de horas inválido.");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                // encontra e remove o item completo (ex.: "ABC1234 - Fusca")
                var veiculoEncontrado = veiculos.First(x => x.ToUpper().StartsWith(placa.ToUpper()));
                veiculos.Remove(veiculoEncontrado);

                Console.WriteLine($"O veículo {veiculoEncontrado} saiu da vaga e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI* FEITO
                foreach (var v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
