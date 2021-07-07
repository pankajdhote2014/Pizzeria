import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';
import { PizzaComponent } from './pizza/pizza.component';
import { NonPizzaComponent } from './non-pizza/non-pizza.component';

const routes: Routes = [
  { path: 'Homepage', component: HomepageComponent },
  { path: '', redirectTo: '/Homepage', pathMatch: 'full' },
  { path: 'Pizza', component: PizzaComponent },
  { path: 'NonPizza', component: NonPizzaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
