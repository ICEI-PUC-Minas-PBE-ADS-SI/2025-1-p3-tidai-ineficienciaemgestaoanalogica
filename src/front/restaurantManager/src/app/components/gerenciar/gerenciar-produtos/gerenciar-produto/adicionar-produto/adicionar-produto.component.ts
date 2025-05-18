import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Categoria } from 'src/app/interfaces/categoria';
import { Extra } from 'src/app/interfaces/extra';
import { Produto } from 'src/app/interfaces/produto';
import { CategoriaService } from 'src/app/services/categoria.service.';
import { ProdutoService } from 'src/app/services/produto.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-adicionar-produto',
  imports: [CommonModule, FormsModule],
  templateUrl: './adicionar-produto.component.html',
  styleUrl: './adicionar-produto.component.css'
})
export class AdicionarProdutoComponent {
  produto?: Produto | null;
  categoriaSelecionada?: Categoria | null;
  extras?: Extra[] | null;
  categorias?: Categoria[] | null;
  selectedFile: File | null = null;
  environment = environment;

  images = {
    editar: "assets/images/editar-no-border.svg",
    remover: "assets/images/remover-no-border.svg",
    adicionar: "assets/images/incrementar.svg"
  }
  constructor(private route: ActivatedRoute, private router: Router, private produtoService: ProdutoService, private categoriaService: CategoriaService) {}

  ngOnInit() {
    this.produto = {
      id: 0,
      nome: '',
      descricao: '',
      preco: 0,
      categoriaId: 0,
      foto: '',
      extras:[]
    }

    this.categoriaService.getCategorias().subscribe(
      (data) => {
        this.categorias = data;
      },
      (error) => {
        console.error("Erro ao carregar categoria selecionada", error);
      }
    )
    this.categoriaSelecionada = this.categorias?.find(c => c.id == this.produto!.categoriaId);
  }

  onFileSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if(input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }
  criar(){
    if(!this.produto) {
      console.log('Produto vazio.');
      return;
    }
    const criarProduto = () => {
      const body = {
        categoriaId: this.produto!.categoriaId,
        nome: this.produto!.nome,
        descricao: this.produto!.descricao ?? "",
        preco: this.produto!.preco,
        foto: this.produto!.foto,
        extras: this.produto!.extras,
      };

      this.produtoService.criarProduto(body).subscribe({
        next: () => {
          console.log("Produto criado");
          this.router.navigate(['../'], { relativeTo: this.route})
        },
        error: (err) => {
          console.error("Erro ao criar produto:", err);
        }
      });
    };

    if(this.selectedFile) {
      this.produtoService.uploadImagem(this.selectedFile).subscribe({
        next: (res) => {
          this.produto!.foto = res.caminho;
          criarProduto();
        },
        error: (err) => {
          console.error("Erro ao fazer upload da imagem:", err);
        }
      });
    } else {
      criarProduto();
    }
  }

  // Extras
  extraTemp: Extra = { id: 0, nome: '', precoAdicional: 0 };
  extraEditando: Extra | null = null;

  removerExtra(index: number) {
    this.produto?.extras.splice(index, 1);
  }

  editarExtra(extra: any) {
    this.extraEditando = extra;
    this.extraTemp = { ...extra };
  }

  novoExtra() {
    this.extraEditando = null;
    this.extraTemp = { id: 0, nome: '', precoAdicional: 0 };
  }

  salvarExtra() {
    if(this.extraEditando) {
      this.extraEditando.nome = this.extraTemp.nome;
      this.extraEditando.precoAdicional = this.extraTemp.precoAdicional;
    } else {
      this.produto?.extras.push({ ...this.extraTemp })
    }
  }
}
