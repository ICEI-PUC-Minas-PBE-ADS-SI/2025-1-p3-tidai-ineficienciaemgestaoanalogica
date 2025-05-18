import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoCriacaoComponent } from './pedido-criacao.component';

describe('PedidoCriacaoComponent', () => {
  let component: PedidoCriacaoComponent;
  let fixture: ComponentFixture<PedidoCriacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoCriacaoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PedidoCriacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
