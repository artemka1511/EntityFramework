using EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories
{
    public class BookRepository
    {
        private AppContext _context;

        public Book GetBookById(int id) { return _context.Books.Where(b => b.Id == id).First(); }

        public List<Book> GetAllBooks() { return _context.Books.ToList(); }

        public void AddNewBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void RemoveBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void UpdateBookYearById(int id, int year) 
        {
            GetBookById(id).Year = year;
            _context.SaveChanges();
        }

        public List<Book> GetBooksByGenreAndYears(int genreId, int firstYear, int secondYear) { return _context.Books.Where(b => b.GenreId == genreId && b.Year >= firstYear && b.Year <= secondYear).ToList(); }

        public bool IsContainsBookOnLibraryByAuthorAndName(int authorId, string name) { return _context.Books.Where(b => b.AuthorId == authorId && b.Name == name).Any(); }

        public int GetCountBooksByAuthor(int authorId) { return _context.Books.Where(b => b.Author.Id == authorId).ToList().Count; }

        public int GetCountBooksByGenre(int genreId) { return _context.Books.Where(b => b.Genre.Id == genreId).ToList().Count; }

        public List<Book> GetAllBooksSortedByNameAsc() { return _context.Books.OrderBy(b => b.Name).ToList(); }

        public List<Book> GetAllBooksSortedByYearDesc() { return _context.Books.OrderByDescending(b => b.Year).ToList(); }

        public Book GetLastBook() { return GetAllBooksSortedByYearDesc().First(); }
    }
}
