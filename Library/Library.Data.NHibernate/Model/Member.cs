using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.NHibernate.Model
{
    public class Member : Entity
    {
        public virtual Name Name { get; private set; }
        public Email Email { get; private set; }
        public virtual Book FavoriteBook{ get; private set; }

        private readonly List<Borrowing> _borrowings = new();
        public virtual IReadOnlyList<Borrowing> Borrowings => _borrowings.ToList();

        protected Member()
        {
        }

        public Member(
            Name name, Email email, Book favoriteBook)
            : this()
        {
            Name = name;
            Email = email;
            FavoriteBook = favoriteBook;
        }

        public Result BorrowBook(Book book)
        {
            if (_borrowings.Count <= 5)
                return Result.Failure($"Can not borrow more than 5 books");

            var borrowing = new Borrowing(this, book, DateTime.Now);
            _borrowings.Add(borrowing);

            return Result.Success("OK");
        }

        public void ReturnBook(Book book)
        {
            var borrowing = _borrowings.FirstOrDefault(x => x.Book == book);

            if (borrowing == null)
                return;

            _borrowings.Remove(borrowing);
        }
    }
}
