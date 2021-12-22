using System;
using System.Collections.Generic;
using System.Text;


namespace Project1
{
    public class ThirteensBoard
    {
        Board board = new Board();
        Deck deck = new Deck();

        public void RemoveK(List<Card> list)
        {
            bool King = false;
            bool flag = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Rank == "King" && !King)
                    King = true;
                else
                    continue;
            }

            if (King)
            {
                string userInput;
                do
                {
                    Console.WriteLine("\nYou have a King! \nWould you like to take them out? \n");
                    Console.WriteLine("Answer (Y/N): ");
                    userInput= Console.ReadLine();
                } while (userInput != "Y" && userInput != "y" && userInput != "n" && userInput != "N");

                if (userInput == "n" || userInput == "N")
                    return;
                else
                {
                    do
                    {
                        King = false;

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "King" && !King)
                            {
                                King = true;
                                list.RemoveAt(i);
                            }
                        }

                        board.DealCards(13, list);
                        deck.PrintDeck(list);

                        Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                        Console.WriteLine("\n\tYour score is : " + board.Score);

                        flag = true;
                    } while (!flag);
                }
            }
        }
    
     
        public void ThirteensGame(List<Card> list, int card1, int card2, int cardValue)
        {
            bool flag = false;
            // Repeat this task until user are not able to find two cards in the card list with total equals 10.
            do
            {
                Console.WriteLine("\nValue between cards selected is: " + cardValue + "\n");

                if (cardValue != 13)
                {
                    flag = true;
   
                    deck.PrintDeck(list);

                    Console.WriteLine("\nNumber of Cards from the Deck: " + deck.CardListCount());

                }
                else
                {
                    board.RemoveReplace(card1, card2, list);
                    board.scorePoint(1);
                }

                deck.PrintDeck(list);

                Console.WriteLine("\n\t" + (board.CardsRemaining - deck.CardListCount(list)) + " Undealt Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + board.Score);

                RemoveK(list);

                board.PairCheck(list,13);

                board.UserCards(list, 10);

            } while (!flag);
        }
    }
}
