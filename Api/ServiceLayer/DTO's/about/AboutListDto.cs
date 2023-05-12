﻿namespace ServiceLayer.DTOs.about
{
    public class AboutListDto
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
