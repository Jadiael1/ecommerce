using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Migration20230521012359 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    login = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birth_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    photo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_admin = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP "),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    photo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    technical_information = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "UTC_TIMESTAMP()"),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "UTC_TIMESTAMP()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                    table.ForeignKey(
                        name: "FK_Products_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 1, new DateTime(1954, 8, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 512, DateTimeKind.Utc).AddTicks(470), "idell@fadel.com", "bryon", "Mossie", "Doloribus ut id facere et ab.", "4149297509", "https://loremflickr.com/640/480/abstract", "Towne" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 2, new DateTime(1924, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 512, DateTimeKind.Utc).AddTicks(5304), "rita.ruecker@mccullough.co.uk", true, true, "graham", "Cecile", "Neque consectetur fugit similique nihil et nihil et magnam repellat. Neque officiis officiis et.", "7834931970", "https://loremflickr.com/640/480/abstract", "Blick" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 3, new DateTime(1913, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 512, DateTimeKind.Utc).AddTicks(9460), "houston_hyatt@leannon.co.uk", "wiley", "Amina", "Cum eveniet dolorem ab tempore commodi et est.", "0768136148", "https://loremflickr.com/640/480/abstract", "Corwin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 4, new DateTime(1940, 8, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 513, DateTimeKind.Utc).AddTicks(4289), "cara@leannon.name", true, true, "amir", "Destiney", "Aut repudiandae aliquam occaecati. Praesentium dolor libero a qui voluptas et.", "5360938382", "https://loremflickr.com/640/480/abstract", "Lehner" },
                    { 5, new DateTime(1933, 8, 9, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 514, DateTimeKind.Utc).AddTicks(232), "magdalen@dietrich.uk", true, true, "charlene.blanda", "Ciara", "Omnis qui iure illo quo quos quia. Excepturi ut maxime qui unde a odio rerum aut. Inventore quis soluta sint ea consectetur quam laudantium.", "9327830512", "https://loremflickr.com/640/480/abstract", "Mohr" },
                    { 6, new DateTime(1902, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 514, DateTimeKind.Utc).AddTicks(5048), "alysson@leuschke.co.uk", true, true, "torey", "Moses", "Aspernatur excepturi aut expedita. Et et dolores et quibusdam.", "2962191363", "https://loremflickr.com/640/480/abstract", "Wintheiser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 7, new DateTime(2018, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 514, DateTimeKind.Utc).AddTicks(9977), "everardo.steuber@blanda.co.uk", true, "mallie", "Dean", "Cumque voluptates delectus ea sequi soluta. Voluptates earum neque perferendis voluptatem cum cumque.", "1931092036", "https://loremflickr.com/640/480/abstract", "Spencer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 8, new DateTime(1903, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 515, DateTimeKind.Utc).AddTicks(6305), "doyle.cremin@kassulke.biz", true, "buddy", "Alfredo", "Et autem est impedit tempora aspernatur. Exercitationem occaecati et expedita veniam fugiat in voluptas occaecati. Dolores deleniti unde saepe dignissimos dolor blanditiis voluptatem. Impedit voluptas id odit.", "4833079151", "https://loremflickr.com/640/480/abstract", "Luettgen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 9, new DateTime(1967, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 516, DateTimeKind.Utc).AddTicks(1775), "rollin_cole@oharalubowitz.biz", true, true, "olaf", "Mallory", "Cum est qui dignissimos repellendus beatae qui dolore. Cumque sed sed nesciunt veritatis vero ullam.", "4490828977", "https://loremflickr.com/640/480/abstract", "Fritsch" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 10, new DateTime(1938, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 24, 3, 516, DateTimeKind.Utc).AddTicks(6768), "ralph.oberbrunner@spenceroconner.ca", true, "watson_mayer", "Jayda", "Totam et deleniti consectetur magni rerum. Libero perferendis voluptatem magni.", "8271100459", "https://loremflickr.com/640/480/abstract", "Labadie" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "amount", "created_at", "description", "name", "photo", "price", "technical_information", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2023, 5, 21, 4, 24, 3, 518, DateTimeKind.Utc).AddTicks(998), "Ut labore quidem consequatur reprehenderit. Sapiente rerum nihil a consequatur iusto et ex. Ut omnis fugiat eligendi distinctio voluptatem omnis ad est.", "Porro voluptatibus deserunt quia quas aut aut doloremque rerum commodi. Nam hic placeat quas quia atque dolore harum est consequuntur. Deleniti sint eum possimus omnis et sit quo tempore hic.", "https://loremflickr.com/640/480/abstract", 14m, "Et officiis necessitatibus autem in corrupti omnis perspiciatis harum ut. Non aut quia nobis at animi dolor omnis nostrum. Corrupti dolores deleniti omnis harum nesciunt. Voluptate odio est nam sapiente maiores. Quod eaque animi ut ex alias velit iusto occaecati. Quos qui sint voluptas eos nihil quae corporis reiciendis. Assumenda ipsa velit illo voluptatem modi eius velit assumenda. Magni natus sed eum quis est fugiat velit dolor sit. Adipisci rem voluptatibus eos. Consequuntur consequatur culpa sunt nostrum ullam non optio sit voluptatem. Sint et reprehenderit doloremque veniam sunt molestiae qui dolorum.", new DateTime(2023, 5, 21, 4, 24, 3, 518, DateTimeKind.Utc).AddTicks(999), 1 },
                    { 2, 9, new DateTime(2023, 5, 21, 4, 24, 3, 519, DateTimeKind.Utc).AddTicks(127), "Totam repellat dicta et neque.", "Quo porro sequi corrupti cumque quasi qui et sed sunt. Unde nam omnis non assumenda fugit repudiandae esse.", "https://loremflickr.com/640/480/abstract", 13m, "Iure fuga illum quia fugit et. Consequatur eveniet enim consequatur fugiat error. Aut aperiam quidem rerum. Eaque id sint totam optio sed ut eum nostrum. Quos cupiditate necessitatibus quia corrupti in. Nulla magnam nostrum laborum enim aut ab. Alias eveniet qui velit et occaecati in non cupiditate. Qui molestiae quidem non et officia consequuntur qui neque recusandae. Id officia modi explicabo nobis autem veritatis iusto dolorem. Harum modi officiis iusto ut quibusdam error. Excepturi odio voluptatem odio voluptatem eum officia non accusamus.", new DateTime(2023, 5, 21, 4, 24, 3, 519, DateTimeKind.Utc).AddTicks(127), 2 },
                    { 3, 8, new DateTime(2023, 5, 21, 4, 24, 3, 520, DateTimeKind.Utc).AddTicks(1002), "Neque ullam officia ut reiciendis autem est. In ut nihil perferendis perferendis id omnis architecto aut enim.", "Voluptatum iusto dolores facilis accusantium nostrum non esse. At ullam qui distinctio praesentium ut et consequuntur maxime. Aut nulla dolores vitae.", "https://loremflickr.com/640/480/abstract", 12m, "Inventore nobis maiores facere consequatur nihil consequuntur laudantium nesciunt aut. Nostrum enim quis voluptate eius quaerat ut quis et. Sunt ullam optio est eum laboriosam exercitationem tenetur hic aspernatur. Sapiente libero nostrum ea sunt. Soluta exercitationem optio ut voluptas. Iure voluptatem occaecati consectetur. Aperiam occaecati qui commodi unde quia et voluptatem qui nihil. Tenetur qui maiores eos voluptas quia consequatur aut a officia. Minus est deserunt occaecati non. Omnis ea eaque voluptates quia. Occaecati et possimus placeat error omnis nihil et. Amet consectetur saepe saepe ipsam.", new DateTime(2023, 5, 21, 4, 24, 3, 520, DateTimeKind.Utc).AddTicks(1003), 3 },
                    { 4, 3, new DateTime(2023, 5, 21, 4, 24, 3, 521, DateTimeKind.Utc).AddTicks(1317), "Cumque rerum nesciunt dolor nemo animi velit reprehenderit quo odio. Consequatur modi molestiae dolore soluta. Cum repellendus illo explicabo laboriosam sunt.", "Voluptas quo nihil debitis rerum inventore et. Quae qui culpa nobis magni. Ipsam rerum molestiae corrupti quo eaque distinctio.", "https://loremflickr.com/640/480/abstract", 11m, "Voluptatem qui nihil et eos et est aspernatur et nemo. Dolores officiis et architecto sit ut ad architecto error. Labore voluptatem sequi deserunt accusantium eos iure. Veniam culpa qui dolorum. Et vel illo repellendus voluptates provident iste tempore sed quo. Facere ratione quia eveniet exercitationem. Cupiditate vel voluptates consequuntur aut et in assumenda. Minus sapiente quae commodi eveniet dolor voluptatem dicta. Saepe aut autem quam et est consequatur sed libero. Quia sequi voluptate qui voluptates aperiam et necessitatibus odio.", new DateTime(2023, 5, 21, 4, 24, 3, 521, DateTimeKind.Utc).AddTicks(1317), 4 },
                    { 5, 4, new DateTime(2023, 5, 21, 4, 24, 3, 521, DateTimeKind.Utc).AddTicks(8559), "Repellendus expedita dicta qui excepturi rerum minus.", "Sint quis neque voluptate eum corporis nisi vero ipsam.", "https://loremflickr.com/640/480/abstract", 12m, "Aliquid delectus odio eum consequuntur. Dolor temporibus qui sed. Ut perferendis sit ut. Alias dolores et consequuntur aperiam quam quam suscipit ut ea. Ea dignissimos velit qui nesciunt quia odio. Et soluta iusto nihil corporis cumque. Totam corrupti corporis numquam totam. Aperiam totam ad et sequi explicabo amet nemo. Molestiae id ex accusantium. Modi praesentium consequatur eligendi fugiat et. Voluptatem natus provident totam sint id consectetur.", new DateTime(2023, 5, 21, 4, 24, 3, 521, DateTimeKind.Utc).AddTicks(8559), 5 },
                    { 6, 10, new DateTime(2023, 5, 21, 4, 24, 3, 522, DateTimeKind.Utc).AddTicks(9275), "Ea ipsum repellat labore animi explicabo quo porro recusandae sunt. Dolorem commodi dolor consequuntur tenetur excepturi nihil dignissimos sequi id.", "Pariatur hic corrupti sit.", "https://loremflickr.com/640/480/abstract", 11m, "Necessitatibus occaecati et quia ea eum esse error et soluta. Sed est magnam aliquam sunt quia possimus aperiam occaecati. Et veritatis consequatur vel et dicta. Reiciendis culpa et quibusdam odio saepe. Quibusdam voluptatem est vitae adipisci temporibus expedita ut optio molestias. Culpa dolores eius recusandae sit quos. Ad enim ut sint. Omnis voluptas sint a earum. Repellendus saepe repudiandae ut est veritatis commodi aspernatur quod voluptas. Doloribus quis laudantium ullam sed non dolore facere reprehenderit molestiae. Rerum id eaque et voluptas sint inventore aspernatur accusantium. Soluta nam quidem aut. Eligendi consequuntur hic repellat iure aut ea sunt voluptas qui.", new DateTime(2023, 5, 21, 4, 24, 3, 522, DateTimeKind.Utc).AddTicks(9276), 6 },
                    { 7, 9, new DateTime(2023, 5, 21, 4, 24, 3, 524, DateTimeKind.Utc).AddTicks(1811), "Ipsum vel veniam reiciendis iure nisi aut repudiandae autem. Nemo aliquid omnis inventore voluptatem dignissimos quia porro consequatur quia. Blanditiis et aut necessitatibus et. Quis enim neque deserunt.", "Quis consequuntur eius autem ut voluptas distinctio. Hic nemo tempore qui maiores sapiente quod.", "https://loremflickr.com/640/480/abstract", 19m, "Quia tempore doloribus iusto animi at neque. Molestias quaerat est consectetur ullam qui sint magnam neque aut. Fugit sit beatae omnis. Ut enim inventore molestiae vel quam dolor sed qui ducimus. Temporibus dignissimos rerum aut qui esse. Qui quaerat at et error. Aut ad illo rerum ipsa reiciendis modi nulla odio commodi. Quis excepturi quia temporibus cupiditate eveniet. Totam eius sunt reprehenderit accusamus recusandae qui et. Quo voluptatem aut molestias quia et ipsa in eveniet aperiam. Repellendus incidunt non enim commodi sit quo vitae illo. Iusto doloremque aut veniam libero. Omnis et dolor sapiente odio error.", new DateTime(2023, 5, 21, 4, 24, 3, 524, DateTimeKind.Utc).AddTicks(1811), 7 },
                    { 8, 6, new DateTime(2023, 5, 21, 4, 24, 3, 525, DateTimeKind.Utc).AddTicks(4004), "Eum omnis animi reprehenderit impedit necessitatibus molestias optio autem omnis. Earum nihil repellendus ut velit quae aut quo quam. Fugit omnis amet saepe necessitatibus quo.", "Non omnis incidunt ipsum temporibus facere cum molestiae quia. Qui ut at aut atque voluptatum non rerum accusantium. Quia accusantium ratione dolores iure.", "https://loremflickr.com/640/480/abstract", 14m, "Blanditiis libero dolorem omnis nihil atque vitae quibusdam harum sapiente. Enim aut occaecati voluptates voluptate velit consequatur sit laborum magni. Magni voluptas blanditiis deserunt. Illum velit non harum atque dolor velit ut distinctio. At sed vel ut labore. Optio voluptatem sed mollitia quidem sequi repellendus. Fugiat sed dolorum et voluptates ducimus quas. Consectetur nobis et dolores doloremque alias sint. Modi similique et excepturi impedit totam quia est suscipit voluptatem. Fuga tempore repudiandae saepe. Omnis dolores dolorum molestiae similique. Voluptates qui est velit voluptatum harum.", new DateTime(2023, 5, 21, 4, 24, 3, 525, DateTimeKind.Utc).AddTicks(4004), 8 },
                    { 9, 1, new DateTime(2023, 5, 21, 4, 24, 3, 526, DateTimeKind.Utc).AddTicks(3426), "Quaerat nemo magni iste suscipit.", "Esse sunt repudiandae esse aut non. Non debitis ullam incidunt dolores molestias hic voluptates eaque enim. Consequatur rerum tempore incidunt maiores aut quaerat sed. Est non qui voluptas.", "https://loremflickr.com/640/480/abstract", 10m, "Et est aut voluptates et voluptatem laborum ut consectetur. Ipsam incidunt reprehenderit culpa dolor. Suscipit eveniet unde adipisci nobis quos modi possimus. Consequatur cum non rem debitis eius. Assumenda provident dolore sit temporibus. Consequatur aperiam minima libero aut. Sit ea alias voluptas eos. Ea tempore officia iure odit magnam aliquid voluptates dicta atque. Eius blanditiis et qui suscipit distinctio vero laborum aliquid. Id numquam necessitatibus eum atque delectus sapiente culpa aliquam.", new DateTime(2023, 5, 21, 4, 24, 3, 526, DateTimeKind.Utc).AddTicks(3426), 9 },
                    { 10, 3, new DateTime(2023, 5, 21, 4, 24, 3, 527, DateTimeKind.Utc).AddTicks(5513), "Sint quis quibusdam recusandae sed et facilis repellat at. Voluptas omnis rerum fugit omnis sed et nihil.", "Voluptas harum dolores architecto quis autem. Sunt molestias dignissimos unde praesentium similique. Beatae sint ex eos nulla rerum corporis nesciunt id. Expedita minus et ut repellendus voluptatem et.", "https://loremflickr.com/640/480/abstract", 15m, "Quo ut deleniti id nostrum a eaque sequi voluptatum porro. Velit aspernatur amet laboriosam est et earum. Optio dicta velit laborum et nam sapiente qui sapiente. Eius quia autem veritatis aut numquam repellendus consequatur. Assumenda nihil alias nulla consequuntur est ratione corrupti architecto natus. Provident mollitia rerum nostrum enim sit occaecati. Aliquam assumenda iste minus quos quia quia vel quam. Et quaerat rem molestias officia. Quis similique aut nobis et reprehenderit est. Voluptatem facere omnis eum est doloribus fugiat et. Et quod omnis rerum quisquam.", new DateTime(2023, 5, 21, 4, 24, 3, 527, DateTimeKind.Utc).AddTicks(5514), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_user_id",
                table: "Products",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
