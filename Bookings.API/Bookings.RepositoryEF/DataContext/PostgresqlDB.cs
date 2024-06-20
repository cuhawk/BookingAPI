using Bookings.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.RepositoryEF.DataContext
{
    public partial class PostgresqlDB : DbContext
    {
        public PostgresqlDB()
        {
        }

        public PostgresqlDB(DbContextOptions<PostgresqlDB> options)
            : base(options)
        {

        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Idbooking)
                    .HasName("bookings_pkey");

                entity.ToTable("bookings");

                entity.Property(e => e.Idbooking)
                    .HasColumnType("character varying")
                    .HasColumnName("idbooking")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Bookingdate)
                    .HasColumnType("character varying")
                    .HasColumnName("bookingdate");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("creationdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Documentnumber)
                    .HasColumnType("character varying")
                    .HasColumnName("documentnumber");

                entity.Property(e => e.Idclient)
                    .HasColumnType("character varying")
                    .HasColumnName("idclient");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient)
                    .HasName("clients_pkey");

                entity.ToTable("clients");

                entity.Property(e => e.Idclient)
                    .HasColumnType("character varying")
                    .HasColumnName("idclient")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Clientname)
                    .HasColumnType("character varying")
                    .HasColumnName("clientname");

                entity.Property(e => e.Clientnit)
                    .HasColumnType("character varying")
                    .HasColumnName("clientnit");

                entity.Property(e => e.Creationdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("creationdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Idservice).HasColumnName("idservice");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Idservice)
                    .HasName("services_pkey");

                entity.ToTable("services");

                entity.Property(e => e.Idservice)
                    .HasColumnType("character varying")
                    .HasColumnName("idservice")
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.Fechacreacion)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fechacreacion")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Servicename)
                    .HasColumnType("character varying")
                    .HasColumnName("servicename");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
