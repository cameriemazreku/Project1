
using System;
using System.Collections.Generic;
using System.Text;


namespace Project1
{
    public class Board
    {
        Deck deck = new Deck();
        
        public int card1, card2, cardValue = 0, score = 0;
        
        // Getting User Cards
        public void UserCards(List<Card> list, int max)
        {
            Console.WriteLine("\n\nPlease, select two cards from the list.");

            do
            {
 
                Console.Write("\nCard #1: ");
                card1 = Convert.ToInt32(Console.ReadLine());
            } while (card1 < 1 || card1 > max);

            do
            {
                Console.Write("\nCard #2: ");
                card2 = Convert.ToInt32(Console.ReadLine());
            } while (card2 < 1 || card2 > max || card1 == card2);

            cardValue = list[card1 - 1].getCardValue();

            cardValue += list[card2 - 1].getCardValue();
        }

        // Dealing Cards using NumCards as number of cards from specific game
        public void DealCards(int num, List<Card> list)
        {
     
            deck.Shuffle();

            Console.WriteLine("\nDealing " + num + " cards to new list card...\n");

            if (deck.CardListCount() >= num)
            {
                for (int i = 0; i < num; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
            }
                
            else if (deck.CardListCount() >= num - 1)
            {
                for (int i = 0; i < num- 1; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
                Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + Score);
            }
                
            else if (deck.CardListCount() >= num- 2)
            {
                for (int i = 0; i < num - 2; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
                Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + Score);
            }

            else if (deck.CardListCount() >= num - 3) 
            { 
                for (int i = 0; i < num - 3; i++)
                {
                    list.Add(deck.TakeTopCard());
                }
                Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Cards Remaining...");
                Console.WriteLine("\n\tYour score is : " + Score);
            }
            else
                Console.WriteLine("\nDeck Empty\n");

            


        }

        // Removing and Replacing cards after user choice
        public void RemoveReplace(int card1, int card2, List<Card> list)
        {
            if (card1 > card2)
            {
                list.RemoveAt(card1 - 1);

                if (deck.CardListCount(list) == 1)
                    HasWon();
                else
                    list.RemoveAt(card2 - 1);
            }
            else
            {
                list.RemoveAt(card1 - 1);

                if (card2 == 2)
                {
                    if (deck.CardListCount(list) == 1)
                        HasWon();
                    else
                        list.RemoveAt(card2 - 2);
                }
                else
                    list.RemoveAt(card2 - 2);
            }

            for (int i = 11; i < 13; i++)
            {
                if (deck.CardListCount() >= 2)
                {
                    list.Add(deck.TakeTopCard());
                }
                else if (deck.CardListCount() >= 1)
                {
                    list.Add(deck.TakeTopCard());
                    break;
                }
                else
                    break;

            }

        }

        public void HasWon()
        {
            Console.WriteLine("\n\tYour score is : " + Score);
            Console.WriteLine("\nYOU WIN THIS GAME! CONGRATULATIONS :D\n");
            System.Environment.Exit(0);
        }
        public int CardsRemaining
        {
            get { return deck.CardListCount(); }
        }
        public int Score
        {
            get { return score; }
        }
        public void scorePoint(int point)
        {
            score += point;
        }

        public void resetGame()
        {

        }

        internal void UserCards(List<Card> list)
        {
            throw new NotImplementedException();
        }
        public void PairCheck(List<Card> list, int gameNum)
        {
            int counter = 0, cardValue;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1 + i; j < list.Count; j++)
                {
                    cardValue = list[i].getCardValue() + list[j].getCardValue();
                    if (cardValue == gameNum)
                        counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine(" \nNO PAIR AVALABLE. GAME OVER.\nNumber of cards remaining in Deck: " + deck.CardListCount());
                System.Environment.Exit(0);
            }
        }
        public void RemoveJQK(List<Card> list)
        {

            bool J, Q, K, flag;
                    do
                    {
            
                        J = false;
                        Q = false;
                        K = false;

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Jack" && !J)
                            {
                                J = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Queen" && !Q)
                            {
                                Q = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "King" && !K)
                            {
                                K = true;
                                list.RemoveAt(i);
                            }
                        }

                        DealCards(3, list);
                        deck.PrintDeck(list);

                        Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Cards Remaining");
                        Console.WriteLine("\n\tYour score is : " + Score);

                        flag = true;
                    } while (!flag);
                }

        public void RemoveTJQK(List<Card> list)
        {
            bool T = false;
            bool J = false;
            bool Q = false;
            bool K = false;
            bool flag = false;

                    do
                    {
            

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Ten" && !T)
                            {
                                T = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Jack" && !J)
                            {
                                J = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "Queen" && !Q)
                            {
                                Q = true;
                                list.RemoveAt(i);
                            }
                        }

                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].Rank == "King" && !K)
                            {
                                K = true;
                                list.RemoveAt(i);
                            }
                        }

                        DealCards(4, list);
                        deck.PrintDeck(list);

                        Console.WriteLine("\n\t" + (CardsRemaining - deck.CardListCount(list)) + " Cards Remaining...");
                        Console.WriteLine("\n\tYour score is : " + Score);

                        flag = true;
                    } while (!flag);
                }
            }

        }
        


    