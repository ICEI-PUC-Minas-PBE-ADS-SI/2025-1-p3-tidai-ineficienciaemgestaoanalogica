import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { map, of, switchMap } from 'rxjs';

export const roleGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const expectedRoles = route.data['roles'] as string[];

  return authService.carregarFuncionario().pipe(
    map(funcionario => {
      if(funcionario && expectedRoles.includes(funcionario.tipo)){
        return true;
      } else {
        router.navigate(['/nao-autorizado']);
        return false;
      }
    })
  )
};
