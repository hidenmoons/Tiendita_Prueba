import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaProductsComponent } from './lista-products.component';

describe('ListaProductsComponent', () => {
  let component: ListaProductsComponent;
  let fixture: ComponentFixture<ListaProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaProductsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
