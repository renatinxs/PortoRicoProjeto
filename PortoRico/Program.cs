using PortoRico.Libraries.Login;

using PortoRico.Models;
using PortoRico.Repository;
using PortoRico.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adicionar a Interface como um serviço 
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();


// Corrigir problema com TEMPDATA
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Definir um tempo para duracao.
    options.IdleTimeout = TimeSpan.FromSeconds(60);
    options.Cookie.HttpOnly = true;

    // Mostrar para o navegador que o cookie é essencial
    options.Cookie.IsEssential = true;
});

builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddScoped<PortoRico.Libraries.Sessao.Sessao>();
builder.Services.AddScoped<LoginCliente>();


//Adicionado para manipular a Sessão
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.MapStaticAssets();
app.UseCookiePolicy();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
