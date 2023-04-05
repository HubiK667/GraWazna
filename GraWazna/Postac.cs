using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraWazna
{

    class Postac
    {
        public string Nazwa;
        public string Plec;
        public int Poziom;
        public Ekwipunek Ek;

        public class Ekwipunek
        {
            public string Miecz;
            public string Zbroja;

            public void PoprawEkwipunek(int poziom)
            {
                if (poziom >= 100 && poziom < 130)
                {
                    Miecz = "drewniany";
                    Zbroja = "drewniana";
                }
                else if (poziom >= 130 && poziom < 150)
                {
                    Miecz = "żelazny";
                    Zbroja = "żelazna";
                }
                else if (poziom >= 150 && poziom < 170)
                {
                    Miecz = "złoty";
                    Zbroja = "złota";
                }
                else if (poziom >= 170)
                {
                    Miecz = "tytanowy";
                    Zbroja = "tytanowa";
                }
            }

            public override string ToString()
            {
                return $"Ekwipunek: Miecz: {Miecz}, Zbroja: {Zbroja}";
            }
        }

        public void ZmienPoziom(int punkty)
        {
            Poziom += punkty;
            Ek.PoprawEkwipunek(Poziom);
        }

        public override string ToString()
        {
            return $"Postać: {Nazwa}, Płeć: {Plec}, Poziom: {Poziom}\n{Ek}";
        }


        class Gra
        {
            private Random rand = new Random();
            private Postac postacA;
            private Postac postacB;

            public Gra()
            {
                postacA = new Postac()
                {
                    Nazwa = "Postać A",
                    Plec = "kobieta",
                    Poziom = rand.Next(100, 151),
                    Ek = new Postac.Ekwipunek()
                };
                postacA.Ek.PoprawEkwipunek(postacA.Poziom);

                postacB = new Postac()
                {
                    Nazwa = "Postać B",
                    Plec = "mężczyzna",
                    Poziom = rand.Next(120, 171),
                    Ek = new Postac.Ekwipunek()
                };
                postacB.Ek.PoprawEkwipunek(postacB.Poziom);
            }

            public void WylosujEkwipunek(Postac postac)
            {
                int los = rand.Next(1, 3);
                if (los == 1)
                {
                    postac.Ek.Miecz = "M";
                }
                else
                {
                    postac.Ek.Zbroja = "Z";
                }
            }

            public void Rozgrywka()
            {
                WylosujEkwipunek(postacA);
                WylosujEkwipunek(postacB);

                Console.WriteLine("Postać A:");
                Console.WriteLine(postacA);

                Console.WriteLine("Postać B:");
                Console.WriteLine(postacB);

                if (postacA.Ek.Miecz == "M" && postacB.Ek.Zbroja == "Z")
                {
                    postacA.ZmienPoziom(10);
                }
                else if (postacA.Ek.Miecz == "M" && postacB.Ek.Zbroja == "M")
                {
                    if (postacA.Poziom > postacB.Poziom)
                    {
                        postacA.ZmienPoziom(10);
                    }
                    else
                    {
                        postacB.ZmienPoziom(10);
                    }
                }
                
               
            }

        }
    }
}
            





            
