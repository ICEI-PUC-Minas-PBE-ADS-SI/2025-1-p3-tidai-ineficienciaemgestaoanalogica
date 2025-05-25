# Plano de testes de software

## Objetivo
O objetivo desse plano de teste é garantir que nosso sistema funcione corretamente dentro do esperado, de forma estável e assegurando que todas as etapas antecessoras ao teste estão alinhadas com o produto até então.

## Escopo de Teste
Serão testadas as funcionalidades principais do sistema, considerando o fluxo esperado de uso pelos funcionários, garantindo assim a estabilidade, usabilidade e confiabilidade do sistema.

**Funcionalidades testadas**
- 

| **Caso de teste**  | **CT-001 – Gerenciamento de Produtos**  |
|:---: |:---: |
| Requisito associado | RF-001 - O gerente deve ser capaz de gerenciar produtos. |
| Objetivo do teste | Verificar criação, edição e remoção de produtos. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar tela de gerenciar <br> - Selecionar opção produtos <br><br> **Criar Produto**  <br> - Pressionar o botão adicionar <br> - Preencher dados do produto <br> - Confirmar criação do produto <br><br> **Editar Produto** <br> - Pressionar botão editar em um dos produtos(ícone de lápis) <br> - Alterar dados do produto <br> - Confirmar edição do produto <br><br> **Remover Produto** <br> - Pressionar botão remover em um dos produtos <br> Confirmar remoção do produto |
| Critério de êxito | - Produto criado aparece na lista <br> - Produto editado exibe novos dados <br> - Produto removido some da tela |

<br>

| **Caso de teste**  | **CT-002 – Gerenciamento de Categorias**  |
|:---: |:---: |
| Requisito associado | RF-002 - O gerente deve ser capaz de gerenciar as categorias de produtos. |
| Objetivo do teste | Verificar criação, edição e remoção de categorias. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar tela de gerenciar <br> - Selecionar opção Produtos <br> - Pressionar o botão editar(ícone de lápis) na barra de categorias <br><br> **Criar Categoria** <br> Pressionar botão adicionar <br>  - Preencher nome da categoria <br> - Confirmar criação da categoria <br><br> **Editar Categoria** <br> - Pressionar botão editar em uma das categorias(ícone de lápis) <br> - Alterar nome da categoria <br> - Confirmar edição da categoria <br><br> **Remover Categoria** <br> - Pressionar botão remover em uma das categorias(ícone de lixeira) <br> Confirmar remoção da categoria |
| Critério de êxito | - Categoria criada aparece na lista <br> - Categoria renomeada exibe novo nome <br> - Categoria e produtos vinculados são removidos. |

<br>

| **Caso de teste**  | **CT-003 – Gerenciamento de Pedidos**  |
|:---: |:---: |
| Requisito associado | RF-003 - O funcionário deve ser capaz de gerenciar pedidos. |
| Objetivo do teste | Verificar criação, atualização e fechamento de pedidos. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br><br> **Fazer Pedido** <br> - Acessar tela de fazer pedidos <br> Selecionar mesa <br> - Adicionar produtos <br> - Pressionar botão inferior <br> - Adicionar extras e observação <br> - Confirmar <br><br> **Atualizar Pedido** <br> - Acessar tela de ver pedidos <br> - Pressionar o botão atualizar em um dos pedidos <br> - Alterar produtos/extras/observações <br> - Confirmar <br><br> **Fechar Pedido** <br> - Acessar tela de ver pedidos <br> - Pressionar o botão fechar em um dos pedidos <br> - Confirmar |
| Critério de êxito | - Pedido criado aparece na lista <br> - Pedido atualizado exibe novos dados <br> - Pedido fechado some da lista |

<br>

| **Caso de teste**  | **CT-004 – Visualização de Relatórios**  |
|:---: |:---: |
| Requisito associado | RF-004 - O gerente deve ser capaz de visualizar relatórios de pedidos por data ou períodos personalizados. |
| Objetivo do teste | Verificar a geração de relatórios diários e por período personalizado. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar tela de relatórios <br><br> **Gerar relatório diário** <br> - Selecionar opção Diário <br> - Selecionar data <br> - Gerar <br><br> **Gerar relatório por período** <br> - Selecionar opção Período <br> - Selecionar data de início e de fim <br> - Gerar |
| Critério de êxito | - Relatório diário exibe cards dos pedidos da data selecionada <br> - Relatório por período exibe cards dos dias do período selecionado |

<br>

| **Caso de teste**  | **CT-005 – Gerenciamento de Funcionários**  |
|:---: |:---: |
| Requisito associado | RF-005 - O gerente deve ser capaz de gerenciar o acesso dos funcionários do sistema. |
| Objetivo do teste | Verificar cadastro, edição e remoção de funcionários. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar tela de gerenciamento <br> - Selecionar opção Funcionarios <br><br> **Adicionar Funcionario** <br> - Pressionar botão adicionar <br> - Inserir dados do funcionário e sua responsabilidade <br> - Confirmar <br><br> **Editar funcionario** <br> - Pressionar botão editar(ícone de lápis) <br> - Inserir novos dados do funcionário <br> - Confirmar <br><br> **Remover Funcionario** <br> - Pressionar botão remover(ícone de lixeira) <br> - Confirmar |
| Critério de êxito | - Funcionário cadastrado aparece na lista <br> - Dados editados são atualizados <br> - Funcionário removido some da lista |

<br>

| **Caso de teste**  | **CT-006 – Gerenciamento de Mesas**  |
|:---: |:---: |
| Requisito associado | RF-006 - O gerente deve ser capaz de gerenciar as mesas do restaurante. |
| Objetivo do teste | Verificar adição, renomeação e remoção de mesas. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar tela de gerenciamento <br> - Selecionar opção Mesas <br><br> **Adicionar Mesa** <br> - Pressionar botão adicionar <br> - Inserir nome <br> - Confirmar <br><br> **Renomear Mesa** <br> - Pressionar botão editar(ícone de lápis) <br> - Inserir novo nome <br> - Confirmar <br><br> **Remover Mesa** <br> - Pressionar botão remover(ícone de lixeira) <br> - Confirmar |
| Critério de êxito | - Mesa adicionada paarece na lista <br> - Mesa renomeada exibe novo nome <br> - Mesa removida some da lista |

<br>

| **Caso de teste**  | **CT-007 – Impressão de Contas e Relatórios**  |
|:---: |:---: |
| Requisito associado | RF-007 - O sistema deve permitir a impressão de contas e relatórios. |
| Objetivo do teste | Verificar a impressão de contas e relatórios (diário/período). |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br><br> **Imprimir Conta** <br> - Acessar tela de ver pedidos <br> - Pressionar a opção fechar em um dos pedidos <br> - Confirmar <br> - Pressionar o botão imprimir <br><br> **Imprimir Relatório** <br> - Gerar Relatório (CT-004) <br> - Pressionar o botão imprimir |
| Critério de êxito | - Modal de impressão é exibido com formatação adaptada para o relatório |

<br>

| **Caso de teste**  | **CT-008 – Responsividade**  |
|:---: |:---: |
| Requisito associado | RNF-004 - Funcionamento adequado em dispositivos móveis e desktops. |
| Objetivo do teste | Garantir adaptação a diferentes tamanhos de tela. |
| Passos | - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar telas principais do sistema <br> - Utilizar as devtools do navegador para simular a visualização em diferentes dispositivos |
| Critério de êxito | - Interface se adapta corretamente em todos os dispositivos testados |

<br>

| **Caso de teste**  | **CT-009 – Otimização para Hardware Limitado**  |
|:---: |:---: |
| Requisito associado | RNF-007 - Boa performance em hardwares modestos. |
| Objetivo do teste | Verificar desempenho em ambiente com recursos limitados. |
| Passos | - Instalar o sistema em um servidor com hardware limitado <br> - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar telas principais do sistema |
| Critério de êxito | - Sistema funciona sem travamentos. |

<br>

| **Caso de teste**  | **CT-010 – Controle de Acesso por Permissões**  |
|:---: |:---: |
| Requisito associado | Restricao-003 - Restrições de acesso por perfil. |
| Objetivo do teste | Verificar se as permissões são aplicadas corretamente. |
| Passos | <br> - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login como funcionário comum <br> - Tentar acessar tela de relatórios <br> - Tentar acessar tela de gerenciar <br> - Fazer login como gerente <br> - Tentar acessar tela de relatórios <br> - Tentar acessar tela de gerenciar |
| Critério de êxito | - Funcionário comum não acessa funções restritas. <br> - Gerente tem acesso completo |

<br>

| **Caso de teste**  | **CT-011 – Atualização em Tempo Real**  |
|:---: |:---: |
| Requisito associado | Restricao-006 - Atualizações imediatas dos pedidos. |
| Objetivo do teste | Verificar sincronização de atualizações dos pedidos. |
| Passos | <br> - Acessar o navegador <br> - Informar o endereço do sistema <br> - Fazer login (se necessário) <br> - Acessar tela de Ver Pedidos <br> - Acessar o navegador em aba anônima ou outro dispositivo <br> - Fazer Pedido(CT-003) <br> - Atualizar Pedido(CT-003) <br> - Fechar Pedido(CT-003) |
| Critério de êxito | - Pedidos feitos são adicionados automaticamente à tela de ver pedidos na primeira sessão. <br> - Pedidos atualizados são alterados automaticamente na tela de ver pedidos na primeira sessão. <br> - Pedidos fechados são removidos automaticamente da tela de ver pedidos na primeira sessão |
