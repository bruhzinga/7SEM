using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PWS_3.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using PWS_3.Dto;
using PWS_3.Exceptions;
using PWS_3.Filters;
using PWS_3.XML;

namespace PWS_3.Controllers
{
    [ApiException]
    [DisableCors]
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        private readonly DbContext _context = new DbContext();

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> GetAsync(
            HttpRequestMessage request,
            [FromUri] GetRequestDto? requestDto
        )
        {
            requestDto ??= new GetRequestDto();

            var students = await _context.GetAllAsync(requestDto);

            var studentsWithSpecifiedProperties = GetStudentsWithSpecifiedProperties(requestDto.Columns, students);

            var response = new GetStudentsResponseDto
            {
                Students = studentsWithSpecifiedProperties,
                Links = new List<Link>
                {
                    new Link("http://localhost:49640/api/students", "GET", "self"),

                    new Link("http://localhost:49640/api/students/{id}", "GET", "get student by id"),
                    new Link("http://localhost:49640/api/students", "POST", "create student"),
                    new Link("http://localhost:49640/api/students/{id}", "PUT", "update student by id"),
                    new Link("http://localhost:49640/api/students/{id}", "DELETE", "delete student by id"),
                }
            };

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
            };

            var content = requestDto.Format switch
            {
                "json" => new StringContent(
                    JsonConvert.SerializeObject(response),
                    Encoding.UTF8,
                    "application/json"
                ),
                "xml" =>
                    new StringContent(
                        MyXmlSerializer.Serialize(response),
                        Encoding.UTF8,
                        "application/xml"
                    ),
                _ => throw new BadFormatException(requestDto.Format)
            };
            responseMessage.Content = content;

            return responseMessage;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> GetAsync(int? id, HttpRequestMessage request,
            [FromUri] GetRequestDto requestDto)
        {
            var student = await _context.GetByIdAsync(id);

            if (student is null)
            {
                throw new StudentNotFoundException();
            }

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
            };

            var response = new GetStudentByIdResponseDto
            {
                Student = student,
                Links = new List<Link>
                {
                    new Link($"http://localhost:49640/api/students/{student.Id}", "GET", "self"),
                    new Link("http://localhost:49640/api/students", "GET", "get all students"),
                    new Link($"http://localhost:49640/api/students/{student.Id}", "PUT", "update student by id"),
                    new Link($"http://localhost:49640/api/students/{student.Id}", "DELETE", "delete student by id"),
                }
            };


            var content = requestDto.Format switch
            {
                "json" => new StringContent(
                    JsonConvert.SerializeObject(response),
                    Encoding.UTF8,
                    "application/json"
                ),
                "xml" =>
                    new StringContent(
                        MyXmlSerializer.Serialize(response),
                        Encoding.UTF8,
                        "application/xml"
                    ),
                _ => throw new BadFormatException(requestDto.Format)
            };
            responseMessage.Content = content;

            return responseMessage;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody] StudentCreateRequest createRequest)
        {
            var student = _context.Post(createRequest);

            var links = new List<Link>
            {
                new Link($"http://localhost:49640/api/students/{student.Id}", "GET", "self"),
                new Link("http://localhost:49640/api/students", "GET", "get all students"),
                new Link($"http://localhost:49640/api/students/{student.Id}", "PUT", "update the student"),
                new Link($"http://localhost:49640/api/students/{student.Id}", "DELETE", "delete the student "),
            };

            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new { student, Links = links }),
                    Encoding.UTF8,
                    "application/json"
                )
            };

            return responseMessage;
        }
        
        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] StudentUpdateRequest updateRequest, HttpRequestMessage request)
        {
            var student = _context.Put(id, updateRequest);

            var links = new List<Link>
            {
                new Link("http://localhost:49640/api/students", "GET", "get all students"),
                new Link("http://localhost:49640/api/students", "POST", "create student"),
                new Link("http://localhost:49640/api/students", "GET", "get all students"),
                new Link("http://localhost:49640/api/students", "POST", "create student"),
            };
            
            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new { student, Links = links }),
                    Encoding.UTF8,
                    "application/json"
                )
            };

            return responseMessage;
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id, HttpRequestMessage request)
        {
            var student = _context.Delete(id);

            var links = new List<Link>
            {
                new Link("http://localhost:49640/api/students", "GET", "get all students"),
                new Link("http://localhost:49640/api/students", "POST", "create student"),
            };
            
            var responseMessage = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new { student, Links = links }),
                    Encoding.UTF8,
                    "application/json"
                )
            };

            return responseMessage;
        }

        private List<object> GetStudentsWithSpecifiedProperties(string columns, List<Student> studentsList)
        {
            var propertiesToSerialize = new List<string>();

            propertiesToSerialize.AddRange(columns.Split(','));

            var list = new List<object>();

            foreach (var student in studentsList)
            {
                var studentDict = new Dictionary<string, object>();

                foreach (var prop in propertiesToSerialize)
                {
                    var propertyInfo = student
                        .GetType()
                        .GetProperty
                            (prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo == null) continue;

                    var value = propertyInfo.GetValue(student);

                    studentDict.Add(prop, value);
                }

                list.Add(studentDict);
            }

            return list;
        }
    }
}