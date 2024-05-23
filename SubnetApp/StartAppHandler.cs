using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace SubnetApp
{

    internal class StartAppHandler
    {
        private IPAddressHandler addressHandler = new IPAddressHandler();
        private SubnetHandler subnetHandler = new SubnetHandler();

        public void start() {

            //Check the input net (x.x.x.x/y)
            addressHandler.checkInputNet();
            //assign the ip part of input network (x.x.x.x)
            IPAddress networkIP = addressHandler.address(addressHandler.ipPart());
            //assign the mask length (/y)
            int maskLength = addressHandler.maskPart();

            while (true) { // start the loop for setting inputs
                Console.WriteLine("Zadej IP adresu:");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) { //if input of basic IP is empty string, then stop
                    break;
                }

                IPAddress subnetAddress = addressHandler.address(input); // assign the value of input IP

                if (subnetAddress == null) { // handling of wrong IP format
                    Console.WriteLine("Neexistujici IP adresa, zadejte prosim znovu:");
                    continue; // according to the task, only empty string can stop the loop
                }

                bool result = subnetHandler.isInRange(networkIP, subnetAddress, maskLength); 

                if (result == true) {
                    Console.WriteLine("Ano je ze stejne siti"); ;
                }
                else {
                    Console.WriteLine("Neni ze stejne siti");
                }
            }
        }
    }
}
