using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "BookImage", "Description", "ISBN", "NumberOfPages", "NumberOfPurchases", "Price", "Quantity", "SummaryDescription", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Kate Douglas Wiggin", "rebecca", "The novel depicts an unnamed young woman who impetuously marries a wealthy widower, before discovering that both he and his household are haunted by the memory of his late first wife, the title character.", "8764-212314551", 143, 23, 20.989999999999998, 5, "Rebecca is a 1938 Gothic novel written by English author Daphne du Maurier.", "Rebecca", 1938 },
                    { 2, "Jane Austen", "emma", "It is set in the fictional country village of Highbury and the surrounding estates of Hartfield, Randalls and Donwell Abbey, and involves the relationships among people from a small number of families.", "978-1853260285", 1036, 11, 15.59, 31, "Emma is a novel written by Jane Austen", "Emma", 1815 },
                    { 3, "Octavia E. Butler", "kindred", "Kindred (1979) is a novel by American writer Octavia E. Butler that incorporates time travel and is modeled on slave narratives.  Widely popular, it has frequently been chosen as a text by community-wide reading programs and book organizations, and for high school and college courses.", "0-385-15059-8", 264, 3, 25.59, 1, "Kindred (1979) is a novel by American writer Octavia E. Butler that incorporates time travel and is modeled on slave narratives", "Kindred ", 1979 },
                    { 4, "Chris Frazer Smith", "atonement", "Set in three time periods, 1935 England, Second World War England and France, and present-day England, it covers an upper-class girl's half-innocent mistake that ruins lives, her adulthood in the shadow of that mistake, and a reflection on the nature of writing.", "0-224-06252-2", 371, 77, 17.390000000000001, 14, "Atonement is a 2001 British metafictional novel written by Ian McEwan.", "Atonement ", 2001 },
                    { 5, "Chimamanda Ngozi Adichie", "americanah", "The novel traces Ifemelu's life in both countries, threaded by her love story with high school classmate Obinze. It was Adichie's third novel.", "978-0-307-96212-6", 608, 1, 35.200000000000003, 2, "Americanah is a 2013 novel by the Nigerian author Chimamanda Ngozi Adichie, for which Adichie won the 2013 U.S", "Americanah", 2013 },
                    { 6, "John Steinbeck", "ofmiceandmen", "Published in 1937, it narrates the experiences of George Milton and Lennie Small, two displaced migrant ranch workers, who move from place to place in California in search of new job opportunities during the Great Depression in the United States.", "978-0-307-96212-6", 107, 42, 5.2000000000000002, 3, "Of Mice and Men is a novella written by John Steinbeck.", "Of Mice and Men", 1937 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
