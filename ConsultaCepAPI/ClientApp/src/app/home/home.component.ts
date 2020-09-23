import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { setTimeout } from 'timers';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  cep: ceps[] = undefined;
  cepBusca: string = '';
  erro = false;
  sucess = false;
  warning = false;
  invalid = false;
  favoritado = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string
    ){ 
  }

  PesquisarCeps(cepBusca : string) {
    if (cepBusca.length == 8){
      this.http.get<ceps[]>(this.baseUrl + 'api/ConsultaCep/BuscaCep/' + cepBusca).subscribe(result => {
        
        if (result){
          this.cep = result;
        } else{
          this.warning = true;
          setTimeout(() => {  this.warning = false; }, 4000);
        }

      }, error => {
        this.erro = true;
        setTimeout(() => {  this.erro = false; }, 5000);
      });
    } else {
        this.invalid = true;
        setTimeout(() => {  this.invalid = false; }, 5000);
    }
  }

  onClickButton(cep){
    this.http.post(this.baseUrl + 'api/ConsultaCep/', cep).subscribe(result => {
      cep.favorito = true;
      this.cep = undefined;
      this.cepBusca = '';

      this.sucess = true;
      setTimeout(() => {  this.sucess = false; }, 4000);
    }, error => {
      if (error.error == ""){
        this.erro = true;
        setTimeout(() => {  this.erro = false; }, 5000);
      } else {
        this.favoritado = true;
        setTimeout(() => {  this.favoritado = false; }, 5000);
      }

    });
  }
}

interface ceps {
  id: number;
  cep: string;
  logradouro: string;
  complemento: string;
  bairro: string;
  localidade: string;
  uf: string;
  ibge: string;
  gia: string;
  ddd: string;
  siafi: string;
}
