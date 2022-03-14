using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteConsumoAPIContagem.Clients;

namespace SiteConsumoAPIContagem.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly APIContagemClient _client;

    public IndexModel(ILogger<IndexModel> logger,
        APIContagemClient client)
    {
        _logger = logger;
        _client = client;
    }

    public void OnGet()
    {
        _logger.LogInformation("Acionado o método OnGet em Index.cshtml.cs...");
        TempData["ResultadoAPIContagem"] =
            _client.ObterDadosContagem();
    }
}