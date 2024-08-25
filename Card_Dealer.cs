using Godot;

public partial class Card_Dealer : Node2D
{
	Deck deck = new Deck();
	
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
			Node2D new_card = new_card_scene.Instantiate<Node2D>();
			new_card.GetChild<Label>(0).Text = hand[i].ToString();
			new_card.Position = GetChild<Node2D>(i).Position;
			GetNode("Hand").AddChild(new_card);
		}
	}

	void Clear_Hand()
	{
		foreach(Node child_card in GetNode("Hand").GetChildren())
		{
			child_card.QueueFree();
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
}
