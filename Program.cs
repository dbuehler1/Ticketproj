using System;
using System.IO;

namespace firstProj
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrays to store questions and inputs/outputs
            string[] details = new string[7];
            string[] questions = {
            "Enter TicketID: ",
            "Enter Summary: ",
            "Enter Status: ",
            "Enter Priority: ",
            "Enter Submitter: ",
            "Enter Assigned: ",
            "Enter Watching: "};
            //user repsonses
            String userResponse = "";
            string allInputs = "";
            string file = "Tickets.csv";
            string userDecision = "";
            int counter = 0;
            //ask the user what they want to do

            //write to csv

            string writeAgain = "yes";

            Console.WriteLine("Make entries:");
            using (StreamWriter writer = new StreamWriter(file))
            {

                while (writeAgain.ToLower().Equals("yes"))
                {
                    allInputs = "";
                    for (int i = 0; i < questions.Length; i++)
                    {
                        Console.Write(questions[i]);
                        userResponse = Console.ReadLine();
                        allInputs = allInputs + userResponse + ",";
                    }

                    if (counter == 0)
                    {
                        writer.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                        writer.WriteLine(allInputs.Substring(0, allInputs.Length - 1));
                        counter++;
                    }
                    else
                    {
                        writer.WriteLine(allInputs.Substring(0, allInputs.Length - 1));
                    }

                    Console.WriteLine("Would you like to make another entry?(\"yes\" or \"no\")");
                    writeAgain = Console.ReadLine();
                }

                //writer.WriteLine("\n");
                writer.Close();
            }

            do
            {
                Console.Write("\"read\" or \"stop\": ");
                userDecision = Console.ReadLine();
                if (userDecision.ToLower().Equals("read"))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        Console.WriteLine("-----------");
                        //initialized line up here so it would skip the header line from reading since all outputs are already labeled
                        var line = reader.ReadLine();
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            var response = line.Split(",");

                            for (int i = 0; i < 7; i++)
                            {
                                details[i] = response[i];
                            }
                            for (int i = 0; i < 7; i++)
                            {
                                Console.Write(questions[i].Substring(6));
                                Console.Write(details[i]);
                                Console.WriteLine();
                            }
                            //seperate lines
                            Console.WriteLine("-----------");
                        }
                        reader.Close();
                    }
                }
                else if(!userDecision.Equals("stop"))
                {
                    Console.WriteLine("Invalid Input");
                }
            } while (!userDecision.ToLower().Equals("stop"));

            Console.WriteLine("end");

        }
    }
}
