using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.EF.Model
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public virtual Name AuthorName { get; private set; }
        private readonly List<Category> _categories = new();
        public virtual IReadOnlyList<Category> Categories => _categories.ToList();

        protected Book()
        {
        }

        private Book(string title, Name authorName)
            : this()
        {
            Title = title;
            AuthorName = authorName;
        }

        public static Result<Book> Create(string title, Name authorName)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result.Failure<Book>("Title should not be empty");

            title = title.Trim();

            if (title.Length > 500)
                return Result.Failure<Book>("Title is too long");

            return Result.Success(new Book(title, authorName));
        }

        public Result AddCategory(Category category)
        {
            if(Categories.Any(x => x == category))
                return Result.Failure("Category already assigned");

            _categories.Add(category);

            return Result.Success();
        }
    }
}
