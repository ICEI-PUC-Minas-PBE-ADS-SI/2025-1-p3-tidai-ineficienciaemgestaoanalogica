import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FazerPedidosComponent } from './fazer-pedidos.component';

describe('FazerPedidosComponent', () => {
  let component: FazerPedidosComponent;
  let fixture: ComponentFixture<FazerPedidosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FazerPedidosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FazerPedidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
