﻿namespace Application.ViewModels
{
    public class ContactResponseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
