using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    class wwVergeten
    {        
        
        public static List<string> GetEmail()
        {
            List<string> wwVergeten = new List<string>();    
            bool Invullen = true;

            string wwVer_email = null;
            string wwVer_code = null;

            while (Invullen)
            {
                UserInterface.PrintLogo();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    Rotterdam Airlines | Account | Wachtwoord vergeten");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("    ────────────────────────────");
                Console.WriteLine();
                Console.WriteLine("    [0] Hoofdmenu");
                Console.WriteLine();
                Console.WriteLine("    [1] Email" + wwVer_email);
                Console.WriteLine("    [2] Code" + wwVer_code);
                Console.WriteLine("    [3] Stuur code");
                Console.WriteLine("    [4] Pas wachtwoord aan");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("    Maak een keuze: ");
                Console.ForegroundColor = ConsoleColor.White;
                
                string wwaanpassen_input = Console.ReadLine();
                int wwaanpassen_choice = int.Parse(wwaanpassen_input);

                switch (wwaanpassen_choice)
                {
                    case 0:
                        Invullen = false;
                        Console.Clear();
                        break;

                    case 1:
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("    Vul uw email in :");
                            wwVer_email = Console.ReadLine();
                            Console.WriteLine();
                            if (wwVer_email.Contains("@") && wwVer_email.Contains("."))
                            {
                                wwVergeten.Add(wwVer_email);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Uw email moet een '@' en een punt bevatten)");
                                Console.WriteLine();
                            }

                        }
                        Console.Clear();
                        break;

                    case 2:
                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("    Vul uw email in :");
                            wwVer_code = Console.ReadLine();
                            Console.WriteLine();
                            if (wwVer_code == TruewwVer_code)
                            {
                                wwVergeten.Add(wwVer_code);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("    Onjuiste invoer. Probeer opniew. (Code is onjuist)");
                                Console.WriteLine();

                            }

                        }

                        Console.Clear();
                        break;


                }

            }

        }
        
        
    }
}
