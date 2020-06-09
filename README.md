# DesafioWM

Projeto desenvolvido para atender o [desafio backend](http://desafioonline.webmotors.com.br/) proposto: Criar um crud de anúncios, integrando com as camadas propostas no pdf do desafio.

## Recursos utilizados
* .net core 3.1.100
* node v12.18.0
* Angular CLI: 9.1.7
* SQL Server


## Primeiros passos

Clone o projeto e inicie a API através da solution

```
DesafioWM.API.sln
``` 

Inicie o front-end no diretorio "~/DesafioWM/DesafioWM.Front/" utilizando os seguintes comandos dentro de um terminal, para instalar as dependências e então rodar o projeto.

```
npm install
``` 
```
ng serve
``` 

Ao rodar o projeto da API, sua tela inicial será a interface do swagger contendo os seguintes métodos:

Authentication
* GET - /api/Authentication/GetUsers
* POST - /api/Authentication/login

Anuncio
* GET - /api/Anuncios/GetAll
* GET - /api/Anuncios/GetById
* POST - /api/Anuncios
* PUT - /api/Anuncios
* DELETE - /api/Anuncios
* GET - /api/Anuncios/GetAllWithToken 

A API possui a autenticação JWT implementada, porem para facilitar os testes manuais, apenas o método /api/Anuncios/GetAllWithToken manteve 
a autenticação. Para que se possa validar a funcionalidade da autenticação implementada e para executar a chamada da API de Anuncio,
será preciso realizar a autenticação para obter o Bearer Token.

Para obter a lista de usuários disponiveis para realizar o Login, realize uma chamada GET para o endpoint /api/Authentication/GetUsers.
Com o UserName e o UserPsw obtidos, realize o Post de Login (/api/Authentication/login) para receber o token de autenticação.
Exemplo de retorno de User

```
{
  "success": true,
  "data": [
    {
      "id": 1,
      "userName": "WebMotors",
      "userPsw": "123456"
    }
  ]
}

``` 
Após obter o Token, autentique seu swagger no cadeado de Authorize inserindo o Value sendo Bearer mais o valor do token obtido, como o de examplo: 'Bearer 12345abcdef'

Agora que autenticado, a API permite executar o Get de todos os anúncios no método com autenticação obrigatoria (/api/Anuncios/GetAllWithToken).

Para interagir com o portal que consome a API, acesse http://localhost:4200/ após seguir as instruções iniciais.

Dentro do portal será possivel Listar, Adicionar, Atualizar e Remover anúncios de carros utilizando as APIs auxiliares
disponibilizadas para consulta no desafio e também acessar o SWAGGER das APIs pela opção localizada no canto superior direito.

## Exemplo de interação com portal (printscreen)

![desafioWM](https://user-images.githubusercontent.com/10716159/84118186-0267b500-aa09-11ea-8454-70daec083eef.PNG)

## Contato

* Gabriel Milaré - gmilare@outlook.com
