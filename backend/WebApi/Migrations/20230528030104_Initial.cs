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
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
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
                    price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    technical_information = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
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
                values: new object[] { 1, new DateTime(2013, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 318, DateTimeKind.Utc).AddTicks(4765), "miguel.boyle@hagenes.us", "isidro", "Genesis", "Expedita corrupti non est.", "5640555599", "https://loremflickr.com/640/480/abstract", "Homenick" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 2, new DateTime(2015, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 319, DateTimeKind.Utc).AddTicks(2880), "eliza_fisher@conn.uk", true, "itzel.huel", "Harvey", "Quos repellat rerum non et velit recusandae. Eum non tempore rerum cupiditate omnis doloremque qui aut. Fuga sed autem qui ea illo et laborum.", "8462648963", "https://loremflickr.com/640/480/abstract", "Herman" },
                    { 3, new DateTime(1955, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 320, DateTimeKind.Utc).AddTicks(1961), "rosalinda@bergnaum.biz", true, "dulce.gottlieb", "Jordyn", "Illo totam consequuntur et illo ducimus ad nisi voluptatem. Quia animi aperiam numquam rerum quam facilis omnis nostrum. Exercitationem voluptatibus veritatis molestiae rerum voluptate. Nobis nulla at odio et qui quaerat tempora est.", "5963973341", "https://loremflickr.com/640/480/abstract", "Stamm" },
                    { 4, new DateTime(1911, 9, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 320, DateTimeKind.Utc).AddTicks(9083), "loyal@dooley.com", true, "dangelo", "Connor", "Eos quis ut recusandae et dicta sapiente. Expedita qui rerum aut asperiores quo sunt. Veritatis incidunt sed distinctio sunt qui et sit.", "2144968187", "https://loremflickr.com/640/480/abstract", "Watsica" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 5, new DateTime(1944, 8, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 321, DateTimeKind.Utc).AddTicks(4545), "maci@goldner.com", true, true, "alanis", "Sean", "Molestias repellat at quia amet totam ut excepturi.", "7644720901", "https://loremflickr.com/640/480/abstract", "Purdy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 6, new DateTime(1967, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 322, DateTimeKind.Utc).AddTicks(260), "obie@sawaynweber.name", true, "antonietta.schmidt", "Bernadette", "Debitis non quia consequatur consequatur tenetur.", "0043652204", "https://loremflickr.com/640/480/abstract", "Nitzsche" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 7, new DateTime(1962, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 322, DateTimeKind.Utc).AddTicks(6621), "jamil.kilback@veum.ca", true, "shaina.howell", "Melody", "Sint tempora eos quaerat enim dolorem cum.", "3622623241", "https://loremflickr.com/640/480/abstract", "Fadel" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 8, new DateTime(1930, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 323, DateTimeKind.Utc).AddTicks(2208), "dewayne.ritchie@lehner.info", true, "maryam_stiedemann", "Joelle", "Nulla sed aut atque deserunt.", "0345036115", "https://loremflickr.com/640/480/abstract", "Halvorson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 9, new DateTime(1978, 10, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 324, DateTimeKind.Utc).AddTicks(839), "talia@sipes.co.uk", "clotilde.flatley", "Alford", "Dolor itaque iusto aperiam fugiat nihil voluptatem sed praesentium. Ut quo voluptas dolore magnam. Sint tempore tempore quod quo qui sapiente. Ad et magnam vero ut nostrum eos facilis.", "1424430739", "https://loremflickr.com/640/480/abstract", "West" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 10, new DateTime(2007, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 28, 3, 1, 4, 324, DateTimeKind.Utc).AddTicks(8849), "myriam@kshlerin.info", true, "robb_baumbach", "Riley", "Non pariatur quam vel debitis consequuntur. Adipisci nobis autem consequatur illum. Aliquam mollitia cum maxime laborum soluta ea velit. Quia voluptate molestias dolorem ipsum sit vero et.", "4860274628", "https://loremflickr.com/640/480/abstract", "Jakubowski" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "amount", "created_at", "description", "name", "photo", "price", "technical_information", "user_id" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2023, 5, 28, 3, 1, 4, 326, DateTimeKind.Utc).AddTicks(5018), "Itaque architecto sunt quibusdam. Natus hic nihil reiciendis voluptatum repellat et tenetur. Quasi nihil non repellat sed velit veritatis.", "Est fugiat blanditiis et.", "https://loremflickr.com/640/480/abstract", 14m, "Et cum expedita officia enim eaque. Iure et nemo consequatur. Incidunt laborum similique facere voluptas excepturi et similique rerum. Placeat et omnis voluptatibus magnam voluptates perspiciatis. Neque pariatur et quis aspernatur autem libero ut tempore aspernatur. Odit sit ut nihil in. Vel ipsa rerum molestiae sit qui optio doloribus. Optio sed iste ratione non ad tempore aliquid doloribus voluptatem. Reiciendis veniam reprehenderit magni quam non possimus. Cum nisi molestiae ipsum atque sunt. Sit quod et magnam qui quidem. Voluptatem veniam possimus officia magni nihil recusandae id odit minima. Velit rerum aspernatur et earum eveniet debitis.", 1 },
                    { 2, 1, new DateTime(2023, 5, 28, 3, 1, 4, 327, DateTimeKind.Utc).AddTicks(6856), "Ratione aspernatur ab animi sunt accusamus blanditiis et hic.", "Omnis et est laborum vel. Laudantium voluptas rerum cum magnam pariatur saepe odio fugit excepturi. Laudantium eos rerum quia sed voluptatem autem laboriosam laudantium. Ex dolorum et cupiditate est non et amet qui.", "https://loremflickr.com/640/480/abstract", 14m, "Qui voluptate quod suscipit accusantium molestiae. Ducimus quisquam quas reprehenderit. Distinctio placeat voluptate modi rerum natus modi consequatur. Aut et et et. Sunt atque non aut quos. Et voluptas illum voluptatum est velit in est repellat. Ut sunt ut ea. Natus nobis quas fugit. Et eos et ut placeat porro. Optio corrupti id consequuntur et provident et omnis.", 2 },
                    { 3, 6, new DateTime(2023, 5, 28, 3, 1, 4, 329, DateTimeKind.Utc).AddTicks(240), "Iusto consequuntur laborum molestiae molestiae eos nisi quasi distinctio corrupti. Et quos fugiat explicabo exercitationem esse sed.", "Tempore repellat harum ut iste autem ullam commodi cupiditate nemo. Ut ad totam accusantium asperiores enim doloribus et et. Qui dolorem assumenda totam.", "https://loremflickr.com/640/480/abstract", 17m, "Fugiat quidem et qui animi molestias qui sed. Ut nostrum autem quam quos ducimus quia rerum vel. Ut id perspiciatis voluptas veritatis totam. Fuga est quia eos voluptas quia rem. Cupiditate veritatis possimus non aut voluptas tenetur accusantium quis. Enim sapiente occaecati unde dolore. Consequuntur corrupti cum laborum earum sed amet vitae sapiente. Atque itaque officiis facere doloribus odit voluptatem. Sit fugit enim explicabo ut quia qui quas. Consectetur porro distinctio nihil.", 3 },
                    { 4, 1, new DateTime(2023, 5, 28, 3, 1, 4, 330, DateTimeKind.Utc).AddTicks(3143), "Eius omnis eligendi animi rerum tempora aut.", "Hic et facere excepturi. Debitis in placeat dolorem aspernatur corporis quis.", "https://loremflickr.com/640/480/abstract", 18m, "Quibusdam itaque repellendus libero est vel. Quo explicabo earum est architecto qui atque eveniet sequi. Qui exercitationem sed molestias explicabo dolor. Quaerat temporibus quo ex. Voluptas vitae blanditiis dignissimos voluptatem et. At et enim modi consequuntur laborum et aperiam maiores pariatur. Amet quibusdam tenetur sit sit. Rerum et ipsa sapiente voluptatem vel. Ut voluptas molestias qui magnam quibusdam error adipisci aliquid dolor. Totam est quae autem non ea excepturi unde adipisci est. Qui voluptatem et est autem qui tenetur possimus aut. Velit modi esse incidunt et. Asperiores consequatur voluptas laboriosam.", 4 },
                    { 5, 7, new DateTime(2023, 5, 28, 3, 1, 4, 331, DateTimeKind.Utc).AddTicks(6180), "Officiis perspiciatis consequuntur quis. Voluptas sapiente ut iusto qui. Enim sunt aut eos.", "Ducimus aperiam commodi quo repudiandae culpa cupiditate voluptas voluptatem.", "https://loremflickr.com/640/480/abstract", 20m, "Quia aut recusandae omnis officia. Architecto dolorem non aut veritatis rerum debitis. Numquam omnis nobis minima officia magni. Ullam doloribus ea enim voluptatibus doloremque itaque. Praesentium et et voluptatem. Suscipit beatae non consequuntur sit aspernatur fugit. Eligendi nisi ex eveniet similique necessitatibus labore. Itaque beatae magni rem magnam aspernatur. Adipisci dignissimos doloribus id vero eum dicta. Eos molestiae sequi rerum omnis ut cum deserunt qui. Modi qui non in officia eos. Sit facere ipsam aperiam suscipit rerum reprehenderit dolorem sit. Deleniti sed aliquam velit iste et.", 5 },
                    { 6, 3, new DateTime(2023, 5, 28, 3, 1, 4, 332, DateTimeKind.Utc).AddTicks(9254), "Quia id temporibus quasi quidem fuga ut et accusamus. Accusamus et incidunt qui. Voluptatibus non qui maiores quas.", "Dolorem eligendi et aspernatur rerum voluptatum animi. Aut corporis expedita quibusdam.", "https://loremflickr.com/640/480/abstract", 18m, "Tempore nulla officiis quia corrupti voluptatum tenetur magnam ad. Cupiditate ut facere sint. Possimus et occaecati laborum dolores eum rerum. In voluptas commodi officiis iure pariatur ea veritatis a. Quis sunt alias aut tenetur eaque recusandae quisquam. Consequatur et laboriosam cum earum amet tenetur qui porro. Ipsum consequatur et reiciendis aut aspernatur itaque deleniti. Quia laudantium eligendi reprehenderit ea pariatur inventore ipsam omnis similique. Non dolorum odit unde illo temporibus. Quasi molestias quia voluptas quia omnis rem voluptas itaque officia.", 6 },
                    { 7, 5, new DateTime(2023, 5, 28, 3, 1, 4, 333, DateTimeKind.Utc).AddTicks(9918), "Ipsum fugit delectus non incidunt qui enim nisi aut. Ea expedita molestias inventore.", "Modi occaecati repudiandae blanditiis quis qui.", "https://loremflickr.com/640/480/abstract", 16m, "Tempora eius illum pariatur laudantium. Aliquid dolores sit sunt sed aliquid est. Aut mollitia rem labore et ut consequuntur. Alias corporis quasi velit reprehenderit adipisci quasi unde saepe. Voluptate eos fugit dolores sequi ullam voluptate. Temporibus tempore non sed beatae perspiciatis fuga. Eos inventore vero exercitationem incidunt aperiam maiores et. Suscipit est magni dolores ea fugit. Ducimus ullam ut dolor aliquam impedit aut minima voluptatum. Eveniet nihil nesciunt repellendus alias.", 7 },
                    { 8, 9, new DateTime(2023, 5, 28, 3, 1, 4, 335, DateTimeKind.Utc).AddTicks(1336), "Eum praesentium ut et facere culpa. Aut tempore provident quibusdam delectus tenetur asperiores voluptates.", "Aut molestias optio voluptates eius ducimus qui maxime.", "https://loremflickr.com/640/480/abstract", 10m, "Mollitia ut laudantium assumenda tempora quidem excepturi. Dolores explicabo est voluptate quae et recusandae ratione alias. Omnis consequatur dolores sint doloremque ut quis quod dolorem nam. Iure et eius magnam ea maiores inventore. Est consequatur voluptatem quis sed vel qui eos. Et ratione dolores rerum ea dolorem similique consectetur veniam. Quia minima sequi quasi autem et harum. Est quisquam similique aut. In aut optio deserunt ut. Vitae rerum reiciendis velit vero consectetur impedit.", 8 },
                    { 9, 3, new DateTime(2023, 5, 28, 3, 1, 4, 336, DateTimeKind.Utc).AddTicks(5835), "Voluptas consectetur ea placeat sequi qui.", "Omnis quis voluptatibus omnis cum quibusdam ut dolorum sunt quis. Reiciendis quaerat et tenetur dicta provident velit. Sunt ut voluptas fugiat in expedita at ut delectus.", "https://loremflickr.com/640/480/abstract", 17m, "Numquam et nihil quidem numquam autem neque nihil. Nam quaerat cum non quod quia autem occaecati quia. Consequatur delectus architecto aut est consequatur nemo distinctio quo magnam. Hic natus quaerat assumenda. Est occaecati quasi delectus voluptates corporis placeat. Optio ipsum voluptas ducimus dolor voluptate quasi. Perspiciatis quo mollitia est quia ipsum. Deleniti maiores dolores expedita odio qui officia repellendus. Rerum laboriosam ut voluptatem sint sit ducimus sunt impedit. Voluptatibus id nihil iste et odit. Voluptatibus omnis aut reprehenderit aliquid vel ut consectetur tempora non.", 9 },
                    { 10, 8, new DateTime(2023, 5, 28, 3, 1, 4, 338, DateTimeKind.Utc).AddTicks(2549), "Asperiores quia voluptatem magnam consequatur. Occaecati maxime alias possimus cupiditate rerum qui eveniet. Aut ut molestias aspernatur dolorum voluptate blanditiis.", "Voluptate asperiores alias corporis quia non. Laudantium natus qui commodi aut aspernatur. Commodi reprehenderit quis placeat.", "https://loremflickr.com/640/480/abstract", 10m, "Ut ab asperiores asperiores dolorum est iure architecto fugit. Fuga voluptatem repellat enim. Voluptatem sit magnam atque aut earum ratione. Et repellat sequi et hic sint nisi commodi aperiam. Est et natus error velit accusantium laborum. Aliquid in dicta quia ad veritatis inventore occaecati. Animi et delectus sed est eum blanditiis aperiam culpa harum. Ut laudantium est voluptatem quia delectus dolore libero corporis commodi. Autem temporibus voluptatem mollitia quos ea voluptatem possimus. Et quis sint corrupti laborum dignissimos nesciunt maiores non. Amet dignissimos quia asperiores. Dolores perferendis et architecto quam aliquid perspiciatis maxime voluptas natus. Vero ut necessitatibus sed.", 10 }
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
