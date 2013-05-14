////

namespace PokerTest
{ 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class HandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CardsSet_CreateHandWithValueForCardsNull()
        {
            new Hand(null);
        }

        [TestMethod]
        public void ToString_HandWithOneCard()
        {
            IList<ICard> cards = new List<ICard> { new Card(CardFace.Ace, CardSuit.Clubs) };
            Hand hand = new Hand(cards);
            
            string expected = "|A♣|";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_HandWithCoupleCards()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            };
            Hand hand = new Hand(cards);

            string expected = "|A♣||A♠|";
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_HandWithNoCards()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);

            string expected = string.Empty;
            string actual = hand.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
