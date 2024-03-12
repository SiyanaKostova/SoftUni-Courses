using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        List<Card> cards = new List<Card>();
        string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input.Length; i += 2)
        {
            try
            {
                string face = input[i];
                string suit = input[i + 1];

                Card card = new Card();
                card = card.CreateCard(face, suit);
                cards.Add(card);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var card in cards)
        {
            Console.Write($"{card} ");
        }
    }
}

public class Card
{
    public Card(){}

    public Card(string face, string suit)
        : this()
    {
        Face = face;
        Suit = suit;
    }

    public string Face { get; private set; }
    public string Suit { get; private set; }

    public Card CreateCard(string face, string suit)
    {
        string[] faces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] suits = new string[] { "S", "H", "D", "C" };

        if (faces.Contains(face) && suits.Contains(suit))
        {
            return new Card(face, suit);
        }
        else
        {
            throw new ArgumentException("Invalid card!");
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        char S = '\u2660';
        char H = '\u2665';
        char D = '\u2666';
        char C = '\u2663';

        if (Suit == "S")
        {
            sb.Append($"[{Face}{S}]");
        }
        else if (Suit == "H")
        {
            sb.Append($"[{Face}{H}]");
        }
        else if (Suit == "D")
        {
            sb.Append($"[{Face}{D}]");
        }
        else if (Suit == "C")
        {
            sb.Append($"[{Face}{C}]");
        }
        return sb.ToString().TrimEnd();
    }
}

