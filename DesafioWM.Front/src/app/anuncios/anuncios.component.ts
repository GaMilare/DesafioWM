import { Component, OnInit } from '@angular/core';
import { Anuncio } from '../models/Anuncio';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FabricanteModel } from '../models/FabricanteModel';
import { AnunciosService } from './anuncios.service';
import { ModelosModel } from '../models/ModelosModel';
import { VersaoModel } from '../models/VersaoModel';

@Component({
  selector: 'app-anuncios',
  templateUrl: './anuncios.component.html',
  styleUrls: ['./anuncios.component.css']
})
export class AnunciosComponent implements OnInit {
  
  public anuncioForm: FormGroup;
  public titulo = 'Anuncios';
  public anuncioSelecionado: Anuncio;
  
  public fabricanteSelecionado: FabricanteModel;
  public fabricantes: FabricanteModel[];
  public modelos: ModelosModel[];
  public versoes: VersaoModel[];
  
  
  public carros = [
    {"id": 1,
    "marca": "C3"	,
    "modelo": "1.3 Preto"	,
    "versao": "ctr"	,
    "ano": "2014"	,
    "quilometragem": "100",
    "observacao":"Documentação paga."},
    {"id": 2,
    "marca": "C4"	,
    "modelo": "1.4 Preto"	,
    "versao": "ctr4"	,
    "ano": "2016"	,
    "quilometragem": "140",
    "observacao":"Documentação paga."},
    
  ];
  
  constructor(private fb: FormBuilder,
    private anuncioService: AnunciosService) { 
      this.criarAnuncioForm()
    }
    
    ngOnInit(): void {
      this.carregarFabricantes();
    }
    
      buscarModelo(fabricanteId : number){
      console.log(fabricanteId);
      this.anuncioService.getModelsByManufacturerId(fabricanteId).subscribe(
        (modelos: ModelosModel[]) => {
          this.modelos = modelos;
        },
        (erro:any) => {
          console.error(erro);
        }
        )
      }

      buscarVersao(modeloId: number){
        this.anuncioService.getVersionByModelId(modeloId).subscribe(
          (versao: VersaoModel[]) => {
            this.versoes = versao;
          },
          (erro: any) => {
            console.error(erro);
          }
        )

      }
      
      carregarFabricantes(){
        this.anuncioService.getManufacturer().subscribe(
          (fabricantes: FabricanteModel[]) => {
            this.fabricantes = fabricantes;
          },
          (erro: any) => {
            console.error(erro);
          }
          );
        }
        
        criarAnuncioForm(){
          this.anuncioForm = this.fb.group({
            id: [''],
            marca:['', Validators.required],
            modelo:['',Validators.required],
            versao:['',Validators.required],
            ano:['',Validators.required],
            quilometragem:['',Validators.required],
            observacao:['',Validators.required]
          });
        }
        
        submitAnuncio(){
          console.log(this.anuncioForm.value)
        }
        
        anuncioSelect(anuncio: Anuncio){
          this.anuncioSelecionado = anuncio;
          this.anuncioForm.patchValue(anuncio)
        }
        
        voltar(){
          this.anuncioSelecionado = null;
        }
        
        adicionarAnuncio(){
          
        }
        
      }
      