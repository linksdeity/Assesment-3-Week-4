using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyPeeps
{
    class Program
    {
        static void Main(string[] args)
        {

            //make a list for our people
            List<Person> PersonList = new List<Person>();

            //make a list just for team members
            List<TeamMember> MemberList = new List<TeamMember>();

            //make some people
            Person Dan = new Person("Dan", "Frank", 19, "myeamil.fun.net");
            Person Brian = new Person("Brian", "Bobo", 18, "myeamil@internet.aol");

            //add people
            PersonList.Add(Dan);
            PersonList.Add(Brian);

            //make some team members
            TeamMember Cindy = new TeamMember("Cindy", "Lauper", 32, "cindy@email.net", 100000000, "123 Moon Ave.");
            TeamMember Jack = new TeamMember("Jack", "Calahan", 45, "CalahanAuto@email.com", 9999999, "123 Mars St.");

            //add employees - works on my generic list because an employee is a person
            PersonList.Add(Cindy);
            PersonList.Add(Jack);
            MemberList.Add(Cindy);
            MemberList.Add(Jack);


            while (true)
            {

                Console.WriteLine("Welcome to the PERSON LIST!!\n\n");
                Console.WriteLine("There are currently {0} people in the list\n", PersonList.Count());

                foreach (Person dude in PersonList)
                {
                    if(dude is TeamMember)
                    {
                        Console.Write("Team Member: ");
                    }

                    Console.WriteLine(dude.FirstName + " " + dude.LastName);
                }



                Console.WriteLine("\nTeam Member breakdown: ");

                foreach(TeamMember tm in MemberList)
                {
                    Console.WriteLine("-------");
                    Console.WriteLine("NAME: " + tm.FirstName + " " + tm.LastName);
                    Console.WriteLine("SALARY: " + tm.Salary);
                    Console.WriteLine("ADDRESS: " + tm.Address);
                    Console.WriteLine("EMAIL: " + tm.EmailAddress);
                    Console.WriteLine("AGE: " + tm.Age);
                    Console.WriteLine("-------");

                }


                Console.WriteLine("\nWould you like to add a person?\n('y' for YES, anything else for NO)");

                char answer = Console.ReadKey(true).KeyChar;

                if (answer == 'y' || answer == 'Y')
                {
                        PersonList.Add(NewPerson(MemberList));

                    if (PersonList.Contains(null))
                    {
                        PersonList.Remove(null);
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("GOODBYE!");
                    Console.ReadKey(true);
                    break;
                }

                Console.Clear();

            }

        }



        static Person NewPerson(List<TeamMember> MemberList)
        {
            string firstName;
            string lastName;
            string email;
            int age;

            int salary;
            string address;
            bool memberFlag = false;

            while(true)
            {
                Console.Clear();

                Console.WriteLine("Let's add a person to the list!\n");
                Console.WriteLine("Is this person a Team Member?\n('y' for YES anything else for NO!)");

                char personChoice = Console.ReadKey(true).KeyChar;

                if(personChoice == 'y' || personChoice == 'Y')
                {
                    memberFlag = true;
                    Console.WriteLine("\n--- we are now adding a team member ---\n");
                }
                else
                {
                    Console.WriteLine("\n--- we are now adding a person ---\n");
                }


                firstName = GetString("Please enter a first name in Title Case:", @"^[A-Z][a-z]+$");

                lastName = GetString("Please enter a last name in Title Case:", @"^[A-Z][a-z]+$");

                email = GetString("please enter a valid email address:", @"^[A-Za-z0-9]+[@][A-Za-z0-9]+[.][a-z]{3}$");

                age = GetNumber("Please enter a valid age (0 - 122):", 0, 122);

                    if (age > 18)
                    {
                        if (memberFlag == false)
                        {
                            Person NewDude = new Person(firstName, lastName, age, email);
                            return NewDude;
                        }
                        else
                        {
                        salary = GetNumber("Please eneter the yearly salary (0 - 1000000):", 0, 1000000);
                        address = GetString("Please eneter an address in Title Case, space, and then a 2-3 letter abbreviation followed by '.'\n" +
                                            "EX: '123 Stonehoof Dr.'   or    '2134 Moon Ave.'\n", @"^[0-9]+(\s[A-Z][a-z]+)+\s[A-Z][a-z]{1,3}[.]$");
                        TeamMember NewDude = new TeamMember(firstName, lastName, age, email, salary, address);
                        MemberList.Add(NewDude);
                        return NewDude;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cannot add a person under 18!");
                        Console.WriteLine("Would you like to continue?\n('y' for YES, anything else for NO!)");

                        char answer = Console.ReadKey(true).KeyChar;

                        if (answer == 'y' || answer == 'Y')
                        {
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            return null;
                        }
                    }
            }

        }


        //my two favorite methods i am trying to refine more: string and number input checking

        static string GetString(string message, string regExpect)
        {
            //verify that a string is formatted as expected

            while (true)

            {
                Console.WriteLine(message);

                string words = Console.ReadLine();

                if (Regex.IsMatch(words, regExpect))
                {
                    return words;

                }
                else
                {
                    continue;
                }
            }
        }


        static int GetNumber(string message, int minValue, int maxValue)
        {
            //verify input is a number and within boundaries
            while (true)

            {
                Console.WriteLine(message);

                int number;

                try
                {
                    number = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a valid number, no letters or symbols!");
                    continue;
                }

                if (number < minValue || number > maxValue)
                {
                    continue;
                }
                else
                {
                    return number;
                }
            }
        }







    }
}
