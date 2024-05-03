﻿using System;
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
            String random_ip = "";
            int random_cidr = -1;

            random_ip = CreateRandomDezIP();
            random_cidr = CreateRandomCIDR();
            CreateBinSubnetmask(random_cidr);   
            
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
        static String CreateBinSubnetmask(int counter)
        {
            String bin_subnetmask = "";
            // 0-31 (32 Stellen) + 3 (für die Punkte [.] + 1 (weil exklusiv))
            for (int i = 0; i < 31 + 3 + 1 ; i++)
            {
                // an dem Index 8, 17 & 26 soll ein Punkt entstehen
                // da diese Stelle dann, statt einer 0 oder 1 vergeben wird, muss der Counter 
                // hochgesetzt werden, damit nachher noch immer 4 Oktette entstehen
                if (i == 8 || i == 17 || i == 26)
                {
                    counter++;
                    bin_subnetmask += ".";
                }
                else if(i < counter)            // Anzahl der Einsen
                {
                    bin_subnetmask += "1";
                }
                else                            // Anzahl der Nullen (32-counter)
                {
                    bin_subnetmask += "0";
                }                
            }
            return bin_subnetmask;
        }
        // Funktion: erstellen einer Subnetzmaske

        static String CreateDezSubnetmask(int counter)
        {
            
            String return_Subnet;
            String num = "0";
            
            int random_int;
            Random random = new Random();


            random_int = random.Next(1, 8 + 1);
            
            switch(random_int)
            {
                case 1:
                    num = "128";
                    break;
                case 2:
                    num = "192";
                    break;
                case 3:
                    num = "224";
                    break;
                case 4:
                    num = "240";
                    break;
                case 5:
                    num = "248";
                    break;
                case 6:
                    num = "252";
                    break;
                case 7:
                    num = "254";
                    break;
                case 8:
                    num = "255";
                    break;
            }
            return_Subnet = num;

            for (int i = 3; i != 0; i--)
            {
                if (random_int < 8)
                {
                    num = "0";
                }
                else
                {
                    random_int = random.Next(1, 8 + 1);

                    switch (random_int)
                    {
                        case 1:
                            num = "128";
                            break;
                        case 2:
                            num = "192";
                            break;
                        case 3:
                            num = "224";
                            break;
                        case 4:
                            num = "240";
                            break;
                        case 5:
                            num = "248";
                            break;
                        case 6:
                            num = "252";
                            break;
                        case 7:
                            num = "254";
                            break;
                        case 8:
                            num = "255";
                            break;
                    }

                }
                return_Subnet = return_Subnet + "." + num;
            }
            Console.WriteLine(return_Subnet);

            return return_Subnet;
        }
    }
}
