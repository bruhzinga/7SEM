namespace PWS_3.Exceptions
{
    public class StudentNotFoundException : BaseException
    {
        public StudentNotFoundException() : base("Student not found")
        {
            
        }
        
        public override int SubCode => 1;
        
        public override string Description => "Student not found";
    }
}