using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UIL.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Image", "Title" },
                values: new object[] { new Guid("68f0eaed-189e-4c65-8cf8-475539d6f21b"), "React (also known as React.js or ReactJS) is an open-source, front end, JavaScript library for building user interfaces or UI components. It is maintained by Facebook and a community of individual developers and companies. React can be used as a base in the development of single-page or mobile applications. However, React is only concerned with rendering data to the DOM, and so creating React applications usually requires the use of additional libraries for state management and routing.Redux and React Router are respective examples of such libraries.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fa%2Fa7%2FReact-icon.svg%2F1200px-React-icon.svg.png&imgrefurl=https%3A%2F%2Fru.wikipedia.org%2Fwiki%2FReact&tbnid=bs9SxMY2Dnr1RM&vet=12ahUKEwjY07W48dHsAhUgwQIHHd_2DfAQMygAegUIARCoAQ..i&docid=uDQPDMqXXQYhqM&w=1200&h=848&q=react&ved=2ahUKEwjY07W48dHsAhUgwQIHHd_2DfAQMygAegUIARCoAQ", "React" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Image", "Title" },
                values: new object[] { new Guid("76cf600f-7bf6-40fb-8803-142eac60f3dd"), "Angular is a platform and framework for building single-page client applications using HTML and TypeScript. Angular is written in TypeScript. It implements core and optional functionality as a set of TypeScript libraries that you import into your apps.", "https://www.google.com/imgres?imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fc%2Fcf%2FAngular_full_color_logo.svg%2F1200px-Angular_full_color_logo.svg.png&imgrefurl=https%3A%2F%2Fru.wikipedia.org%2Fwiki%2FAngular_(%25D1%2584%25D1%2580%25D0%25B5%25D0%25B9%25D0%25BC%25D0%25B2%25D0%25BE%25D1%2580%25D0%25BA)&tbnid=zMVT-tzIv4v9fM&vet=12ahUKEwi8mfWe8dHsAhUpwAIHHRG_BosQMygAegUIARCmAQ..i&docid=-C72sGJUKv1HNM&w=1200&h=1200&q=angular&ved=2ahUKEwi8mfWe8dHsAhUpwAIHHRG_BosQMygAegUIARCmAQ", "Angular" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentText", "Email", "PostId" },
                values: new object[] { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), "When React was first introduced, it fundamentally changed how JavaScript frameworks worked. While everyone else was pushing MVC, MVVM, etc, React chose to isolate view rendering from the model representation and introduce a completely new architecture to the JavaScript front-end ecosystem: Flux.", "super1234@gmail.com", new Guid("68f0eaed-189e-4c65-8cf8-475539d6f21b") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentText", "Email", "PostId" },
                values: new object[] { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "The Google team developed it to upgrade the earlier version of AngularJS. In the focus of development, on the one hand, there was the fulfillment of modern demands, talking about technology, and, on the other hand, the tendency to combine the concepts that best showed in practice. With this framework, the Google team has undoubtedly set standards in this sphere. They published the first version of Angular (v2) in 2016. Before that, in 2014 and 2015 were released alpha and beta.", "kriklyavlad@gmail.com", new Guid("76cf600f-7bf6-40fb-8803-142eac60f3dd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("68f0eaed-189e-4c65-8cf8-475539d6f21b"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: new Guid("76cf600f-7bf6-40fb-8803-142eac60f3dd"));
        }
    }
}
