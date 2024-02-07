
namespace ExerciciosEpicos.Controllers
{
    /// <summary>
    /// Struct geradora de fakers de imoveis
    /// </summary>
    public struct Imovel
    {
        private static Random random = new Random();
        private static int IdStatic = 0;
        private static List<string> PossibleAddreses = new List<string>()
        {
            "Dionisio Marques", "Sete de Setembro", "Avenida Brasil", "Rua Tiradentes"
        };

        public Imovel()
        {
            Id = IdStatic++;
            Endereco = PossibleAddreses.ElementAt(random.Next(PossibleAddreses.Count));
            Quartos = random.Next(1, 4);
            Banheiros = random.Next(1, 4);
            Area = 33.0d + (random.NextDouble() * (140.0d - 33.0d)); // Formula engraçada
            Aluguel = CalcularAluguel();
        }

        private decimal CalcularAluguel()
        {
            decimal aluguelBase = 600.0m;
            decimal porQuarto = 200.0m;
            decimal porBanheiro = 100.0m;
            decimal porMetroQauadrado = 5.0m;

            decimal aluguelAdicional = Quartos * porQuarto +
                                       Banheiros * porBanheiro +
                                       (decimal)Area * porMetroQauadrado;

            return aluguelBase + aluguelAdicional;
        }

        public int Id;
        public string Endereco { get; private set; }
        public int Quartos;
        public int Banheiros;
        public double Area;
        public decimal Aluguel;
        
        public string GetInfo()
        {
            return $"Id: {Id} | Endereco: {Endereco} | Quartos: {Quartos} | Banheiros: {Banheiros} | Area: {Math.Round(Area)} | Aluguel: {Aluguel:C}";
        }
    }
}