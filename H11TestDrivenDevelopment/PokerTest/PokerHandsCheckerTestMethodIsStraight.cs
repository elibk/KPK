////

namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTestMethodIsStraight
    {
        [TestMethod]
        public void IsStraight_HandWithStraight()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_HandWithStraightTheWheel()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_HandWithFullStraightTheWheel()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_HandWithThreeOfAKind()
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

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_HandWithTwoPairs()
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

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_HandWithFullHouse()
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

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_HandWithStraightFlush()
        {
            IList<ICard> cards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            };

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand));
        }
    }
}