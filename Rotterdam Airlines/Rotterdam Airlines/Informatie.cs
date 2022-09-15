using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotterdam_Airlines
{
    internal class Informatie
    {


        public static void PrintWinkelen()
        {
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Informatie | Faciliteiten | Winkelen");
            Console.WriteLine("    ───────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Winkelen");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    De winkels in Rotterdam Airlines zijn 24/7 open.");
            Console.WriteLine("    In de luchthaven van Rotterdam Airlines is een brede selectie aan winkels.");
            Console.WriteLine("    er zijn Supermarkten, Elektronicawinkels, Boekenwinkels, Kledingwinkels en nog veel meer.");
            Console.WriteLine("    De supermarkten in Rotterdam Airlines zijn Albert Heijn en Jumbo");
            Console.WriteLine("    Rotterdam Airlines bevat ook een Mediamarkt voor alle electronica ");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
        }

        public static void PrintEetgelegenheden()
        {
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Informatie | Faciliteiten | Eetgelegenheden");
            Console.WriteLine("    ──────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Eetgelegenheden");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Rotterdam Airlines heeft een grote variatie aan eetgelegenheden,");
            Console.WriteLine("    van Lekker eten bij een snackbar, tot een chic diner aan een loungebar.");
            Console.WriteLine("    De eetgelegen in Rotterdam Airlines zijn vooral eten van eigen bodem,");
            Console.WriteLine("    zo kan je lekker bitterballen met mosterd halen, maar ook genieten van een typisch Nederlandse borrelplank.");
            Console.WriteLine("    Naast lekker eten is het drinken ook een aanrader, zo hebben wij een Nederlandse wijnproeverij en een Heineken bar.");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();

        }

        public static void PrintRecreatie()

        {
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Informatie | Faciliteiten | Recreatie");
            Console.WriteLine("    ────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.WriteLine("    ────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Recreatie");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Heeft je vlucht vertraging of heb je tijd over tijdens het overstappen?");
            Console.WriteLine("    Ontdek dan onze nieuwe Recreatie hallen!");
            Console.WriteLine("    Er zijn nu chillrooms om lekker achterover te hangen terwijl je naar je favoriete muziek kan luisteren,");
            Console.WriteLine("    ook kan je een korte tour doen door het vliegveld waardoor je veel van de Nederlandse cultuur zelf kan meemaken,");
            Console.WriteLine("    naast dat hebben we nu ook een nieuwe speeltuin waarvan de onderdelen zelf zijn gekozen");
            Console.WriteLine("    door kinderen om optimaal plezier te beleven!");
            Console.WriteLine();
            Console.WriteLine("    ────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
            Console.WriteLine();

        }


        public static void PrintOnzeVliegtuigen()
        {
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Informatie | Onze vliegtuigen");
            Console.WriteLine("    ───────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Boeing 737");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    De Boeing 737 heeft 195 zitplaatsen en 3 Verschillende toiletten");
            Console.WriteLine();
            Console.WriteLine("    Stoelafstand per classe");
            Console.WriteLine("    Economy Class           76 cm");
            Console.WriteLine("    Economy Comfort         81 cm");
            Console.WriteLine("    Europe Business Class   84 cm");
            Console.WriteLine();
            Console.WriteLine("    Wifi beschikbaar        Nee");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Airbus A330");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    De Airbus 330-200 heeft 345 zitplaatsen en 7 Verschillende toiletten");
            Console.WriteLine();
            Console.WriteLine("    Stoelafstand per classe");
            Console.WriteLine("    Economy Class           79 cm");
            Console.WriteLine("    Economy Comfort         89 cm");
            Console.WriteLine("    Europe Business Class   Ligbedden");
            Console.WriteLine();
            Console.WriteLine("    Wifi beschikbaar        Ja");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Boeing 787");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    De Boeing 787 heeft 219 zitplaatsen en 6 Verschillende toiletten");
            Console.WriteLine();
            Console.WriteLine("    Stoelafstand per classe");
            Console.WriteLine("    Economy Class           79 cm");
            Console.WriteLine("    Economy Comfort         89 cm");
            Console.WriteLine("    Europe Business Class   Ligbedden");
            Console.WriteLine();
            Console.WriteLine("    Wifi beschikbaar        Ja");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
        }


        public static void PrintFAQ()
        {
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Informatie | Veelgestelde vragen");
            Console.WriteLine("    ───────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Hoelaat voor mijn vlucht moet ik op schiphol zijn?");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Wij raden 2 uur aan zodat je geen tijdnood hebt voor inchecken tijdens spitsuren.");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Wat is de beste plek om iemand af te zetten voor het vliegveld?");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Rotterdam Airlines heeft een weg gemaakt waar je mensen kan afzetten naast de");
            Console.WriteLine("    parkeerplaats. De locatie is: Driemanssteeweg 120.");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Mag je alcohol meenemen op reis?");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Je mag niet met alcohol door de security check gaan met alcohol, maar je mag wel");
            Console.WriteLine("    alcoholische dranken kopen nadat je door de check bent geweest.");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.WriteLine("    Is er een paspoortcontrole binnen de Schengenzone?");
            UserInterface.SetDefaultColor();
            Console.WriteLine("    Nee, er is geen paspoortcontrole binnen de Schengenzone, maar je moet wel een");
            Console.WriteLine("    identiteitsbewijs meenemen");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
        }
        public static void PrintLaatsteNieuws()
        {
            UserInterface.SetMainColor();
            Console.WriteLine("    Rotterdam Airlines | Informatie | Laatste Nieuws");
            Console.WriteLine("    ───────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetDefaultColor();
            Console.WriteLine("    [0] Hoofdmenu");
            Console.WriteLine("    [1] Terug");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            Console.WriteLine("    In Iederland is er geen coronabewijs of mandkapje meer nodig!");
            Console.WriteLine("    Maar let op, in andere landen kan dat anders zijn");
            Console.WriteLine("    in alle EU landen, Ijsland, Noorwegen en Zwitserland kan je gebruik maken van de Coronacheck app.");
            Console.WriteLine();
            Console.WriteLine("    Nergens in Nederland is het meer verplicht om een mondkapje te dragen");
            Console.WriteLine("    voor mensen met kwetsbare gezondheid is het natuurlijk wel geadviseerd");
            Console.WriteLine("    in het buitenland kunnen de regels wel anders zijn, dus let daar vooral goed op.");
            Console.WriteLine();
            Console.WriteLine("    ─────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine();
            UserInterface.SetMainColor();
            Console.Write("    Maak een keuze: ");
            UserInterface.SetDefaultColor();
        }
    }
}
