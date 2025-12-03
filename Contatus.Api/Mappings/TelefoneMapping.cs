using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Contatus.Core.Models;

namespace Contatus.Api.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Numero)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);
            builder.Property(x => x.Tipo)
                .IsRequired(true)
                .HasColumnType("SMALLINT");
            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);
            builder.Property(x => x.PessoaId)
                .IsRequired(true)
                .HasColumnType("INT");
            builder.HasOne(x => x.Pessoa)
                .WithMany(p => p.Telefones)
                .HasForeignKey(x => x.PessoaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
