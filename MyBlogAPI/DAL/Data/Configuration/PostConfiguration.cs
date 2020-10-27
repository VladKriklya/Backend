using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DAL.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData
            (
                new Post
                {
                    Id = new Guid("68f0eaed-189e-4c65-8cf8-475539d6f21b"),
                    Title = "React",
                    Content = "React (also known as React.js or ReactJS) is an open-source, front end, JavaScript library for building user interfaces or UI components. It is maintained by Facebook and a community of individual developers and companies. React can be used as a base in the development of single-page or mobile applications. However, React is only concerned with rendering data to the DOM, and so creating React applications usually requires the use of additional libraries for state management and routing.Redux and React Router are respective examples of such libraries.",
                    Image = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fa%2Fa7%2FReact-icon.svg%2F1200px-React-icon.svg.png&imgrefurl=https%3A%2F%2Fru.wikipedia.org%2Fwiki%2FReact&tbnid=bs9SxMY2Dnr1RM&vet=12ahUKEwjY07W48dHsAhUgwQIHHd_2DfAQMygAegUIARCoAQ..i&docid=uDQPDMqXXQYhqM&w=1200&h=848&q=react&ved=2ahUKEwjY07W48dHsAhUgwQIHHd_2DfAQMygAegUIARCoAQ"
                },
                new Post
                {
                    Id = new Guid("76cf600f-7bf6-40fb-8803-142eac60f3dd"),
                    Title = "Angular",
                    Content = "Angular is a platform and framework for building single-page client applications using HTML and TypeScript. Angular is written in TypeScript. It implements core and optional functionality as a set of TypeScript libraries that you import into your apps.",
                    Image = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fc%2Fcf%2FAngular_full_color_logo.svg%2F1200px-Angular_full_color_logo.svg.png&imgrefurl=https%3A%2F%2Fru.wikipedia.org%2Fwiki%2FAngular_(%25D1%2584%25D1%2580%25D0%25B5%25D0%25B9%25D0%25BC%25D0%25B2%25D0%25BE%25D1%2580%25D0%25BA)&tbnid=zMVT-tzIv4v9fM&vet=12ahUKEwi8mfWe8dHsAhUpwAIHHRG_BosQMygAegUIARCmAQ..i&docid=-C72sGJUKv1HNM&w=1200&h=1200&q=angular&ved=2ahUKEwi8mfWe8dHsAhUpwAIHHRG_BosQMygAegUIARCmAQ"
                }
            );
        }
    }
}
