import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { HttpOperationService } from '../Shared/HttpOperation.service';
import { Pizzatype } from '../Shared/model/pizzatype';
import { Pizza } from '../Shared/model/Pizza';
import { Router } from '@angular/router';
import { Ingredients } from '../Shared/model/ingredients';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { parse } from 'querystring';

@Component({
  selector: 'app-non-pizza',
  templateUrl: './non-pizza.component.html',
  styleUrls: ['./non-pizza.component.css']
})
export class NonPizzaComponent implements OnInit {

  ingredients: Ingredients[] = [];
  formData: Pizza;
  type: Pizzatype[] = [];
  displayedColumns: string[] = ['select', 'id', 'name', 'price', 'image'];
  dataSource?: MatTableDataSource<Ingredients>;
  selection = new SelectionModel<Ingredients>(true, []);
  total: number = 0;

  constructor(
    private router: Router,
    public crudService: HttpOperationService
  ) { }

  ngOnInit() {
    this.crudService.getAll().subscribe((data) => this.dataSource = new MatTableDataSource(data));

    this.crudService.getAllPizzaType().subscribe((data) => {
      this.type = data;
    });
  }

}
