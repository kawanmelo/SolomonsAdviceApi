# SolomonsAdvice API

Este é um projeto da API SolomonsAdvice, oferecendo endpoints para acessar, criar, atualizar e excluir conselhos de Salomão do livro Provérbios.

## Endpoints Disponíveis

### Random Advice

- **Endpoint:** `/advice`
- **Método HTTP:** GET
- **Função:** Retorna um conselho aleatório.

### Advice by ID

- **Endpoint:** `/advice/{Id:int}`
- **Método HTTP:** GET
- **Função:** Retorna um conselho com base no ID fornecido.

### Advice by Text

- **Endpoint:** `/advice/{advice}`
- **Método HTTP:** GET
- **Função:** Retorna conselhos que contêm o texto fornecido.

### Create Advice

- **Endpoint:** `/advice/`
- **Método HTTP:** POST
- **Função:** Cria um novo conselho.

### Update Advice

- **Endpoint:** `/advice/`
- **Método HTTP:** PUT
- **Função:** Atualiza um conselho existente.

### Delete Advice

- **Endpoint:** `/advice/{Id:int}`
- **Método HTTP:** DELETE
- **Função:** Exclui um conselho com base no ID fornecido.


## Tecnologias Utilizadas

- ASP.NET Core
- SQL Server
- C#

## Autor

Kawan Guilherme Cabral de Melo

