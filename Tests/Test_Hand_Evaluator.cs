using GD_NET_ScOUT;

[Test]
public partial class Test_Hand_Evaluator : Hand_Evaluator
{

    [Test] public void Test_Is_Flush_Five_Cards()
    {
        Assert.IsTrue(Is_Flush(Create_Flush()), "Flush hand returned false");
    }

    [Test] public void Test_Is_Flush_Five_Cards_False()
    {
        Assert.IsFalse(Is_Flush(Create_High_Card()), "Nonflush was returned true");
    }

    [Test] public void Test_Is_Straight_Five_Cards()
    {
        Assert.IsFalse(Is_Straight(Create_Staight()), "Nonflush was returned true");
    }

    [Test] public void Test_Evaluate_Hand_Flush()
    {
        Assert.AreEqual<Hand_Evaluator.hand_type>(hand_type.Flush, Evaluate_Hand(Create_Flush()),
         "evaluated a flush hand as something else");
    }

    [Test] public void Test_Evaluate_Hand_High_Card()
    {
        Assert.AreEqual<Hand_Evaluator.hand_type>(hand_type.HighCard, Evaluate_Hand(Create_High_Card()),
         "evaluated a high card as something else");
    }

    [Test] public void Test_Evaluate_Hand_Straight()
    {
        hand_type hand = Evaluate_Hand(Create_Staight());
        Assert.AreEqual<Hand_Evaluator.hand_type>(hand_type.Straight, hand,
         $"evaluated a Straight hand as a {hand}");
    }

    [Test] public void Test_Evaluate_Hand_Straight_Flush()
    {
        Assert.AreEqual<hand_type>(hand_type.StraightFlush, Evaluate_Hand(Create_Straight_Flush()),
        "evaluated a straight flush as something else");
    }

    [Test] public void Test_Find_Match_Tier()
    {
        Assert.AreEqual(hand_type.TwoKind, Find_Match_Tier(Create_Pair()), "evaluated a Pair wrong");
        Assert.AreEqual(hand_type.TwoPair, Find_Match_Tier(Create_Two_Pair()), "evaluated Two Pair wrong");
        Assert.AreEqual(hand_type.ThreeKind, Find_Match_Tier(Create_Three_Kind()), "evaluated Three of a Kind wrong");
        Assert.AreEqual(hand_type.FullHouse, Find_Match_Tier(Create_Full_House()), "evaluated a Full House wrong");
        Assert.AreEqual(hand_type.FourKind, Find_Match_Tier(Create_Four_Kind()), "evaluated Four of a Kind wrong");
        Assert.AreEqual(hand_type.HighCard, Find_Match_Tier(Create_High_Card()), "evaluated High card wrong");
    }

    [Test] public void Test_Evaluate_Hand_Totals()
    {
        Assert.AreEqual(hand_type.HighCard, Evaluate_Hand(Create_High_Card()), "evaluated High card wrong");
        Assert.AreEqual(hand_type.TwoKind, Evaluate_Hand(Create_Pair()), "evaluated a Pair wrong");
        Assert.AreEqual(hand_type.TwoPair, Evaluate_Hand(Create_Two_Pair()), "evaluated Two Pair wrong");
        Assert.AreEqual(hand_type.ThreeKind, Evaluate_Hand(Create_Three_Kind()), "evaluated Three of a Kind wrong");
        Assert.AreEqual(hand_type.Straight, Evaluate_Hand(Create_Staight()), "evaluated Straight wrong");
        Assert.AreEqual(hand_type.Flush, Evaluate_Hand(Create_Flush()), "evaluated Flush wrong");
        Assert.AreEqual(hand_type.FullHouse, Evaluate_Hand(Create_Full_House()), "evaluated a Full House wrong");
        Assert.AreEqual(hand_type.FourKind, Evaluate_Hand(Create_Four_Kind()), "evaluated Four of a Kind wrong");
        Assert.AreEqual(hand_type.StraightFlush, Evaluate_Hand(Create_Straight_Flush()), "evaluated High card wrong");
    }

    Card[] Create_Flush()
    {
        return new Card[]
        {new Card(7,Card.Suits.Clubs),
        new Card(7,Card.Suits.Clubs),
        new Card(7,Card.Suits.Clubs),
        new Card(14,Card.Suits.Clubs),
        new Card(12,Card.Suits.Clubs)};
    }

    Card[] Create_Staight()
    {
        return new Card[]
        {new Card(10, Card.Suits.Hearts),
        new Card(11, Card.Suits.Clubs),
        new Card(12, Card.Suits.Diamonds),
        new Card(13),
        new Card(14)};
    }

    Card[] Create_Straight_Flush()
    {
        return new Card[]
        {new Card(),
        new Card(10),
        new Card(12),
        new Card(13),
        new Card(11)};
    }

    Card[] Create_High_Card()
    {
        return new Card[]
        {new Card(2,Card.Suits.Spades),
        new Card(5,Card.Suits.Clubs),
        new Card(7,Card.Suits.Clubs),
        new Card(14,Card.Suits.Clubs),
        new Card(12,Card.Suits.Clubs)};
    }

    Card[] Create_Four_Kind()
    {
        return new Card[]
        {
            new Card(7, Card.Suits.Hearts),
            new Card(7),
            new Card(7),
            new Card(7),
            new Card(9)
        };
    }

    Card[] Create_Three_Kind()
    {
        return new Card[]
        {
            new Card(3, Card.Suits.Hearts),
            new Card(3),
            new Card(3),
            new Card(4),
            new Card(2)
        };
    }

    Card[] Create_Full_House()
    {
        return new Card[]
        {
            new Card(5, Card.Suits.Hearts),
            new Card(5),
            new Card(5),
            new Card(8),
            new Card(8)
        };
    }

    Card[] Create_Two_Pair()
    {
        return new Card[]
        {
            new Card(5, Card.Suits.Clubs),
            new Card(5),
            new Card(3),
            new Card(3),
            new Card(2)
        };
    }

    Card[] Create_Pair()
    {
        return new Card[]
        {
            new Card(9, Card.Suits.Diamonds),
            new Card(9),
            new Card(6),
            new Card(5),
            new Card(4)
        };
    }
}
