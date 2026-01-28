import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingService } from './loading.service';
import { finalize } from 'rxjs/operators';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);

  const excludedUrls = [
    '/login',
    '/Auth/Login',
    '/api/Auth/Login'
  ];

  if (excludedUrls.some(url => req.url.includes(url))) {
    return next(req);
  }
  loadingService.show();

  return next(req).pipe(
    finalize(() => loadingService.hide())
  );
};
