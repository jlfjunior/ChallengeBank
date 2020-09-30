# ChallengeBank

Este projeto é destinado a simulação de recursos de bank similar a uma conta digital.

## Estrutura dos projetos
- BankAccount.Api -
- BankAccount.Domain -
- BankAccount.Service - 
- BankAccount.Infra -
- BankAccount.Test -

## Entidades 
 - Customer - Essa entidade pode ter uma lista de contas.
 - BankAccount - Essa entidade é reponsavel por armazenar o saldo atual da conta. Um bankAccount tem uma lista de Transactions que é o seu extrato
 - Transaction - Responsavel por armazenar o extrato de conta
 - DailyBalance - Entidade responsavel por armazenaro saldo diariamente de cada conta que tem direito a ser remonerado naquele dia.

## Rotas
 - Criar um cliente - [POST] - 'api/customers'
 - Listar todos os cliente - [GET] - 'api/customers'
 - Criar uma conta - [POST] - 'api/bank-accounts'
 - Depositar recursos - [POST] - 'api/bank-accounts/deposit'
 - Sacar recursos - [POST] - 'api/bank-accounts/withdraw'
 - Pagar uma conta - [POST] - 'api/bank-accounts/pay'
 - Listar o extrato de uma conta - [GET] - 'api/bank-accounts/statements/**ID**'
 - Remunerar contas diariamente - [POST] - 'api/bank-accounts/remunerate
 - Listar todas as contas - [GET] - 'api/bank-accounts/

## Frmeworks ou bibliotecas utilizadas
 - Microsoft.AspNetCore.Mvc.NewtonsoftJson
 - Microsoft.EntityFrameworkCore.InMemory
 - Pomelo.EntityFrameworkCore.MySql
 - Microsoft.EntityFrameworkCore
 - Microsoft.AspNet.WebApi.Client
 - Microsoft.AspNetCore.Mvc.Testing
  
 ## Parametros de remuneração das contas
 - 100% SELIC diariamente a uma taxa meta de 4.49% ao ano.

 ## Observações
  - Neste contexto foi utilizado o ciclo perfeito, sem implementação de exções ou validações.