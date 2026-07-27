
using System.Net.Http;
using System.Text.Json;

public class EmpresaService
{

    private static readonly HttpClient httpClient = new HttpClient();

    static EmpresaService()
    {
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
    }
    public static async Task<Empresa> BuscarEmpresa(string cnpj)
    {
        string url = $"https://brasilapi.com.br/api/cnpj/v1/{cnpj}";


        var resposta = await httpClient.GetAsync(url);

        string json = await resposta.Content.ReadAsStringAsync();



        if (!resposta.IsSuccessStatusCode)
        {
            throw new Exception($"Erro da API: {resposta.StatusCode}");
        }

        var empresa = JsonSerializer.Deserialize<Empresa>(json);
        if (empresa == null)
        {
            throw new Exception("Não foi possível interpretar a resposta da API.");

        }
        return empresa;
    }
}