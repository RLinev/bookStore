using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public string DbPath { get; }

    public BookContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "book.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().HasData(
            new Book 
            { 
                ID = 1,
                Title = "Rebecca",
                Author = "Kate Douglas Wiggin",
                BookImage= "rebecca", 
                Description= "The novel depicts an unnamed young woman who impetuously marries a wealthy widower, before discovering that both he and his household are haunted by the memory of his late first wife, the title character.",
                SummaryDescription= "Rebecca is a 1938 Gothic novel written by English author Daphne du Maurier.",
                ISBN = "8764-212314551",
                NumberOfPages = 143,
                NumberOfPurchases = 23,  
                Price=20.99,
                Quantity= 5,
                Year = 1938
            },
            new Book
            {
                ID = 2,
                Title = "Emma",
                Author = "Jane Austen",
                BookImage = "emma",
                Description = "It is set in the fictional country village of Highbury and the surrounding estates of Hartfield, Randalls and Donwell Abbey, and involves the relationships among people from a small number of families.",
                SummaryDescription = "Emma is a novel written by Jane Austen",
                ISBN = "978-1853260285",
                NumberOfPages = 1036,
                NumberOfPurchases = 11,
                Price = 15.59,
                Quantity = 31,
                Year = 1815
            }, new Book
            {
                ID = 3,
                Title = "Kindred ",
                Author = "Octavia E. Butler",
                BookImage = "kindred",
                Description = "Kindred (1979) is a novel by American writer Octavia E. Butler that incorporates time travel and is modeled on slave narratives.  Widely popular, it has frequently been chosen as a text by community-wide reading programs and book organizations, and for high school and college courses.",
                SummaryDescription = "Kindred (1979) is a novel by American writer Octavia E. Butler that incorporates time travel and is modeled on slave narratives",
                ISBN = "0-385-15059-8",
                NumberOfPages = 264,
                NumberOfPurchases = 3,
                Price = 25.59,
                Quantity = 1,
                Year = 1979
            },
            new Book
            {
                ID = 4,
                Title = "Atonement ",
                Author = "Chris Frazer Smith",
                BookImage = "atonement",
                Description = "Set in three time periods, 1935 England, Second World War England and France, and present-day England, it covers an upper-class girl's half-innocent mistake that ruins lives, her adulthood in the shadow of that mistake, and a reflection on the nature of writing.",
                SummaryDescription = "Atonement is a 2001 British metafictional novel written by Ian McEwan.",
                ISBN = "0-224-06252-2",
                NumberOfPages = 371,
                NumberOfPurchases = 77,
                Price = 17.39,
                Quantity = 14,
                Year = 2001
            },
            new Book
            {
                ID = 5,
                Title = "Americanah",
                Author = "Chimamanda Ngozi Adichie",
                BookImage = "americanah",
                Description = "The novel traces Ifemelu's life in both countries, threaded by her love story with high school classmate Obinze. It was Adichie's third novel.",
                SummaryDescription = "Americanah is a 2013 novel by the Nigerian author Chimamanda Ngozi Adichie, for which Adichie won the 2013 U.S",
                ISBN = "978-0-307-96212-6",
                NumberOfPages = 608,
                NumberOfPurchases = 1,
                Price = 35.20,
                Quantity = 2,
                Year = 2013
            },
              new Book
              {
                  ID = 6,
                  Title = "Of Mice and Men",
                  Author = "John Steinbeck",
                  BookImage = "ofmiceandmen",
                  Description = "Published in 1937, it narrates the experiences of George Milton and Lennie Small, two displaced migrant ranch workers, who move from place to place in California in search of new job opportunities during the Great Depression in the United States.",
                  SummaryDescription = "Of Mice and Men is a novella written by John Steinbeck.",
                  ISBN = "978-0-307-96212-6",
                  NumberOfPages = 107,
                  NumberOfPurchases = 42,
                  Price = 5.20,
                  Quantity = 3,
                  Year = 1937
              }

            );
    }
}

public class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string SummaryDescription { get; set; }
    public string ISBN { get; set; }
    public string BookImage { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public int NumberOfPages { get; set; }
    public int Quantity { get; set; }
    public int NumberOfPurchases { get; set; }
}
