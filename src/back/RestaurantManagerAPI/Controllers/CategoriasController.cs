using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class CategoriasController : Controller<Categoria>
{
    public CategoriasController(AppDbContext context) : base(context) {}
}