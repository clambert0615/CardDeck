using CardDeck.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CardDeckUnitTests
{
    [TestFixture]
    public class DeckUnitTests
    {
        private Deck deck;

        [SetUp]
        public void SetUp()
        {
            deck = new Deck();
        }

        [Test]
        public void Constructor_SetsCardDeckInDeclaredOrder()
        {
            // arrange

            // act
            Card firstCard = deck.CardDeck.First();
            Card lastCard = deck.CardDeck.Last();

            // assert
            Assert.AreEqual(Suit.Heart, firstCard.Suit);
            Assert.AreEqual(Value.Ace, firstCard.Value);
            Assert.AreEqual(Suit.Club, lastCard.Suit);
            Assert.AreEqual(Value.King, lastCard.Value);
        }

        [Test]
        public void Shuffle_ReturnsShuffledDeck()
        {
            // arrange

            // act
            deck.Shuffle();

            // assert
            // check that each possible card appears exactly once in the deck

            List<Card> cardDeck = deck.CardDeck.Select(x => new Card { Suit = x.Suit, Value = x.Value }).ToList();
            bool isValid = true;

            foreach (Card card in deck.ShuffledDeck)
            {
                Card matchingCard = cardDeck.SingleOrDefault(x => x.Suit == card.Suit && x.Value == card.Value);

                if (matchingCard != null)
                {
                    cardDeck.Remove(matchingCard);
                }
                else
                {
                    // duplicate card, already previously removed
                    isValid = false;
                    break;
                }
            }

            if (isValid && cardDeck.Count > 0)
            {
                // at least one card not found
                isValid = false;
            }

            Assert.IsTrue(isValid);
        }

        [Test]
        public void DealOneCard_DeckHasCards_ReturnsCard()
        {
            // arrange
            deck.ShuffledDeck.Add(new Card { Suit = Suit.Club, Value = Value.Ace });
            deck.ShuffledDeck.Add(new Card { Suit = Suit.Heart, Value = Value.Five });

            Card expected = deck.ShuffledDeck[0];

            // act
            Card actual = deck.DealOneCard();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DealOneCard_DeckHasNoCards_ReturnsNull()
        {
            // arrange
            deck.ShuffledDeck.Clear();

            // act
            Card actual = deck.DealOneCard();

            // assert
            Assert.Null(actual);
        }
    }
}
