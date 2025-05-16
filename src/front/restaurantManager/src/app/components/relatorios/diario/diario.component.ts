import { CommonModule } from '@angular/common';
import { Component, OnChanges, SimpleChange, SimpleChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DateAdapter, MAT_DATE_LOCALE, MatNativeDateModule } from '@angular/material/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { LOCALE_ID } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';

@Component({
  selector: 'app-diario',
  imports: [
    CommonModule,
    FormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'pt' },{provide: MAT_DATE_LOCALE, useValue: 'pt-BR'}],
  templateUrl: './diario.component.html',
  styleUrl: './diario.component.css'
})
export class DiarioComponent {

  dataSelecionada: Date = new Date();

  constructor(private route: ActivatedRoute ,private router: Router, private adapter: DateAdapter<Date>) {
    this.adapter.setLocale('pt-BR');
    const hoje = new Date();
    this.dataSelecionada = new Date(
      hoje.getFullYear(),
      hoje.getMonth(),
      hoje.getDate()
    );
  }

  enviar(){
    this.router.navigate([`${this.dataSelecionada.toISOString().split('T')[0]}`], { relativeTo: this.route })
  }
}
