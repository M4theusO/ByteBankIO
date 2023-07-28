using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        var linhas = File.ReadAllLines("contas.txt"); //Lê todas as linhas do arquivo e retorna um array de strings
        Console.WriteLine(linhas.Length);

        /*foreach(var linha in linhas)
        {
            Console.WriteLine(linha);
        }*/

        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");
        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText"); //Sobrescreve o arquivo
        Console.WriteLine("Aplicação finalizada. . .");
        Console.ReadLine();
    }
}