﻿namespace ServiceLayer.DTOs.Header
{
    public class HeaderListDto
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
        public string? Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}