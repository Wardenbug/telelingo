﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telelingo.DataContext;

#nullable disable

namespace Telelingo.DataContext.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20240604175413_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Telelingo.EntityModels.Chat", b =>
                {
                    b.Property<long>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ChatId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("Telelingo.EntityModels.ChatWord", b =>
                {
                    b.Property<long>("ChatId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WordId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LearningRate")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ShowOn")
                        .HasColumnType("TEXT");

                    b.HasKey("ChatId", "WordId");

                    b.HasIndex("WordId");

                    b.ToTable("ChatWord");
                });

            modelBuilder.Entity("Telelingo.EntityModels.Word", b =>
                {
                    b.Property<long>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WordId");

                    b.ToTable("Word");

                    b.HasData(
                        new
                        {
                            WordId = 1L,
                            Key = "kto",
                            Priority = 1,
                            Value = "хто"
                        },
                        new
                        {
                            WordId = 2L,
                            Key = "čo",
                            Priority = 1,
                            Value = "що"
                        },
                        new
                        {
                            WordId = 3L,
                            Key = "aký, aká, aké",
                            Priority = 1,
                            Value = "який, яка, яке"
                        },
                        new
                        {
                            WordId = 4L,
                            Key = "ten, tá, to",
                            Priority = 1,
                            Value = "цей, ця, це; той, та, те"
                        },
                        new
                        {
                            WordId = 5L,
                            Key = "tento, táto, toto",
                            Priority = 1,
                            Value = "цей, ця, це"
                        },
                        new
                        {
                            WordId = 6L,
                            Key = "nejaký , nejaká, nejaké",
                            Priority = 1,
                            Value = "якийсь, якась, якесь"
                        },
                        new
                        {
                            WordId = 7L,
                            Key = "auto",
                            Priority = 1,
                            Value = "автомобіль"
                        },
                        new
                        {
                            WordId = 8L,
                            Key = "dedko",
                            Priority = 1,
                            Value = "дідусь"
                        },
                        new
                        {
                            WordId = 9L,
                            Key = "dieťa",
                            Priority = 1,
                            Value = "дитина"
                        },
                        new
                        {
                            WordId = 10L,
                            Key = "dom",
                            Priority = 1,
                            Value = "дім, будинок"
                        },
                        new
                        {
                            WordId = 11L,
                            Key = "doma",
                            Priority = 1,
                            Value = "вдома"
                        },
                        new
                        {
                            WordId = 12L,
                            Key = "futbalista",
                            Priority = 1,
                            Value = "футболіст"
                        },
                        new
                        {
                            WordId = 13L,
                            Key = "kniha",
                            Priority = 1,
                            Value = "книга"
                        },
                        new
                        {
                            WordId = 14L,
                            Key = "kosť",
                            Priority = 1,
                            Value = "кістка"
                        },
                        new
                        {
                            WordId = 15L,
                            Key = "kvet",
                            Priority = 1,
                            Value = "квітка"
                        },
                        new
                        {
                            WordId = 16L,
                            Key = "lekáreň",
                            Priority = 1,
                            Value = "аптека"
                        },
                        new
                        {
                            WordId = 17L,
                            Key = "mačka",
                            Priority = 1,
                            Value = "кішка"
                        },
                        new
                        {
                            WordId = 18L,
                            Key = "múzeum",
                            Priority = 1,
                            Value = "музей"
                        },
                        new
                        {
                            WordId = 19L,
                            Key = "muž",
                            Priority = 1,
                            Value = "чоловік"
                        },
                        new
                        {
                            WordId = 20L,
                            Key = "námestie",
                            Priority = 1,
                            Value = "Міська площа"
                        },
                        new
                        {
                            WordId = 21L,
                            Key = "pes",
                            Priority = 1,
                            Value = "собака"
                        },
                        new
                        {
                            WordId = 22L,
                            Key = "posteľ",
                            Priority = 1,
                            Value = "ліжко"
                        },
                        new
                        {
                            WordId = 23L,
                            Key = "ruža",
                            Priority = 1,
                            Value = "троянда"
                        },
                        new
                        {
                            WordId = 24L,
                            Key = "srdce",
                            Priority = 1,
                            Value = "серце"
                        },
                        new
                        {
                            WordId = 25L,
                            Key = "šteňa",
                            Priority = 1,
                            Value = "щеня"
                        },
                        new
                        {
                            WordId = 26L,
                            Key = "žena",
                            Priority = 1,
                            Value = "жінка"
                        },
                        new
                        {
                            WordId = 27L,
                            Key = "je",
                            Priority = 1,
                            Value = "є"
                        },
                        new
                        {
                            WordId = 28L,
                            Key = "veľmi",
                            Priority = 1,
                            Value = "дуже, вельми"
                        },
                        new
                        {
                            WordId = 29L,
                            Key = "vysoký",
                            Priority = 1,
                            Value = "високий"
                        },
                        new
                        {
                            WordId = 30L,
                            Key = "nízky",
                            Priority = 1,
                            Value = "низький"
                        },
                        new
                        {
                            WordId = 31L,
                            Key = "veľký",
                            Priority = 1,
                            Value = "великий"
                        },
                        new
                        {
                            WordId = 32L,
                            Key = "malý",
                            Priority = 1,
                            Value = "малий"
                        },
                        new
                        {
                            WordId = 33L,
                            Key = "pekný",
                            Priority = 1,
                            Value = "гарний"
                        },
                        new
                        {
                            WordId = 34L,
                            Key = "krásny",
                            Priority = 1,
                            Value = "красивий"
                        },
                        new
                        {
                            WordId = 35L,
                            Key = "dobrý",
                            Priority = 1,
                            Value = "добрий"
                        },
                        new
                        {
                            WordId = 36L,
                            Key = "nový",
                            Priority = 1,
                            Value = "новий"
                        },
                        new
                        {
                            WordId = 37L,
                            Key = "starý",
                            Priority = 1,
                            Value = "старий"
                        },
                        new
                        {
                            WordId = 38L,
                            Key = "moderný",
                            Priority = 1,
                            Value = "сучасний"
                        },
                        new
                        {
                            WordId = 39L,
                            Key = "červený",
                            Priority = 1,
                            Value = "червоний"
                        },
                        new
                        {
                            WordId = 40L,
                            Key = "zelený",
                            Priority = 1,
                            Value = "зелений"
                        },
                        new
                        {
                            WordId = 41L,
                            Key = "čierny",
                            Priority = 1,
                            Value = "чорний"
                        },
                        new
                        {
                            WordId = 42L,
                            Key = "biely",
                            Priority = 1,
                            Value = "білий"
                        },
                        new
                        {
                            WordId = 43L,
                            Key = "modrý",
                            Priority = 1,
                            Value = "синій"
                        },
                        new
                        {
                            WordId = 44L,
                            Key = "žltý",
                            Priority = 1,
                            Value = "жовтий"
                        },
                        new
                        {
                            WordId = 45L,
                            Key = "tam",
                            Priority = 1,
                            Value = "там"
                        },
                        new
                        {
                            WordId = 46L,
                            Key = "tu",
                            Priority = 1,
                            Value = "тут"
                        },
                        new
                        {
                            WordId = 47L,
                            Key = "a",
                            Priority = 1,
                            Value = "і; та"
                        },
                        new
                        {
                            WordId = 48L,
                            Key = "alebo",
                            Priority = 1,
                            Value = "або"
                        },
                        new
                        {
                            WordId = 49L,
                            Key = "ja som ...",
                            Priority = 1,
                            Value = "Я є ..."
                        },
                        new
                        {
                            WordId = 50L,
                            Key = "ty si ...",
                            Priority = 1,
                            Value = "Ти є ..."
                        },
                        new
                        {
                            WordId = 51L,
                            Key = "on/ona/ono je ...",
                            Priority = 1,
                            Value = "він/вона/воно є ..."
                        },
                        new
                        {
                            WordId = 52L,
                            Key = "my sme ...",
                            Priority = 1,
                            Value = "ми є ..."
                        },
                        new
                        {
                            WordId = 53L,
                            Key = "vy ste ...",
                            Priority = 1,
                            Value = "Ви є ..."
                        },
                        new
                        {
                            WordId = 54L,
                            Key = "oni/ony sú ...",
                            Priority = 1,
                            Value = "вони є ..."
                        });
                });

            modelBuilder.Entity("Telelingo.EntityModels.ChatWord", b =>
                {
                    b.HasOne("Telelingo.EntityModels.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telelingo.EntityModels.Word", null)
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
