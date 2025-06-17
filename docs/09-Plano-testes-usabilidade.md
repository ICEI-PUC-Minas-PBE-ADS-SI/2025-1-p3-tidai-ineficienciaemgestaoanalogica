# Plano de testes de usabilidade

<span style="color:red">Pré-requisitos: <a href="04-Projeto-interface.md"> Projeto de interface</a></span>, <a href="07-Plano-testes-software.md"> Plano de testes de software</a>

O teste de usabilidade permite avaliar a qualidade da interface com o usuário da aplicação interativa. Um plano de teste de usabilidade deverá conter: o detalhamento dos objetivos (ou cenários) em função dos requisitos levantados/implementados, os critérios que serão utilizados para a seleção dos participantes, os procedimentos a serem adotados pelos condutores de teste (por exemplo: os testes serão presenciais ou remotos? O método será observação direta, medição ou avaliação?), os dados a serem coletados (quantidade de cliques, número de erros, tempo, etc.), a ordem de execução das tarefas e das etapas da sessão de teste, os recursos demandados, as métricas coletadas, entre outros.

Para cada voluntário do teste, é fundamental coletar e apresentar todos os dados/métricas previamente definidos. No entanto, atendendo à LGPD (Lei Geral de Proteção de Dados), nenhum dado sensível que permita identificar o voluntário deverá ser apresentado.

> Exemplo:

O objetivo doPlano de testes de usabilidade é obter informações quanto à expectativa dos usuários em relação à funcionalidade da aplicação de forma geral.

Para tanto, foram elaborados quatro cenários, cada um baseado na definição apresentada sobre as histórias dos usuários, definido na etapa das especificações do projeto.

Foram convidadas quatro pessoas que os perfis se encaixassem nas definições das histórias apresentadas na documentação, visando averiguar os seguintes indicadores:

Taxa de sucesso: responde se o usuário conseguiu ou não executar a tarefa proposta;

Satisfação subjetiva: responde como o usuário avalia o sistema com relação à execução da tarefa proposta, conforme a seguinte escala:

1. Péssimo; 
2. Ruim; 
3. Regular; 
4. Bom; 
5. Ótimo.

Tempo para conclusão da tarefa: em segundos, e em comparação com o tempo utilizado quando um especialista (um desenvolvedor) realiza a mesma tarefa.

Objetivando respeitar as diretrizes da Lei Geral de Proteção de Dados, as informações pessoais dos usuários que participaram do teste não foram coletadas, tendo em vista a ausência de Termo de Consentimento Livre e Esclarecido.

> Apresente os cenários de testes utilizados na realização dos testes de usabilidade da sua aplicação. Escolha cenários de testes que demonstrem as principais histórias de usuário sendo realizadas. Neste tópico, você deve detalhar quais funcionalidades foram avaliadas, o grupo de usuários que foi escolhido para participar do teste e as ferramentas utilizadas.

## Personas

### Roberto, o Gerente
- *Idade:* 48 anos;
- *Perfil:* Proprietário do restaurante, focado na gestão estratégica e financeira. Ele precisa de dados consolidados para tomar decisões assertivas sobre o negócio.
- *Desafios:* Manter o cardápio e os preços sempre atualizados no sistema, treinar novos funcionários para usar a ferramenta corretamente e garantir que os dados financeiros sejam precisos para o fechamento do mês.
- *Necessidades:* Um painel de controle com acesso a relatórios detalhados e ferramentas simples para gerenciar os produtos vendidos.

### Carlos, o Garçom
- *Idade:* 26 anos;
- *Perfil:* Profissional ágil e comunicativo, responsável por atender os clientes nas mesas. Sua prioridade é a rapidez e a precisão no registro dos pedidos.
- *Desafios:* Anotar pedidos complexos com modificações e gerenciar várias mesas simultaneamente, principalmente em horários de pico.
- *Necessidades:* Uma interface intuitiva e rápida para lançar itens, adicionar observações e enviar os pedidos para a cozinha sem erros.

### Lúcia, a Atendente de Caixa
- *Idade:* 38 anos;
- *Perfil:* Organizada e metódica, sua função é finalizar a experiência do cliente, garantindo que a cobrança seja feita de forma correta e sem demora.
- *Desafios:* Evitar filas no caixa, conferir rapidamente todos os itens de um pedido longo e aplicar taxas de serviço corretamente.
- *Necessidades:* Um sistema que permita localizar facilmente o pedido de uma mesa e gerar uma conta clara e formatada para impressão imediata.

### Sandra, a Cozinheira
- *Idade:* 42 anos;
- *Perfil:* Chefe de cozinha experiente, responsável por garantir a qualidade e a padronização dos pratos. Ela trabalha sob pressão para manter o fluxo da cozinha.
- *Desafios:* Interpretar corretamente as comandas, especialmente as observações (ponto da carne, alergias, ingredientes a remover) e organizar a fila de preparo.
- *Necessidades:* Receber os pedidos de forma padronizada e legível, com todas as especificações do cliente bem destacadas para evitar erros na produção.

## Histórias de usuários

Com base na análise das personas, foram identificadas as seguintes histórias de usuários:

| EU COMO... PERSONA | QUERO/PRECISO... FUNCIONALIDADE | PARA... MOTIVO/VALOR |
| :--- | :--- | :--- |
| *Gerente* | Gerar relatórios de vendas consolidados por período | Analisar o desempenho financeiro do restaurante e tomar decisões estratégicas. |
| | Adicionar e editar os produtos do cardápio no sistema | Manter o menu sempre atualizado para que os pedidos sejam registrados com os preços e itens corretos. |
| *Garçom* | Lançar e atualizar os pedidos de uma mesa de forma rápida e intuitiva | Agilizar o atendimento ao cliente e minimizar a chance de erros na comunicação com a cozinha. |
| *Atendente de Caixa* | Acessar um pedido e imprimir a conta final detalhada | Realizar o fechamento da conta de forma ágil e transparente, evitando filas no caixa. |
| *Cozinheira* | Receber a comanda com os itens e observações de forma clara e padronizada | Preparar os pratos exatamente como o cliente solicitou, garantindo a qualidade e a satisfação. |

> **Links úteis**:
> - [Teste de usabilidade: o que é e como fazer passo a passo](https://neilpatel.com/br/blog/teste-de-usabilidade/)
> - [Teste de usabilidade: tudo o que você precisa saber!](https://medium.com/aela/teste-de-usabilidade-o-que-voc%C3%AA-precisa-saber-39a36343d9a6/)
> - [Planejando testes de usabilidade: o que (e o que não) fazer](https://imasters.com.br/design-ux/planejando-testes-de-usabilidade-o-que-e-o-que-nao-fazer/)
> - [Ferramentas de testes de usabilidade](https://www.usability.gov/how-to-and-tools/resources/templates.html)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
