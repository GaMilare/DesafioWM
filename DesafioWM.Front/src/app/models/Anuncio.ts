export class Anuncio{
    "id": number;
    "marca": string;
    "modelo": string;
    "versao": string;
    "ano": number;
    "quilometragem": number;
    "observacao": string;
}

export class AnuncioSubmit{
    "id": number;
    "marca": string;
    "modelo": string;
    "versao": string;
    "ano": number;
    "quilometragem": number;
    "observacao": string;
    
    constructor(submit: any) {
        this.marca = submit.marca.Name ?? submit.marca;
        this.modelo = submit.modelo.Name ?? submit.modelo;
        this.versao = submit.versao.Name ?? submit.versao;
        this.ano = submit.ano;
        this.observacao = submit.observacao;
        this.quilometragem = submit.quilometragem;
        this.id = submit.id;
    }
}

export class NovoAnuncio{
    "id": number;
    "marca": string;
    "modelo": string;
    "versao": string;
    "ano": number;
    "quilometragem": number;
    "observacao": string;

    constructor(){
        this.marca = "";
        this.modelo = "";
        this.versao = "";
        this.ano = 0;
        this.observacao = "";
        this.quilometragem = 0;
        this.id = 0;
    }
}