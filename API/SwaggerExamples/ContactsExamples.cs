﻿namespace API.SwaggerExamples
{
    using Application.ViewModels;
    using Swashbuckle.AspNetCore.Filters;

    public class ContactRequestExample : IExamplesProvider<ContactRequestModel>
    {
        public ContactRequestModel GetExamples()
        {
            return new ContactRequestModel
            {
                Name = "Sanders Vieira",
                Ddd = "11",
                Phone = "98155-4567",
                Email = "sanders.vieira@example.com"
            };
        }
    }

    public class ContactResponseExample : IExamplesProvider<ContactResponseModel>
    {
        public ContactResponseModel GetExamples()
        {
            return new ContactResponseModel
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = "Sanders Vieira",
                Ddd = "11",
                Phone = "98155-4567",
                Email = "sanders.vieira@example.com"
            };
        }
    }

    public class ListOfContactResponseExample : IExamplesProvider<IList<ContactResponseModel>>
    {
        public IList<ContactResponseModel> GetExamples()
        {
            return new List<ContactResponseModel>()
            {
                new()
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Name = "Sanders Vieira",
                    Ddd = "11",
                    Phone = "98155-4567",
                    Email = "sanders.vieira@example.com"
                }
            };
        }
    }
}
