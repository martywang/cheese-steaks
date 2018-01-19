import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

export class APIInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let apiUrl = "http://localhost:32781/api";

    const apiReq = req.clone({ url: `${apiUrl}/${req.url}` });
    return next.handle(apiReq);
  }
}