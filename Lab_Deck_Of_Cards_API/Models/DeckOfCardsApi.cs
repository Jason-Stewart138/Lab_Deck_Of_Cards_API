namespace Lab_Deck_Of_Cards_API.Models
{
	public class DeckOfCardsApi
	{		
		public bool success { get; set; }
        public string deck_id { get; set; }
        public int remaining { get; set; }
		public bool shuffled { get; set; }
		public DrawCard[] cards { get; set; }

	}
}
