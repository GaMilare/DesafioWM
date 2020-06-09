export class BaseResponse<T>{
    data: T;
    success: boolean;
    erros: string[];
    mensagens?: string[];
    
    constructor(){
        this.erros = [];
        this.mensagens = [];
    }
}