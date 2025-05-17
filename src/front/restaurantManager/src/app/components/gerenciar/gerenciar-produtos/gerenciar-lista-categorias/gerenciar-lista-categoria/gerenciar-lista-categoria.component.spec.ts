import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarListaCategoriaComponent } from './gerenciar-lista-categoria.component';

describe('GerenciarListaCategoriaComponent', () => {
  let component: GerenciarListaCategoriaComponent;
  let fixture: ComponentFixture<GerenciarListaCategoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GerenciarListaCategoriaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarListaCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
