////

namespace Poker
{
    using System;
    using System.Linq;

    public enum HandCategorie
    {
        StraightFlush = 8,
        FourOfAKind = 7,
        FullHouse = 6,
        Flush = 5,
        Straight = 4,
        ThreeOfAKind = 3,
        TwoPairs = 2,
        OnePair = 1,
        HighCard = 0,
    }
}
