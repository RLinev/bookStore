namespace DAL
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks(string name, int? priceFrom = null, int? priceTo = null);
        void AddOrUpdateBook(Book book);
        void DeleteBook(int id);
    }
}
