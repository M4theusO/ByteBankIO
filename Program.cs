using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using(var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var linha = leitor.ReadLine();
            //var texto = leitor.ReadToEnd();
            //var numero = leitor.Read();

            while(!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }
       Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 123,4678,789.10,Gustavo Santos
        var campos = linha.Split(',');
        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComoInt = int.Parse(agencia);
        var numeroComoInt = int.Parse(numero);
        var saldoComoDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);
        resultado.Depositar(saldoComoDouble);
        resultado.Titular = titular;

        return resultado;
    }
}