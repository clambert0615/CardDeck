using CardDeck.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace CardDeck.Controllers
{
    public class CardDeckController : Controller
    {
        private Deck deck = new Deck();

        public IActionResult Index()
        {
            deck.Shuffle();
            SessionHelper.WriteObjectAsJson(HttpContext.Session,"key", deck);

            return View();
        }

        public IActionResult DrawCard()
        {
            deck = SessionHelper.ReadObjectFromJson<Deck>(HttpContext.Session, "key");
            Card cardDealt = deck.DealOneCard(deck.ShuffledDeck);
            SessionHelper.WriteObjectAsJson(HttpContext.Session, "key", deck);
            return View(cardDealt);
        }

    }
}
