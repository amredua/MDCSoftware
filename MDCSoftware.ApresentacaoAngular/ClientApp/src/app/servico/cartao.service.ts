import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { Cartao } from '../modelo/cartao';

@Injectable({
    providedIn: 'root'
})
export class CartaoService {

    urlAplicacao: string;
    urlApi: string;
    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json; charset=utf-8'
        })
    };

    constructor(private http: HttpClient) {
        this.urlAplicacao = "https://localhost:44300/";//environment.appUrl;
        this.urlApi = 'api/cartao';
    }

    obterTodosCartoes(): Observable<Cartao[]> {
        return this.http.get<Cartao[]>(this.urlAplicacao + this.urlApi)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    obterCartaoPorId(postId: number): Observable<Cartao> {
        return this.http.get<Cartao>(this.urlAplicacao + this.urlApi + postId)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    adicionarCartao(cartao): Observable<Cartao> {
        return this.http.post<Cartao>(this.urlAplicacao + this.urlApi, JSON.stringify(cartao), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    atualizarCartao(idPessoa: number, cartao): Observable<Cartao> {
        return this.http.put<Cartao>(this.urlAplicacao + this.urlApi + idPessoa, JSON.stringify(cartao), this.httpOptions)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    deletarCartao(idPessoa: number): Observable<Cartao> {
        return this.http.delete<Cartao>(this.urlAplicacao + this.urlApi + idPessoa)
            .pipe(
                retry(1),
                catchError(this.errorHandler)
            );
    }

    errorHandler(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Get client-side error
            errorMessage = error.error.message;
        } else {
            // Get server-side error
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}
