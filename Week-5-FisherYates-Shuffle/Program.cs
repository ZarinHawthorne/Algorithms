namespace Week_5_FisherYates_Shuffle
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the game of War!");

            // Create and shuffle the deck
            List<Card> deck = CreateShuffledDeck();

            // Initialize players and their decks
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            player1.InitializeDeck(deck.GetRange(0, 26));
            player2.InitializeDeck(deck.GetRange(26, 26));

            Console.WriteLine("Players have been initialized with shuffled decks.");
            Console.WriteLine("Let's play!");

            // Play the game
            while (player1.HasCards() && player2.HasCards())
            {
                PlayRound(player1, player2);
            }

            // Determine the winner
            if (player1.HasCards())
            {
                Console.WriteLine($"Player 1 wins the game!");
            }
            else
            {
                Console.WriteLine($"Player 2 wins the game!");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static List<Card> CreateShuffledDeck()
        {
            List<Card> deck = new List<Card>();
            // Initialize the deck with all 52 cards
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(rank, suit));
                }
            }

            // Shuffle the deck using Fisher-Yates algorithm
            Random random = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }

            return deck;
        }

        static void PlayRound(Player player1, Player player2)
        {
            Card card1 = player1.DrawCard();
            Card card2 = player2.DrawCard();

            Console.WriteLine($"Player 1 plays: {card1}");
            Console.WriteLine($"Player 2 plays: {card2}");

            if (card1.CompareTo(card2) > 0)
            {
                Console.WriteLine("Player 1 wins the round!");
                player1.AddToGarbagePile(card1);
                player1.AddToGarbagePile(card2);
            }
            else if (card1.CompareTo(card2) < 0)
            {
                Console.WriteLine("Player 2 wins the round!");
                player2.AddToGarbagePile(card1);
                player2.AddToGarbagePile(card2);
            }
            else
            {
                Console.WriteLine("It's a tie! Cards go to garbage piles.");
                player1.AddToGarbagePile(card1);
                player2.AddToGarbagePile(card2);
            }

            Console.WriteLine($"Player 1 cards left: {player1.DeckCount()}, Player 2 cards left: {player2.DeckCount()}");
            Console.WriteLine();
        }
    }

    enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    enum Rank
    {
        Ace = 1,
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack, Queen, King
    }

    class Card : IComparable<Card>
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public int CompareTo(Card other)
        {
            return Rank.CompareTo(other.Rank);
        }
    }

    class Player
    {
        private string name;
        private List<Card> deck;
        private List<Card> garbagePile;

        public Player(string name)
        {
            this.name = name;
            deck = new List<Card>();
            garbagePile = new List<Card>();
        }

        public void InitializeDeck(List<Card> cards)
        {
            deck.AddRange(cards);
        }

        public bool HasCards()
        {
            return deck.Count > 0;
        }

        public Card DrawCard()
        {
            if (deck.Count == 0)
            {
                // Shuffle garbage pile into deck
                deck.AddRange(garbagePile);
                garbagePile.Clear();
                // Reshuffle deck
                deck = Program.CreateShuffledDeck();
            }
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            return drawnCard;
        }

        public void AddToGarbagePile(Card card)
        {
            garbagePile.Add(card);
        }

        public int DeckCount()
        {
            return deck.Count;
        }
    }   
}
