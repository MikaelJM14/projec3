using System;
using Xunit;
using Projec2;

namespace Projec2.Test
{
    public class TypeTests
    {
        [Fact]
        public void GetStudentReturnsDifferentthings()
        {
            var studententeredByUser1 = GetStudent("Robert", "covalski");
            var studententeredByUser2 = GetStudent("ana", "magdolena");

            Assert.NotSame(studententeredByUser1, studententeredByUser2);
            Assert.False(studententeredByUser1.Equals(studententeredByUser2));
            Assert.False(Object.ReferenceEquals(studententeredByUser1, studententeredByUser2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var studententeredByUser1 = GetStudent("Isabella", "covalska");
            var studententeredByUser2 = studententeredByUser1;

            Assert.Same(studententeredByUser1, studententeredByUser2);
            Assert.True(studententeredByUser1.Equals(studententeredByUser2));
            Assert.True(Object.ReferenceEquals(studententeredByUser1, studententeredByUser2));
        }

        private StudentInMermory GetStudent(string firstName, string secondName)
        {
            return new StudentInMermory(firstName, secondName);
        }
    }
}
