import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CartoesComponent } from './cartoes/cartoes.component';
import { CartaoComponent } from './cartao/cartao.component';
import { CartaoAdicionarAtualizarComponent } from './cartao-adicionar-atualizar/cartao-adicionar-atualizar.component';


const routes: Routes = [
    { path: '', component: CartoesComponent, pathMatch: 'full' },
    { path: 'cartao/:id', component: CartaoComponent },
    { path: 'adicionar', component: CartaoAdicionarAtualizarComponent },
    { path: 'cartao/atualizar/:id', component: CartaoAdicionarAtualizarComponent },
    { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
