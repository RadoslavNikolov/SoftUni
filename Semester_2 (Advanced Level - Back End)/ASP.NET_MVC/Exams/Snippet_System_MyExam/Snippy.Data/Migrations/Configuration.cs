namespace Snippy.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<Snippy.Data.SnippyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Snippy.Data.SnippyDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedRoles(context);
                this.SeedAdmin(context);
                var users = this.SeedUsers(context);
                var languages = this.SeedLanguages(context);
                var labels = this.SeedLabels(context);
                var snippets = this.SeedSnippets(context, users,languages);
                this.SeedComments(context, snippets, users);
                this.SeedLabelsInSnippet(context, snippets, labels);
            }
        }

        private void SeedLabelsInSnippet(SnippyDbContext context, List<Snippet> snippets, List<Label> labels)
        {
            var snippet = context.Snippets.Find(snippets[0].Id);
            snippet.Labels.Add(labels[1]);

            snippet = context.Snippets.Find(snippets[1].Id);
            snippet.Labels.Add(labels[6]);
            snippet.Labels.Add(labels[9]);

            snippet = context.Snippets.Find(snippets[2].Id);
            snippet.Labels.Add(labels[2]);
            snippet.Labels.Add(labels[4]);
            snippet.Labels.Add(labels[5]);
            snippet.Labels.Add(labels[8]);

            snippet = context.Snippets.Find(snippets[3].Id);
            snippet.Labels.Add(labels[5]);
            snippet.Labels.Add(labels[8]);

            snippet = context.Snippets.Find(snippets[4].Id);
            snippet.Labels.Add(labels[0]);
            snippet.Labels.Add(labels[1]);
            snippet.Labels.Add(labels[3]);

            snippet = context.Snippets.Find(snippets[5].Id);
            snippet.Labels.Add(labels[4]);

            snippet = context.Snippets.Find(snippets[6].Id);
            snippet.Labels.Add(labels[5]);
            snippet.Labels.Add(labels[8]);

            snippet = context.Snippets.Find(snippets[7].Id);
            snippet.Labels.Add(labels[1]);
        }


        private void SeedComments(SnippyDbContext context, List<Snippet> snippets, List<User> users)
        {
            var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");
            var snippet = context.Snippets.Find(snippets[0].Id);
            snippet.Comments.Add(new Comment() { SnippetId = snippet.Id, AuthorId = admin.Id, CreatedOn = new DateTime(2015, 10, 30, 11, 50, 38), Content = "Now that's really funny! I like it!" });
            snippet.Comments.Add(new Comment() { SnippetId = snippet.Id, AuthorId = users[1].Id, CreatedOn = new DateTime(2015, 11, 1, 15, 52, 42), Content = "Here, have my comment!" });
            snippet.Comments.Add(new Comment() { SnippetId = snippet.Id, AuthorId = users[0].Id, CreatedOn = new DateTime(2015, 11, 2, 5, 30, 20), Content = "I didn't manage to comment first :(" });

            snippet = context.Snippets.Find(snippets[5].Id);
            snippet.Comments.Add(new Comment() { SnippetId = snippet.Id, AuthorId = users[1].Id, CreatedOn = new DateTime(2015, 10, 27, 15, 28, 14), Content = "That's why I love Python - everything is so simple!" });

            snippet = context.Snippets.Find(snippets[1].Id);
            snippet.Comments.Add(new Comment() { SnippetId = snippet.Id, AuthorId = users[0].Id, CreatedOn = new DateTime(2015, 10, 29, 15, 8, 42), Content = "I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject" });

            snippet = context.Snippets.Find(snippets[3].Id);
            snippet.Comments.Add(new Comment() { SnippetId = snippet.Id, AuthorId = admin.Id, CreatedOn = new DateTime(2015, 11, 3, 12, 56, 20), Content = "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I'm ready." });

            context.SaveChanges();
        }

        private List<Snippet> SeedSnippets(SnippyDbContext context, List<User> users, List<Language> languages)
        {
            var admin = context.Users.FirstOrDefault(u => u.UserName == "admin");
            var snippets = new List<Snippet>()
            {
                new Snippet(){Title = "Ternary Operator Madness", Description = "This is how you DO NOT user ternary operators in C#!", Code = "bool X = Glob.UserIsAdmin ? true : false;", CreatedOn = new DateTime(2015,10,26,17,20,33), AuthorId = admin.Id, LanguageId = languages[0].Id},
                new Snippet(){Title = "Points Around A Circle For GameObject Placement", Description = "Determine points around a circle which can be used to place elements around a central point", Code = @"private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)
{
	float ptRatio = currentPoint / totalPoints;
	float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;
	float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;

	Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);

	return panelCenter;
}
", CreatedOn = new DateTime(2015,10,26,20,15,30), AuthorId = admin.Id, LanguageId = languages[0].Id},
                new Snippet(){Title = "forEach. How to break?", Description = "Array.prototype.forEach You can't break forEach. So use \"some\" or \"every\". Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true. Array.prototype.every every is almost identical to some except it's expecting false to break the loop.", 
                    Code = @"var ary = [""JavaScript"", ""Java"", ""CoffeeScript"", ""TypeScript""];
 
ary.some(function (value, index, _ary) {
	console.log(index + "": "" + value);
	return value === ""CoffeeScript"";
});
// output: 
// 0: JavaScript
// 1: Java
// 2: CoffeeScript
 
ary.every(function(value, index, _ary) {
	console.log(index + "": "" + value);
	return value.indexOf(""Script"") > -1;
});
// output:
// 0: JavaScript
// 1: Java
", CreatedOn = new DateTime(2015,10,27,10,53,20), AuthorId = users[1].Id, LanguageId = languages[1].Id},
                new Snippet(){Title = "Numbers only in an input field", Description = "Method allowing only numbers (positive / negative / with commas or decimal points) in a field", Code = @"$(""#input"").keypress(function(event){
	var charCode = (event.which) ? event.which : window.event.keyCode;
	if (charCode <= 13) { return true; } 
	else {
		var keyChar = String.fromCharCode(charCode);
		var regex = new RegExp(""[0-9,.-]"");
		return regex.test(keyChar); 
	} 
});
", CreatedOn = new DateTime(2015,10,28,9,0,56), AuthorId = users[0].Id, LanguageId = languages[1].Id},
                new Snippet(){Title = "Create a link directly in an SQL query", Description = "That's how you create links - directly in the SQL!", Code = @"SELECT DISTINCT
              b.Id,
              concat('<button type=""button"" onclick=""DeleteContact(', cast(b.Id as char), ')"">Delete...</button>') as lnkDelete
FROM tblContact   b
WHERE ....
", CreatedOn = new DateTime(2015,10,30,11,20,0), AuthorId = admin.Id, LanguageId = languages[4].Id},
                new Snippet(){Title = "Reverse a String", Description = "Almost not worth having a function for...", Code = @"def reverseString(s):
	""Reverses a string given to it.""
	return s[::-1]
", CreatedOn = new DateTime(2015,10,26,9,35,13), AuthorId = admin.Id, LanguageId = languages[2].Id},
                new Snippet(){Title = "Pure CSS Text Gradients", Description = "This code describes how to create text gradients using only pure CSS", Code = @"/* CSS text gradients */
h2[data-text] {
	position: relative;
}
h2[data-text]::after {
	content: attr(data-text);
	z-index: 10;
	color: #e3e3e3;
	position: absolute;
	top: 0;
	left: 0;
	-webkit-mask-image: -webkit-gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));
", CreatedOn = new DateTime(2015,10,22,19,26,42), AuthorId = users[0].Id, LanguageId = languages[3].Id},
                                new Snippet(){Title = "Check for a Boolean value in JS", Description = "How to check a Boolean value - the wrong but funny way :D", Code = @"var b = true;

if (b.toString().length < 5) {
  //...
}
", CreatedOn = new DateTime(2015,10,22,5,30,4), AuthorId = admin.Id, LanguageId = languages[1].Id},
            };

            foreach (var snippet in snippets)
            {
                context.Snippets.Add(snippet);
            }

            context.SaveChanges();

            return snippets;
        }

        private List<Label> SeedLabels(SnippyDbContext context)
        {
            var labels = new List<Label>()
            {
                new Label(){Text = "bug"},
                new Label(){Text = "funny"},
                new Label(){Text = "jquery"},
                new Label(){Text = "mysql"},
                new Label(){Text = "useful"},
                new Label(){Text = "web"},
                new Label(){Text = "geometry"},
                new Label(){Text = "back-end"},
                new Label(){Text = "front-end"},
                new Label(){Text = "games"},
            };

            foreach (var label in labels)
            {
                context.Labels.Add(label);
            }

            context.SaveChanges();

            return labels;
        }


        private List<Language> SeedLanguages(SnippyDbContext context)
        {
            var languages = new List<Language>()
            {
                new Language(){ Name = "C#"},
                new Language(){ Name = "JavaScript"},
                new Language(){ Name = "Python"},
                new Language(){ Name = "CSS"},
                new Language(){ Name = "SQL"},
                new Language(){ Name = "PHP"},
            };

            foreach (var language in languages)
            {
                context.Languages.Add(language);
            }

            context.SaveChanges();

            return languages;
        }


        private void SeedRoles(SnippyDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }
        }

        private void SeedAdmin(SnippyDbContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            var user = new User { UserName = "admin", Email = "admin@snippy.softuni.com" };

            manager.Create(user, "adminPass123");
            manager.AddToRole(user.Id, "Admin");
        }

        private List<User> SeedUsers(SnippyDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var user1 = new User()
            {
                UserName = "someUser",
                Email = "someUser@example.com"
            };

            var user2 = new User()
            {
                UserName = "newUser",
                Email = "new_user@gmail.com"
            };

            var createUserResult = userManager.Create(user1, "someUserPass123");
            createUserResult = userManager.Create(user2, "userPass123");
            var users = new List<User>();
            users.Add(user1);
            users.Add(user2);

            return users;
        }
    }
}
