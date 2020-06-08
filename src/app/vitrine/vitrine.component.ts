import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vitrine',
  templateUrl: './vitrine.component.html',
  styleUrls: ['./vitrine.component.css']
})
export class VitrineComponent implements OnInit {

  public titulo = "Visualização de anuncios"
  constructor() { }

  ngOnInit(): void {
  }

}
