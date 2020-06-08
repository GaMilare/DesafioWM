import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AnunciosComponent } from './anuncios/anuncios.component';
import { VitrineComponent } from './vitrine/vitrine.component';


const routes: Routes = [
  {path: '', redirectTo: 'vitrine', pathMatch: 'full' },
  {path:'anuncios', component: AnunciosComponent },
  {path:'vitrine', component: VitrineComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
