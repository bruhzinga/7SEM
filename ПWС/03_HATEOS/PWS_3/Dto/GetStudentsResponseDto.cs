using System.Collections.Generic;
using PWS_3.Models;

namespace PWS_3.Dto
{
    public class GetStudentsResponseDto
    {
        public List<object> Students { get; set; }
        public List<Link>? Links { get; set; }
    }
}