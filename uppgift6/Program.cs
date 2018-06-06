using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uppgift6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true; //  Variabel för att kontrollera om spelet ska fortsätta köras
            List<string[]> loggBok = new List<string[]> { }; //deklarerar list of arrays "lggBok"

            DateTime tid = DateTime.Now; //deklarerar en "DateTime" variabel och Och sätta realtid i den för att använda med vektoren. 

            int menyVal = 0; //menyVal för att tillåta användaren välja

            while (isRunning) //använda while för att programmet ska förtsätta.
            {
                Console.Write("\n\n\n\tVälkommen till loggboken." +         //visa alla varianter för användaren.
                    "\n\t[1] Skriv ut alla loggar i loggboken." +
                    "\n\t[2] Skriv ett nytt inlägg i loggboken." +
                    "\n\t[3] Sök efter inlägg i loggboken." +
                    "\n\t[4] Rensa loggboken." +
                    "\n\t[5] Rensa specifik loggbok." +
                    "\n\t[6] Redigera specifik loggbok." +
                    "\n\t[7] Avsluta." +
                    "\n\t välj ett nummer : ");

                try  //använda try-catch metoden för att lösa fel inmatning problem och det hör till hela programmet.
                {
                    menyVal = Convert.ToInt32(Console.ReadLine());  //användaren ska välja.


                    switch (menyVal) //switch metod med meny situationen 
                    {
                        case 1: //om användaren har väljat "1" ... case 2 om användaren har väljat "2" ... och så vidare
                            if (loggBok.Count == 0)
                            {
                                Console.WriteLine("Är du seriös? Loggen är tom");
                            }
                            else
                            {


                                foreach (var item in loggBok)  //första foreach för att gå igenom all listor ... DVS för att gå igenom all vektorer
                                {
                                    foreach (var temp in item) //andra foreach för att gå igenom all objekt i varje vektor.
                                    {
                                        Console.Write("\t" + temp + "\t");
                                    }
                                    Console.WriteLine(); //organisering syfte

                                }
                            }
                            break;

                        case 2:
                            string[] myInlägg = new string[4]; //deklarerar en vektor med fyra objekt.

                            myInlägg[0] = Convert.ToString(tid); //sätta in tiden i första objekt.

                            Console.Write("\tskriv in titeln: ");
                            myInlägg[1] = Console.ReadLine(); //sätta in titeln i andra objekt.

                            Console.Write("\n\tskriv in ett meddelandet: ");
                            myInlägg[2] = Console.ReadLine(); //sätta in meddelandet i tredje objekt.



                            //sätta in mobilnummer i sista objekt.
                            Console.Write("\n\tskriv in ett mobilnummer: ");
                            int mobilnummer = int.Parse(Console.ReadLine()); //jag har använt "int" variabel  för att vara säker att användaren bara skriver siffror
                            myInlägg[3] = Convert.ToString(mobilnummer); //konvertera igen to string eftersom variablen är "string" typ.

                            //sätta in  "myInlägg" som är "vektor" i "loggBok" som är list of arrays.
                            loggBok.Add(myInlägg);


                            break;
                        case 3:

                            Console.Write("\tVad letar du efter? ");

                            string sökord = Console.ReadLine(); //användaren ska skriva sökordet.
                            Console.WriteLine();  //organisering syfte
                            bool hittaOrdet = false; //bool variabel för att använda med if-sats.

                            foreach (string[] item in loggBok)//första foreach för att gå igenom alla listor ... DVS för att gå igenom all vektorer
                            {
                                foreach (string temp in item)//andra foreach för att gå igenom alla objekt i varje vektor.
                                {
                                    if (temp == sökord) // om objektet är sökrdet eller inte.
                                    {
                                        foreach (var temp2 in item) //för att visa alla objekt i denna vektor.
                                        {
                                            Console.Write("\t" + temp2 + "\t");
                                            hittaOrdet = true; //för att undvika if-sata 
                                        }
                                        Console.WriteLine(); //organisering syfte
                                    }
                                }

                            }
                            if (!hittaOrdet) //om programmet inte hitta sökordet ska programmet visa det
                                Console.WriteLine("\n\t {0} finns inte i loggboken!", sökord);

                            break;
                        case 4:
                            loggBok.Clear(); //rensa loggboken
                            Console.WriteLine("\n\tLoggboken har rensats!");


                            break;


                        case 5:
                            Console.Write("\n\tdet finns {0} loggar, vilken vill du rensa? ", loggBok.Count);
                            int indexSkaRensa = Convert.ToInt32(Console.ReadLine());//avändaren ska välja vilken logg ska rensas.
                            if (indexSkaRensa <= loggBok.Count)//för att vara säker att användaren ska skriva ett nummer Inom intervallet.
                            {
                                Console.WriteLine("\tloggen nummer {0} har rensats!", indexSkaRensa);
                                loggBok.RemoveAt(indexSkaRensa - 1);//Rensa ett specifikt index.
                            }
                            else
                                Console.WriteLine("\tdet finns bara {0} loggar!", loggBok.Count());

                            break;
                        case 6:
                            Console.Write("\n\tdet finns {0} loggar, vilken vill du redigera? ", loggBok.Count);
                            int indexSkaRedigera = Convert.ToInt32(Console.ReadLine());//avändaren ska välja vilken logg ska ändras.
                            if (indexSkaRedigera <= loggBok.Count)//för att vara säker att användaren ska skriva ett nummer Inom intervallet.
                            {
                                //matta in en logg på samma sätt i "case 2" 
                                string[] nyInlägg = new string[4];

                                nyInlägg[0] = Convert.ToString(tid);

                                Console.Write("\tskriv in titeln: ");
                                nyInlägg[1] = Console.ReadLine();

                                Console.Write("\n\tskriv in ett meddelandet: ");
                                nyInlägg[2] = Console.ReadLine();

                                Console.Write("\n\tskriv in ett mobilnummer: ");
                                int nyMobilnummer = int.Parse(Console.ReadLine());
                                nyInlägg[3] = Convert.ToString(nyMobilnummer);

                                //här vet jag inte om man kan ändra en logg så jag har rensat loggen och göra "insert" i samma plats istället.
                                loggBok.Insert(indexSkaRedigera, nyInlägg);
                                loggBok.RemoveAt(indexSkaRedigera - 1);


                            }
                            else
                                Console.WriteLine("det finns bara {0} loggar!", loggBok.Count());


                            break;

                        case 7:
                            isRunning = false;//ge while loop false värde för att avsluta loopet
                            break;
                        default: // om användaren skriver ett annat nummer.
                            Console.WriteLine("\t matta in ett nummer mellan 1 och 7!");
                            break;
                    }


                }
                //programmet hoppar alltid till "catch" när det finns nåt fel 
                catch (FormatException) //FormatException betyder att användaren har inmatat  bokstaver istället av siffror.
                {
                    Console.WriteLine("\t\t\afel : inmatning foramt var felaktig, inmata siffror");
                }

                catch (Exception) //om nåt annat fel har hänt.
                {
                    Console.WriteLine("\t\t\afel : någonting gick fel, försök igen!");
                }

            }
        }
    }
}
