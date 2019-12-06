import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CartaoService } from '../servico/cartao.service';
import { Cartao } from '../modelo/cartao';

@Component({
  selector: 'app-cartoes',
  templateUrl: './cartoes.component.html',
  styleUrls: ['./cartoes.component.scss']
})
export class CartoesComponent implements OnInit {

    cartoes$: Observable<Cartao[]>;

    constructor(private cartaoServico: CartaoService) {
    }

    ngOnInit() {
        this.carregarCartoes();
  }

    carregarCartoes() {
        this.cartoes$ = this.cartaoServico.obterTodosCartoes();
    }

    deletar(pessoaId) {
        const ans = confirm('Deseja excluir a postagem do blog com o ID: ' + pessoaId);
        if (ans) {
            this.cartaoServico.deletarCartao(pessoaId).subscribe((data) => {
                this.carregarCartoes();
            });
        }
    }

}
