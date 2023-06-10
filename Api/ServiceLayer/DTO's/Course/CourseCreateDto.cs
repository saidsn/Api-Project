﻿namespace ServiceLayer.DTO_s.Course
{
    public class CourseCreateDto
    {
        public byte[]? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int[]? authorIds { get; set; }
    }
}