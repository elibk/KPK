////

namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTestMethodIsFlush
    {
        [TestMethod]
        public void IsFlush_FiveCardsOfSameSuitButNotConsecutive()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlush_FiveCardsOfSameSuitButConsecutive()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlush_FourCardsOfSameSuitAndLastOfDifferantSuit()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }
    }
}
