import { Component, OnInit } from '@angular/core';
import { MatCarousel, MatCarouselComponent } from '@ngmodule/material-carousel';


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  slides = [
    { 'image': 'assets/Margherita.jpg' },
    { 'image': 'assets/Pizza.jpg' },
    { 'image': 'assets/GreatPizza.jpg' }
  ];

  ngOnInit() {
  }

}
