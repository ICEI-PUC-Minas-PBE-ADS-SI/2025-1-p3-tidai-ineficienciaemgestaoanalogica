import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { map, of, switchMap } from 'rxjs';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  return authService.carregarFuncionario().pipe(
    map(funcionario => {
      if(funcionario){
        return true;
      } else {
        router.navigate(['/login']);
        return false;
      }
    })
  )
};
