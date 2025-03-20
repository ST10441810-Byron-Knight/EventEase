using System;
using System.Collections.Generic;
using EventEaseApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEaseApplication.Data;

public partial class EEDbContext : DbContext
{
    public EEDbContext()
    {
    }

    public EEDbContext(DbContextOptions<EEDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACD2E72B2BD");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingDate)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.VenueId).HasColumnName("VenueID");

            entity.HasOne(d => d.Event).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK__Booking__EventID__3D5E1FD2");

            entity.HasOne(d => d.Venue).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("FK__Booking__VenueID__3E52440B");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__7944C870372B006A");

            entity.ToTable("Event");

            entity.HasIndex(e => e.EventName, "UQ__Event__59D2B72671CD309F").IsUnique();

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EventDate)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venue__3C57E5D2DA2ECC61");

            entity.ToTable("Venue");

            entity.HasIndex(e => e.VenueName, "UQ__Venue__A40F8D1285519D80").IsUnique();

            entity.Property(e => e.VenueId).HasColumnName("VenueID");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.VenueName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
