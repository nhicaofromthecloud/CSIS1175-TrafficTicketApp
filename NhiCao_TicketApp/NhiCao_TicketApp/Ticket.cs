using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NhiCao_TicketApp
{
    internal class Ticket
    {
        //auto-properties
        public string StudentId { get; set; }
        public char StudentCategory { get; set; }
       
        public int SpeedLimit {get; set; }
        public int SpeedReported { get; set; }


        //computed read-only property
        //does not need to return a value outside of get
        public string CategoryName
        {
            get { 
                
                if (StudentCategory=='1')
                {
                    return "Freshman";
                }
                else if (StudentCategory =='2')
                {
                    return "Sophomore";
                }

                else if (StudentCategory == '3')
                {
                    return "Junior";

                }
                else if (StudentCategory == '4')
                {
                    return "Senior";
                }
                else 
                {
                    return "Error";
                }

            }
            
        }

        //Constructors have same name with class name
        //there's no "out" bc it isnt a method.
        //OUT is used to create loaddetails()
        //to load users' inputs into the object
        public Ticket (string studentId, char studentCategory, 
             int speedLimit, int speedReported)
        {
            StudentId = studentId;
            StudentCategory = studentCategory;
            SpeedLimit = speedLimit;
            SpeedReported = speedReported;

        }

        public decimal Fine
        {
            get
            {
                int speedDiff = SpeedReported - SpeedLimit; //local variable inside get method
                if (speedDiff > 0)
                {
                    decimal fine = 75.0m + (speedDiff / 5) * 87.5m;
                    if (StudentCategory == '4' && speedDiff > 20)
                    {
                        fine += 200; //same as fine = fine + 200
                    }
                    else if (StudentCategory == '4' && speedDiff <= 20)
                    {
                        fine += 50;
                    }
                    else if (StudentCategory == '1' && speedDiff < 20)
                    {
                        fine -= 50; //same as fine = fine - 50
                    }
                    else if (speedDiff >= 20)
                    {
                        fine += 100;
                    }
                    return fine; //puts value of fine in Fine property
                }
                else
                {
                    return 0; //Fine is set to 0
                }
            }
        }

        public override string ToString()
        {
            string outputStr = "\n Student ID: " + StudentId
                + "\n Student Category: " + StudentCategory
                + "\n " + CategoryName
                + "\n Speed Limit: " + SpeedLimit
                + "\n Speed Reported: " + SpeedReported
                + "\n Fine: " + Fine.ToString("C");
            return outputStr;
        }
    }
}
