using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaistHeightCalculator {
    /*
    * Calculate waist to heigh ratio
    * the same units of measurement is used for waist and height.
    * 
    * Author: Megan Hunter
    * Date: March 2015
    *
    */
    class Program {
        static void WelcomeMessage() {
            Console.WriteLine("\n\n\t Welcome to Waist to Height Ratio Calculator\n");
        } // end WelcomeMessage

        static void EndProgram() {
            Console.WriteLine("\n Press any key to terminate program...");
            Console.ReadKey();
        } // end EndProgram

        static double InputWaist() {
            double waist; bool value = true;
            do {
                Console.Write("\n Enter waist measurement in cms: ");
                string text = Console.ReadLine();
                if (double.TryParse(text, out waist)) {
                    if (waist < 60) {
                        Console.WriteLine("\n Measurement out of range");
                    } else {
                        value = false;
                    }
                } else {
                    Console.WriteLine("\n Invalid Input");
                }
            } while (value);

            return waist;
        } // end InputWaist

        static double InputHeight() {
            double height; bool value = true;
            do {
                Console.Write("\n Enter height measurement in cms: ");
                string text = Console.ReadLine();
                if (double.TryParse(text, out height)) {
                    if (height < 120) {
                        Console.WriteLine("\n Measurement out of range");
                    } else {
                        value = false;
                    }
                } else {
                    Console.WriteLine("\n Invalid Input");
                }
            } while (value);

            return height;
        } // end InputHeight

        static double CalculateRatio(double wvalue, double hvalue) {
            double ratio = wvalue / hvalue;
            return ratio;
        } // end CalculateRatio

        static void ShowRatio(double ratio) {
            Console.WriteLine("\n Your waist to height ratio is " + ratio);
        } // end ShowRatio

        static int AskGender() {
            int gender; bool value = true;
            do {
                Console.Write("\n Are you \n\t 1> male \n\t 2> female \n\t Enter your option <1 or 2>: ");
                string text = Console.ReadLine();
                if (int.TryParse(text, out gender)) {
                    if ((gender == 1) || (gender == 2)) {
                        value = false;
                    } else {
                        Console.WriteLine("\n Not a valid option, Try again");
                    }
                }
            } while (value);
            return gender;
        } // end AskGender

        static void RiskLevel(int gender, double ratio) {
            if (gender == 1) {
                if (ratio < 0.536) {
                    Console.WriteLine("\t and \n you are at low risk of obesity related cardiovascular disease.\n");
                } else {
                    Console.WriteLine("\t and \n you are at risk of obesity related cardiovascular disease.\n");
                }
            }
            if (gender == 2) {
                if (ratio < 0.492) {
                    Console.WriteLine("\t and \n you are at low risk of obesity related cardiovascular disease.\n");
                } else {
                    Console.WriteLine("\t and \n you are at risk of obesity related cardiovascular disease.\n");
                }
            }
        } // end RiskLevel

        static bool AnotherCalculation() {
            string answer; bool value = true, test = true;
            do {
                Console.Write("\n Another calculation <Enter Y or N>: ");
                answer = (Console.ReadLine()).ToUpper();
                if ((answer == "N") || (answer == "Y")) {
                    if (answer == "N") {
                        value = false;
                        test = false;
                    } else if (answer == "Y") {
                        value = true;
                        test = false;
                    }
                } else {
                    Console.WriteLine("\n Not a valid option, Try again");
                    test = true;
                }
            } while (test);
            return value;
        } // end AnotherCalculation

        static void Main() {
            double waist = 0, height = 0, ratio = 0;
            int gender = 0;
            bool again = true;

            WelcomeMessage();
            while (again) {
                waist = InputWaist();
                height = InputHeight();
                gender = AskGender();
                ratio = CalculateRatio(waist, height);
                ShowRatio(ratio);
                RiskLevel(gender, ratio);
                again = AnotherCalculation();
            } // end while
            EndProgram();
        } // end main
    }
}

