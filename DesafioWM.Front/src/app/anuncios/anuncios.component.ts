import { Component, OnInit, ɵSWITCH_COMPILE_INJECTABLE__POST_R3__ } from '@angular/core';
import { Anuncio, AnuncioSubmit, NovoAnuncio } from '../models/Anuncio';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FabricanteModel } from '../models/FabricanteModel';
import { AnunciosService } from './anuncios.service';
import { ModelosModel } from '../models/ModelosModel';
import { VersaoModel } from '../models/VersaoModel';
import { BaseResponse } from '../models/BaseResponse';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-anuncios',
  templateUrl: './anuncios.component.html',
  styleUrls: ['./anuncios.component.css']
})
export class AnunciosComponent implements OnInit {
  
  public anuncioForm: FormGroup;
  public titulo = 'Anúncios';
  public anuncioSelecionado: Anuncio;
  
  public fabricanteSelecionado: FabricanteModel;
  public fabricantes: FabricanteModel[];
  public modelos: ModelosModel[];
  public versoes: VersaoModel[];
  public anuncios: Anuncio[];
  
  constructor(private fb: FormBuilder,
    private anuncioService: AnunciosService) { 
      this.criarAnuncioForm()
    }
    
    ngOnInit(): void {
      this.carregarFabricantes();
      this.carregarAnuncios();
    }
    
    buscarModelo(fabricante : any){
      this.anuncioService.getModelsByManufacturerId(fabricante.ID).subscribe(
        (modelos: ModelosModel[]) => {
          this.modelos = modelos;
        },
        (erro:any) => {
          console.error(erro);
        }
        )
      }
      
      buscarVersao(modelo : any){
        this.anuncioService.getVersionByModelId(modelo.ID).subscribe(
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
          
          carregarAnuncios(){
            this.anuncioService.getAll().subscribe(
              (anuncios: BaseResponse<Anuncio[]>) => {
                this.anuncios = anuncios.data;
                debugger;
              },
              (erro : any) => {
                console.error(erro);
              }
              )
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
              let novoAnuncio = new AnuncioSubmit(this.anuncioForm.value);
              debugger;
              if(novoAnuncio.id){
                this.anuncioService.put(novoAnuncio).subscribe(
                  (response : BaseResponse<boolean>) => {
                    Swal.fire('Atualizado com sucesso');
                    this.voltar();
                  },
                  (erro : any) : void => {
                    Swal.fire("ops, identificamos um erro, por favor tente novamente mais tarde");
                  });
                }else{
                  novoAnuncio.id = 0;
                  this.anuncioService.post(novoAnuncio).subscribe(
                    (response : BaseResponse<boolean>) => {
                      Swal.fire('Inserido com sucesso');
                      this.voltar();
                    },
                    (erro : any) : void => {
                      Swal.fire("ops, identificamos um erro, por favor tente novamente mais tarde");
                    }
                    );
                  } 
                } 
                
                RemoverAnuncio(id: number){
                  this.anuncioService.delete(id).subscribe(
                    (result : BaseResponse<Boolean>) => {
                      Swal.fire('Removido com sucesso');
                      this.voltar();
                    },
                    (erro:any) : void => {
                      Swal.fire("ops, identificamos um erro, por favor tente novamente mais tarde");
                    });
                  };
                  
                  anuncioSelect(anuncio: Anuncio){
                    this.anuncioSelecionado = anuncio;
                    this.anuncioForm.patchValue(anuncio)
                  }
                  
                  voltar(){
                    this.anuncioSelecionado = null;
                    this.carregarAnuncios();
                  }
                  
                  adicionarAnuncio(){
                    this.anuncioSelecionado = new NovoAnuncio();
                    this.anuncioForm.reset(this.anuncioSelecionado);
                    debugger;
                }
}