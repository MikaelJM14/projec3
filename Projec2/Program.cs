using System;
using System.Threading.Channels;

namespace Projec2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WritelineColorAndText(ConsoleColor.DarkBlue, "Hello to the Student's Grading System console app.");
            Console.WriteLine();

            bool StudentsGradingSystemApp = false;

            while (!StudentsGradingSystemApp)
            {
                Console.WriteLine();
                WritelineColorAndText(ConsoleColor.Cyan,
                    "1 - Add student's grades to the program memory and show statistics (1 to 6)\n" +
                    "2 - Add student's grades to the .txt file and show statistics (1 to 6)\n" +
                    "X - Close app\n");

                WritelineColorAndText(ConsoleColor.Yellow, "What you want to do? \nPress key 1, 2 or X: ");
                var UserAnswer = Console.ReadLine().ToUpper();

                switch (UserAnswer)
                {
                    case "1":
                        AddGradesToEmployeeFromConsole(true);
                        break;

                    case "2":
                        AddGradesToEmployeeFromConsole(false);
                        break;

                    case "X":
                        StudentsGradingSystemApp = true;
                        break;

                    default:
                        WritelineColorAndText(ConsoleColor.White, "Invalid operation.\n");
                        continue;
                }
            }
        }

        static void OnGradeUnder3(object sender, EventArgs args)
        {
            WritelineColorAndText(ConsoleColor.Red, $"Oh no! Student got grade under 3. We should inform student’s parents about this fact!");
        }

        private static void AddGradesToEmployeeFromConsole(bool isInMemory)
        {
            string firstName = GetValueFromUserInput("Please enter student's first name: ");
            string lastName = GetValueFromUserInput("Please enter student's last name: ");
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {

                IStudent student = isInMemory ? new StudentInMermory(firstName, lastName) : new StudentSaved(firstName, lastName);
                student.GradeUnder3 += OnGradeUnder3;
                EnterGrade(student);
                student.ShowStatistics();
            }
            else
            {
                WritelineColorAndText(ConsoleColor.Red, "Student's firstname and lastname can not be empty!");
            }
        }

        private static void EnterGrade(IStudent student)
        {
            while (true)
            {
                WritelineColor(ConsoleColor.Yellow, $"Enter grade for {student.FirstName} {student.LastName}:");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    student.AddGrade(input);
                }
                catch (FormatException ex)
                {
                    WritelineColor(ConsoleColor.White, ex.Message);
                }
                catch (ArgumentException ex)
                {
                    WritelineColor(ConsoleColor.White, ex.Message);
                }
                catch (NullReferenceException ex)
                {
                    WritelineColor(ConsoleColor.White, ex.Message);
                }
                finally
                {
                    WritelineColor(ConsoleColor.DarkMagenta, $"To leave and show {student.FirstName} {student.LastName} statistics enter 'q'.");
                }
            }
        }

        private static void WritelineColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void WritelineColorAndText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string GetValueFromUserInput(string value)
        {
            WritelineColorAndText(ConsoleColor.Yellow, value);
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}