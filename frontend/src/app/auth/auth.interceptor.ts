import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const token = authService.getToken();

   let headers: any = {
    TenantId: 'Valmarq'
  };

  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }


  const cloned = req.clone({
    setHeaders: headers
  });

  return next(cloned);
};
