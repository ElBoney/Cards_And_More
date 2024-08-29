using Godot;

public partial class Card_Object : TextureButton
{
    public Card card = new Card();

    public override void _Draw()
    {
        GetNode<Label>("Label").Text = card.ToString();
    }
}
