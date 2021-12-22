using System;
using System.Collections.Generic;


namespace Project1
{
    class Program
    {   
        static void Main(string[] args)
        {
            int choice;

            // Creating a board object
            Board board = new Board();

            // Initializing Game Tens
            TensBoard tens = new TensBoard();

            // Initializing Game Elevens
            ElevensBoard elevens = new ElevensBoard();

            // Initializing Game Thirteens
            ThirteensBoard thirteens = new ThirteensBoard();

            // Creating a deck object
            Deck deck = new Deck();

            // Create a new card list
            List<Card> cardList = new List<Card>();

            choice = PrintMenu();

            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:

                        // Deal 13 cards from the deck and add them into the card list
                        board.DealCards(13, cardList);
                        // Print cards in the card list and ask user select two cards from the list from the command line
                        deck.PrintDeck(cardList);

                        Console.WriteLine("\n\t" + (deck.CardListCount() - deck.CardListCount(cardList)) + " Cards Remaining");
                        Console.WriteLine("\n\tYour Score is: " + board.Score);

                        // Checking if card list don't contain pairs...
                        board.PairCheck(cardList, 10);

                        // Asking for Card 1 and Card 2
                        board.UserCards(cardList, 13);

                        // Play Tens Game
                        tens.TensGame(cardList, board.card1, board.card2, board.cardValue);
                        break;
                    case 2:
                        // Deal 9 cards from the deck and add them into the card list
                        board.DealCards(9, cardList);

                        // Print cards in the card list and ask user select two cards from the list from the command line
                        deck.PrintDeck(cardList);

                        Console.WriteLine("\n\t" + (deck.CardListCount() - deck.CardListCount(cardList)) + " Cards Remaining");
                        Console.WriteLine("\n\tYour Score is: " + board.Score);

                        // Checking if card list no contain pairs...
                        board.PairCheck(cardList, 11);

                        // Asking for Card 1 and Card 2
                        board.UserCards(cardList, 11);

                        // Play Tens Game
                        elevens.ElevensGame(cardList, board.card1, board.card2, board.cardValue);
                        break;
                    case 3:
                        // Deal 10 cards from the deck and add them into the card list
                        board.DealCards(10, cardList);

                        // Print cards in the card list and ask user select two cards from the list from the command line
                        deck.PrintDeck(cardList);

                        Console.WriteLine("\n\t" + (deck.CardListCount() - deck.CardListCount(cardList)) + " Cards Remaining");
                        Console.WriteLine("\n\tYour Score is: " + board.Score);

                        // Checking if card list no contain pairs...
                        board.PairCheck(cardList, 13);

                        // Asking for Card 1 and Card 2
                        board.UserCards(cardList, 10);

                        // Play Tens Game
                        thirteens.ThirteensGame(cardList, board.card1, board.card2, board.cardValue);
                        break;
                    default:
                        Console.WriteLine( "Please, select between 1, 2 and 3");
                        break;
                }
                choice = PrintMenu();
            }
        }

        public static int PrintMenu()
        {
            int menu;
            Console.WriteLine("Select the game that you want to play:\n");
            Console.WriteLine("\n\t1: Play Tens Game.");
            Console.WriteLine("\n\t2: Play Elevens Game.");
            Console.WriteLine("\n\t3: Play Thirteens Game.");
            Console.WriteLine("\n\t4: Quit.\n\n");
            menu = Convert.ToInt32(Console.ReadLine());
         

            return menu;
        }
    }
}
