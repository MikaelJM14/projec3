namespace Projec2
{
    public abstract class StudentBase : Person, IStudent
    {
        public delegate void GradeAddedUnder3Delegade(object sender, EventArgs args);
        public event GradeAddedUnder3Delegade GradeUnder3;
        public override string FirstName { get; set; }
        public override string LastName { get; set; }

        public StudentBase(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public abstract void AddGrade(double grade);

        public void AddGrade(string Input)
        {
            double convertedGradeToDouble = char.GetNumericValue(Input[0]);
            if (Input.Length == 2 && char.IsDigit(Input[0]) && Input[0] <= '6' && (Input[1] == '+' || Input[1] == '-'))
            {
                switch (Input[1])
                {
                    case '+':
                        double gradePlusConverted = convertedGradeToDouble + 0.50;
                        if (gradePlusConverted > 1 && gradePlusConverted <= 6)
                        {
                            AddGrade(gradePlusConverted);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(Input)}. Only grades from 1 to 6 are allowed!");
                        }
                        break;

                    case '-':
                        double gradeMinusConverted = convertedGradeToDouble - 0.250;
                        if (gradeMinusConverted > 1 && gradeMinusConverted <= 6)
                        {
                            AddGrade(gradeMinusConverted);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(Input)}. Only grades from 1 to 6 are allowed!");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid argument: {nameof(Input)}. Only grades from 1 to 6 are allowed!");
                }
            }
            else
            {
                double gradeNumberDouble = 0;
                var isParsed = double.TryParse(Input, out gradeNumberDouble);
                if (isParsed && gradeNumberDouble > 0 && gradeNumberDouble <= 6)
                {
                    AddGrade(gradeNumberDouble);
                }
                else
                {
                    throw new ArgumentException($"Invalid argument: {nameof(Input)}. Only grades from 1 to 6 are allowed!");
                }
            }
        }

        public abstract void ShowGrades();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                ShowGrades();
                Console.WriteLine($"{FirstName} {LastName} statistics:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Total grades: {stat.Count}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Highest grade: {stat.First:N2}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Lowest grade: {stat.Last:N2}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Average: {stat.Average:N2}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"the app Couldn't get statistics for {this.FirstName} {this.LastName} because no student grade has been added.");
                Console.ResetColor();
            }
        }

        protected void CheckEventGradeUnder3()
        {
            if (GradeUnder3 != null)
            {
                GradeUnder3(this, new EventArgs());
            }
        }
    }
}
