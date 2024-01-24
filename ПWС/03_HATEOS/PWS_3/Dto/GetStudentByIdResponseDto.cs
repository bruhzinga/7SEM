using System.Collections.Generic;
using PWS_3.Models;

namespace PWS_3.Dto
{
    public class GetStudentByIdResponseDto
    {
        public Student Student { get; set; }
        public List<Link>? Links { get; set; }
    }
}