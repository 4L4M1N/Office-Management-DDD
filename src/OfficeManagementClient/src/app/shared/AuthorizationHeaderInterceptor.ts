import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OpenIdConnectService } from './open-id-connect.service';

@Injectable()
export class AuthorizationHeaderInterceptor implements HttpInterceptor{
    /**
     *
     */
    constructor(private openIdConnectService: OpenIdConnectService) {
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        request = request.clone(
            {
                setHeaders: { Authorization: this.openIdConnectService.user.token_type + " " + this.openIdConnectService.user.access_token}
            }
        );
        return next.handle(request);
    }
}
