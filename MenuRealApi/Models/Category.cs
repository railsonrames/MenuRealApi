﻿namespace MenuRealApi.Models
{
    public class Category
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}