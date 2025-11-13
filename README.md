# 🌳 3Trees API

API desenvolvida em ASP.NET Core para gerenciamento de trilhas, incluindo upload de imagens.

## 🚀 Tecnologias
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger (documentação)
- Render (deploy)

## ⚙️ Funcionalidades
- CRUD completo de trilhas (criar, listar, editar e apagar)
- Upload e armazenamento de imagens no servidor
- Retorno dos dados via endpoints REST

## 🧠 Endpoints principais
| Método | Rota | Descrição |
|--------|------|-----------|
| GET | `/api/Trilha` | Lista todas as trilhas |
| GET | `/api/Trilha/{id}` | Busca uma trilha por ID |
| POST | `/api/Trilha` | Cadastra uma nova trilha (form-data com imagem) |
| PUT | `/api/Trilha/{id}` | Atualiza uma trilha existente |
| DELETE | `/api/Trilha/{id}` | Remove uma trilha |

## 💾 Banco de Dados
A API utiliza **Entity Framework Core** com **SQL Server**.  
Ao publicar no Render, use um banco remoto (como Azure SQL, Railway ou outro serviço de hospedagem de banco).

## 🧰 Como rodar localmente
```bash
# Clone o repositório
git clone https://github.com/RayStark997/3Trees.git

# Entre na pasta
cd 3Trees

# Rode a aplicação
dotnet run
