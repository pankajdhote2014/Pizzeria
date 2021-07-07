import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Pizza } from './model/pizza';
import { Order } from './model/order';
import { Pizzatype } from './model/pizzatype';
import { Ingredients } from './model/ingredients';

@Injectable({
  providedIn: 'root'
})
export class HttpOperationService {

  private apiServer = "https://localhost:44314/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private httpClient: HttpClient) { }

  create(pizza): Observable<number> {
    return this.httpClient.post<number>(this.apiServer + '/Pizza/', JSON.stringify(pizza), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }

  createOrder(order): Observable<Order> {
    return this.httpClient.post<Order>(this.apiServer + '/Order/', JSON.stringify(order), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }

  getAll(): Observable<Ingredients[]> {
    return this.httpClient.get<Ingredients[]>(this.apiServer + '/Ingredient/')
      .pipe(
        catchError(this.errorHandler)
      )
  }

  getAllPizzaType(): Observable<Pizzatype[]> {
    return this.httpClient.get<Pizzatype[]>(this.apiServer + '/Pizzatype/')
      .pipe(
        catchError(this.errorHandler)
      )
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
