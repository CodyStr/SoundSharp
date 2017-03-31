using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundsharp
{
    class Program
    {
        static string name;

        //Zorgt ervoor dat als je het autologin programma opend, je die eerst krijgt.
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                if (LoginStatus(args[1]) == true)
                {
                    AutoLogin();
                }
                else
                {
                    Console.WriteLine("Er is iets fout gegaan.");
                }
            }
            LogIn();
        }

        //Het autologin menu (Wat je tezien krijgt als je de admin exe gebruikt)
        static void AutoLogin()
        {
            Console.Clear();
            int totaalVoorraad = 0;
            double totaalWaarde = 0;
            double gemiddeldWaarde = 0;
            double bestePrijsPerMb = 0;
            foreach (mp3player mp3 in mp3list)
            {
                Console.Clear();
                Console.WriteLine("=========ADMIN SOUNDSHARP=========");
                Console.WriteLine("");
                Console.WriteLine("====Statistieken====");
                Console.WriteLine();
                totaalVoorraad = totaalVoorraad + mp3.Voorraad;
                Console.WriteLine("Totaal voorraad: {0}", totaalVoorraad);

                totaalWaarde = totaalVoorraad * mp3.Price;
                Console.WriteLine("Totaal waarde: {0} euro", totaalWaarde);

                gemiddeldWaarde = totaalWaarde / 5;
                Console.WriteLine("Gemiddelde waarde van mp3: {0}", gemiddeldWaarde);

                bestePrijsPerMb = 224.95 / 8192;
                Console.WriteLine("Beste prijs per mB: {0}", bestePrijsPerMb);
                Console.WriteLine("");
            }
            Console.WriteLine("====Overzicht mp3 spelers====");
            Console.WriteLine("");
            foreach (mp3player mp3 in mp3list)
            {
                Console.WriteLine("ID: {0}", mp3.ID);
                Console.WriteLine("Make: {0}", mp3.Make);
                Console.WriteLine("Model: {0}", mp3.Model);
                Console.WriteLine("MBsize: {0}", mp3.MBsize);
                Console.WriteLine("Price: {0}", mp3.Price);
                Console.WriteLine("");
            }
            Console.WriteLine("====Overzicht voorraad====");
            Console.WriteLine("");
            foreach (mp3player mp3 in mp3list)
            {
                Console.WriteLine("ID: {0}", mp3.ID);
                Console.WriteLine("Voorraad: {0}", mp3.Voorraad);
                Console.WriteLine("");
            }
            Console.WriteLine("Druk op enter om in te loggen...");
            Console.ReadKey();
        }

        //Zorgt ervoor dat als het wachtwoord klopt dat die doorgaat
        static bool LoginStatus(string password)
        {
            if(password == "sharpsound")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
         
        //Inloggen en 3 waarschuwingen
        static void LogIn()
        {
            int poging = 3;
            string pogingWaarschuwing = null;
            do
            {
                Console.WriteLine("Pogingen over: {0}", poging);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}", pogingWaarschuwing);
                Console.ResetColor();
                Console.Write("Uw naam: ");
                name = Console.ReadLine();
                Console.Write("Wachtwoord: ");
                string password = Console.ReadLine();
                Console.Clear();

                if (LoginStatus(password) == true)
                {
                    Console.Clear();
                    Welcome();
                    break;
                }
                else
                {
                    poging--;
                    switch (poging)
                    {
                        case 1:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Red;
                            pogingWaarschuwing = "PAS OP! Laatste poging!";
                            Console.ResetColor();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }

                }
            }
            while (true);
        }

        //Welkom menu
        static void Welcome()
        {
            Console.WriteLine("Welkom bij Soundsharp, {0}.", name);
            Console.WriteLine("Druk op enter voor het menu.");
            Console.ReadKey();
            Console.Clear();
            mainMenu();
        }

        //Menu loop
        static void mainMenu()
        {

            { 
                const int maxMenuItems = 9;
                int selector = 0;
                bool good = false;
                while (selector != maxMenuItems)
                {
                    Console.Clear();
                    Console.WriteLine(" ===========MENU===========");
                    DrawMenu(maxMenuItems);
                    good = int.TryParse(Console.ReadLine(), out selector);
                    if (good)
                    {
                        switch (selector)
                        {
                            case 1:
                                Overzichtmp3();
                                break;
                            case 2:
                                OverzichtVoorraad();
                                break;
                            case 3:
                                MuteerVoorraad();
                                break;
                            case 4:
                                Console.Clear();
                                Statistieken();
                                break;
                            case 5:
                                Console.Clear();
                                ToevoegMp3();
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("// Code voor case 6");
                                break;
                            case 7:
                                Console.WriteLine("// Code voor case 7");
                                break;
                            case 8:
                                mainMenu();
                                break;
                            case 9:
                                Environment.Exit(0);
                                break;
                            default:
                                if (selector != maxMenuItems)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(" Typ fout, druk op enter om verder te gaan.");
                                    Console.ResetColor();
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Typ fout, druk op enter om verder te gaan.");
                        Console.ResetColor();
                    }
                    Console.ReadKey();
                }
            }
        }

        //Hoe het menu is ingedeeld + een static list van de mp3 spelers
        static void DrawMenu(int maxitems)
        {
            Console.WriteLine(" [1] Overzicht mp3 spelers");
            Console.WriteLine(" [2] Overzicht voorraad");
            Console.WriteLine(" [3] Muteer voorraad");
            Console.WriteLine(" [4] Statistieken");
            Console.WriteLine(" [5] Toevoegen mp3 speler");
            Console.WriteLine(" [6] Menu nummer zes");
            Console.WriteLine(" [7] Menu nummer zeven");
            Console.WriteLine(" [8] Toon menu");
            Console.WriteLine(" [9] Exit");
            Console.WriteLine("");
            Console.Write(" Maak een keuze: ");
        }

        static List<mp3player> mp3list = new List<mp3player>
        {
            new mp3player() {ID = 1, Make = "GET technologies .inc", Model = "HF 410" , MBsize = 4096, Price =  129.95, Voorraad = 500},
            new mp3player() {ID = 2, Make = "Far & Loud", Model = "XM 600" , MBsize = 8192, Price =  224.95, Voorraad = 500},
            new mp3player() {ID = 3, Make = "Innotivative", Model = "Z3" , MBsize = 512, Price =  79.95, Voorraad = 500},
            new mp3player() {ID = 4, Make = "Resistance S.A.", Model = "3001" , MBsize = 4096, Price =  124.95, Voorraad = 500},
            new mp3player() {ID = 5, Make = "CBA", Model = "NXT Volume" , MBsize = 2048, Price =  159.05, Voorraad = 500},
        };

        //Optie 1 van het menu, overzicht mp3 spelers
        static void Overzichtmp3()
        {
            Console.Clear();
            Console.WriteLine("====Overzicht mp3 spelers====");
            Console.WriteLine("");
            foreach (mp3player mp3 in mp3list)
            {
                Console.WriteLine("ID: {0}", mp3.ID);
                Console.WriteLine("Make: {0}", mp3.Make);
                Console.WriteLine("Model: {0}", mp3.Model);
                Console.WriteLine("MBsize: {0}", mp3.MBsize);
                Console.WriteLine("Price: {0}", mp3.Price);
                Console.WriteLine("");
            }
            Console.WriteLine("Druk op enter om verder te gaan...");
            Console.ReadLine();
            mainMenu();
        }

        //De mp3 spelers onderdelen worden gedeclareerd
        public struct mp3player
        {
           public int ID;
           public string Make;
           public string Model;
           public int MBsize;
           public double Price;
           public int Voorraad;
        }

        //Optie 2 van het menu, overzicht vooraad
        static void OverzichtVoorraad()
        {
            Console.Clear();
            Console.WriteLine("====Overzicht voorraad====");
            Console.WriteLine("");
            foreach (mp3player mp3 in mp3list)
            {
                Console.WriteLine("ID: {0}", mp3.ID);
                Console.WriteLine("Voorraad: {0}", mp3.Voorraad);
                Console.WriteLine("");
            }
            Console.WriteLine("Druk op enter om verder te gaan...");
        }
        
        //Optie 3 van het menu, de voorraad muteren
        static void MuteerVoorraad()
        {
            Console.Clear();
            bool juistId = false;
            while (juistId == false)
            {
                Console.Clear();
                Console.WriteLine("====Muteer voorraad====");
                Console.WriteLine("Kies een ID om de voorraad aan te passen.");
                Console.Write("ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < mp3list.Count; i++)
                {
                    if (mp3list[i].ID == id)
                    {
                        try
                        {
                            Console.Write("Nieuwe voorraad: ");
                            int nieuweVoorraad = Convert.ToInt32(Console.ReadLine());
                            juistId = true;
                            mp3player newmp3 = new mp3player();
                            newmp3.ID = mp3list[i].ID;
                            newmp3.Voorraad = mp3list[i].Voorraad;
                            Console.WriteLine();
                                if (nieuweVoorraad >= 0)
                                {
                                    newmp3.Voorraad = Convert.ToInt32(nieuweVoorraad);
                                    mp3list[i] = newmp3;
                                Console.WriteLine("Druk op enter om verder te gaan...");
                                    Console.ReadLine();
                                    mainMenu();
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("De voorraad mag niet negatief zijn. Druk op enter om verder te gaan...");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    MuteerVoorraad();
                                }
                        }
                        catch (Exception)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("De voorraad mag niet negatief zijn. Druk op enter om verder te gaan...");
                            Console.ResetColor();
                            Console.ReadLine();
                            MuteerVoorraad();
                        }
                    }

                }
            }
        }  
        
        //1 foreach loop om alle statistieken te tonen
        static void Statistieken()
        {
            Console.Clear();
            int totaalVoorraad = 0;
            double totaalWaarde = 0;
            double gemiddeldWaarde = 0;
            double bestePrijsPerMb = 0;
            foreach (mp3player mp3 in mp3list)
            {
                Console.Clear();
                Console.WriteLine("====Statistieken====");
                Console.WriteLine();
                totaalVoorraad = totaalVoorraad + mp3.Voorraad;
                Console.WriteLine("Totaal voorraad: {0}", totaalVoorraad);

                totaalWaarde = totaalVoorraad * mp3.Price;
                Console.WriteLine("Totaal waarde: {0} euro", totaalWaarde);

                gemiddeldWaarde = totaalWaarde / 5;
                Console.WriteLine("Gemiddelde waarde van mp3: {0}", gemiddeldWaarde);

                bestePrijsPerMb = 224.95 / 8192;
                Console.WriteLine("Beste prijs per mB: {0}", bestePrijsPerMb);

            }
            Console.WriteLine();
            Console.WriteLine("Druk op enter om verder te gaan...");
        }
        


        static void ToevoegMp3()
        {
            Console.Clear();
            Console.WriteLine("====Toevoegen mp3 speler====");
            Console.WriteLine("Vul de volgende stappen in om een mp3 speler toe te voegen.");
            try
            {
                Console.Write("Make: ");
                string Make = Console.ReadLine();
                Console.Write("Model: ");
                string Model = Console.ReadLine();
                Console.Write("MBsize: ");
                int MBsize = Convert.ToInt32(Console.ReadLine());
                Console.Write("Price: ");
                double Price = Convert.ToDouble(Console.ReadLine());
                mp3list.Add(new mp3player() { ID = mp3list.Count + 1, Make = Make, Model = Model, MBsize = MBsize, Price = Price, Voorraad = 0 });
                Console.WriteLine("");
                Console.WriteLine("Mp3 speler ({0}) toegevoegd. Druk op enter om verder te gaan...", Make);
            }
            catch (Exception)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Typ fout, druk op enter om verder te gaan...");
                Console.ResetColor();
                ToevoegMp3();
            }
        }    
    }
}

