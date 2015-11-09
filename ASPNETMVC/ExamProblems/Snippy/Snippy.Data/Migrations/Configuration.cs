namespace Snippy.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Snippy.Data.SnippyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Snippy.Data.SnippyContext";
        }

        protected override void Seed(Snippy.Data.SnippyContext context)
        {
            if (context.Snippets.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6
            };

            var admin = new User()
            {
                UserName = "admin",
                Email = "admin@snippy.softuni.com",
            };
            var someUser = new User()
            {
                UserName = "someUser",
                Email = "someUser@example.com"
            };
            var newUser = new User()
            {
                UserName = "newUser",
                Email = "new_user@gmail.com"
            };

            userManager.Create(admin, "adminPass123");
            userManager.Create(someUser, "someUserPass123");
            userManager.Create(newUser, "userPass123");

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole("Admin"));
            var adminUser = context.Users
                .FirstOrDefault(u => u.UserName == "admin");

            userManager.AddToRole(adminUser.Id, "Admin");
            context.Labels.Add(new Label()
            {
                Text = "bug"
            });
            context.Labels.Add(new Label()
            {
                Text = "funny"
            });
            context.Labels.Add(new Label()
            {
                Text = "jquery"
            });
            context.Labels.Add(new Label()
            {
                Text = "mysql"
            });
            context.Labels.Add(new Label()
            {
                Text = "useful"
            });
            context.Labels.Add(new Label()
            {
                Text = "web"
            });
            context.Labels.Add(new Label()
            {
                Text = "geometry"
            });
            context.Labels.Add(new Label()
            {
                Text = "back-end"
            });
            context.Labels.Add(new Label()
            {
                Text = "front-end"
            });
            context.Labels.Add(new Label()
            {
                Text = "games"
            });
            context.Languages.Add(new Language()
            {
                Name = "C#"
            });
            context.Languages.Add(new Language()
            {
                Name = "JavaScript"
            });
            context.Languages.Add(new Language()
            {
                Name = "Python"
            });
            context.Languages.Add(new Language()
            {
                Name = "CSS"
            });
            context.Languages.Add(new Language()
            {
                Name = "SQL"
            });
            context.Languages.Add(new Language()
            {
                Name = "PHP"
            });
            context.SaveChanges();
            context.Snippets.Add(new Snippet()
            {
                Title = "Ternary Operator Madness",
                Description = "This is how you DO NOT user ternary operators in C#!",
                Code = "bool X = Glob.UserIsAdmin ? true : false;",
                Author = context.Users.First(u => u.UserName == "admin"),
                CreationTime = new DateTime(2015, 10, 26, 17, 20, 33),
                Language = context.Languages.First(l => l.Name == "C#")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Points Around A Circle For GameObject Placement",
                Description = "Determine points around a circle which can be used to place elements around a central point",
                Code = "private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)" +
                    "{" +
                    "float ptRatio = currentPoint / totalPoints;" +
                    "float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;" +
                    "float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;" +
                    "Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);" +
                    "return panelCenter;" +
                    "}",
                Author = context.Users.First(u => u.UserName == "admin"),
                CreationTime = new DateTime(2015, 10, 26, 20, 15, 30),
                Language = context.Languages.First(l => l.Name == "C#")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "forEach. How to break?",
                Description = "Array.prototype.forEach You can't break forEach. So use \"some\" or \"every\". Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true. Array.prototype.every every is almost identical to some except it's expecting false to break the loop.",
                Code = "var ary = [\"JavaScript\", \"Java\", \"CoffeeScript\", \"TypeScript\"];\n\r\n\rary.some(function(value, index, _ary) {\n\rconsole.log(index + \": \" + value);\n\rreturn value === \"CoffeeScript\";\n\r});\n\r// output: \n\r// 0: JavaScript\n\r// 1: Java\n\r// 2: CoffeeScript\n\r\n\rary.every(function(value, index, _ary)\n\r{\n\rconsole.log(index + \": \" + value);\n\rreturn value.indexOf(\"Script\") > -1;\n\r});\n\r// output:\n\r// 0: JavaScript\n\r// 1: Java",
                Author = context.Users.First(u => u.UserName == "newUser"),
                CreationTime = new DateTime(2015, 10, 27, 10, 53, 20),
                Language = context.Languages.First(l => l.Name == "JavaScript")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Numbers only in an input field",
                Description = "Method allowing only numbers (positive / negative / with commas or decimal points) in a field",
                Code = "$(\"#input\").keypress(function(event){\n\rvar charCode = (event.which) ? event.which : window.event.keyCode;\n\rif (charCode <= 13) { return true; }\n\relse {\n\rvar keyChar = String.fromCharCode(charCode);\n\rvar regex = new RegExp(\"[0-9,.-]\");\n\rreturn regex.test(keyChar);\n\r}\n\r});",
                Author = context.Users.First(u => u.UserName == "someUser"),
                CreationTime = new DateTime(2015, 10, 28, 9, 0, 56),
                Language = context.Languages.First(l => l.Name == "JavaScript")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Create a link directly in an SQL query",
                Description = "That's how you create links - directly in the SQL!",
                Code = "SELECT DISTINCT\n\rb.Id,\n\rconcat('<button type=\"\"button\"\" onclick=\"\"DeleteContact(', cast(b.Id as char), ')\"\">Delete...</button>') as lnkDelete\n\rFROM tblContact   b\n\rWHERE....",
                Author = context.Users.First(u => u.UserName == "admin"),
                CreationTime = new DateTime(2015, 10, 30, 11, 20, 0),
                Language = context.Languages.First(l => l.Name == "SQL")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Reverse a String",
                Description = "Almost not worth having a function for...",
                Code = "def reverseString(s):\n\r\"\"\"Reverses a string given to it.\"\"\"\n\rreturn s[::- 1]",
                Author = context.Users.First(u => u.UserName == "admin"),
                CreationTime = new DateTime(2015, 10, 26, 9, 35, 13),
                Language = context.Languages.First(l => l.Name == "Python")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Pure CSS Text Gradients",
                Description = "This code describes how to create text gradients using only pure CSS",
                Code = "/* CSS text gradients */\n\rh2[data - text] {\n\rposition: relative;\n\r}\n\rh2[data - text]::after {\n\rcontent: attr(data-text);\n\rz-index: 10;\n\rcolor: #e3e3e3;\n\rposition: absolute;\n\rtop: 0;\n\rleft: 0;\n\r-webkit-mask-image: -webkit-gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));",
                Author = context.Users.First(u => u.UserName == "someUser"),
                CreationTime = new DateTime(2015, 10, 22, 19, 26, 42),
                Language = context.Languages.First(l => l.Name == "CSS")
            });
            context.Snippets.Add(new Snippet()
            {
                Title = "Check for a Boolean value in JS",
                Description = "How to check a Boolean value - the wrong but funny way :D",
                Code = "var b = true;\n\r\n\rif (b.toString().length < 5)\n\r{\n\r//...\n\r}",
                Author = context.Users.First(u => u.UserName == "admin"),
                CreationTime = new DateTime(2015, 10, 30, 11, 50, 38),
                Language = context.Languages.First(l => l.Name == "JavaScript")
            });
            context.SaveChanges();
            context.Comments.Add(new Comment()
            {
                Content = "Now that's really funny! I like it!",
                CreationTime = new DateTime(2015, 10, 30, 11, 50, 38),
                Author = context.Users.First(u => u.UserName == "admin"),
                Snippet = context.Snippets.First(s => s.Title == "Ternary Operator Madness")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Here, have my comment!",
                CreationTime = new DateTime(2015, 11, 1, 15, 52, 42),
                Author = context.Users.First(u => u.UserName == "newUser"),
                Snippet = context.Snippets.First(s => s.Title == "Ternary Operator Madness")
            });
            context.Comments.Add(new Comment()
            {
                Content = "I didn't manage to comment first :(",
                CreationTime = new DateTime(2015, 11, 2, 5, 30, 20),
                Author = context.Users.First(u => u.UserName == "someUser"),
                Snippet = context.Snippets.First(s => s.Title == "Ternary Operator Madness")
            });
            context.Comments.Add(new Comment()
            {
                Content = "That's why I love Python - everything is so simple!",
                CreationTime = new DateTime(2015, 10, 27, 15, 28, 14),
                Author = context.Users.First(u => u.UserName == "newUser"),
                Snippet = context.Snippets.First(s => s.Title == "Reverse a String")
            });
            context.Comments.Add(new Comment()
            {
                Content = "I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject",
                CreationTime = new DateTime(2015, 10, 29, 15, 8, 42),
                Author = context.Users.First(u => u.UserName == "someUser"),
                Snippet = context.Snippets.First(s => s.Title == "Points Around A Circle For GameObject Placement")
            });
            context.Comments.Add(new Comment()
            {
                Content = "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I'm ready.",
                CreationTime = new DateTime(2015, 11, 3, 12, 56, 20),
                Author = context.Users.First(u => u.UserName == "admin"),
                Snippet = context.Snippets.First(s => s.Title == "Numbers only in an input field")
            });
            context.Snippets.First(s => s.Title == "Ternary Operator Madness").Labels.Add(context.Labels.First(l => l.Text == "funny"));
            context.Snippets.First(s => s.Title == "Points Around A Circle For GameObject Placement").Labels.Add(context.Labels.First(l => l.Text == "geometry"));
            context.Snippets.First(s => s.Title == "Points Around A Circle For GameObject Placement").Labels.Add(context.Labels.First(l => l.Text == "games"));
            context.Snippets.First(s => s.Title == "forEach. How to break?").Labels.Add(context.Labels.First(l => l.Text == "jquery"));
            context.Snippets.First(s => s.Title == "forEach. How to break?").Labels.Add(context.Labels.First(l => l.Text == "useful"));
            context.Snippets.First(s => s.Title == "forEach. How to break?").Labels.Add(context.Labels.First(l => l.Text == "web"));
            context.Snippets.First(s => s.Title == "forEach. How to break?").Labels.Add(context.Labels.First(l => l.Text == "front-end"));
            context.Snippets.First(s => s.Title == "Numbers only in an input field").Labels.Add(context.Labels.First(l => l.Text == "web"));
            context.Snippets.First(s => s.Title == "Numbers only in an input field").Labels.Add(context.Labels.First(l => l.Text == "front-end"));
            context.Snippets.First(s => s.Title == "Create a link directly in an SQL query").Labels.Add(context.Labels.First(l => l.Text == "bug"));
            context.Snippets.First(s => s.Title == "Create a link directly in an SQL query").Labels.Add(context.Labels.First(l => l.Text == "funny"));
            context.Snippets.First(s => s.Title == "Create a link directly in an SQL query").Labels.Add(context.Labels.First(l => l.Text == "mysql"));
            context.Snippets.First(s => s.Title == "Reverse a String").Labels.Add(context.Labels.First(l => l.Text == "useful"));
            context.Snippets.First(s => s.Title == "Pure CSS Text Gradients").Labels.Add(context.Labels.First(l => l.Text == "web"));
            context.Snippets.First(s => s.Title == "Pure CSS Text Gradients").Labels.Add(context.Labels.First(l => l.Text == "front-end"));
            context.Snippets.First(s => s.Title == "Check for a Boolean value in JS").Labels.Add(context.Labels.First(l => l.Text == "funny"));
            context.SaveChanges();
        }
    }
}