public static class InputHelper
{
    public static string LerCnpjValido()
    {
        while (true)
        {
            string respostaCnpj = Console.ReadLine();
            respostaCnpj = respostaCnpj
            .Replace(".", "")
            .Replace("/", "")
            .Replace("-", "");

            if (string.IsNullOrWhiteSpace(respostaCnpj) ||
                respostaCnpj.Length != 14 ||
                !respostaCnpj.All(char.IsDigit))
            {
                Console.WriteLine("Cnpj inválido. Digite novamente!");
                continue;
            }
            return respostaCnpj;
        }


    }

    public static string LerRespostaValida()
    {
        Console.WriteLine("Deseja consultar outro CNPJ? (s/n)");
        string respostaSn;

        while (true)
        {
            respostaSn = Console.ReadLine();

            if (respostaSn == "s" || respostaSn == "n")
            {

                break;
            }

            Console.WriteLine("Erro. Digite apenas 's' ou 'n'.");

        }
        return respostaSn;
    }

}