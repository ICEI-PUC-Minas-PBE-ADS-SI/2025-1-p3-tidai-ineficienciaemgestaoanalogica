import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarListaCategoriasComponent } from './gerenciar-lista-categorias.component';

describe('GerenciarListaCategoriasComponent', () => {
  let component: GerenciarListaCategoriasComponent;
  let fixture: ComponentFixture<GerenciarListaCategoriasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GerenciarListaCategoriasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarListaCategoriasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
