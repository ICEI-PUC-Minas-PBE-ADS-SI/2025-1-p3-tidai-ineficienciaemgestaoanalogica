import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DateAdapter, MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-periodo',
  imports: [
    CommonModule,
    FormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule
  ],
  providers: [{provide: MAT_DATE_LOCALE, useValue: 'pt-BR'}],
  templateUrl: './periodo.component.html',
  styleUrl: './periodo.component.css'
})
export class PeriodoComponent {

  dataSelecionadaInicio: Date = new Date();
  dataSelecionadaFim: Date = new Date();

  constructor(private route: ActivatedRoute ,private router: Router, private adapter: DateAdapter<Date>) {
    this.adapter.setLocale('pt-BR');
    const hoje = new Date();
    this.dataSelecionadaInicio = new Date(
      hoje.getFullYear(),
      hoje.getMonth(),
      hoje.getDate()
    );
    this.dataSelecionadaFim = new Date(
      hoje.getFullYear(),
      hoje.getMonth(),
      hoje.getDate()
    )
  }
  enviar(){
    this.router.navigate([`${this.dataSelecionadaInicio.toISOString().split('T')[0]}/${this.dataSelecionadaFim.toISOString().split('T')[0]}`], { relativeTo: this.route })
  }
}
