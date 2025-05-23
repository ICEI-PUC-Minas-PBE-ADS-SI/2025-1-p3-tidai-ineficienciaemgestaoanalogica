import { TestBed } from '@angular/core/testing';

import { PedidoSocketService } from './pedido-socket.service';

describe('PedidoSocketService', () => {
  let service: PedidoSocketService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PedidoSocketService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
