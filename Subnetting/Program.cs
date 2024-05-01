using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnetting
{   // Erstellt werden soll ein Programm, bei dem der Benutzer eine IP-Adresse und eine Subnetzmaske angezeigt bekommt. 
    // Anschließend soll der Benutzer die Netzadresse, die erste IP-Adresse, die letzte IP-Adresse und die Broadcastadresse eingeben.
    // Das Programm überprüft, ob die eingegebenen Adressen korrekt sind.
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateRandomIP();
            
        }

        // Funktion: erstellen einer zufälligen, gültigen IP-Adresse
        // 
        static String CreateRandomIP()
        {
            String return_IP;
            int num;
            Random random = new Random();            
            
            num = random.Next(2, 255 + 1);          // Erstelle eine beliebige Nummer zw. 2 und 255 für das 1. Oktett
            String zahl1 = Convert.ToString(num);   // wandle den Datentyp int in String um
            return_IP = zahl1;                      // weise return_IP den Wert von zahl1 zu
            
            for (int i = 3;i != 0; i--)             // Erstelle eine beliebige Nummer zw. 0 und 255 für das 2., 3. und 4. Oktett
            {
                num = random.Next(0, 255 + 1);
                zahl1 = Convert.ToString(num);
                return_IP = return_IP + "." + zahl1;
            }

            Console.WriteLine(return_IP);


            return return_IP;
        }
    }
}
