import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const token = authService.getToken();

   let headers: any = {
    TenantId: 'Valmarq',
    'X-API-KEY': '93c0f156-0173-449f-a290-d17a458918a6'
  };

  if (token) {
    headers.Authorization = `Bearer ${token}`;
  }


  const cloned = req.clone({
    setHeaders: headers
  });

  return next(cloned);
};
