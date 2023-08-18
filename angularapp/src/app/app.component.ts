import { HttpClient} from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public books?: Books[];
  loginEmail = "";
  loginPswd = "";
  title: string = "";
  priceFrom: string = "";
  priceTo: string = "";
  public booksToBuy: Array<Books> = [];
  index = 1;
  sumOfAllBooksForOrder: string = "";
  bookToAddEdit: Books = { id: 0, title: '', description: '', summaryDescription: '', isbn: '', bookImage: '', author: '', year: 0, price: 0, numberOfPages: 0, quantity: 0, numberOfPurchases: 0 };
  token: string = "";
  isAdmin = false;

  constructor(private http: HttpClient) {
    
    http.get<Books[]>('/books/get').subscribe(result => {
      this.books = result;
    }, error => console.error(error));
  }

  buyBook(event: Event, book: Books) {
    if (confirm('Are you sure you want to buy book ' + book.title + '?')) {
      this.booksToBuy.push(book);
     
    }
  }

  login(email: string, password: string) {

   
    this.http.post('/identity/token', { userId: password, email: email }).subscribe((value: any) => {
      this.isAdmin = value.isAdmin == true;
      this.token = value.token;
      this.index = 1;
      this.refresh()
    });
  }
  @ViewChild('coverPhoto') coverPhoto!: ElementRef;
  save(event: any) {
    event.preventDefault();
    event.stopPropagation();
    if (!this.bookToAddEdit.hasOwnProperty('id')) {
      this.bookToAddEdit.id = 0;
    }
    if (!this.bookToAddEdit.hasOwnProperty('idbookImage')) {
      this.bookToAddEdit.bookImage = 'default';
    }
    const headers = { 'Authorization': 'Bearer '+ this.token }

    this.http.post<any>('/books/save', this.bookToAddEdit, { headers }).subscribe((value: any) => {
      this.index = 1;
      this.refresh()
    },
      error => { debugger; console.log("oops", error) });
  }
  editBook(event: Event, book: Books) {
    this.index = 3;
    this.bookToAddEdit = book;
  }
  openNewBook() {
    let x = {} as Books;
    this.bookToAddEdit = x;
    this.index = 3;
  }
  deleteBook(event: Event, book: Books) {
    if (confirm('Are you sure you want to delete book ' + book.title + '?')) {
      const headers = { 'Authorization': 'Bearer ' + this.token }
      this.http.delete<any>('/books/delete?id=' + book.id, { headers }).subscribe((value: any) => {
        this.refresh()
      });
    }
  }
  navigateToCheckout(books: Array<Books>) {
    if (books.length > 0) {
      this.index = 2;
      var x = 0;
      for (let i = 0; i < this.booksToBuy.length; i++) {
        x = x + this.booksToBuy[i].price;
      }
      this.sumOfAllBooksForOrder = x.toFixed(2);
    }
  }
  navigateBackToBooks() {
    this.index = 1;
}
  navigateToLogin() {
    this.index = 0;
  }
  refresh() {
    if (this.title == null ) {
      this.title = ''
    }
    if (this.priceFrom == null) {
      this.priceFrom = ''
    }
    if (this.priceTo == null) {
      this.priceTo = ''
    }
    setTimeout(() => {
      this.http.get<Books[]>('/books/get?name=' + this.title + '&priceFrom=' + this.priceFrom + '&priceTo=' + this.priceTo).subscribe(result => {
        this.books = result;
      }, error => console.error(error));
    }, 1000);

   
  }
}

class Books {
  id: number=0;
  title: string;
  description: string;
  summaryDescription: string;
  isbn: string;
  bookImage: string;
  author: string;
  year: number;
  price: number;
  numberOfPages: number;
  quantity: number;
  numberOfPurchases: number;

}
class TokenResponse {
  isAdmin: boolean;
  token: string;
}
