import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { HttpOperationService } from '../Shared/HttpOperation.service';
import { Pizzatype } from '../Shared/model/pizzatype';
import { Pizza } from '../Shared/model/Pizza';
import { Order } from '../Shared/model/Order';
import { Router } from '@angular/router';
import { Ingredients } from '../Shared/model/ingredients';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { parse } from 'querystring';


@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.css']
})
export class PizzaComponent implements OnInit {

  ingredients: Ingredients[] = [];
  pizza: Pizza;
  order: Order;
  type: Pizzatype[] = [];
  displayedColumns: string[] = ['select', 'id', 'name', 'price', 'image'];
  dataSource?: MatTableDataSource<Ingredients>;
  selection = new SelectionModel<Ingredients>(true, []);
  total: number = 0;

  constructor(
    public router: Router,
    public crudService: HttpOperationService
  ) {
    this.pizza = new Pizza({
    });
    this.order = new Order({
    });
  }

  ngOnInit() {
    this.crudService.getAll().subscribe((data) => this.dataSource = new MatTableDataSource(data));

    this.crudService.getAllPizzaType().subscribe((data) => {
      this.type = data;
    });
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected($event) {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }
  masterToggle($event) {
    if ($event.checked) {
      this.onCompleteRow(this.dataSource);
    }
    this.isAllSelected($event) ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));

    if ($event.checked) {
      this.total = 0;
      this.dataSource.data.forEach(row => this.total = this.total + row.price);
    } else if (!$event.checked) {
      this.total = 0;
    }
  }

  selectRow($event, dataSource) {
    if ($event.checked) {
      console.log(dataSource.name);
      this.total = this.total + dataSource.price;

    } else if (!$event.checked) {
      this.total = this.total - dataSource.price;

    }
  }

  onCompleteRow(dataSource) {
    dataSource.data.forEach(element => {
      console.log(element.name);
    });
  }
  onSubmit(formData) {
    //forms value  
    debugger;
    console.log(formData.value['pizzaType']);
    console.log(this.selection);
    let arrayIngredients = [];
    this.selection.selected.forEach(element => {
      console.log(element.name);
      arrayIngredients.push(element.name);
    });
    let ingredients = arrayIngredients.join();

    this.pizza.Ingredients = ingredients;
    let typeId = formData.value['pizzaType'];
    this.pizza.pizzaTypeId = typeId;
    this.pizza.totalCost = this.total;

    this.crudService.create(this.pizza).subscribe((data) => {
      debugger;
      console.log("stored pizza");
      console.log(data);
      this.order.pizzaId = data;
      this.order.orderStatus = "Order Confirmed";

      this.crudService.createOrder(this.order).subscribe((orderData) => {
        console.log("order confirmed");
        alert("Order Confirmed");
        this.router.navigateByUrl('/Homepage');
      });
    });

  }

}

