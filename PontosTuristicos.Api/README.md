# Pontos Turísticos API

API REST em ASP.NET Core para gerenciamento de pontos turísticos.

## 🚀 Tecnologias

- .NET 8
- ASP.NET Core Web API  
- Entity Framework Core
- SQLite
- Swagger

## 📋 Funcionalidades

- CRUD completo de pontos turísticos
- Busca por nome, cidade ou estado
- Paginação
- Ordenação por data de cadastro

## 🚀 Como executar

```bash
# Restaurar dependências
dotnet restore

# Executar migrations
dotnet ef database update

# Executar aplicação
dotnet run
```

Acesse: `https://localhost:{porta}/swagger`

## 📚 Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/PontosTuristicos` | Lista pontos (com busca e paginação) |
| GET | `/api/PontosTuristicos/{id}` | Busca por ID |
| POST | `/api/PontosTuristicos` | Criar novo |
| PUT | `/api/PontosTuristicos/{id}` | Atualizar |
| DELETE | `/api/PontosTuristicos/{id}` | Excluir |

## 🎯 Modelo

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

## 🏗️ Arquitetura

```
Controllers/ → Services/ → Repositories/ → Data/
```

Arquitetura em camadas seguindo padrão Repository e boas práticas do .NET.