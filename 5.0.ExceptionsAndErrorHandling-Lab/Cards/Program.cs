namespace Cards;

public class Program
{
    private static readonly List<string> faces = new List<string>
    { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    private static readonly Dictionary<string, char> suits = new Dictionary<string, char>
    {
        { "S", '\u2660' },
        { "H", '\u2665' },
        { "D", '\u2666' },
        { "C", '\u2663' }
    };

    private class Card 
    {
        public Card(string face, string suit)
        {
            if (!faces.Contains(face))
            {
                throw new ArgumentException("Invalid card!");
            }

            if (!suits.ContainsKey(suit))
            {
                throw new ArgumentException("Invalid card!");
            }
            Face = face;
            Suit = suits[suit];
        }

        public string Face { get; }
        public char Suit { get; }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }

    public static void Main(string[] args)
    {
        List<Card> listOfCards = new List<Card>();

        string[] inputLine = Console.ReadLine().Split(", ");
        foreach (string line in inputLine)
        {
            try
            {

                string[] cardData = line.Split(" ");

                Card newCard = new Card(cardData[0], cardData[1]);
                listOfCards.Add(newCard);

            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
        }
        Console.WriteLine($"{string.Join(" ",listOfCards)}");
    }
}
