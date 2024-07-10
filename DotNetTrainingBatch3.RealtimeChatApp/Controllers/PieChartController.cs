using DotNetTrainingBatch3.RealtimeChatApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DotNetTrainingBatch3.RealtimeChatApp.Controllers
{
    public class PieChartController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public PieChartController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public static List<PieCharModel> Data { get; set; } = new List<PieCharModel>();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(PieCharModel reqModel)
        {
            Data.Add(reqModel);
            PieChartResponseModel resModel = new PieChartResponseModel()
            {
                Labels = Data.Select(x => x.Label).ToList(),
                Series = Data.Select(x => x.Series).ToList(),
            };

            string jsonStr = JsonConvert.SerializeObject(resModel);
            await _hubContext.Clients.All.SendAsync("ClientReceiveEvent", jsonStr);
            return View();
        }

        public IActionResult Watch()
        {
            return View();
        }
    }

    public class PieCharModel
    {
        public string Label { get; set; }
        public int Series { get; set; }

    }

    public class PieChartResponseModel
    {
        public List<string> Labels { get; set; }
        public List<int> Series { get; set; }
    }
}
