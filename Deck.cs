using Godot;
using System;
using System.Collections.Generic;

public partial class Deck : Node
{
	public List<Card> cards = new List<Card>();
	public Random rng = new Random();

	public void Populate_Deck()
	{
		for(int i= 0; i < 52; i++)
		{
			Card.Suits card_suit = (Card.Suits)(i/13);
			int card_value = i%13 + 2;
			Card new_card = new Card(card_value, card_suit);
			cards.Add(new_card);
		}
	}

    public override void _Ready()
    {
        Populate_Deck();
		Shuffle_Deck();
		//Print_Deck();
		int aceS_index = Find_Card(new Card());
		Card will_move_to_last = cards[aceS_index -1];
		GD.Print(will_move_to_last + " will move to 52");
		GD.Print(cards[aceS_index] + " is at " + (aceS_index + 1));

		Cut_Deck_By_Card(cards[aceS_index]);
		int last_card = Find_Card(will_move_to_last);
		aceS_index = Find_Card(new Card());
		GD.Print($"last card is {cards[last_card]} at {last_card + 1}");
		GD.Print(cards[aceS_index] + " is at " + (aceS_index + 1));
    }

	void Print_Deck()
	{
		foreach(Card c in cards)
		{
			GD.Print(c);
		}
	}

	public void Shuffle_Deck()
	{
		int n = cards.Count;
        while(n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
	}

	int Find_Card(Card desired_card)
	{
		return cards.FindIndex(desired_card.Is_Match);
	}

	void Cut_Deck_By_Card(Card card)
	{
		int cut_position = Find_Card(card) -1;
		for (int i = cut_position; i >= 0; i--)
		{
			//TODO: this sucks ↓
			Card card_ref = cards[0];
			cards.RemoveAt(0);
			cards.Add(card_ref);
		}
	}
}
