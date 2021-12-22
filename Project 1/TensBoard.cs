using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class TensBoard
    {
        Board board = new Board();
        Deck deck = new Deck();

        
        


  
        public void TensGame(List<Card> list, int card1, int card2, int cardValue)
        {
            bool flag = false;
            // Repeat this task until user are not able to find two cards in the card list with total equals 10.
            do
            {
                Console.WriteLine("\nValue between cards selected is: " + cardValue + "\n");

                if(cardValue != 10)
                {
                    flag = true;

                    Console.WriteLine("\nValue has to be equal to 10!");

                    board.DealCards(13, list);

                    // Print the cards in the card list and the number of cards in the deck
                    deck.PrintDeck(list);
                    Console.WriteLine("\nCards Remaining: " + deck.CardListCount());
                }

                // Remove the two card from the list if the total value of the two cards equals to 10,
                // and then deal two more cards from the deck and fill the empty slots.
                else
                {
                    board.RemoveReplace(card1, card2, list);
                    board.scorePoint(1);
                }

                deck.PrintDeck(list);

                Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list))+ " Cards Remaining");
                Console.WriteLine("\n\tYour score is : " + board.Score);

                board.RemoveTJQK(list);

                board.PairCheck(list, 10);

                board.UserCards(list, 13);

            } while (!flag);
        } 
    }
}
