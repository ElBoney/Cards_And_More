using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Card_Dealer : Node2D
{
	Deck deck = new Deck();
	Hand_Evaluator hand_evaluator = new Hand_Evaluator();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		deck.Shuffle_Deck();
		Create_Hand();
	}

	Card[] Draw_Cards(int how_many)
	{
		Card[] hand = new Card[how_many];
		for(int i = 0; i< how_many; i++)
		{
			hand[i] = deck.cards[i];
		}

		return hand;
	}

	void Create_Hand()
	{
		Clear_Hand();
		Card[] hand = Draw_Cards(5);
		deck.Cut_Deck_By_Position(5);
		PackedScene new_card_scene = ResourceLoader.Load<PackedScene>("res://Card.tscn");
		
		for(int i = 0; i < 5; i++)
		{
			Card_Object new_card = new_card_scene.Instantiate<Card_Object>();
			new_card.card = hand[i];
			//new_card.Position = GetChild<Node2D>(i).Position;
			GetNode("Hand_Container").GetChild(i).AddChild(new_card);
		}
		GetNode<Label>("Label").Text = hand_evaluator.Evaluate_Hand(hand).ToString();
	}

	void Clear_Hand()
	{
		foreach(Node child_container in GetNode("Hand_Container").GetChildren())
		{
			if(child_container.GetChildCount() == 0) {continue;}
			child_container.GetChild(0).QueueFree();
		}
	}

	void Print_Card(int index)
	{
		GD.Print(deck.cards[index]);
	}

    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("SpaceBar"))
		{
			Clear_Hand();
		}
    }

	public void Redraw_Cards()
	{
		List<Card> hand = new List<Card>();
		foreach(Node card_container in GetNode("Hand_Container").GetChildren())
		{
			Card_Object card = card_container.GetChild<Card_Object>(0);
			if(card.ButtonPressed)
			{
				card.QueueFree();
				PackedScene new_card_scene = ResourceLoader.Load<PackedScene>("res://Card.tscn");
				Card_Object new_card = new_card_scene.Instantiate<Card_Object>();
				new_card.card = deck.cards[0];
				deck.Cut_Deck_By_Position(1);
				card_container.AddChild(new_card);
				card = new_card;
			}
			hand.Add(card.card);
		}
		GetNode<Label>("Label").Text = hand_evaluator.Evaluate_Hand(hand.ToArray<Card>()).ToString();
	}
}
