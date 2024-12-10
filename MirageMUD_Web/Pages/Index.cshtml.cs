using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MirageMUD_Web.Services;

namespace MirageMUD_Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WebSocketService _webSocketService;

        public IndexModel(WebSocketService webSocketService)
        {
            _webSocketService = webSocketService;
        }

        public async Task OnGetAsync()
        {
            await _webSocketService.PingServerAsync(new Uri("wss://localhost:7777/ws"));
        }
    }
}
