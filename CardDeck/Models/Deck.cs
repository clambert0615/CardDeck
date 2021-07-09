using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDeck.Models
{
    public class Deck
    {
        public List<Card> CardDeck { get; }
        public List<Card> ShuffledDeck { get; }

        private readonly Random random = new Random();

        public Deck()
        {
            CardDeck = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    Card card = new Card { Suit = suit, Value = value };

                    CardDeck.Add(card);
                }
            }

            ShuffledDeck = new List<Card>();
        }

        public void Shuffle()
        {
            List<Card> cardDeck = CardDeck.Select(x => new Card { Suit = x.Suit, Value = x.Value }).ToList();

            while (cardDeck.Count > 0)
            {
                Card randomCard = cardDeck[random.Next(cardDeck.Count)];

                cardDeck.Remove(randomCard);
                ShuffledDeck.Add(randomCard);
            }
        }

        public Card DealOneCard()
        {
            if (ShuffledDeck.Count > 0)
            {
                Card cardDrawn = ShuffledDeck.First();
                ShuffledDeck.Remove(cardDrawn);
                return cardDrawn;
            }
            else
            {
                return null;
            }
        }

    }
}
