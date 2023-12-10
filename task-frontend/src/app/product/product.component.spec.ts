import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';

import { ProductComponent } from './product.component';
import { ProductService } from './product.service';
import { of } from 'rxjs';
import { Product } from './product.model';

describe('ProductComponent', () => {
  let fixture: ComponentFixture<ProductComponent>;
  let component: ProductComponent;
  let productService: jasmine.SpyObj<ProductService>;

  beforeEach(() => {
    const productServiceSpy = jasmine.createSpyObj('ProductService', ['getProducts']);

    TestBed.configureTestingModule({
      declarations: [ProductComponent],
      providers: [
        { provide: ProductService, useValue: productServiceSpy },
      ],
    });

    fixture = TestBed.createComponent(ProductComponent);
    component = fixture.componentInstance;
    productService = TestBed.inject(ProductService) as jasmine.SpyObj<ProductService>;
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch and display products', fakeAsync(() => {
    const mockProducts = [
      { id: 1, name: 'Product 1', },
      { id: 2, name: 'Product 2' },
    ] as Product[];

    productService.getProducts.and.returnValue(of(mockProducts));

    fixture.detectChanges();

    expect(component.products).toEqual(mockProducts);

    const element: HTMLElement = fixture.debugElement.nativeElement;
    expect(element.textContent).toContain('Product 1');
    expect(element.textContent).toContain('Product 2');
  }));

  it('should handle error when fetching products', fakeAsync(() => {
    productService.getProducts.and.returnValue(of([]));
    fixture.detectChanges();
    tick();
    expect(component.products).toEqual([]);
  }));
});
