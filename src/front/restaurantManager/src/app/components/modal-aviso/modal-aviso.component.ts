import { AfterViewInit, Component, ElementRef, Input,  ViewChild } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-modal-aviso',
  imports: [RouterLink],
  templateUrl: './modal-aviso.component.html',
  styleUrl: './modal-aviso.component.css'
})
export class ModalAvisoComponent {
  @Input() mensagem: string = '';
  @ViewChild('botaoModalConfirmar') botaoModal!: ElementRef<HTMLButtonElement>;

  abrirModal(): void {
      this.botaoModal.nativeElement.click();
  }
}
