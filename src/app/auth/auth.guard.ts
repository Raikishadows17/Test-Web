import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = () => {
  const token = localStorage.getItem('token');
  const exp = localStorage.getItem('tokenExpiration');
  const router = inject(Router);

  if (!token) return router.createUrlTree(['/login']);

  if (exp) {
    const expiration = new Date(exp);
    if (expiration < new Date()) {
      localStorage.clear();
      return router.parseUrl('/login');
    }
  }

  return true;
};

