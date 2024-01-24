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
  
  title = 'Products-APP';
  httpClient = inject(HttpClient);
  products:any = [];
  fetchProducts(): void{
    this.httpClient.get('https://localhost:7199/api/Products').subscribe((data:any)=>{
      this.products = data;
      console.log(this.products);
    });
  }

  ngOnInit(): void {
    this.fetchProducts();
  }
}
