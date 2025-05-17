import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciarMesasComponent } from './gerenciar-mesas.component';

describe('GerenciarMesasComponent', () => {
  let component: GerenciarMesasComponent;
  let fixture: ComponentFixture<GerenciarMesasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GerenciarMesasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GerenciarMesasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
