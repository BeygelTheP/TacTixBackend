using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TacTix.WebApi.SQLDbContext
{
    public partial class TacTixDbContext : DbContext
    {
        public TacTixDbContext()
        {
        }

        public TacTixDbContext(DbContextOptions<TacTixDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppearancesDatum> AppearancesData { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameFormation> GameFormations { get; set; }
        public virtual DbSet<Medical> Medicals { get; set; }
        public virtual DbSet<PerformanceDatum> PerformanceData { get; set; }
        public virtual DbSet<PhysicalDatum> PhysicalData { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerPosition> PlayerPositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Password=U^,zIg#VIO*82kT:;Persist Security Info=True;User ID=sa;Initial Catalog=TacTixDB;Data Source=192.168.1.67");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<AppearancesDatum>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId })
                    .HasName("PK__appearan__D85D144DF3AE4B2F");

                entity.ToTable("appearancesData");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.FirstPosition)
                    .HasMaxLength(20)
                    .HasColumnName("firstPosition");

                entity.Property(e => e.FirstPositionPlayingTime).HasColumnName("firstPositionPlayingTime");

                entity.Property(e => e.SecondPosition)
                    .HasMaxLength(20)
                    .HasColumnName("secondPosition");

                entity.Property(e => e.SecondPositionPlayingTime).HasColumnName("secondPositionPlayingTime");

                entity.Property(e => e.StartingEleven).HasColumnName("startingEleven");

                entity.Property(e => e.SubInMin).HasColumnName("subInMin");

                entity.Property(e => e.SubOutMin).HasColumnName("subOutMin");

                entity.Property(e => e.TotalMinutesPlayed).HasColumnName("totalMinutesPlayed");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.AppearancesData)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appearanc__gameI__5812160E");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.AppearancesData)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__appearanc__playe__571DF1D5");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId })
                    .HasName("PK__Discipli__D85D144D3666F26F");

                entity.ToTable("Discipline");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.FromCompetition)
                    .HasMaxLength(1)
                    .HasColumnName("fromCompetition");

                entity.Property(e => e.GamesSuspended).HasColumnName("gamesSuspended");

                entity.Property(e => e.RedCard).HasColumnName("redCard");

                entity.Property(e => e.StraightRed).HasColumnName("straightRed");

                entity.Property(e => e.SuspensionEndDate)
                    .HasColumnType("date")
                    .HasColumnName("suspensionEndDate");

                entity.Property(e => e.SuspensionStartDate)
                    .HasColumnType("date")
                    .HasColumnName("suspensionStartDate");

                entity.Property(e => e.YellowCards).HasColumnName("yellowCards");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disciplin__gameI__48CFD27E");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disciplin__playe__47DBAE45");
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.ToTable("Formation");

                entity.Property(e => e.FormationId).HasColumnName("formationId");

                entity.Property(e => e.FormationStyle)
                    .HasMaxLength(24)
                    .HasColumnName("formationStyle");

                entity.Property(e => e.TacticalFormation)
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("tacticalFormation");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.Competition)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("competition");

                entity.Property(e => e.GameDate)
                    .HasColumnType("date")
                    .HasColumnName("gameDate");

                entity.Property(e => e.GoalsAgainst).HasColumnName("goalsAgainst");

                entity.Property(e => e.GoalsFor).HasColumnName("goalsFor");

                entity.Property(e => e.LineUpPicturePath)
                    .HasMaxLength(256)
                    .HasColumnName("lineUpPicturePath");

                entity.Property(e => e.Opponent)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("opponent");

                entity.Property(e => e.Result)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("result");

                entity.Property(e => e.Season)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("season");
            });

            modelBuilder.Entity<GameFormation>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.FormationId })
                    .HasName("PK__gameForm__D8C00D46E31C1256");

                entity.ToTable("gameFormations");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.FormationId).HasColumnName("formationId");

                entity.Property(e => e.GoalsAgainst).HasColumnName("goalsAgainst");

                entity.Property(e => e.GoalsFor).HasColumnName("goalsFor");

                entity.Property(e => e.MinutesPlayed).HasColumnName("minutesPlayed");

                entity.HasOne(d => d.Formation)
                    .WithMany(p => p.GameFormations)
                    .HasForeignKey(d => d.FormationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__gameForma__forma__44FF419A");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameFormations)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__gameForma__gameI__440B1D61");
            });

            modelBuilder.Entity<Medical>(entity =>
            {
                entity.HasKey(e => e.InjuryId)
                    .HasName("PK__Medical__26BF980BD3FBDF34");

                entity.ToTable("Medical");

                entity.Property(e => e.InjuryId).HasColumnName("injuryId");

                entity.Property(e => e.DateOfInjury)
                    .HasColumnType("date")
                    .HasColumnName("dateOfInjury");

                entity.Property(e => e.EstimateRecoveryDurationInDays).HasColumnName("estimateRecoveryDurationInDays");

                entity.Property(e => e.EstimateReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("estimateReturnDate");

                entity.Property(e => e.InjuryType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("injuryType");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.ReturnDateInPractice)
                    .HasColumnType("date")
                    .HasColumnName("returnDateInPractice");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Medicals)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__Medical__playerI__3F466844");
            });

            modelBuilder.Entity<PerformanceDatum>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId })
                    .HasName("PK__performa__D85D144D629020F5");

                entity.ToTable("performanceData");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.Assists).HasColumnName("assists");

                entity.Property(e => e.AssistsMin)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("assistsMin");

                entity.Property(e => e.Goals).HasColumnName("goals");

                entity.Property(e => e.GoalsMin)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("goalsMin");

                entity.Property(e => e.KeyPasses).HasColumnName("keyPasses");

                entity.Property(e => e.ShotsOnTarget).HasColumnName("shotsOnTarget");

                entity.Property(e => e.Tackels).HasColumnName("tackels");

                entity.Property(e => e.TackelsWon).HasColumnName("tackelsWon");

                entity.Property(e => e.TotalPasses).HasColumnName("totalPasses");

                entity.Property(e => e.TotalShots).HasColumnName("totalShots");

                entity.Property(e => e.WeightedScore).HasColumnName("weightedScore");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.PerformanceData)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__performan__gameI__5CD6CB2B");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PerformanceData)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__performan__playe__5BE2A6F2");
            });

            modelBuilder.Entity<PhysicalDatum>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlayerId })
                    .HasName("PK__physical__D85D144D3D2FF04A");

                entity.ToTable("physicalData");

                entity.Property(e => e.GameId).HasColumnName("gameId");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.AverageSpeed).HasColumnName("averageSpeed");

                entity.Property(e => e.DistanceCoverd).HasColumnName("distanceCoverd");

                entity.Property(e => e.TopSpeed).HasColumnName("topSpeed");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.PhysicalData)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__physicalD__gameI__3C69FB99");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PhysicalData)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__physicalD__playe__3B75D760");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.HasIndex(e => e.PlayerNo, "UQ__Player__2CDBBEC24E552DB3")
                    .IsUnique();

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerHight).HasColumnName("playerHight");

                entity.Property(e => e.PlayerNo).HasColumnName("playerNo");
            });

            modelBuilder.Entity<PlayerPosition>(entity =>
            {
                entity.HasKey(e => e.PlayerId)
                    .HasName("PK__playerPo__2CDA01F1F59D2353");

                entity.ToTable("playerPosition");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("playerId");

                entity.Property(e => e.MainPosition)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("mainPosition");

                entity.Property(e => e.MainUnit)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("mainUnit");

                entity.Property(e => e.SecondaryPosition)
                    .HasMaxLength(30)
                    .HasColumnName("secondaryPosition");

                entity.Property(e => e.SecondaryUnit)
                    .HasMaxLength(24)
                    .HasColumnName("secondaryUnit");

                // entity.HasOne(d => d.Player)
                //     .WithOne(p => p.PlayerPosition)
                //     .HasForeignKey<PlayerPosition>(d => d.PlayerId)
                //     .OnDelete(DeleteBehavior.ClientSetNull)
                //     .HasConstraintName("FK__playerPos__playe__52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
