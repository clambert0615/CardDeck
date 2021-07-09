using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardDeck.Models
{
    public class Deck
    {
        public List<Card> CardDeck { get; set; } = new List<Card>();
        public List<Card> ShuffledDeck { get; set; } = new List<Card>();

        Random random = new Random();

        public void Shuffle()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                 {
                    Card card = new Card { Suit = suit, Value = value };
                    CardDeck.Add(card);
                }
            }
           while (CardDeck.Count > 0)
           {
                Card randomCard = CardDeck[random.Next(CardDeck.Count)];
                CardDeck.Remove(randomCard);
                ShuffledDeck.Add(randomCard);
           }
        }

        public Card DealOneCard(List<Card> shuffledCards)
        {
            if(ShuffledDeck.Count > 0)
            {
                Card cardDrawn = shuffledCards[0];
                shuffledCards.Remove(cardDrawn);
                return cardDrawn;
            }
            else
            {
                return null;
            }
        }

    }
}
