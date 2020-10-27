using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DAL.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData
            (
                new Comment
                {
                    Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Email = "kriklyavlad@gmail.com",
                    CommentText = "The Google team developed it to upgrade the earlier version of AngularJS. In the focus of development, on the one hand, there was the fulfillment of modern demands, talking about technology, and, on the other hand, the tendency to combine the concepts that best showed in practice. With this framework, the Google team has undoubtedly set standards in this sphere. They published the first version of Angular (v2) in 2016. Before that, in 2014 and 2015 were released alpha and beta.",
                    PostId = new Guid("76cf600f-7bf6-40fb-8803-142eac60f3dd")
                },
                 new Comment
                 {
                     Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                     Email = "super1234@gmail.com",
                     CommentText = "When React was first introduced, it fundamentally changed how JavaScript frameworks worked. While everyone else was pushing MVC, MVVM, etc, React chose to isolate view rendering from the model representation and introduce a completely new architecture to the JavaScript front-end ecosystem: Flux.",
                     PostId = new Guid("68f0eaed-189e-4c65-8cf8-475539d6f21b")
                 }
            );
        }
    }
}
