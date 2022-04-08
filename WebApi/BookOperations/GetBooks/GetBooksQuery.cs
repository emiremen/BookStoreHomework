using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks{
    public class  GetBooksQuery{
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle(){
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> booksViewModel = new List<BooksViewModel>();
            foreach (var item in bookList)
            {
                booksViewModel.Add(new BooksViewModel(){
                    Title = item.Title,
                    Genre = ((GenreEnum)item.GenreId).ToString(),
                    PublishDate = item.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = item.PageCount
                });
            }
            return booksViewModel;
        }
    }

    public class BooksViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}