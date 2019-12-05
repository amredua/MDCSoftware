import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CartoesComponent } from './cartoes/cartoes.component';
import { CartaoComponent } from './cartao/cartao.component';
import { CartaoAdicionarAtualizarComponent } from './cartao-adicionar-atualizar/cartao-adicionar-atualizar.component';
import { CartaoService } from './Servicos/cartao.service';

@NgModule({
    declarations: [
        AppComponent,
        CartoesComponent,
        CartaoComponent,
        CartaoAdicionarAtualizarComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        ReactiveFormsModule
    ],
    providers: [
        CartaoService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
