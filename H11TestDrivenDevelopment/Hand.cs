////

namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Value for 'Cards' can not be null");
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var card in this.Cards)
            {
                result.Append(card);
            }

            return result.ToString();
        }
    }
}
