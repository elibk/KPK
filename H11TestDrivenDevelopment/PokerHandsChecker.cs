////

namespace Poker
{
    using System; 
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int CountOfCardsInHand = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != CountOfCardsInHand)
            {
                return false;       
            }

            if (this.AreThereEqualCards(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.StraightFlush)
            {
                return true;
            }

            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.FourOfAKind)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.FullHouse)
            {
                return true;
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.Flush)
            {
                return true;
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.Straight)
            {
                return true;
            }

            return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.ThreeOfAKind)
            {
                return true;
            }

            return false;
        }

        public bool IsTwoPairs(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.TwoPairs)
            {
                return true;
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.OnePair)
            {
                return true;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (this.GetHandCategorie(hand) == HandCategorie.HighCard)
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            Debug.Assert(this.IsValidHand(firstHand));
            Debug.Assert(this.IsValidHand(secondHand));

            HandCategorie firstHandCategorie = this.GetHandCategorie(firstHand);

            HandCategorie secondHandCategorie = this.GetHandCategorie(secondHand);

            if (!firstHandCategorie.Equals(secondHandCategorie))
            {
                int firstHandCategorieRate = Convert.ToInt32(firstHandCategorie);
                int secondHandCategorieRate = Convert.ToInt32(secondHandCategorie);

                return firstHandCategorieRate.CompareTo(secondHandCategorieRate);
            }

            switch (firstHandCategorie)
            {
                case HandCategorie.StraightFlush:
                    return this.CompareStraight(firstHand, secondHand);
                    
                case HandCategorie.FourOfAKind:
                    return this.CompareFourOfAKind(firstHand, secondHand);
                    
                case HandCategorie.FullHouse:
                    return this.CompareFullHouse(firstHand, secondHand);
                   
                case HandCategorie.Flush:
                    return this.CompareFlush(firstHand, secondHand);
                   
                case HandCategorie.Straight:
                    return this.CompareStraight(firstHand, secondHand);
                   
                case HandCategorie.ThreeOfAKind:
                    return this.CompareThreeOfAKind(firstHand, secondHand);
                   
                case HandCategorie.TwoPairs:
                    return this.CompareTwoPairs(firstHand, secondHand);
                    
                case HandCategorie.OnePair:
                    return this.CompareOnePair(firstHand, secondHand);
                   
                case HandCategorie.HighCard:
                    return this.CompareHighCard(firstHand, secondHand);
                default:
                    throw new InvalidOperationException(string.Format("The category '{0}' for card is not recodnized for comapare.", firstHandCategorie));
            }
        }

        #region Comparers
        private int CompareStraight(IHand firstHand, IHand secondHand)
        {
            int[] cardFacesValuesFirstHand = this.ExtractSortedCardFacesValues(firstHand);
            int[] cardFacesValuesSecondHand = this.ExtractSortedCardFacesValues(secondHand);

            if (this.IsTheConsecutiveWheel(cardFacesValuesFirstHand))
            {
                Debug.Assert(cardFacesValuesFirstHand[cardFacesValuesFirstHand.Length - 1] == 14);
                cardFacesValuesFirstHand[cardFacesValuesFirstHand.Length - 1] = 1;
                Array.Sort(cardFacesValuesFirstHand);
            }

            if (this.IsTheConsecutiveWheel(cardFacesValuesSecondHand))
            {
                Debug.Assert(cardFacesValuesSecondHand[cardFacesValuesSecondHand.Length - 1] == 14);
                cardFacesValuesSecondHand[cardFacesValuesSecondHand.Length - 1] = 1;
                Array.Sort(cardFacesValuesSecondHand);
            }

            Debug.Assert(cardFacesValuesFirstHand.Length == cardFacesValuesSecondHand.Length);
            return cardFacesValuesFirstHand[cardFacesValuesFirstHand.Length - 1].CompareTo(cardFacesValuesSecondHand[cardFacesValuesSecondHand.Length - 1]);
        }

        private int CompareFlush(IHand firstHand, IHand secondHand)
        {
            int[] cardFacesValuesFirstHand = this.ExtractSortedCardFacesValues(firstHand);
            int[] cardFacesValuesSecondHand = this.ExtractSortedCardFacesValues(secondHand);

            Debug.Assert(cardFacesValuesFirstHand.Length == cardFacesValuesSecondHand.Length);
            return this.CompareByKickers(cardFacesValuesFirstHand.ToList<int>(), cardFacesValuesSecondHand.ToList<int>());
        }

        private int CompareFullHouse(IHand firstHand, IHand secondHand)
        {
            return this.CompareSeveralOfAKind(firstHand, secondHand, 3);
        }

        private int CompareFourOfAKind(IHand firstHand, IHand secondHand)
        {
            return this.CompareSeveralOfAKind(firstHand, secondHand, 4);
        }

        private int CompareThreeOfAKind(IHand firstHand, IHand secondHand)
        {
            return this.CompareSeveralOfAKind(firstHand, secondHand, 3);
        }

        private int CompareTwoPairs(IHand firstHand, IHand secondHand)
        {
            KeyValuePair<List<CardFace>, List<int>> firstHandHistogram = this.ExtractUniqueFacesHistogram(firstHand);
            KeyValuePair<List<CardFace>, List<int>> secondHandHistogram = this.ExtractUniqueFacesHistogram(secondHand);

            int indexOfTheKickerFirstHand = firstHandHistogram.Value.IndexOf(1);
            int indexOfTheKickerSecondHand = secondHandHistogram.Value.IndexOf(1);

            int kickerValueFirstHand = Convert.ToInt32(firstHandHistogram.Key[indexOfTheKickerFirstHand]);
            int kickerValueSecondHand = Convert.ToInt32(secondHandHistogram.Key[indexOfTheKickerSecondHand]);

            firstHandHistogram.Key.RemoveAt(indexOfTheKickerFirstHand);
            secondHandHistogram.Key.RemoveAt(indexOfTheKickerSecondHand);

            List<int> pairsValuesFirstHand = this.ConvertListOfCardFacesToListOfInt(firstHandHistogram.Key);
            pairsValuesFirstHand.Sort();
            List<int> pairsValuesSecondHand = this.ConvertListOfCardFacesToListOfInt(secondHandHistogram.Key);
            pairsValuesSecondHand.Sort();

            var pairsCheck = this.CompareByKickers(pairsValuesFirstHand, pairsValuesSecondHand);

            if (pairsCheck != 0)
            {
                return pairsCheck;
            }

            return kickerValueFirstHand.CompareTo(kickerValueSecondHand);
        }

        private int CompareOnePair(IHand firstHand, IHand secondHand)
        {
            return this.CompareSeveralOfAKind(firstHand, secondHand, 2);
        }

        private int CompareHighCard(IHand firstHand, IHand secondHand)
        {
            int[] cardFacesValuesFirstHand = this.ExtractSortedCardFacesValues(firstHand);
            int[] cardFacesValuesSecondHand = this.ExtractSortedCardFacesValues(secondHand);

            Debug.Assert(cardFacesValuesFirstHand.Length == cardFacesValuesSecondHand.Length);
            return this.CompareByKickers(cardFacesValuesFirstHand.ToList<int>(), cardFacesValuesSecondHand.ToList<int>());
        }

        private int CompareSeveralOfAKind(IHand firstHand, IHand secondHand, int howMuchOfAKind)
        {
            Debug.Assert(howMuchOfAKind == 4 || howMuchOfAKind == 2 || howMuchOfAKind == 3);
            KeyValuePair<List<CardFace>, List<int>> firstHandHistogram = this.ExtractUniqueFacesHistogram(firstHand);
            KeyValuePair<List<CardFace>, List<int>> secondHandHistogram = this.ExtractUniqueFacesHistogram(secondHand);

            int indexOfGroupWithEqualFirstHand = firstHandHistogram.Value.IndexOf(howMuchOfAKind);
            int indexOfGroupWithEqualSecondHand = secondHandHistogram.Value.IndexOf(howMuchOfAKind);

            int checkForOfAKind = Convert.ToInt32(firstHandHistogram.Key[indexOfGroupWithEqualFirstHand]).CompareTo(Convert.ToInt32(secondHandHistogram.Key[indexOfGroupWithEqualSecondHand]));
            if (checkForOfAKind != 0)
            {
                return checkForOfAKind;
            }

            firstHandHistogram.Key.RemoveAt(indexOfGroupWithEqualFirstHand);
            secondHandHistogram.Key.RemoveAt(indexOfGroupWithEqualSecondHand);

            List<int> kickersValuesFirstHand = this.ConvertListOfCardFacesToListOfInt(firstHandHistogram.Key);
            kickersValuesFirstHand.Sort();
            List<int> kickersValuesSecondHand = this.ConvertListOfCardFacesToListOfInt(secondHandHistogram.Key);
            kickersValuesSecondHand.Sort();

            return this.CompareByKickers(kickersValuesFirstHand, kickersValuesSecondHand);
        }
        #endregion

        #region AdditionalPrivateMethods

        private bool AreThereEqualCards(IHand hand)
        {
            IList<ICard> uniqueCards = new List<ICard>();

            foreach (var card in hand.Cards)
            {
                foreach (var uniqieCard in uniqueCards)
                {
                    if (card.Face.Equals(uniqieCard.Face))
                    {
                        if (card.Suit.Equals(uniqieCard.Suit))
                        {
                            return true;
                        }
                    }
                }

                uniqueCards.Add(card);
            }

            Debug.Assert(uniqueCards.Count == CountOfCardsInHand);
            return false;
        }

        private List<int> ConvertListOfCardFacesToListOfInt(List<CardFace> cardFaces)
        {
            List<int> cardFacesValues = new List<int>();

            for (int i = 0; i < cardFaces.Count; i++)
            {
                cardFacesValues.Add(Convert.ToInt32(cardFaces[i]));
            }

            return cardFacesValues;
        }

        private HandCategorie GetHandCategorie(IHand hand) 
        {
            // TODO: Exract methods to prevent same operations in Comperes. They are not need to call GetHandCategory but
            // it's methods. Maybe the main ComapreHands can call methods from GetHandCategorie
            Debug.Assert(this.IsValidHand(hand));
            KeyValuePair<List<CardFace>, List<int>> histogram = this.ExtractUniqueFacesHistogram(hand);
            histogram.Value.Sort();
            StringBuilder formula = new StringBuilder();

            formula.Append('|');
            for (int i = 0; i < histogram.Value.Count; i++)
            {
                formula.Append(histogram.Value[i]);
                formula.Append('|');
            }

            switch (formula.ToString())
            {
                case "|1|4|":
                    return HandCategorie.FourOfAKind;
                    
                case "|2|3|":
                    return HandCategorie.FullHouse;
                    
                case "|1|1|3|":
                    return HandCategorie.ThreeOfAKind;
                    
                case "|1|2|2|":
                    return HandCategorie.TwoPairs;
                    
                case "|1|1|1|2|":
                    return HandCategorie.OnePair;
                    
                case "|1|1|1|1|1|":
                    bool isStraight = this.AreCardsConsecutive(hand);
                    bool isFlush = this.AreCardsOfSameSuit(hand);

                    if (isFlush && isStraight)
                    {
                        return HandCategorie.StraightFlush;
                    }
                    else
                    {
                        if (isFlush)
                        {
                            return HandCategorie.Flush;
                        }
                        else if (isStraight)
                        {
                            return HandCategorie.Straight;
                        }
                        else
                        {
                            return HandCategorie.HighCard;
                        }
                    }

                default:
                    throw new ArgumentException("Impossible combination of cards.");  
            }
        }

        private KeyValuePair<List<CardFace>, List<int>> ExtractUniqueFacesHistogram(IHand hand)
        {
            KeyValuePair<List<CardFace>, List<int>> historgam = new KeyValuePair<List<CardFace>, List<int>>(new List<CardFace>(), new List<int>());
            ////List<CardFace> uniqueCardFaces = new List<CardFace>();
            ////List<int> uniqueCardFacesOccurence = new List<int>();

            foreach (var card in hand.Cards)
            {
                var indexOfCard = historgam.Key.IndexOf(card.Face);

                if (indexOfCard < 0)
                {
                    historgam.Key.Add(card.Face);
                    historgam.Value.Add(1);
                }
                else
                {
                    historgam.Value[indexOfCard]++;
                }
            }

            return historgam;
        }

        private bool AreCardsOfSameSuit(IHand hand) 
        {
            CardSuit suitForCheck = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (!hand.Cards[i].Suit.Equals(suitForCheck))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreCardsConsecutive(IHand hand)
        {
            int[] cardFaces = this.ExtractSortedCardFacesValues(hand);

            if (this.IsTheConsecutiveWheel(cardFaces))
            {
                return true;
            }

            int currentCardValue = cardFaces[0];

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if ((cardFaces[i] - currentCardValue) != 1)
                {
                    return false;
                }

                Debug.Assert(cardFaces[i] > currentCardValue);

                currentCardValue = cardFaces[i];
            }

            return true;
        }

        private int[] ExtractSortedCardFacesValues(IHand hand)
        {
            int[] cardFaces = new int[hand.Cards.Count];
            for (int i = 0; i < cardFaces.Length; i++)
            {
                cardFaces[i] = Convert.ToInt32(hand.Cards[i].Face);
            }

            Array.Sort(cardFaces);
            return cardFaces;
        }

        private bool IsTheConsecutiveWheel(int[] sortedCardFacesValuesAscendingOrder) 
        { 
            ////TODO: Fix this bullshit
            if (sortedCardFacesValuesAscendingOrder[0] == 2 &&
                sortedCardFacesValuesAscendingOrder[1] == 3 &&
                sortedCardFacesValuesAscendingOrder[2] == 4 &&
                sortedCardFacesValuesAscendingOrder[3] == 5 &&
                sortedCardFacesValuesAscendingOrder[4] == 14)
            {
                return true;
            }

            return false;
        }

        private int CompareByKickers(List<int> firstHandKickers, List<int> secondHandKickers)
        {
            Debug.Assert(firstHandKickers.Count == secondHandKickers.Count);

            for (int i = firstHandKickers.Count - 1; i >= 0; i--)
            {
                int check = firstHandKickers[i].CompareTo(secondHandKickers[i]);

                if (check != 0)
                {
                    return check;
                }
            }

            return 0;
        }
        #endregion
    }
}