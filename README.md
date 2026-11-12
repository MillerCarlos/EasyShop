# EasyShop - Persistência Poliglota (SQL + NoSQL)

## Integrantes
- Miller de Oliveira Carlos
- Vinícius Lemes Cazelato
- 
- 

## Sobre o projeto
Mini e-commerce em .NET MAUI que usa dois bancos de dados locais ao mesmo tempo:
- **Produtos (NoSQL, LiteDB):** documentos com atributos dinâmicos, sem schema fixo.
- **Clientes (SQL, SQLite):** tabela relacional com validação dos dados.

## Arquitetura em camadas
- **Views / ViewModels (Apresentação):** telas e interação com o usuário.
- **Services (Negócio):** validações e regras (ex.: preço válido, e-mail válido).
- **Data (Acesso a dados):** repositórios que fazem o CRUD no SQLite e no LiteDB.
- **Models:** classes `Customer` e `Product`.

## Tecnologias
- .NET MAUI
- sqlite-net-pcl + SQLitePCLRaw.bundle_green
- LiteDB

## Como executar
1. Instale o Visual Studio com a carga de trabalho **.NET Multi-platform App UI development**.
2. Clone o repositório e abra o arquivo `EasyShop.sln`.
3. Selecione um emulador Android (ex.: Pixel 5 - API 34).
4. Clique em ▶ para executar.

## Como usar
- Aba **Produtos:** informe nome, preço e atributos no formato `chave=valor; chave=valor` (ex.: `cor=Azul; tamanho=M`).
- Aba **Clientes:** informe nome completo e e-mail.

## Vídeo de demonstração
(cole aqui o link do vídeo)
