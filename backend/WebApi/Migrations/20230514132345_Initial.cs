using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "NOW()")
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
                values: new object[] { 1, new DateTime(2002, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 237, DateTimeKind.Utc).AddTicks(7966), "sophia@mohrbins.com", "dorris", "Austin", "Iste ipsa voluptatem et voluptatem impedit. Numquam in incidunt neque sed aut amet. Et ut quo modi quod. Laboriosam optio enim dicta quidem similique vel iure.", "9210262530", "https://loremflickr.com/640/480/abstract", "O'Conner" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 2, new DateTime(1966, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 238, DateTimeKind.Utc).AddTicks(5845), "clint@beahan.uk", true, "maurice.cummings", "Brant", "Et nihil sunt optio dolorem corporis. Quas et temporibus quasi quia blanditiis. Doloremque dolores quia perferendis. Repudiandae odit alias ut molestiae.", "0545617278", "https://loremflickr.com/640/480/abstract", "Ruecker" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 3, new DateTime(1905, 2, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 239, DateTimeKind.Utc).AddTicks(5024), "kaley.runolfsdottir@bode.ca", true, true, "allie_treutel", "Ward", "Dolorem a ut exercitationem et non inventore culpa est. Quidem tempora reiciendis sed ut quo. Quia eligendi optio nobis voluptas qui magnam. Corporis in id et numquam eum.", "3226467077", "https://loremflickr.com/640/480/abstract", "Hagenes" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 4, new DateTime(1914, 5, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 240, DateTimeKind.Utc).AddTicks(4702), "phyllis@wehner.com", true, "gay", "Johan", "Voluptatem cum qui consequatur labore minus aliquid ratione quis. Odit quod hic aut et voluptatem laboriosam et eligendi quo. Sed qui ipsum aspernatur enim quam est ex qui. Possimus velit sit necessitatibus maxime rem soluta qui similique.", "7530483234", "https://loremflickr.com/640/480/abstract", "Kihn" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 5, new DateTime(2015, 7, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 241, DateTimeKind.Utc).AddTicks(3628), "braden@veum.info", true, "gilda", "Mike", "Tempora consequatur qui est beatae rerum fuga in officia. Omnis cumque distinctio reiciendis. Dolorem quo voluptatibus deserunt laborum est. Ut ad voluptatibus laudantium et placeat.", "2969682559", "https://loremflickr.com/640/480/abstract", "Donnelly" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 6, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 242, DateTimeKind.Utc).AddTicks(2639), "erica@dickensmonahan.name", "helga", "Braulio", "Vel consequatur corrupti accusantium eos. Sint dolores consequuntur cum odio ratione. Delectus neque amet asperiores eius. Repellendus et repudiandae itaque nisi similique enim recusandae omnis ducimus.", "9413328560", "https://loremflickr.com/640/480/abstract", "Auer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 7, new DateTime(2003, 3, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 243, DateTimeKind.Utc).AddTicks(1617), "leonie.collier@turnervolkman.com", true, true, "miracle", "Bradford", "Quia incidunt deleniti veniam id odio est maxime eius. Ea ad sunt non recusandae modi voluptas at dignissimos ea. Numquam quo facere nostrum aut ipsa exercitationem.", "4885914051", "https://loremflickr.com/640/480/abstract", "Hyatt" },
                    { 8, new DateTime(1989, 10, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 243, DateTimeKind.Utc).AddTicks(7993), "maxime_sporer@schiller.uk", true, true, "iliana_mclaughlin", "Lorine", "Porro odit voluptatem unde sunt.", "6590124434", "https://loremflickr.com/640/480/abstract", "Hegmann" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 9, new DateTime(1976, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 244, DateTimeKind.Utc).AddTicks(4448), "guido_thompson@willms.us", true, "fanny.roberts", "Fausto", "Ut omnis pariatur est explicabo ullam earum sit consectetur.", "4903312410", "https://loremflickr.com/640/480/abstract", "Olson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 10, new DateTime(1919, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 14, 13, 23, 45, 245, DateTimeKind.Utc).AddTicks(994), "jean@kuphal.co.uk", true, true, "oswald", "Cierra", "Molestiae a ratione et quis molestias dolor iure reprehenderit occaecati. Aspernatur nam excepturi voluptatem voluptatum eaque velit.", "4892413186", "https://loremflickr.com/640/480/abstract", "Runte" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "amount", "created_at", "description", "name", "photo", "price", "technical_information", "updated_at", "user_id" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2023, 5, 14, 13, 23, 45, 246, DateTimeKind.Utc).AddTicks(5422), "Excepturi quasi inventore voluptatibus dolores ipsa magnam. Nisi ducimus ut omnis aperiam.", "Excepturi autem et fuga natus libero et aut. Eum beatae aut illo.", "https://loremflickr.com/640/480/abstract", 17m, "Culpa quae sunt voluptatem voluptatem nihil dolor dignissimos eaque sint. Qui ut animi voluptas neque dolore. Est laborum rerum ab et hic quia id et. Ut aut et animi doloremque. Magnam non dolores suscipit. Velit ut esse praesentium qui est cum iusto commodi quam. Incidunt quasi ut dolores aut doloremque aspernatur. Eaque omnis magni cum molestiae pariatur ut accusantium. Ad ipsum sit sit et impedit occaecati maxime itaque. Tempora quia eos inventore. Dolor occaecati eum repellat.", new DateTime(2023, 5, 14, 13, 23, 45, 246, DateTimeKind.Utc).AddTicks(5422), 1 },
                    { 2, 2, new DateTime(2023, 5, 14, 13, 23, 45, 247, DateTimeKind.Utc).AddTicks(7844), "Quo suscipit debitis ab.", "Et explicabo aut mollitia ipsum id iusto blanditiis.", "https://loremflickr.com/640/480/abstract", 16m, "Consequatur reprehenderit sit eaque possimus animi. Error dolorum repellat consectetur quis aliquid. Laboriosam odit et aliquam dolorem veniam. Maxime est aut enim minus qui quibusdam fugit iusto rerum. Aut dignissimos voluptatem officia eius odit. Nihil voluptatem qui tempora dolore illo cumque. Adipisci amet at laboriosam tempore a. Omnis inventore quibusdam accusamus qui est. Quia temporibus vel quo ut adipisci sit minus nisi. Distinctio animi aperiam animi veniam nostrum est. Magnam enim dolorem debitis optio ut non odio suscipit. Est harum repudiandae dolor quidem itaque. In dolor aperiam numquam porro tempore provident.", new DateTime(2023, 5, 14, 13, 23, 45, 247, DateTimeKind.Utc).AddTicks(7844), 2 },
                    { 3, 5, new DateTime(2023, 5, 14, 13, 23, 45, 248, DateTimeKind.Utc).AddTicks(8416), "Quae alias dicta aut voluptatem necessitatibus.", "Vel maiores iusto harum exercitationem aut aut. Possimus fugiat dolorem nobis dolorem accusantium rerum eum.", "https://loremflickr.com/640/480/abstract", 13m, "Sit ipsum atque voluptatum sunt. Voluptatem debitis officiis labore. Et quas modi voluptatum ipsam. Reprehenderit esse possimus ex. Totam aliquam qui impedit. Necessitatibus rem facilis et rerum rerum iste nesciunt. Et sed aut sit impedit doloribus. Sapiente nesciunt delectus minus. Optio aperiam neque explicabo cumque. Alias dolorem iste vero aut nemo. Voluptate aspernatur ipsa culpa molestiae rerum officia rerum. Non quis fugit eius perferendis.", new DateTime(2023, 5, 14, 13, 23, 45, 248, DateTimeKind.Utc).AddTicks(8417), 3 },
                    { 4, 7, new DateTime(2023, 5, 14, 13, 23, 45, 249, DateTimeKind.Utc).AddTicks(8479), "Doloribus dolor adipisci officia.", "Voluptatibus dolorem et non voluptatem quae.", "https://loremflickr.com/640/480/abstract", 20m, "Voluptas aspernatur suscipit autem dolores quibusdam doloribus libero ducimus. Nesciunt sunt eum tempore dignissimos iure ducimus voluptatem voluptatibus et. Aperiam maiores est reprehenderit. Modi et fugiat non totam dolorum eligendi laborum est consectetur. Molestiae adipisci maxime mollitia. Aut repellendus occaecati est iusto. Sint odio provident omnis fugiat rerum culpa impedit. Consequatur odit dolores excepturi quis. Adipisci alias doloremque magni. Voluptatum aut mollitia asperiores ea temporibus. Aspernatur tenetur nam iure. Vitae consequuntur repudiandae molestiae.", new DateTime(2023, 5, 14, 13, 23, 45, 249, DateTimeKind.Utc).AddTicks(8479), 4 },
                    { 5, 1, new DateTime(2023, 5, 14, 13, 23, 45, 251, DateTimeKind.Utc).AddTicks(3876), "Vel ut alias dolores esse cum provident quia expedita ut.", "Veritatis soluta eum et. Ex unde consequatur ab soluta. Est ut enim et nulla iste aut necessitatibus sint. Asperiores molestiae nihil et facilis enim ea.", "https://loremflickr.com/640/480/abstract", 12m, "Consequatur eum natus voluptates amet ducimus blanditiis sed. Voluptas vitae ea maxime asperiores. Aut accusantium suscipit expedita quisquam suscipit quis illum velit magnam. Tempora incidunt est modi eaque at. Repudiandae id ut at repellat. Voluptatem voluptas reprehenderit deserunt cupiditate amet alias rerum. Qui delectus ad blanditiis animi sit rerum velit et ut. Assumenda expedita aliquid sapiente mollitia assumenda id et. Reiciendis nam repellat amet at sit a esse. Et provident blanditiis hic sit cumque quis. Sed quod ut voluptatem dolores totam. Excepturi laboriosam in dicta. Quis corrupti sed enim unde consequuntur beatae dolor.", new DateTime(2023, 5, 14, 13, 23, 45, 251, DateTimeKind.Utc).AddTicks(3876), 5 },
                    { 6, 7, new DateTime(2023, 5, 14, 13, 23, 45, 252, DateTimeKind.Utc).AddTicks(7594), "Amet omnis odit sed fugiat voluptate excepturi quae. Rerum et aperiam excepturi quod. Quaerat in et consectetur ducimus mollitia doloremque ut in corrupti.", "Voluptas voluptas architecto vel quia consequatur beatae officia neque. Neque eum omnis totam explicabo non odio facilis. Quia necessitatibus et occaecati voluptates eum consequuntur sapiente a quam.", "https://loremflickr.com/640/480/abstract", 18m, "Molestiae nulla aut exercitationem rerum ut. Voluptatem quia nulla facilis sit corporis corrupti. Commodi voluptatem minus aliquid qui sint nihil repellendus aut ipsa. Repellendus est dolor autem magnam minus aspernatur. Vitae voluptatibus voluptate perspiciatis non eos atque. Ratione quo inventore odit est delectus minus. Cupiditate nisi dolores dolores. Aut ab deserunt natus voluptates rerum. Architecto harum aliquam cumque tempora. Voluptatem sunt aliquam rerum.", new DateTime(2023, 5, 14, 13, 23, 45, 252, DateTimeKind.Utc).AddTicks(7594), 6 },
                    { 7, 1, new DateTime(2023, 5, 14, 13, 23, 45, 254, DateTimeKind.Utc).AddTicks(2516), "Aperiam delectus dolor quia.", "Eum dolores in mollitia perferendis facere. Voluptas voluptatibus alias dolor assumenda dolor laborum doloribus velit. Vel qui ab expedita minus explicabo. Sint fugiat quia quo nam sit qui reiciendis officiis.", "https://loremflickr.com/640/480/abstract", 16m, "Eius magnam tempora quasi. Qui doloribus aspernatur error blanditiis accusantium. Nisi qui quod dolor ex. Adipisci culpa accusantium expedita voluptas non sit illo accusamus ut. Cumque officiis id qui iure omnis. Voluptates voluptates molestiae sunt aliquam. Aut et accusantium magnam facilis sint. Dolores repudiandae mollitia est sint cupiditate deleniti. Aut accusantium tenetur sed ipsam nesciunt ea. Est quisquam nostrum blanditiis rerum rem earum quo aut nihil. Delectus voluptatem earum ea eveniet beatae optio neque illum. Laboriosam et fugit quia vitae itaque. Officia facere nihil impedit aut quam.", new DateTime(2023, 5, 14, 13, 23, 45, 254, DateTimeKind.Utc).AddTicks(2516), 7 },
                    { 8, 5, new DateTime(2023, 5, 14, 13, 23, 45, 256, DateTimeKind.Utc).AddTicks(899), "Non odio itaque et velit omnis vero tenetur. Qui est saepe delectus quia. Accusamus sit voluptas vero aut dolores laborum. Omnis et sunt ut.", "Dicta molestias sed id voluptatem tempora non repellat adipisci expedita. Est eos qui hic quod tempora sint sit consequatur unde. Ex fuga molestiae adipisci odit perferendis itaque non ullam et. Perspiciatis sequi quas fuga amet ipsa.", "https://loremflickr.com/640/480/abstract", 12m, "Amet et aut nihil iure eum quasi facere. Nesciunt sit laudantium nostrum ex temporibus sapiente aut sed. A sint et sit et enim et aut esse reiciendis. A qui non quis earum nemo repellendus rerum quam. Voluptatum maxime et eos. Sint perferendis asperiores labore fuga qui. Labore fuga vel praesentium laudantium nesciunt eos eius atque placeat. Ratione voluptatem iste corporis. Assumenda tenetur est adipisci officiis unde sed porro est quisquam. Et laboriosam ullam dolore quis. Libero praesentium est et omnis eveniet et id. Quia consequatur et eaque quia numquam ut et ipsa.", new DateTime(2023, 5, 14, 13, 23, 45, 256, DateTimeKind.Utc).AddTicks(900), 8 },
                    { 9, 9, new DateTime(2023, 5, 14, 13, 23, 45, 257, DateTimeKind.Utc).AddTicks(6671), "Aut eius culpa autem. Consequatur dolorem ea asperiores. A voluptatem hic id quod sit consequuntur ut nulla occaecati.", "Aliquam saepe architecto culpa optio atque. Asperiores consectetur quia est. Non cum qui accusantium. Eum exercitationem distinctio earum.", "https://loremflickr.com/640/480/abstract", 20m, "Odit quisquam sunt impedit odio non. Omnis ab quibusdam qui et est fugiat exercitationem repudiandae. Aspernatur distinctio et cumque eos recusandae veniam. Enim perferendis qui ullam officiis repellat et neque eum aliquam. Sunt doloremque et ea numquam placeat provident. Id eius quidem eaque et autem ullam nihil omnis alias. Quis et numquam repellendus possimus. Consequuntur cum dolores nesciunt qui ex minima ea natus dolor. Autem corporis itaque omnis alias doloremque inventore. A ducimus natus cumque in est officia est nihil dolor. Eveniet deserunt quia est aut qui tenetur ut omnis rerum. Quia beatae nihil magni qui.", new DateTime(2023, 5, 14, 13, 23, 45, 257, DateTimeKind.Utc).AddTicks(6672), 9 },
                    { 10, 1, new DateTime(2023, 5, 14, 13, 23, 45, 259, DateTimeKind.Utc).AddTicks(2203), "Voluptas provident non ut voluptates. Corporis et aut eum ipsa. Ea totam doloribus voluptatem hic quasi et voluptatibus et. Et rerum minima quis.", "Facilis harum aperiam soluta animi beatae voluptas in suscipit aliquid. Sit aspernatur vero fuga nisi consequuntur illum tenetur et. Possimus maxime recusandae maiores repudiandae consectetur consequatur et incidunt. Dolores eos maxime libero similique fuga sed quos consequatur.", "https://loremflickr.com/640/480/abstract", 11m, "Et dicta non ut quo sunt est. Rerum illo eius libero. Enim minima occaecati ipsa. Error qui et inventore enim deleniti quod tempore. Qui quia repellendus qui deserunt error. Est hic omnis sed. Autem atque eius voluptates neque explicabo velit. Id eos temporibus commodi similique. Iste et soluta sit aut illum voluptas perspiciatis dolores omnis. Cumque labore aut illum est reiciendis nihil. Ab saepe est qui deleniti.", new DateTime(2023, 5, 14, 13, 23, 45, 259, DateTimeKind.Utc).AddTicks(2204), 10 }
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
