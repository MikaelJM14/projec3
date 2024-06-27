using static Projec2.StudentBase;

namespace Projec2
{
    public interface IStudent
    {
        string FirstName { get; set; }
        string LastName { get; set; }

        event GradeAddedUnder3Delegade GradeUnder3;

        void AddGrade(double grade);

        void AddGrade(string grade);

        void ShowGrades();

        Statistics GetStatistics();

        void ShowStatistics();
    }
}
