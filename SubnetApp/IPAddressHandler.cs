using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubnetApp
{
    // class created for handling all interactions with IP adress and mask
    internal class IPAddressHandler
    {
        public string validatedSequence { get; set; } // strind where is stored net address

        public void checkInputNet() {

            //pattern of regex to match the IPV4 standard with /y network mask attached
            string pattern
                = @"^((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\/([0-9]|[12][0-9]|3[0-2])$";

            Console.WriteLine("Zadej adresu site, ve formatu 192.168.64.0/24");
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            if (regex.IsMatch(input)) { // regex check
                
                validatedSequence = input;
            }
            else {
               
                Console.WriteLine("Wrong input, type it again:");
                checkInputNet();
            }
        }

        public string[] parsedSequence() { // splits the sequence in 2 parts - ip address and mask part
            
            string[] sequence = validatedSequence.Split('/');

            return sequence;
        }

        public string ipPart() { // assigning of ip part
            string[] octets = parsedSequence();

            return octets[0];
        }

        public int maskPart() { // asigning of the mask

            string[] masc = parsedSequence();

            return Int32.Parse(masc[1]);
        }


        public IPAddress address(string iP) { //function, defined to convert string to IPAddress types
            IPAddress ipAddress;

            if (IPAddress.TryParse(iP, out ipAddress)) { //if IPV4 pattern of input string is matched, converts
                return ipAddress;
            }

            else return null;
        }
    }
}
