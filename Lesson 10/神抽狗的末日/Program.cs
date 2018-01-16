using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 神抽狗的末日
{
    enum CardType
    {
        SSR,
        SR,
        R,
        A,
        B
    }

    class Program
    {
        static Random random = new Random();

        static List<Card> Cardlist()
        {
            List<Card> CardList = new List<Card>();
            Card card1 = new Card("关羽", CardType.SR);
            CardList.Add(card1);
            Card card2 = new Card("赵云", CardType.SSR);
            CardList.Add(card2);
            Card card3 = new Card("华雄", CardType.A);
            CardList.Add(card3);
            Card card4 = new Card("黄忠", CardType.R);
            CardList.Add(card4);
            Card card5 = new Card("吕布", CardType.SSR);
            CardList.Add(card5);
            Card card6 = new Card("颜良", CardType.R);
            CardList.Add(card6);
            Card card7 = new Card("廖化", CardType.B);
            CardList.Add(card7);
            Card card8 = new Card("张辽", CardType.R);
            CardList.Add(card8);
            Card card9 = new Card("文丑", CardType.A);
            CardList.Add(card9);
            Card card10 = new Card("魏延", CardType.R);
            CardList.Add(card10);
            return CardList;
        }

        static int GetCardWeight(List<Card> cardlist)
        {
            int weight = 0;
            foreach (Card card in cardlist)
            {
                weight += card.Weight;
            }
            return weight;

        }
        static Card GetCard(List<Card> cardlist)
        {
            Card card = null;
            int r = random.Next(GetCardWeight(cardlist));
            if (r <= 5)
            {
                List<Card> ssrlist = new List<Card>();
                foreach (Card _card in cardlist)
                {
                    if (_card.Weight == 5)
                    {
                        ssrlist.Add(_card);
                    }
                }
                card = ssrlist[random.Next(ssrlist.Count)];
            }
            else if (r <= 10)
            {
                List<Card> srlist = new List<Card>();
                foreach (Card _card in cardlist)
                {
                    if (_card.Weight == 10)
                    {
                        srlist.Add(_card);
                    }
                }
                card = srlist[random.Next(srlist.Count)];
            }
            else if (r <= 50)
            {
                List<Card> rlist = new List<Card>();
                foreach (Card _card in cardlist)
                {
                    if (_card.Weight == 50)
                    {
                        rlist.Add(_card);
                    }
                }
                card = rlist[random.Next(rlist.Count)];
            }
            else if (r <= 100)
            {
                List<Card> alist = new List<Card>();
                foreach (Card _card in cardlist)
                {
                    if (_card.Weight == 100)
                    {
                        alist.Add(_card);
                    }
                }
                card = alist[random.Next(alist.Count)];
            }
            else if (r <= 200)
            {
                List<Card> blist = new List<Card>();
                foreach (Card _card in cardlist)
                {
                    if (_card.Weight == 200)
                    {
                        blist.Add(_card);
                    }
                }
                card = blist[random.Next(blist.Count)];
            }
            else
            {
                card = new Card("强化狗粮卡", CardType.B);
            }
            return card;
        }
        static void Main(string[] args)
        {
            int times = 1;
            while (true)
            {
                List<Card> list = Cardlist();
                Card card = GetCard(list);
                Console.WriteLine("你抽到了:{0}.{1},你一共抽了{2}次", card.Type, card.Name, times);
                Console.ReadKey();
                if (card.Type == CardType.SSR || card.Type == CardType.SR)
                {
                    Console.ReadLine();
                }
                Console.Clear();
                times++;
            }


        }
    }
    class Card
    {
        public string Name;
        public CardType Type;
        public int Weight;
        public Card(string name, CardType type)
        {
            Name = name;
            Type = type;
            if (Type == CardType.SSR)
            {
                Weight = 5;
            }
            else if (Type == CardType.SR)
            {
                Weight = 10;
            }
            else if (Type == CardType.R)
            {
                Weight = 50;
            }
            else if (Type == CardType.A)
            {
                Weight = 100;
            }
            else
            {
                Weight = 200;
            }
        }
    }
}
