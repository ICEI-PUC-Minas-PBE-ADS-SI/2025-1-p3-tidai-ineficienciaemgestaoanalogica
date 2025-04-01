# Metodologia

A Metodologia de trabalho adotada pelo grupo para o desenvolvimento do software foi baseada no framework Scrum, que permite uma abordagem ágil e iterativa. O projeto está dividido em sprints, com entregas incrementais e reuniões diárias para acompanhamento do progresso. A equipe utiliza ferramentas modernas para gestão de código, documentação e colaboração.

## Relação de ambientes de trabalho

| Ambiente                     | Plataforma        | Link de Acesso |
| :----                        | :----             | :----          |
| Repositório de código fonte  | GitHub            | [Repositório](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica)  |
| Projeto de Interface         | Figma             | [Figma](https://www.figma.com/)  |
| Hospedagem                   | Docker            | [Docker Hub](https://hub.docker.com/)  |
| Banco de Dados               | MySQL             | [MySQL WorkBench](https://www.mysql.com/products/workbench/)/[DBeaver](https://dbeaver.io/)  |
| Desenvolvimento Front-end    | VS Code / Neovim  | [VS Code](https://code.visualstudio.com/)/[Neovim](https://neovim.io/)  |
| Desenvolvimento Back-end     | VS Code / Neovim  | [VS Code](https://code.visualstudio.com/)/[Neovim](https://neovim.io/)  |

## Controle de versão

A ferramenta de controle de versão adotada no projeto foi o [Git](https://git-scm.com/), sendo que o [GitHub](https://github.com) foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software.
- `dev`: versão de desenvolvimento do software.
- `feature/*`: branches para desenvolvimento de novas funcionalidades.
- `release/*`: branches para a preparação de novas versòes de produção.
- `hotfix/*`: branches para correções críticas na versão estável.

O fluxo de trabalho funciona da seguinte forma:

- Todo o desenvolvimento ocorre na branch `dev`.
- Novas funcionalidades são desenvolvidas em branches do tipo `feature/*`, que são criadas a partir da branch `dev`.
- Quando uma funcionalidade está concluída, a branch `feature/*` é mesclada de volta na branch `dev`.
- Quando uma nova versão está pronta para ser liberada, uma branch `release/*` é criada a partir da branch `dev`
- A branch `release/*` é usada para testes finais e correções de bugs. Após a validação, ela é mesclada na branch `main` (para produção) e também na branch `dev` (para manter a sincronia).
- Caso sejam identificados bugs críticos na produção, uma branch `hotfix/*` é criada a partir da branch `main`. Após a correção, a branch `hotfix/*` é mesclada na branch `main` e também na branch `dev`.

O projeto utiliza o seguinte padrão para as tags:

As tags são utilizadas para marcar versões estáveis, seguirão o padrão semântico `MAJOR.MINOR.PATCH` (ex: `v1.0.0`).

Os commits seguem o padrão Conventional Commits:

- Exemplo: `feat(login): adiciona tela de autenticação #11`.

Quanto à gerência de issues, o projeto adota a seguinte convenção para etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

As issues são vinculadas aos commits usando `#<número_da_issue>` (ex: `git commit -m "fix(login): corrige erro de autenticação #12"`).
Processo de Commits:

## Planejamento do projeto

###  Divisão de papéis

#### Sprint 1
- _Scrum master_: Pedro César da Matta Silveira
- Documentação do Contexto: Marco Antonio Alves Moreira
- Personas e Histórias de Usuário: Davi Telles Xavier
- Requisitos e Restrições: Thiago Botelho Neves 
- Casos de Uso: Caio Moreira Marques 
- Metodologia: Pedro César da Matta Silveira 

###  Quadro de tarefas

#### Sprint 1

Atualizado em: 17/03/2025

| Responsável                    | Tarefa/Requisito                  | Iniciado em | Prazo      | Status | Terminado em |
| :----                          | :----                             | :----:      | :----:     | :----: | :----:       |
| Marco Antonio Alves Moreira    | Problema                          | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Marco Antonio Alves Moreira    | Objetivos                         | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Marco Antonio Alves Moreira    | Justificativa                     | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Marco Antonio Alves Moreira    | Público-Alvo                      | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Davi Telles Xavier             | Personas                          | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Davi Telles Xavier             | Histórias de usuários             | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Thiago Botelho Neves           | Requisitos de Software            | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Thiago Botelho Neves           | Restrições da Solução             | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Caio Moreira Marques           | Diagramas de Casos de Uso         | 08/03/2025  | 17/03/2025 | ✔️      | 17/03/2025   |
| Pedro César da Matta Silveira  | Relação de ambientes de trabalho  | 08/03/2025  | 17/03/2025 | ✔️      | 13/03/2025   |
| Pedro César da Matta Silveira  | Controle de versão                | 08/03/2025  | 17/03/2025 | ✔️      | 13/03/2025   |
| Pedro César da Matta Silveira  | Planejamento do projeto           | 08/03/2025  | 17/03/2025 | ✔️      | 13/03/2025   |

#### Sprint 2

Atualizado em: 31/03/2025

| Responsável                    | Tarefa/Requisito                  | Iniciado em | Prazo      | Status | Terminado em |
| :----                          | :----                             | :----:      | :----:     | :----: | :----:       |
| Pedro César da Matta Silveira  | Projeto de Interface              | 31/03/2025  | 14/04/2025 | 📝      |    |
| Caio Moreira Marques           | Template da Aplicação             |             | 28/04/2025 | ❌      |    |
| Marco Antonio Alves Moreira    | Template da Aplicação             |             | 28/04/2025 | ❌      |    |
| Thiago Botelho                 | Arquitetura da Solução            | 31/03/2025  | 28/04/2025 | 📝      |    |
| Davi Telles Xavier             | Modelo de Dados                   | 31/03/2025  | 28/04/2025 | 📝      |    |

Legenda:
- ✔️ : terminado
- 📝: em execução
- ⌛: atrasado
- ❌: não iniciado

### Processo

O grupo utiliza o GitHub Projects para gerenciar o andamento do projeto. O quadro Kanban é organizado em colunas como "To Do", "In Progress", "In Review" e "Done". As issues são criadas para cada tarefa e associadas às milestones correspondentes a cada sprint. Reuniões são realizadas para alinhamento da equipe e identificação de possíveis impedimentos.

### Ferramentas

| Ambiente                            | Plataforma                         | Link de Acesso                         |
|-------------------------------------|------------------------------------|----------------------------------------|
| Repositório de código fonte         | GitHub                             | [Repositório](https://github.com/ICEI-PUC-Minas-PBE-ADS-SI/2025-1-p3-tidai-ineficienciaemgestaoanalogica)  |
| Projeto de Interface                | Figma                              | [Figma](https://www.figma.com/)  |
| Hospedagem                          | Docker                             | [Docker Hub](https://hub.docker.com/)  |
| Banco de Dados                      | MySQL                              | [MySQL WorkBench](https://www.mysql.com/products/workbench/)/[DBeaver](https://dbeaver.io/)  |
| Gerenciamento do projeto            | GitHub Projects                    | [Projeto](https://github.com/orgs/ICEI-PUC-Minas-PBE-ADS-SI/projects/26/views/1) |
| Desenvolvimento Front-end           | VS Code / Neovim                   | [VS Code](https://code.visualstudio.com/)/[Neovim](https://neovim.io/)  |
| Desenvolvimento Back-end            | VS Code / Neovim                   | [VS Code](https://code.visualstudio.com/)/[Neovim](https://neovim.io/)  |
| Linguagem Front-end                 | JavaScript                         | [JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript)  |
| Estrutura de linguagem back-end     | .NET 8.0                           | [.NET](https://dotnet.microsoft.com/pt-br/)  |

