using System;

namespace ProgettoSettimanaleC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  ___     _  _       ___     ___      ___     _  _      ___   \r\n  |_ _|   | \\| |     | __|   | __|    | _ \\   | \\| |    / _ \\  \r\n   | |    | .` |     | _|    | _|     |   /   | .` |   | (_) | \r\n  |___|   |_|\\_|    _|_|_    |___|    |_|_\\   |_|\\_|    \\___/  \r\n_|\"\"\"\"\"| _|\"\"\"\"\"| _| \"\"\" | _|\"\"\"\"\"| _|\"\"\"\"\"| _|\"\"\"\"\"| _|\"\"\"\"\"| \r\n\"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' ");
            Console.ResetColor();

            Console.WriteLine("\r\n _____       _           _       _                       _ _   _                     \r\n/  __ \\     | |         | |     | |                     | (_) | |                    \r\n| /  \\/ __ _| | ___ ___ | | __ _| |_ ___  _ __ ___    __| |_  | |_ __ _ ___ ___  ___ \r\n| |    / _` | |/ __/ _ \\| |/ _` | __/ _ \\| '__/ _ \\  / _` | | | __/ _` / __/ __|/ _ \\\r\n| \\__/\\ (_| | | (_| (_) | | (_| | || (_) | | |  __/ | (_| | | | || (_| \\__ \\__ \\  __/\r\n \\____/\\__,_|_|\\___\\___/|_|\\__,_|\\__\\___/|_|  \\___|  \\__,_|_|  \\__\\__,_|___/___/\\___|\r\n                                                                                     \r\n                                                                                     \r\n");
            Console.WriteLine("Premi un qualsiasi tasto nella tastiera per andare avanti ...");
            Console.ReadKey();
            Console.Clear();

            Contribuente contribuente = AcquisisciDatiContribuente();
            CalcolaTasse(contribuente);
        }

        static Contribuente AcquisisciDatiContribuente()
        {
            bool verificaCiclo = true;
            int giornoDiNascita = 0, annoDiNascita = 0, meseDiNascita = 0;
            string codFisc = "", sesso = "";
            double reddito = 0;

            Console.WriteLine("Inserisci il tuo nome");
            string nome = Console.ReadLine().ToUpper();
            Console.WriteLine("Inserisci il tuo cognome");
            string cognome = Console.ReadLine().ToUpper();

            while (verificaCiclo)
            {
                Console.WriteLine("Inserisci il giorno in cui sei nato/a (GG) ");
                giornoDiNascita = int.Parse(Console.ReadLine());

                if (giornoDiNascita <= 0 || giornoDiNascita > 31)
                    Console.WriteLine("Errore: Non esiste questo giorno!");
                else
                    verificaCiclo = false;
            }

            verificaCiclo = true;
            while (verificaCiclo)
            {
                Console.WriteLine("Inserisci il mese in cui sei nato/a (MM)");
                meseDiNascita = int.Parse(Console.ReadLine());

                if (meseDiNascita <= 0 || meseDiNascita > 12 ||
                    (meseDiNascita == 2 && giornoDiNascita > 29) ||
                    ((meseDiNascita == 4 || meseDiNascita == 6 || meseDiNascita == 9 || meseDiNascita == 11) && giornoDiNascita > 30))
                {
                    Console.WriteLine("Errore: Mese non valido!");
                }
                else
                {
                    verificaCiclo = false;
                }
            }

            verificaCiclo = true;
            while (verificaCiclo)
            {
                Console.WriteLine("Inserisci l'anno in cui sei nato/a (AAAA)");
                annoDiNascita = int.Parse(Console.ReadLine());

                if (annoDiNascita > 2024)
                {
                    Console.WriteLine("Errore: Siamo nel 2024 e' impossibile che sei nato/a in quell'anno");
                }
                else
                {
                    verificaCiclo = false;
                }
            }

            verificaCiclo = true;
            while (verificaCiclo)
            {
                Console.WriteLine("Inserisci il tuo sesso (M o F)");
                sesso = Console.ReadLine().ToUpper();

                if (sesso != "M" && sesso != "F")
                {
                    Console.WriteLine("Errore: Sesso non valido!");
                }
                else
                {
                    verificaCiclo = false;
                }
            }

            verificaCiclo = true;
            while (verificaCiclo)
            {
                Console.WriteLine("Inserisci il tuo codice fiscale");
                codFisc = Console.ReadLine().ToUpper();

                if (codFisc.Length != 16)
                {
                    Console.WriteLine("Errore: Il codice fiscale deve contenere 16 caratteri!");
                }
                else
                {
                    verificaCiclo = false;
                }
            }

            verificaCiclo = true;
            while (verificaCiclo)
            {
                Console.WriteLine("Inserisci il tuo reddito");
                try
                {
                    reddito = double.Parse(Console.ReadLine());
                    verificaCiclo = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: Inserisci un valore numerico per il reddito!");
                }
            }

            return new Contribuente(nome, cognome, giornoDiNascita, meseDiNascita, annoDiNascita, sesso, codFisc, reddito);
        }

        static void CalcolaTasse(Contribuente contribuente)
        {
            double tasse = 0;

            if (contribuente.Reddito <= 15000)
            {
                tasse = contribuente.Reddito * 0.15;
            }
            else if (contribuente.Reddito <= 28000)
            {
                tasse = 15000 * 0.15 + (contribuente.Reddito - 15000) * 0.23;
            }
            else if (contribuente.Reddito <= 55000)
            {
                tasse = 15000 * 0.15 + 13000 * 0.23 + (contribuente.Reddito - 28000) * 0.28;
            }
            else if (contribuente.Reddito <= 75000)
            {
                tasse = 15000 * 0.15 + 13000 * 0.23 + 27000 * 0.28 + (contribuente.Reddito - 55000) * 0.38;
            }
            else
            {
                tasse = 15000 * 0.15 + 13000 * 0.23 + 27000 * 0.28 + 20000 * 0.38 + (contribuente.Reddito - 75000) * 0.41;
            }

            Console.WriteLine($"\nCaro/a {contribuente.Nome} {contribuente.Cognome},\n");
            Console.WriteLine($"I tuoi dati:");
            Console.WriteLine($"Nome: {contribuente.Nome}");
            Console.WriteLine($"Cognome: {contribuente.Cognome}");
            Console.WriteLine($"Data di nascita: {contribuente.GiornoDiNascita}/{contribuente.MeseDiNascita}/{contribuente.AnnoDiNascita}");
            Console.WriteLine($"Sesso: {contribuente.Sesso}");
            Console.WriteLine($"Codice fiscale: {contribuente.CodiceFiscale}");
            Console.WriteLine($"Reddito: {contribuente.Reddito} €");
            Console.WriteLine($"\nLe tue tasse sono di {tasse} €.\n");

            Console.WriteLine("\n  ___     _  _       ___     ___      ___     _  _      ___   \r\n  |_ _|   | \\| |     | __|   | __|    | _ \\   | \\| |    / _ \\  \r\n   | |    | .` |     | _|    | _|     |   /   | .` |   | (_) | \r\n  |___|   |_|\\_|    _|_|_    |___|    |_|_\\   |_|\\_|    \\___/  \r\n_|\"\"\"\"\"| _|\"\"\"\"\"| _| \"\"\" | _|\"\"\"\"\"| _|\"\"\"\"\"| _|\"\"\"\"\"| _|\"\"\"\"\"| \r\n\"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' \"`-0-0-' ");
        }
    }

    class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int GiornoDiNascita { get; set; }
        public int MeseDiNascita { get; set; }
        public int AnnoDiNascita { get; set; }
        public string Sesso { get; set; }
        public string CodiceFiscale { get; set; }
        public double Reddito { get; set; }

        public Contribuente(string nome, string cognome, int giornoDiNascita, int meseDiNascita, int annoDiNascita, string sesso, string codiceFiscale, double reddito)
        {
            Nome = nome;
            Cognome = cognome;
            GiornoDiNascita = giornoDiNascita;
            MeseDiNascita = meseDiNascita;
            AnnoDiNascita = annoDiNascita;
            Sesso = sesso;
            CodiceFiscale = codiceFiscale;
            Reddito = reddito;
        }
    }
}
