////

namespace PokerTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void ToString_AceClubs()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string expected = "|A♣|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ThreeClubs()
        {
            Card card = new Card(CardFace.Three, CardSuit.Clubs);
            string expected = "|3♣|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "|2♣|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TenClubs()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Clubs);
            string expected = "|10♣|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_AceDiamonds()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Diamonds);
            string expected = "|A♦|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ThreeDiamonds()
        {
            Card card = new Card(CardFace.Three, CardSuit.Diamonds);
            string expected = "|3♦|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TwoDiamonds()
        {
            Card card = new Card(CardFace.Two, CardSuit.Diamonds);
            string expected = "|2♦|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TenDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "|10♦|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_AceHearts()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            string expected = "|A♥|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ThreeHearts()
        {
            Card card = new Card(CardFace.Three, CardSuit.Hearts);
            string expected = "|3♥|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TwoHearts()
        {
            Card card = new Card(CardFace.Two, CardSuit.Hearts);
            string expected = "|2♥|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TenHearts()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Hearts);
            string expected = "|10♥|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_AceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "|A♠|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_ThreeSpades()
        {
            Card card = new Card(CardFace.Three, CardSuit.Spades);
            string expected = "|3♠|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TwoSpades()
        {
            Card card = new Card(CardFace.Two, CardSuit.Spades);
            string expected = "|2♠|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_TenSpades()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Spades);
            string expected = "|10♠|";
            string actual = card.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
