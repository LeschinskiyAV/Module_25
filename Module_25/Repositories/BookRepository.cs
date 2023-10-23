namespace Module_25.Repositories
{
    internal class BookRepository
    {
        public Book GetBookById(int id)
        {
            using (var db = new AppContext())
            {
                return db.Books.FirstOrDefault();
            }
        }
        public List<Book> GetAllUsers()
        {
            using (var db = new AppContext())
            {
                return db.Books.ToList();
            }
        }

        public bool RemoveBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Remove(book);
                return true;
            }
        }

        public bool AddBook(Book book)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(book);
                return true;
            }
        }

        public bool UpdateName(int id, int NewYear)
        {
            using (var db = new AppContext())
            {
                Book book = GetBookById(id);
                book.Year = NewYear;
                db.SaveChanges();
                return true;
            }
        }

        public List<Book> GetByGenreAndYear(int genreId, int startYear, int endYear)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(b => b.GenreId == genreId && b.Year >= startYear && b.Year <= endYear).ToList();
            }
        }

        public int GetBooksQtyByAuthor(int authorId)
        {
            using (var db = new AppContext())
            {
                return (db.Books.Where(b => b.AuthorId == authorId).ToList()).Count;
            }
        }

        public int GetBooksQtyByGenre(int genreId)
        {
            using (var db = new AppContext())
            {
                return db.Books.Where(b => b.GenreId == genreId).ToList().Count;
            }
        }

        public bool BookExists(int authorId, string title)
        {
            using (var db = new AppContext())
            {
                var booksList = db.Books
                    .Where(b => b.AuthorId == authorId && b.Title == title)
                    .ToList();
                return booksList.Count > 0;
            }
        }

        public bool UserHaveBook(int bookId)
        {
            using (var db = new AppContext())
            {
                return (from b in db.Books
                    join user in db.Users on b.CurrentReaderId equals user.Id
                    where b.Id == bookId
                    select user).Any();
            }
        }

        public int UserBooksInReadingQty(int userId)
        {
            using (var db = new AppContext())
            {
                return
                    (from b in db.Books
                     join user in db.Users on b.CurrentReaderId equals user.Id
                     where user.Id == userId
                     select user).Count();
            }
        }

        public Book GetLastReleasedBook()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.Year).FirstOrDefault();
            }
        }

        public List<Book> GetSortedBooksByTitle()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderBy(b => b.Title).ToList();
            }
        }

        public List<Book> GetSortedBooksByYear()
        {
            using (var db = new AppContext())
            {
                return db.Books.OrderByDescending(b => b.Year).ToList();
            }
        }
    }
}
