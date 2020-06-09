import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnunciosComponent } from './anuncios/anuncios.component';
import { VitrineComponent } from './vitrine/vitrine.component';


const routes: Routes = [
  {path: '', redirectTo: 'anuncios', pathMatch: 'full' },
  {path:'anuncios', component: AnunciosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
