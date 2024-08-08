using System;
using System.Collections.Generic;

public partial class Deck
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

	public Deck()
	{
		Populate_Deck();
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

	public int Find_Card(Card desired_card)
	{
		return cards.FindIndex(desired_card.Equals);
	}

	public void Cut_Deck_By_Card(Card card)
	{
		int cut_position = Find_Card(card);
		Cut_Deck_By_Position(cut_position);
	}

	public void Cut_Deck_By_Position(int cut_position)
	{
		List<Card> cut_cards = cards.GetRange(0,cut_position);
		cards.RemoveRange(0,cut_position);
		cards.AddRange(cut_cards);
	}

}
