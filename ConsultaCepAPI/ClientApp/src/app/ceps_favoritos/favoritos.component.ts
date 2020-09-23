import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './favoritos.component.html'
})
export class FavoritosComponent {
  ceps: cep[] = [];
  sucess = false;
  erro = false;

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string) 
  {
    this.ObterCeps();
  }
  
  ObterCeps(){
    this.http.get<cep[]>(this.baseUrl + 'api/ConsultaCep/CepsSalvos').subscribe(result => {
      this.ceps = result;
    }, 
    error => {
      this.erro = true;
      setTimeout(() => {  this.erro = false; }, 5000);
    });}

  onClickButton(id){
    this.http.delete(this.baseUrl + 'api/ConsultaCep/' + id).subscribe(result => {
      this.sucess = true;
      this.ObterCeps();
      setTimeout(() => {  this.sucess = false; }, 4000);
    }, error => {
      this.erro = true;
      setTimeout(() => {  this.erro = false; }, 5000);
    });}  
}
interface cep {
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