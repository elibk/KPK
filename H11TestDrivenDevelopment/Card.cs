////

namespace Poker
{
    using System;
    using System.Text;

    public class Card : ICard
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append('|');
            result.Append(CardFaceToString(this.Face));
            result.Append(CardSuitToString(this.Suit));
            result.Append('|');

            return result.ToString();
        }

        private static string CardFaceToString(CardFace cardFace)
        {
            string result;
            switch (cardFace)
            {
                case CardFace.Two:
                    result = "2";
                    break;
                case CardFace.Three:
                    result = "3";
                    break;
                case CardFace.Four:
                    result = "4";
                    break;
                case CardFace.Five:
                    result = "5";
                    break;
                case CardFace.Six:
                    result = "6";
                    break;
                case CardFace.Seven:
                    result = "7";
                    break;
                case CardFace.Eight:
                    result = "8";
                    break;
                case CardFace.Nine:
                    result = "9";
                    break;
                case CardFace.Ten:
                    result = "10";
                    break;
                case CardFace.Jack:
                    result = "J";
                    break;
                case CardFace.Queen:
                    result = "Q";
                    break;
                case CardFace.King:
                    result = "K";
                    break;
                case CardFace.Ace:
                    result = "A";
                    break;
                default:
                    throw new ArgumentException(string.Format("Invalid value for card face : '{0}'.", cardFace));  
            }

            return result;
        }

        private static string CardSuitToString(CardSuit cardSuit)
        {
            string result;

            switch (cardSuit)
            {
                case CardSuit.Clubs:
                    result = "♣";
                    break;
                case CardSuit.Diamonds:
                    result = "♦";
                    break;
                case CardSuit.Hearts:
                    result = "♥";
                    break;
                case CardSuit.Spades:
                    result = "♠";
                    break;
                default:
                    throw new ArgumentException(string.Format("Invalid value for card suit : '{0}'.", cardSuit));  
            }

            return result;
        }
    }
}