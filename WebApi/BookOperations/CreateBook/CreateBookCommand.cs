using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel BookModel { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == BookModel.Title);
            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut!");
            }
            book = new Book()
            {
                Title = BookModel.Title,
                PublishDate = BookModel.PublishDate,
                PageCount = BookModel.PageCount,
                GenreId = BookModel.GenreId
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}