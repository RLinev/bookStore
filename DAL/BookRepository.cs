namespace DAL
{
    public  class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        public BookRepository()
        {
            _context = new BookContext();
        }
        public List<Book> GetAllBooks(string name, int? priceFrom = null, int? priceTo = null)
        {
            var result = _context.Books.Where(z=> 
            (string.IsNullOrEmpty(name)? 1==1: z.Title.ToLower().Contains(name.ToLower())) 
            && (priceFrom.HasValue? z.Price>= priceFrom.Value : 1 == 1) 
            && (priceTo.HasValue ? z.Price <= priceTo.Value : 1==1 )).OrderByDescending(z=> z.NumberOfPurchases).ToList();

            return result;
        }
        public void AddOrUpdateBook(Book book)
        {
            var dbBook = _context.Books.FirstOrDefault(z=> z.ID == book.ID);
            if (dbBook != null) 
            {
                _context.Entry(dbBook).CurrentValues.SetValues(book);
            }
            else
            {
                _context.Books.Add(book);
            }
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var dbBook = _context.Books.FirstOrDefault(z => z.ID == id);
            _context.Books.Remove(dbBook);
            _context.SaveChanges();   
        }
    }
}
