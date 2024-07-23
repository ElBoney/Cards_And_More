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
		//Shuffle_Deck();
		Card middle_card = cards[26];
		GD.Print(middle_card);
		Cut_Deck_By_Card(middle_card);
		//Cut_Deck_By_Position(26);
		Print_Deck();
		
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
		return cards.FindIndex(desired_card.Equals);
	}

	void Cut_Deck_By_Card(Card card)
	{
		int cut_position = Find_Card(card);
		Cut_Deck_By_Position(cut_position);
	}

	void Cut_Deck_By_Position(int cut_position)
	{
		List<Card> cut_cards = cards.GetRange(0,cut_position);
		cards.RemoveRange(0,cut_position);
		cards.AddRange(cut_cards);
		cut_position--;
	}

}
