namespace Grafos
{
    public class Student
    {
        public int code { get; set; }
        public int searchArea { get; set; }
        public int groupId { get; set; }

        public Student(int code, int searchArea)
        {
            this.searchArea = searchArea;
            this.code = code;
        }
    }
}