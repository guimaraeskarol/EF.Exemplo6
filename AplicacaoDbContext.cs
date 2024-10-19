﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EF.Exemplo6;

public class AplicacaoDbContext : DbContext
{
    public DbSet<Autor> Autor { get; set; }
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Livro> Livro { get; set; }
    public DbSet<Genero> Genero { get; set; }
    public DbSet<LivroGenero> LivroGenero { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(@"Host=10.140.74.49;" +
                                 "Username=postgres;" +
                                 "Password=123456;" +
                                 "Database=biblioteca;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new LivroConfiguration());
        modelBuilder.ApplyConfiguration(new AutorConfiguration());
        modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
        modelBuilder.ApplyConfiguration(new GeneroConfiguration());
        modelBuilder.ApplyConfiguration(new LivroGeneroConfiguration());
    }
}