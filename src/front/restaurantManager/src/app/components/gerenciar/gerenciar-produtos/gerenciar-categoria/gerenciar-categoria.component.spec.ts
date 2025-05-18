import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarCategoriaComponent } from './gerenciar-categoria.component';

describe('GerenciarCategoriaComponent', () => {
  let component: GerenciarCategoriaComponent;
  let fixture: ComponentFixture<GerenciarCategoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GerenciarCategoriaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
