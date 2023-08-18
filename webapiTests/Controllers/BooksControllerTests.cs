using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DAL;
using System.Drawing.Text;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers.Tests
{
    [TestClass()]
    public class BooksControllerTests
    {
        private IBookRepository _repo;
        private BooksController _controller;
        private IdentityController _idController;
        private readonly Book book = new Book() { Author = "Robert", Title = "Word of the Boom", BookImage = "", Description = "", ID = 0, ISBN = "", NumberOfPages = 2, NumberOfPurchases = 0, Price = 23.45, Quantity = 1, SummaryDescription = "", Year = 1900 };
        
        [TestInitialize]
        public void SetUp()
        {
            //Set up Prerequirments
            _repo = new BookRepository();
            _controller = new BooksController(_repo);
            _idController = new IdentityController();
        }
        public void CleanUp()
        {
            var books = _controller.Get();
            foreach (var book in books.Where(z => z.Title.Contains("Word of the Boom")))
            {
                _controller.Delete(book.ID);
            }
        }
        [TestMethod()]
        public void GetWithoutFiltrationTest()
        {
            //Act
            var books = _controller.Get();
            //Assert Result
            Assert.IsTrue(books.Count()> 0);

            CleanUp();
        }

        [TestMethod()]
        public void GetWithFiltrationByTitleTest()
        {
            var newBook = new Book() { Author = "Robert", Title = "Word of the Boom"+DateTime.Now.ToString(), BookImage = "", Description = "", ID = 0, ISBN = "", NumberOfPages = 2, NumberOfPurchases = 0, Price = 23.45, Quantity = 1, SummaryDescription = "", Year = 1900 };
            //Prepare
            _controller.Save(newBook);
            //Act
            var books = _controller.Get(newBook.Title);
            //Assert Result
            Assert.IsTrue(books.Count()  == 1);

            CleanUp();
        }
        [TestMethod()]
        public void GetWithFiltrationByPriceTest()
        {
            //Prepare
            _controller.Save(book);
            //Act
            var allBooks = _controller.Get();
            
            var booksFrom = _controller.Get(null,10);
            var booksTo = _controller.Get(null,null,20);
            var booksBetween = _controller.Get(null,15,20);
            //Assert Result
            Assert.AreEqual<int>(allBooks.Where(z => z.Price >= 10).Count(), booksFrom.Count());
            Assert.AreEqual<int>(allBooks.Where(z => z.Price <= 20).Count(), booksTo.Count());
            Assert.AreEqual<int>(allBooks.Where(z => z.Price >= 15 && z.Price <=20).Count(), booksBetween.Count());
            
            
            CleanUp();
        }
        [TestMethod()]
        public void SaveTest()
        {
            //prepare
            var allBooks = _controller.Get();
            int allBooksCount = allBooks.Count();
            //Act
            _controller.Save(book);
            allBooks = _controller.Get();
            //Assert
            Assert.AreEqual<int>(allBooksCount+1, allBooks.Count());

            CleanUp();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //prepare
            var allBooks = _controller.Get();
            int allBooksCount = allBooks.Count();
            //Act
            _controller.Delete(allBooks.FirstOrDefault().ID);
            allBooks = _controller.Get();
            //Assert
            Assert.AreEqual<int>(allBooksCount - 1, allBooks.Count());

            CleanUp();
        }

        [TestMethod()]
        public void IdentityTest()
        {
            //prepare
            string email = "test",
                password = "password";
            //Act
            var tokenResult = _idController.Token(new TokenGenerationRequest() { Email = email, UserId = password });
            //Assert
            Assert.IsNotNull(tokenResult);
        }
    }
}