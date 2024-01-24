using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using PWS_3.Dto;
using PWS_3.Exceptions;

namespace PWS_3.Models
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Student> Students { get; set; }
        
        
        
        public async Task<Student> GetByIdAsync(int? id)
        {
            return await Students.SingleOrDefaultAsync(x => x.Id == id)
                   ?? throw new StudentNotFoundException();
        }

        public async Task<List<Student>> GetAllAsync(GetRequestDto getRequestDto)
        {
            var searchQuery = Students
                .Where(s => s.Id >= getRequestDto.Minid)
                .Where(s => s.Id <= getRequestDto.Maxid);
            
            if (!getRequestDto.Globallike.IsNullOrWhiteSpace())
            {
                var globallike = getRequestDto.Globallike;

                searchQuery = searchQuery.Where(s =>
                    (s.Phone
                     + SqlFunctions.StringConvert((decimal)s.Id)
                     + s.Name)
                    .Contains(globallike));
            }

            if (!getRequestDto.Like.IsNullOrWhiteSpace())
            {
                searchQuery = searchQuery.Where(s => s.Name.Contains(getRequestDto.Like));
            }

            searchQuery = getRequestDto.Sort switch
            {
                "asc" => searchQuery.OrderBy(x => x.Name),
                "desc" => searchQuery.OrderByDescending(x => x.Name),
                _ => searchQuery.OrderBy(x => x.Id)
            };

            searchQuery = searchQuery
                .Skip(getRequestDto.Offset)
                .Take(getRequestDto.Limit);

            return await searchQuery.ToListAsync();
        }

        public Student Post(StudentCreateRequest request)
        {
            var student = new Student(request.Name, request.Phone);

            Students.Add(student);

            SaveChanges();

            return student;
        }
        
        public Student Put(int id, StudentUpdateRequest updateRequest)
        {
            var student = Students.SingleOrDefault(x => x.Id == id);

            if (student == null)
            {
                throw new StudentNotFoundException();
            }

            student.Name = updateRequest.Name;
            student.Phone = updateRequest.Phone;

            SaveChanges();

            return student;
        }

        public Student Delete(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                throw new StudentNotFoundException();
            }

            Students.Remove(student);

            SaveChanges();

            return student;
        }

    }
}