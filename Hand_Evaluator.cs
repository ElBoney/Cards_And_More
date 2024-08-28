using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Hand_Evaluator : Node
{
    public enum hand_type
    {
        HighCard = 1,
        TwoKind,
        TwoPair,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind,
        StraightFlush,
        RoyalFlush
    }

    public hand_type Evaluate_Hand(Card[] hand)
    {
        hand = hand.OrderByDescending(card => card.value).ToArray();
        
        hand_type value = hand_type.HighCard;
        if(Is_Flush(hand))
        { value = hand_type.Flush;}
        
        if(Is_Straight(hand))
        {
            if(value == hand_type.Flush)
            {
                value = hand_type.StraightFlush;
                return value;
            }
            else{value = hand_type.Straight;}
        }

        hand_type compare_value = Find_Match_Tier(hand);
        if(value > compare_value){return value;}
        value = compare_value;


        return value;
    }

    protected bool Is_Flush(Card[] cards)
    {
        int[] suit_matches = {0,0,0,0};

        foreach(Card c in cards)
        {
            switch(c.suit)
            {
                case 0:
                    suit_matches[0]++;
                    break;
                case (Card.Suits)1:
                    suit_matches[1]++;
                    break;
                case (Card.Suits)2:
                    suit_matches[2]++;
                    break;
                case (Card.Suits)3:
                    suit_matches[3]++;
                    break;
                default:
                    break;
            }
        }
        foreach(int i in suit_matches)
        {
            if(i >= 5){return true;}
        }
        return false;
    }

    protected bool Is_Straight(Card[] hand)
    {
        int staight_count = 0;
        for(int i = 0; i < hand.Count() -1; i++)
        {
            if(hand[i].value - hand[i+1].value == 1)
            {
                staight_count++;
            }
            else{staight_count = 0;}

            if(staight_count == 4){return true;}
        }
        return false;
    }

    protected hand_type Find_Match_Tier(Card[] hand)
    {
        Dictionary<int,int> pair_finder = new Dictionary<int, int>();
        foreach(Card c in hand)
        {
            if(!pair_finder.ContainsKey(c.value))
            {
                pair_finder.Add(c.value, 1);
                continue;
            }
            pair_finder[c.value]++;
        }

        int pairs = 0;
        bool has_threekind = false;
        foreach(int i in pair_finder.Values)
        {
            switch(i)
            {
                case >=4:
                    return hand_type.FourKind;
                case 3:
                    has_threekind = true;
                    break;
                case 2:
                    pairs++;
                    break;
                default:
                    break;
            }
        }
        if(has_threekind)
        {
            if(pairs > 0){return hand_type.FullHouse;}
            return hand_type.ThreeKind;
        }
        switch(pairs)
        {
            case >=2:
                return hand_type.TwoPair;
            case 1:
                return hand_type.TwoKind;
            default:
                break;
        }

        return hand_type.HighCard;
    }

}
