using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class ElevensBoard
    {
        Board board = new Board();
        Deck deck = new Deck();


   
        public void ElevensGame(List<Card> list, int card1, int card2, int cardValue)
        {
            bool flag = false;
            // Repeat this task until user are not able to find two cards in the card list with total equals 10.
            do
            {
                Console.WriteLine("\nValue between cards selected is: " + cardValue + "\n");

                if (cardValue != 11)
                {
                    flag = true;

                    if (cardValue > 11)
                        Console.WriteLine("\nValue has exceeded!");
                    else
                        Console.WriteLine("\nValue has is less than expected!");

                    // Print the cards in the card list and the number of cards in the deck
                    Console.WriteLine("\nPrinting Cards from the Card List: \n");
                    deck.PrintDeck(list);

                    Console.WriteLine("\nNumber of Cards from the Deck: " + deck.CardListCount());

                }

                // Remove the two card from the list if the total value of the two cards equals to 10,
                // and then deal two more cards from the deck and fill the empty slots.
                else
                {
                    board.RemoveReplace(card1, card2, list);
                    board.scorePoint(1);
                }

                deck.PrintDeck(list);

                Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list)) + " Cards Remaining");
                Console.WriteLine("\n\tYour score is : " + board.Score);

                board.RemoveJQK(list);

                board.PairCheck(list,11);

                board.UserCards(list);

            } while (!flag);
        }
    }
}
