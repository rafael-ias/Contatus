using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contatus.Core.Models;

namespace Contatus.Api.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            builder.Property(x => x.CPF)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);
            builder.Property(x => x.DataDeNascimento)
                .IsRequired(false);
            builder.Property(x => x.EstaAtivo)
                .IsRequired(true)
                .HasColumnType("BIT");
            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);
            builder.HasMany(x => x.Telefones)
                .WithOne(t => t.Pessoa)
                .HasForeignKey(t => t.PessoaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
