using CardDeck.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardDeck.Controllers
{
    public class CardDeckController : Controller
    {
        private const string DeckSessionKey = "Deck";

        private Deck deck;

        public CardDeckController()
        {
            deck = new Deck();
        }

        public IActionResult Index()
        {
            deck.Shuffle();

            SessionHelper.WriteObjectAsJson(HttpContext.Session, DeckSessionKey, deck);

            return View();
        }

        public IActionResult DrawCard()
        {
            deck = SessionHelper.ReadObjectFromJson<Deck>(HttpContext.Session, DeckSessionKey);
            Card cardDealt = deck.DealOneCard();

            SessionHelper.WriteObjectAsJson(HttpContext.Session, DeckSessionKey, deck);

            return View(cardDealt);
        }
    }
}
