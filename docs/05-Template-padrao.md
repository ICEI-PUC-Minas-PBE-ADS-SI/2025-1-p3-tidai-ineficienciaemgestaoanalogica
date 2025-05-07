# Template padrão da aplicação

## Estrutura das telas

A estrutura das telas foi pensada para a interação com interfaces mobile, a ideia é ser uma interface bastante simples e intuitiva, sem muita informação e elementos supérfluos.

![Frames](./images/frame-aplicacao.png)

## Uso das Cores

A escolha de cores também é pensada para a simplificação, o uso do vermelho é tradicional para representar marcas relacionadas à comida, o uso de apenas quatro cores ajuda a simplificar a aplicação, destacar as fotos das comidas quando elas aparecerem enquanto permite a representação suficiente de cores para os elementos necessários.

![Uso das Cores](./images/uso-das-cores.png)

## Iconografia

Os ícones utilizados são próprios, vetorizados no figma, desenhados com o foco em formas sólidas e simples, permitindo maior contraste com as cores sólidas do projeto.

![Iconografia](./images/iconografia.png)

## Componentes utilizados

O projeto utiliza componentes do bootstrap, como a navbar, os cards, afim de fornecer um visual coeso e responsabilidade

![Cards](./images/cards.png)

## Responsividade

As classes bootstrap para controle de grid e flex são utilizadas para garantir a responsividade das páginas

![Responsividade](./images/responsividade.png)

Isso é feito pelo uso de divs com a classe row-cols, com divs com a classe col no interior delas. O uso de `row-cols-sm`, `rol-cols-lg`, permite mudar o número de colunas que serão exibidads na tela em determinada resolução.

```html
<div class="container-md text-center">
    <div class="d-flex row row-cols-1 row-cols-sm-2 row-cols-lg-4 justify-content-center">
        <a href="./pages/ver_pedidos.html" class="col text-center mt-5">
            <img src="./imgs/ver_pedidos.svg" alt="ver_pedidos">
        </a>
        <a href="./pages/fazer_pedidos.html" class="col text-center mt-5">
            <img src="./imgs/fazer_pedidos.svg" alt="fazer_pedidos">
        </a>
        <a href="./pages/relatorio.html" class="col text-center mt-5">
            <img src="./imgs/relatorio.svg" alt="relatorio">
        </a>
        <a href="./pages/gerenciar.html" class="col text-center mt-5">
            <img src="./imgs/gerenciar.svg" alt="gerenciar">
        </a>
    </div>
</div>
```
