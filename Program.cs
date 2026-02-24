class Program
{
    static void Main()
    {
        string filePath = "students.txt";

        var students = new List<MgaStudyante>
        {
            new MgaStudyante(1, "justin gwapo", "BSIT", 50),
            new MgaStudyante(2, "pilip", "BSCS", 100),
            new MgaStudyante(3, "Alice", "BSIT", 88),
            new MgaStudyante(4, "Bob", "BSCS", 92),
            new MgaStudyante(5, "Charlie", "BSIS", 75)
        };

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var s in students)
            {
                writer.WriteLine($"{s.StudentID},{s.Name},{s.Course},{s.Grade}");
            }
        }

        var loadedStudents = new List<MgaStudyante>();
        string[] lines = File.ReadAllLines(filePath);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            loadedStudents.Add(new MgaStudyante(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                double.Parse(parts[3])
            ));
        }

        Console.WriteLine("Students with Grade > 85");
        var highGrades = loadedStudents.Where(s => s.Grade > 85);
        foreach (var s in highGrades)
        {
            Console.WriteLine($"{s.Name} - {s.Grade}");
        }

        Console.WriteLine("\nSorted by Grade (Descending)");
        var sortedGrades = loadedStudents.OrderByDescending(s => s.Grade);
        foreach (var s in sortedGrades)
        {
            Console.WriteLine($"{s.Name} - {s.Grade}");
        }

        Console.WriteLine("\nStudent Names");
        var namesOnly = loadedStudents.Select(s => s.Name);
        foreach (var name in namesOnly)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("\nAverage Grade:");
        double average = loadedStudents.Average(s => s.Grade);
        Console.WriteLine(average.ToString("F2"));
    }
}