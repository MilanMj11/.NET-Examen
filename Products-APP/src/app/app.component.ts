import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  
  title = 'Examen NET';
  httpClient = inject(HttpClient);
  produse:any = [];
  comenzi:any = [];
  utilizatori:any = [];

  fetchComenzi(): void{
    this.httpClient.get('https://localhost:7199/api/Comenzi').subscribe((data:any)=>{
      this.comenzi = data;
      console.log(this.comenzi);
    });
  }

  fetchUtilizatori(): void{
    this.httpClient.get('https://localhost:7199/api/Utilizatori').subscribe((data:any)=>{
      this.utilizatori = data;
      console.log(this.utilizatori);
    });
  }

  fetchProduse(): void{
    this.httpClient.get('https://localhost:7199/api/Produse').subscribe((data:any)=>{
      this.produse = data;
      console.log(this.produse);
    });
  }

  ngOnInit(): void {
    this.fetchProduse();
    this.fetchComenzi();
    this.fetchUtilizatori();
  }
}
