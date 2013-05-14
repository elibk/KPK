////

namespace PokerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class PokerHandsCheckerTestMethodCompareHands
    {
        
        #region CompareCategories 
        
        [TestMethod]
        public void CompareHands_FourOfAKindWithFullHouse()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
            
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);

            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_StraightTheWheelWithStraightFlushTheWheel()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
            
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);

            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_StraightWithStraightFlush()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
            };
            
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);

            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        #endregion 
        
        #region StraightFlush
        
        [TestMethod]
        public void CompareHands_StraightFlushToAceWithStraightFlushToKing()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_StraightFlushToSixWithStraightFlushTheWheel()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region FourOfAkind
        
        [TestMethod]
        public void CompareHands_FourOfAKindEqual()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FourOfAKindKickerAceWithFourOfAKindKickerKing()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FourOfAKindAceWithFourOfAKindKing()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region FullHouse
        
        [TestMethod]
        public void CompareHands_EqualFullHouses()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FullHouseThreeTwoWithFullHouseThreeFours()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FullHouseTwoThreeWithFullHouseTwoFours()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region Flush
        
        [TestMethod]
        public void CompareHands_FlushTenWithFlushAce()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FlushQueenTenSevenWithFlushQueenTenSix()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FlushQueenTenWithFlushQueenSeven()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FlushQueenTenSevenFiveWithFlushQueenTenSevenFour()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_FlushQueenTenSevenFiveThreeWithFlushQueenTenSevenFiveFour()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_EqualFlushes()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region Straight
        
        [TestMethod]
        public void CompareHands_StraightToSixWithStraightToSeven()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CompareHands_StraightTheWheelWithStraightTheWheel()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
            
            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region ThreeOfAKind
            
        [TestMethod]
        public void CompareHands_EqualThreeOfAKind()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
        
            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        public void CompareHands_ThreeOfAKindSixWithThreeOfAKindAce()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
        
            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_ThreeOfAKindFirstKickerAceWithThreeOfAKindFirstKickerKing()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
        
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_ThreeOfAKindSecondKickerNineWithThreeOfAKindSecondKickerThree()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();
        
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region TwoPairs
            
        [TestMethod]
        public void CompareHands_TwoPairsAceAndJackWithTwoPairsAceAndKing()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
                
        public void CompareHands_TwoPairsAceAndTwoKickerJackWithTwoPairsAceAndandTwoKickerTen()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_TwoPairsAceAndJackKickerThreeWithTwoPairsAceAndJackKickerTwo()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
        
        #region OnePair
            
        [TestMethod]
        public void CompareHands_EqualHandsOnePair()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_OnePairFiveWithOnePairTen()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_OnePairAceFirstKickerSixWithOnePairAceFirstKickerFive()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_OnePairAceSecondKickerFourWithOnePairAceSecondKickerThree()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
            
        [TestMethod]
        public void CompareHands_OnePairAceThirdKickerFourWithOnePairAceThirdKickerFive()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
            };

            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
            
            PokerHandsChecker checker = new PokerHandsChecker();

            int expected = -1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
        
        #endregion
            
        #region HighCard
                
        [TestMethod]
        public void CompareHands_HighCardFirstAceThreeWithHighCardFirstKing()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
        
            PokerHandsChecker checker = new PokerHandsChecker();
        
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
                
        [TestMethod]
        public void CompareHands_HighCardSecondQueenThreeWithHighCardSecondTen()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
        
            PokerHandsChecker checker = new PokerHandsChecker();
        
            int expected = 1;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }
                
        [TestMethod]
        public void CompareHands_EqualHandsHighCard()
        {
            IList<ICard> firstHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
                
            IList<ICard> secondHandCards = new List<ICard> 
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
            };
            
            Hand firstHand = new Hand(firstHandCards);
            Hand secondHand = new Hand(secondHandCards);
        
            PokerHandsChecker checker = new PokerHandsChecker();
    
            int expected = 0;
            int actual = checker.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
        }

        #endregion

    }
}
