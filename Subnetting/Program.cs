using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            String random_ip = "";
            String random_mask = "";
            int random_cidr = -1;

            random_ip = CreateRandomDezIP();
            random_cidr = CreateRandomCIDR();
            random_mask = CreateDezSubnetmask(random_cidr);   
            
        }

        // Funktion: erstellen einer zufälligen, gültigen IP-Adresse
        static String CreateRandomDezIP()
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
        
        // Funktion: erstellen eines zufälligen CIDR
        static int CreateRandomCIDR()
        {
            Random random = new Random();
            int return_CIDR = random.Next(2,32 + 1);
            return return_CIDR;
        }

        // Funktion: erstelle anhand von einem CIDR eine Subnetzmaske in binärform
        static String CreateBinSubnetmask(int p_cidr)
        {
            String bin_subnetmask = "";
            // 0-31 (32 Stellen) + 3 (für die Punkte [.] + 1 (weil exklusiv))
            for (int i = 0; i < 31 + 3 + 1 ; i++)
            {
                // an dem Index 8, 17 & 26 soll ein Punkt entstehen
                // da diese Stelle dann, statt einer 0 oder 1 vergeben wird, muss der Counter (p_cidr) 
                // hochgesetzt werden, damit nachher noch immer 4 Oktette entstehen
                if (i == 8 || i == 17 || i == 26)
                {
                    p_cidr++;
                    bin_subnetmask += ".";
                }
                else if(i < p_cidr)            // Anzahl der Einsen
                {
                    bin_subnetmask += "1";
                }
                else                            // Anzahl der Nullen (32-p_cidr)
                {
                    bin_subnetmask += "0";
                }                
            }
            return bin_subnetmask;
        }


        // Funktion: erstellen einer Subnetzmaske
        static String CreateDezSubnetmask(int p_cidr)
        {
            String dez_subnetmask = "";
            String bin_mask = CreateBinSubnetmask(p_cidr);
            double bin = -1;
            double dez;
            int lenght = -1;
            
            // erstellt ein Array mit den einzelen Oktetten, die durch einen .(Punkt) getrennt sind
            String[] oktett = bin_mask.Split('.');
            foreach(String okt in oktett)                       // jedes einzelne Oktett
            {
                int counter = 7;
                dez = 0;
                for (int i = 0;i <= 7; i++)                     // durchläuft nun das einzelne Oktett Zeichenweise
                {
                    bin = Convert.ToInt16(okt[i]) - 48;         // -48 weil von Char auf Int der ASCCI-Code zurückgegeben wird
                    dez += (Math.Pow(2, counter)) * bin;        // 2^counter: um die 8 bits in dez umzuwandeln
                    counter--;                  
                }
                dez_subnetmask += dez + ".";                    // erstellt einen String mit 4 dezimalzahlen, gefolgt von einem Punkt xxx.xxx.xxx.xxx.
                //Console.WriteLine(okt);
                //Console.WriteLine(dez);
            }
            lenght = dez_subnetmask.Length;                     // die länge des Strings muss man wissen, damit man das letzte Zeichen (den .) entfernen kann.
            dez_subnetmask = dez_subnetmask.Remove(lenght-1, 1);            
            //Console.WriteLine(dez_subnetmask);
            return dez_subnetmask;
        }
    }
}
