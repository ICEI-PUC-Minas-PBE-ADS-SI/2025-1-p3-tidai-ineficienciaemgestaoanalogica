import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelatorioPeriodoComponent } from './relatorio-periodo.component';

describe('RelatorioPeriodoComponent', () => {
  let component: RelatorioPeriodoComponent;
  let fixture: ComponentFixture<RelatorioPeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RelatorioPeriodoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RelatorioPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
