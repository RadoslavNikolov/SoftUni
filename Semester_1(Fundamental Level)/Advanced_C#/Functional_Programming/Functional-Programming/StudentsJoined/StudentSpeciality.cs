namespace StudentsJoined
{
    public class StudentSpeciality
    {
        public StudentSpeciality(string specialityName, int facultyNumber)
        {
            this.SpecialityName = specialityName;
            this.FacultyNumber = facultyNumber;
        }

        public string SpecialityName { get; private set; }

        public int FacultyNumber { get; private set; } 
    }
}