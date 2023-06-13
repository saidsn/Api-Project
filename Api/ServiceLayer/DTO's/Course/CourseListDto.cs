﻿using DomainLayer.Entities;

namespace ServiceLayer.DTO_s.Course
{
    public class CourseListDto
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<DomainLayer.Entities.Student>? Students { get; set; }
        public List<CourseAuthor>? CourseAuthors { get; set; }
    }
}
