﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230528030104_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("photo");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("price");

                    b.Property<string>("TechnicalInformation")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("technical_information");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 8,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 326, DateTimeKind.Utc).AddTicks(5018),
                            Description = "Itaque architecto sunt quibusdam. Natus hic nihil reiciendis voluptatum repellat et tenetur. Quasi nihil non repellat sed velit veritatis.",
                            Name = "Est fugiat blanditiis et.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 14m,
                            TechnicalInformation = "Et cum expedita officia enim eaque. Iure et nemo consequatur. Incidunt laborum similique facere voluptas excepturi et similique rerum. Placeat et omnis voluptatibus magnam voluptates perspiciatis. Neque pariatur et quis aspernatur autem libero ut tempore aspernatur. Odit sit ut nihil in. Vel ipsa rerum molestiae sit qui optio doloribus. Optio sed iste ratione non ad tempore aliquid doloribus voluptatem. Reiciendis veniam reprehenderit magni quam non possimus. Cum nisi molestiae ipsum atque sunt. Sit quod et magnam qui quidem. Voluptatem veniam possimus officia magni nihil recusandae id odit minima. Velit rerum aspernatur et earum eveniet debitis.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 326, DateTimeKind.Utc).AddTicks(5018),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 327, DateTimeKind.Utc).AddTicks(6856),
                            Description = "Ratione aspernatur ab animi sunt accusamus blanditiis et hic.",
                            Name = "Omnis et est laborum vel. Laudantium voluptas rerum cum magnam pariatur saepe odio fugit excepturi. Laudantium eos rerum quia sed voluptatem autem laboriosam laudantium. Ex dolorum et cupiditate est non et amet qui.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 14m,
                            TechnicalInformation = "Qui voluptate quod suscipit accusantium molestiae. Ducimus quisquam quas reprehenderit. Distinctio placeat voluptate modi rerum natus modi consequatur. Aut et et et. Sunt atque non aut quos. Et voluptas illum voluptatum est velit in est repellat. Ut sunt ut ea. Natus nobis quas fugit. Et eos et ut placeat porro. Optio corrupti id consequuntur et provident et omnis.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 327, DateTimeKind.Utc).AddTicks(6857),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Amount = 6,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 329, DateTimeKind.Utc).AddTicks(240),
                            Description = "Iusto consequuntur laborum molestiae molestiae eos nisi quasi distinctio corrupti. Et quos fugiat explicabo exercitationem esse sed.",
                            Name = "Tempore repellat harum ut iste autem ullam commodi cupiditate nemo. Ut ad totam accusantium asperiores enim doloribus et et. Qui dolorem assumenda totam.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 17m,
                            TechnicalInformation = "Fugiat quidem et qui animi molestias qui sed. Ut nostrum autem quam quos ducimus quia rerum vel. Ut id perspiciatis voluptas veritatis totam. Fuga est quia eos voluptas quia rem. Cupiditate veritatis possimus non aut voluptas tenetur accusantium quis. Enim sapiente occaecati unde dolore. Consequuntur corrupti cum laborum earum sed amet vitae sapiente. Atque itaque officiis facere doloribus odit voluptatem. Sit fugit enim explicabo ut quia qui quas. Consectetur porro distinctio nihil.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 329, DateTimeKind.Utc).AddTicks(240),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            Amount = 1,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 330, DateTimeKind.Utc).AddTicks(3143),
                            Description = "Eius omnis eligendi animi rerum tempora aut.",
                            Name = "Hic et facere excepturi. Debitis in placeat dolorem aspernatur corporis quis.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 18m,
                            TechnicalInformation = "Quibusdam itaque repellendus libero est vel. Quo explicabo earum est architecto qui atque eveniet sequi. Qui exercitationem sed molestias explicabo dolor. Quaerat temporibus quo ex. Voluptas vitae blanditiis dignissimos voluptatem et. At et enim modi consequuntur laborum et aperiam maiores pariatur. Amet quibusdam tenetur sit sit. Rerum et ipsa sapiente voluptatem vel. Ut voluptas molestias qui magnam quibusdam error adipisci aliquid dolor. Totam est quae autem non ea excepturi unde adipisci est. Qui voluptatem et est autem qui tenetur possimus aut. Velit modi esse incidunt et. Asperiores consequatur voluptas laboriosam.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 330, DateTimeKind.Utc).AddTicks(3143),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            Amount = 7,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 331, DateTimeKind.Utc).AddTicks(6180),
                            Description = "Officiis perspiciatis consequuntur quis. Voluptas sapiente ut iusto qui. Enim sunt aut eos.",
                            Name = "Ducimus aperiam commodi quo repudiandae culpa cupiditate voluptas voluptatem.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 20m,
                            TechnicalInformation = "Quia aut recusandae omnis officia. Architecto dolorem non aut veritatis rerum debitis. Numquam omnis nobis minima officia magni. Ullam doloribus ea enim voluptatibus doloremque itaque. Praesentium et et voluptatem. Suscipit beatae non consequuntur sit aspernatur fugit. Eligendi nisi ex eveniet similique necessitatibus labore. Itaque beatae magni rem magnam aspernatur. Adipisci dignissimos doloribus id vero eum dicta. Eos molestiae sequi rerum omnis ut cum deserunt qui. Modi qui non in officia eos. Sit facere ipsam aperiam suscipit rerum reprehenderit dolorem sit. Deleniti sed aliquam velit iste et.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 331, DateTimeKind.Utc).AddTicks(6180),
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            Amount = 3,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 332, DateTimeKind.Utc).AddTicks(9254),
                            Description = "Quia id temporibus quasi quidem fuga ut et accusamus. Accusamus et incidunt qui. Voluptatibus non qui maiores quas.",
                            Name = "Dolorem eligendi et aspernatur rerum voluptatum animi. Aut corporis expedita quibusdam.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 18m,
                            TechnicalInformation = "Tempore nulla officiis quia corrupti voluptatum tenetur magnam ad. Cupiditate ut facere sint. Possimus et occaecati laborum dolores eum rerum. In voluptas commodi officiis iure pariatur ea veritatis a. Quis sunt alias aut tenetur eaque recusandae quisquam. Consequatur et laboriosam cum earum amet tenetur qui porro. Ipsum consequatur et reiciendis aut aspernatur itaque deleniti. Quia laudantium eligendi reprehenderit ea pariatur inventore ipsam omnis similique. Non dolorum odit unde illo temporibus. Quasi molestias quia voluptas quia omnis rem voluptas itaque officia.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 332, DateTimeKind.Utc).AddTicks(9254),
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            Amount = 5,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 333, DateTimeKind.Utc).AddTicks(9918),
                            Description = "Ipsum fugit delectus non incidunt qui enim nisi aut. Ea expedita molestias inventore.",
                            Name = "Modi occaecati repudiandae blanditiis quis qui.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 16m,
                            TechnicalInformation = "Tempora eius illum pariatur laudantium. Aliquid dolores sit sunt sed aliquid est. Aut mollitia rem labore et ut consequuntur. Alias corporis quasi velit reprehenderit adipisci quasi unde saepe. Voluptate eos fugit dolores sequi ullam voluptate. Temporibus tempore non sed beatae perspiciatis fuga. Eos inventore vero exercitationem incidunt aperiam maiores et. Suscipit est magni dolores ea fugit. Ducimus ullam ut dolor aliquam impedit aut minima voluptatum. Eveniet nihil nesciunt repellendus alias.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 333, DateTimeKind.Utc).AddTicks(9918),
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            Amount = 9,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 335, DateTimeKind.Utc).AddTicks(1336),
                            Description = "Eum praesentium ut et facere culpa. Aut tempore provident quibusdam delectus tenetur asperiores voluptates.",
                            Name = "Aut molestias optio voluptates eius ducimus qui maxime.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 10m,
                            TechnicalInformation = "Mollitia ut laudantium assumenda tempora quidem excepturi. Dolores explicabo est voluptate quae et recusandae ratione alias. Omnis consequatur dolores sint doloremque ut quis quod dolorem nam. Iure et eius magnam ea maiores inventore. Est consequatur voluptatem quis sed vel qui eos. Et ratione dolores rerum ea dolorem similique consectetur veniam. Quia minima sequi quasi autem et harum. Est quisquam similique aut. In aut optio deserunt ut. Vitae rerum reiciendis velit vero consectetur impedit.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 335, DateTimeKind.Utc).AddTicks(1336),
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            Amount = 3,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 336, DateTimeKind.Utc).AddTicks(5835),
                            Description = "Voluptas consectetur ea placeat sequi qui.",
                            Name = "Omnis quis voluptatibus omnis cum quibusdam ut dolorum sunt quis. Reiciendis quaerat et tenetur dicta provident velit. Sunt ut voluptas fugiat in expedita at ut delectus.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 17m,
                            TechnicalInformation = "Numquam et nihil quidem numquam autem neque nihil. Nam quaerat cum non quod quia autem occaecati quia. Consequatur delectus architecto aut est consequatur nemo distinctio quo magnam. Hic natus quaerat assumenda. Est occaecati quasi delectus voluptates corporis placeat. Optio ipsum voluptas ducimus dolor voluptate quasi. Perspiciatis quo mollitia est quia ipsum. Deleniti maiores dolores expedita odio qui officia repellendus. Rerum laboriosam ut voluptatem sint sit ducimus sunt impedit. Voluptatibus id nihil iste et odit. Voluptatibus omnis aut reprehenderit aliquid vel ut consectetur tempora non.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 336, DateTimeKind.Utc).AddTicks(5836),
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            Amount = 8,
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 338, DateTimeKind.Utc).AddTicks(2549),
                            Description = "Asperiores quia voluptatem magnam consequatur. Occaecati maxime alias possimus cupiditate rerum qui eveniet. Aut ut molestias aspernatur dolorum voluptate blanditiis.",
                            Name = "Voluptate asperiores alias corporis quia non. Laudantium natus qui commodi aut aspernatur. Commodi reprehenderit quis placeat.",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Price = 10m,
                            TechnicalInformation = "Ut ab asperiores asperiores dolorum est iure architecto fugit. Fuga voluptatem repellat enim. Voluptatem sit magnam atque aut earum ratione. Et repellat sequi et hic sint nisi commodi aperiam. Est et natus error velit accusantium laborum. Aliquid in dicta quia ad veritatis inventore occaecati. Animi et delectus sed est eum blanditiis aperiam culpa harum. Ut laudantium est voluptatem quia delectus dolore libero corporis commodi. Autem temporibus voluptatem mollitia quos ea voluptatem possimus. Et quis sint corrupti laborum dignissimos nesciunt maiores non. Amet dignissimos quia asperiores. Dolores perferendis et architecto quam aliquid perspiciatis maxime voluptas natus. Vero ut necessitatibus sed.",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 338, DateTimeKind.Utc).AddTicks(2549),
                            UserId = 10
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_active");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("is_admin");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("login");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("photo");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("surname");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2013, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 318, DateTimeKind.Utc).AddTicks(4765),
                            Email = "miguel.boyle@hagenes.us",
                            IsActive = false,
                            IsAdmin = false,
                            Login = "isidro",
                            Name = "Genesis",
                            Password = "Expedita corrupti non est.",
                            Phone = "5640555599",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Homenick",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 318, DateTimeKind.Utc).AddTicks(4765)
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2015, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 319, DateTimeKind.Utc).AddTicks(2880),
                            Email = "eliza_fisher@conn.uk",
                            IsActive = false,
                            IsAdmin = true,
                            Login = "itzel.huel",
                            Name = "Harvey",
                            Password = "Quos repellat rerum non et velit recusandae. Eum non tempore rerum cupiditate omnis doloremque qui aut. Fuga sed autem qui ea illo et laborum.",
                            Phone = "8462648963",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Herman",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 319, DateTimeKind.Utc).AddTicks(2881)
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1955, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 320, DateTimeKind.Utc).AddTicks(1961),
                            Email = "rosalinda@bergnaum.biz",
                            IsActive = false,
                            IsAdmin = true,
                            Login = "dulce.gottlieb",
                            Name = "Jordyn",
                            Password = "Illo totam consequuntur et illo ducimus ad nisi voluptatem. Quia animi aperiam numquam rerum quam facilis omnis nostrum. Exercitationem voluptatibus veritatis molestiae rerum voluptate. Nobis nulla at odio et qui quaerat tempora est.",
                            Phone = "5963973341",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Stamm",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 320, DateTimeKind.Utc).AddTicks(1961)
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1911, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 320, DateTimeKind.Utc).AddTicks(9083),
                            Email = "loyal@dooley.com",
                            IsActive = false,
                            IsAdmin = true,
                            Login = "dangelo",
                            Name = "Connor",
                            Password = "Eos quis ut recusandae et dicta sapiente. Expedita qui rerum aut asperiores quo sunt. Veritatis incidunt sed distinctio sunt qui et sit.",
                            Phone = "2144968187",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Watsica",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 320, DateTimeKind.Utc).AddTicks(9083)
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1944, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 321, DateTimeKind.Utc).AddTicks(4545),
                            Email = "maci@goldner.com",
                            IsActive = true,
                            IsAdmin = true,
                            Login = "alanis",
                            Name = "Sean",
                            Password = "Molestias repellat at quia amet totam ut excepturi.",
                            Phone = "7644720901",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Purdy",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 321, DateTimeKind.Utc).AddTicks(4546)
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1967, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 322, DateTimeKind.Utc).AddTicks(260),
                            Email = "obie@sawaynweber.name",
                            IsActive = true,
                            IsAdmin = false,
                            Login = "antonietta.schmidt",
                            Name = "Bernadette",
                            Password = "Debitis non quia consequatur consequatur tenetur.",
                            Phone = "0043652204",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Nitzsche",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 322, DateTimeKind.Utc).AddTicks(261)
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1962, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 322, DateTimeKind.Utc).AddTicks(6621),
                            Email = "jamil.kilback@veum.ca",
                            IsActive = false,
                            IsAdmin = true,
                            Login = "shaina.howell",
                            Name = "Melody",
                            Password = "Sint tempora eos quaerat enim dolorem cum.",
                            Phone = "3622623241",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Fadel",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 322, DateTimeKind.Utc).AddTicks(6621)
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1930, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 323, DateTimeKind.Utc).AddTicks(2208),
                            Email = "dewayne.ritchie@lehner.info",
                            IsActive = true,
                            IsAdmin = false,
                            Login = "maryam_stiedemann",
                            Name = "Joelle",
                            Password = "Nulla sed aut atque deserunt.",
                            Phone = "0345036115",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Halvorson",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 323, DateTimeKind.Utc).AddTicks(2209)
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(1978, 10, 21, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 324, DateTimeKind.Utc).AddTicks(839),
                            Email = "talia@sipes.co.uk",
                            IsActive = false,
                            IsAdmin = false,
                            Login = "clotilde.flatley",
                            Name = "Alford",
                            Password = "Dolor itaque iusto aperiam fugiat nihil voluptatem sed praesentium. Ut quo voluptas dolore magnam. Sint tempore tempore quod quo qui sapiente. Ad et magnam vero ut nostrum eos facilis.",
                            Phone = "1424430739",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "West",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 324, DateTimeKind.Utc).AddTicks(839)
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(2007, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc),
                            CreatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 324, DateTimeKind.Utc).AddTicks(8849),
                            Email = "myriam@kshlerin.info",
                            IsActive = false,
                            IsAdmin = true,
                            Login = "robb_baumbach",
                            Name = "Riley",
                            Password = "Non pariatur quam vel debitis consequuntur. Adipisci nobis autem consequatur illum. Aliquam mollitia cum maxime laborum soluta ea velit. Quia voluptate molestias dolorem ipsum sit vero et.",
                            Phone = "4860274628",
                            Photo = "https://loremflickr.com/640/480/abstract",
                            Surname = "Jakubowski",
                            UpdatedAt = new DateTime(2023, 5, 28, 3, 1, 4, 324, DateTimeKind.Utc).AddTicks(8849)
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}