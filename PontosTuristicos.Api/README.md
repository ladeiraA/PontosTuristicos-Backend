# Pontos Turísticos API

API REST desenvolvida em ASP.NET Core para gerenciamento de pontos turísticos, permitindo cadastro, consulta, pesquisa, edição e exclusão de registros.

O projeto foi desenvolvido com foco em simplicidade, organização e boas práticas, adequado para avaliação de desenvolvedor júnior.

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQLite** (banco de dados)
- **Swagger/OpenAPI**

## 📋 Funcionalidades

- ✅ Criar ponto turístico
- ✅ Listar pontos turísticos com paginação
- ✅ Pesquisar pontos turísticos por:
  - Nome
  - Cidade
  - Estado
  - Referência
  - *(aceitando digitar apenas o início da palavra, sem diferenciação de maiúsculas/minúsculas)*
- ✅ Atualizar ponto turístico
- ✅ Excluir ponto turístico
- ✅ Listagem ordenada pelo cadastro mais recente

## 📚 Endpoints

### Listar e pesquisar pontos turísticos
```
GET /api/PontosTuristicos?termo={termo}&pagina={pagina}&tamanhoPagina={tamanhoPagina}
```
Lista e pesquisa pontos turísticos com paginação

### Buscar ponto turístico por ID
```
GET /api/PontosTuristicos/{id}
```
Busca ponto turístico específico por ID

### Cadastrar novo ponto turístico
```
POST /api/PontosTuristicos
```
Cadastra um novo ponto turístico

### Atualizar ponto turístico
```
PUT /api/PontosTuristicos/{id}
```
Atualiza um ponto turístico existente

### Excluir ponto turístico
```
DELETE /api/PontosTuristicos/{id}
```
Exclui um ponto turístico

## 🔧 Pré-requisitos

- **.NET SDK 8** instalado
- **Visual Studio** ou **Visual Studio Code**

*Nota: O SQLite é integrado ao projeto, não necessitando instalação separada de banco de dados.*

## ⚙️ Configuração do Banco de Dados

O projeto utiliza **SQLite** por padrão. A configuração está no `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=PontosTuristicos.db"
  }
}
```

### Executar as migrations:
```bash
dotnet ef database update
```

## 🚀 Executando o Projeto

Na pasta do projeto, execute:

1. **Restaurar dependências:**
```bash
dotnet restore
```

2. **Executar o projeto:**
```bash
dotnet run
```

A aplicação será iniciada e a URL será exibida no terminal.

## 🎯 Modelo de Dados

### PontoTuristico
```json
{
  "id": 1,
  "nome": "Cristo Redentor",
  "descricao": "Uma das sete maravilhas do mundo moderno",
  "referencia": "Estátua no topo do Corcovado",
  "cidade": "Rio de Janeiro",
  "estado": "RJ",
  "dataInclusao": "2024-01-15T10:30:00"
}
```

**Campos obrigatórios:** `nome`, `referencia`, `cidade`, `estado`

**Validações:**
- `nome`: máximo 100 caracteres
- `descricao`: máximo 100 caracteres (opcional)
- `estado`: exatamente 2 caracteres (UF)

## 📖 Swagger

Após iniciar a aplicação, o Swagger estará disponível em:

```
https://localhost:{PORTA}/swagger
```

*(Substitua {PORTA} pela porta exibida no terminal)*

## 🏗️ Arquitetura

O projeto utiliza arquitetura em camadas:

- **Controllers**: Gerenciam requisições HTTP
- **Services**: Contêm regras de negócio  
- **Repositories**: Fazem acesso aos dados
- **Models**: Definem entidades do domínio
- **Data**: Configuram o contexto do Entity Framework

```
PontosTuristicos.Api/
├── Controllers/
├── Services/
├── Repositories/
├── Models/
├── Data/
└── Program.cs
```

## 📝 Observações

- O projeto utiliza arquitetura em camadas (Controller, Service e Repository)
- As regras de negócio ficam concentradas no Service
- O frontend consome esta API através de requisições HTTP
- Paginação implementada para melhor performance
- Pesquisa inteligente com busca parcial

## 👨‍💻 Autor

Projeto desenvolvido para fins de avaliação técnica.

---

## 🔄 Versionamento

Depois de fazer alterações no arquivo:

```bash
git add README.md
git commit -m "Organiza e melhora formatação do README"
git push origin main