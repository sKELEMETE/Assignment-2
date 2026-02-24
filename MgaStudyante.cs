public class MgaStudyante
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
    public double Grade { get; set; }

    public MgaStudyante(int studentID, string name, string course, double grade)
    {
        StudentID = studentID;
        Name = name;
        Course = course;
        Grade = grade;
    }
}