using Godot;
using System;
using System.Collections;
using System.Net.Security;
using System.Runtime.CompilerServices;

public partial class Card : Node
{
	public enum Suits
	{
		Hearts,
		Clubs,
		Diamonds,
		Spades
	}

	public Suits suit;
	public int value;

	public Card(int value = 14, Suits suit = Suits.Spades)
	{
		
		this.value = Math.Clamp(value,2, 14);
		this.suit = suit;
	}

	string Face_Name
	{
		get
		{
			string value_name = "";
			switch(value)
			{
				case 11:
					value_name = "Jack";
					break;
				case 12:
					value_name  = "Queen";
					break;
				case 13:
					value_name = "King";
					break;
				case 14:
					value_name = "Ace";
					break;
				default:
					value_name = value.ToString();
					break;
			}
			return value_name + " of " + suit;
		}
	}

	public override string ToString()
	{
		return Face_Name;
	}

    public override bool Equals(object obj)
    {
        if(obj is Card c)
		{
			if(value == c.value && suit == c.suit)
			{return true;}
		}
		return false;
    }

    public static bool operator ==(Card c1, Card c2){return c1.Equals(c2);}
	public static bool operator !=(Card c1, Card c2){return !c1.Equals(c2);}
}
