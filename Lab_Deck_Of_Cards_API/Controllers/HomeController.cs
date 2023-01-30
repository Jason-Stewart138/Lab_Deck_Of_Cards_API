using Lab_Deck_Of_Cards_API.Models;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using System.Diagnostics;


namespace Lab_Deck_Of_Cards_API.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			DeckOfCardsApi deck = new DeckOfCardsApi();
			string apiUri = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
			var apiTask = apiUri.GetJsonAsync<DeckOfCardsApi>();
			apiTask.Wait();
			deck = apiTask.Result;
			return View(deck);
		}

		public IActionResult DrawCard(DeckOfCardsApi deck,  string Id)
		{
            string apiUri = $"https://deckofcardsapi.com/api/deck/{Id}/draw/?count=5";
            var apiTask = apiUri.GetJsonAsync<DeckOfCardsApi>();
            apiTask.Wait();			
			DeckOfCardsApi cardsDrawn = apiTask.Result;			
				
			return View(cardsDrawn);            
        }
		public IActionResult StartOver()
		{
			
			return View();
		}

		
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}