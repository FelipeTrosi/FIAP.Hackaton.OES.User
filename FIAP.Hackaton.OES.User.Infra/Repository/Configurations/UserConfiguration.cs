using FIAP.Hackaton.OES.User.Domain.Entity;
using FIAP.Hackaton.OES.User.Domain.Enums.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.FCG.User.Infrastructure.Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("bigint")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.CreatedAt)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.CPF)
           .IsRequired()
           .HasMaxLength(14);

        builder.Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.AccessLevel)
            .HasConversion<int>();

        builder.HasIndex(p => p.Email)
            .IsUnique()
            .HasDatabaseName("UX_User_Email"); ;

        builder.HasData(
            new UserEntity
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = "Admin",
                CPF = "71201291285",
                Email = "admin@fiap.com.br",
                Password = "$2a$11$p3ZTAklBXuBMM9T1By4rLOCekLbmvGjdcjP7lrv82KuVfpiVSLi6G",
                AccessLevel = AccessLevelEnum.MANAGER
            });
    }
}
