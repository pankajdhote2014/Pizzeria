import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NonPizzaComponent } from './non-pizza.component';

describe('NonPizzaComponent', () => {
  let component: NonPizzaComponent;
  let fixture: ComponentFixture<NonPizzaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NonPizzaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NonPizzaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
