import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Mesa } from 'src/app/interfaces/mesa';

@Component({
  selector: 'app-mesas',
  imports: [CommonModule, RouterLink],
  templateUrl: './mesas.component.html',
  styleUrl: './mesas.component.css'
})
export class MesasComponent {
  @Input() mesa!: Mesa;
}
