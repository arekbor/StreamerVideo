using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class StreamerDataConfiguration
    : IEntityTypeConfiguration<StreamerData>
{
    public void Configure(EntityTypeBuilder<StreamerData> builder)
    {
        builder.Property(x => x.Username)
            .IsRequired()
            .HasColumnType("varchar(80)");

        builder.Property(x => x.YoutubeName)
            .IsRequired()
            .HasColumnType("varchar(80)");

        builder.Property(x => x.DownloadedOn)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(x => x.AvatarUrl)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(x => x.YoutubeUrl)
            .IsRequired()
            .HasColumnType("varchar(200)");
    }
}
