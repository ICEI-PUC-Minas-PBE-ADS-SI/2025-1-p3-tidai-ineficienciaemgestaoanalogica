import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PeriodoComponent } from './periodo.component';

describe('PeriodoComponent', () => {
  let component: PeriodoComponent;
  let fixture: ComponentFixture<PeriodoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PeriodoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
