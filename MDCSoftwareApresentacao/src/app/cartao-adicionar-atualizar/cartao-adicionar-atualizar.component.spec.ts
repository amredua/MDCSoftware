import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartaoAdicionarAtualizarComponent } from './cartao-adicionar-atualizar.component';

describe('CartaoAdicionarAtualizarComponent', () => {
  let component: CartaoAdicionarAtualizarComponent;
  let fixture: ComponentFixture<CartaoAdicionarAtualizarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartaoAdicionarAtualizarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartaoAdicionarAtualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
