using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NhiCao_TicketApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char moreTicket = 'Y'; //a character to keep track of if user says 'y' for yes to more tickets or 'n' for no more tickets

            while (moreTicket == 'Y')
            {

                GetTicketDetails(out string stId, out char stCat,
                            out int spLimit, out int spReported);
                Ticket myTicket = new Ticket(stId, stCat, spLimit, spReported);
                WriteLine(myTicket); //same as WriteLine(myTicket.ToString())

                //get user input to see if user enters 'Y' for more tickets or 'N' for no more tickets
                Write("Do you want to process another ticket? (Y - yes, N- no): ");
                while (!char.TryParse(ReadLine(), out moreTicket) || (moreTicket != 'Y' && moreTicket != 'N'))
                {
                    Write("Please re-enter your choice. Do you want to process another ticket? (Y-yes, N-no): ");
                }
            }

            if (moreTicket == 'N')
            {
                WriteLine("Thank you for paying your ticket. Goodbye.");
            }


        }

        static void GetTicketDetails(out string studentId,
                                out char studentCat,
                                out int speedLimit,
                                out int speedReported)
        {
            studentId = "";
            studentCat = 'U'; //U refers to undefined, just as an initial value, all intial values not really needed here
            speedLimit = 0;
            speedReported = 0;
            WriteLine("Let us get the ticket details for the ticket...."); 
            
            Write("Please enter student id: ");
            studentId = ReadLine();
            while (studentId=="")
            {
                Write("Student Id cannot be empty. Please re-enter: ");
                studentId = ReadLine();
            }

            Write("Please enter student category (1-freshman, 2-sophomore, 3-junior, 4-senior): "); //NOT operator is !=
            while(!char.TryParse(ReadLine(), out studentCat) || studentCat!='1' && studentCat != '2' && studentCat != '3' && studentCat != '4')
            {
                //enters loop only if value is other than 1, 2, 3 or 4
                Write("Please Re-enter the student category (1-freshman, 2-sophomore, 3-junior, 4-senior): ");
            }

            Write("Please enter speed limit: ");
            while(!int.TryParse(ReadLine(), out speedLimit) || speedLimit <= 0)
            {
                WriteLine("Invalid speed - should be positive number."); 
                Write("Please re-enter speed limit: ");
            }

            Write("Please enter speed reported: ");
            while(!int.TryParse(ReadLine(), out speedReported) || speedReported < speedLimit )
            {
                WriteLine("Invalid speed - should be positive number greater than speed limit");
                Write("Please re-enter speed reported: ");
            }
        }
    }
}
