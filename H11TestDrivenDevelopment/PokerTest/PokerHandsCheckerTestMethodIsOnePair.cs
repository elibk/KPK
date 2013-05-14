////

namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTestMethodIsOnePair
    {
        [TestMethod]
        public void IsOnePair_HandWithOnePair()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePair_HandWithTwoPairs()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePair_HandWithThreeOfAKind()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePair_HandWithFullHouse()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }
    }
}