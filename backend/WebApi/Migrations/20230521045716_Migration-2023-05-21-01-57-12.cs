using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Migration20230521015712 : Migration
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
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
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
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 1, new DateTime(1925, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 172, DateTimeKind.Utc).AddTicks(742), "filomena.rowe@langworth.name", true, "jaleel_pfannerstill", "Adela", "Sed aut autem et quia at. Accusantium at aut animi saepe voluptas qui. Similique quas occaecati quaerat totam. Dolor ex consectetur dolor architecto.", "3327509069", "https://loremflickr.com/640/480/abstract", "Hammes" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 2, new DateTime(1916, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 172, DateTimeKind.Utc).AddTicks(5931), "raheem@wildermanroob.ca", true, true, "murray", "Taryn", "Eaque labore officiis id sapiente architecto in excepturi est laboriosam. Est est animi delectus aut qui ipsa et. Delectus incidunt corporis consequuntur hic rerum at laborum ad quasi.", "9412298404", "https://loremflickr.com/640/480/abstract", "Stokes" },
                    { 3, new DateTime(1975, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 173, DateTimeKind.Utc).AddTicks(135), "ken@jones.biz", true, true, "malika", "Scot", "Maiores repudiandae praesentium delectus vel et quo nam aut.", "9193680910", "https://loremflickr.com/640/480/abstract", "Littel" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 4, new DateTime(1962, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 173, DateTimeKind.Utc).AddTicks(5939), "ernestine_rempel@eichmann.ca", true, "anne.roob", "Jedediah", "Eius quia soluta id dolore sit aut dignissimos magnam. Quaerat qui iusto aut ut autem nostrum. Dolor alias nesciunt sit hic autem ipsum. Vero quaerat accusantium et ea provident ut natus.", "2755253193", "https://loremflickr.com/640/480/abstract", "Padberg" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 5, new DateTime(1989, 11, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 174, DateTimeKind.Utc).AddTicks(920), "carmelo@gerlach.info", true, "ernesto_hauck", "Llewellyn", "Sit voluptates totam commodi asperiores voluptas. Dignissimos quia similique est. Earum praesentium dolor libero laboriosam et dolore molestias sit nemo.", "3849108155", "https://loremflickr.com/640/480/abstract", "Kuvalis" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 6, new DateTime(1920, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 174, DateTimeKind.Utc).AddTicks(5487), "karolann.labadie@hoegerdibbert.us", true, true, "alexane_stiedemann", "Antonio", "Laborum debitis laboriosam accusantium quidem enim ipsa possimus at quo. Hic sed quia nostrum.", "3680532431", "https://loremflickr.com/640/480/abstract", "Hyatt" },
                    { 7, new DateTime(1976, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 175, DateTimeKind.Utc).AddTicks(552), "alfredo_bahringer@kreigerwalsh.com", true, true, "derick", "Terry", "Ipsum delectus aut laboriosam id ipsum culpa.", "2811251987", "https://loremflickr.com/640/480/abstract", "Blanda" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 8, new DateTime(1995, 9, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 175, DateTimeKind.Utc).AddTicks(7140), "hans@nicolas.us", true, "jailyn_pouros", "Bridget", "Excepturi animi quos consequuntur. Dolorem sint at necessitatibus. Saepe nesciunt rerum fugit repellat exercitationem quia velit et. Qui voluptatum dignissimos commodi sed et et ullam laborum atque.", "3379684333", "https://loremflickr.com/640/480/abstract", "Parker" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 9, new DateTime(1918, 11, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 176, DateTimeKind.Utc).AddTicks(1119), "jeanette_harber@hoeger.co.uk", true, "cristian", "Obie", "Et sequi qui quibusdam enim sit et ex.", "3872855697", "https://loremflickr.com/640/480/abstract", "Kiehn" },
                    { 10, new DateTime(1960, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 5, 21, 4, 57, 16, 176, DateTimeKind.Utc).AddTicks(6697), "jazlyn@osinskifarrell.co.uk", true, "madisyn_mueller", "Ed", "Doloremque harum dolores incidunt et est dolor architecto. Corporis beatae accusamus iusto amet fugiat cum beatae. Sapiente qui placeat et nihil voluptatum qui. Laudantium quia dolore fugiat id qui consequatur.", "2715806175", "https://loremflickr.com/640/480/abstract", "Gerhold" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "amount", "created_at", "description", "name", "photo", "price", "technical_information", "user_id" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2023, 5, 21, 4, 57, 16, 177, DateTimeKind.Utc).AddTicks(8278), "Blanditiis voluptatem dolores rerum maiores veritatis. Porro aut ut maxime quaerat veritatis et voluptatem.", "Rerum fugit ullam asperiores ut molestiae amet. Vitae aliquid ea cumque voluptatem atque repellat est rerum. Sed qui facilis consequuntur. Repellat voluptas sit ea vero pariatur rerum vel.", "https://loremflickr.com/640/480/abstract", 20m, "Consequatur quia maiores velit impedit quod eos repellat. Ipsam placeat non pariatur nostrum molestias placeat. Cum autem enim voluptatem minima ducimus incidunt. Harum vel fugiat sequi eum expedita voluptatem tenetur est. Facilis enim in nostrum et iusto et quia et repellat. Quisquam nihil eum illo deleniti animi. Est cupiditate dicta porro quidem et vel quia. Dolores in perspiciatis esse quia. Eligendi corporis sit cupiditate. Molestias est repellendus nihil perspiciatis eum aperiam. Ipsum exercitationem ex officiis sit.", 1 },
                    { 2, 5, new DateTime(2023, 5, 21, 4, 57, 16, 178, DateTimeKind.Utc).AddTicks(5082), "Adipisci qui eos qui enim delectus. Ut vitae porro totam reprehenderit nulla. In et facilis qui dolor enim sit.", "Voluptas architecto consequatur modi asperiores corporis.", "https://loremflickr.com/640/480/abstract", 20m, "Quae rerum fugit adipisci. Autem consequatur enim qui id libero. Adipisci est ut laboriosam. Non rerum saepe nesciunt nihil. Accusamus omnis cumque facilis occaecati officia esse vero qui. Fugiat natus aut officia blanditiis. Enim molestias dicta qui voluptatum amet veniam culpa vitae qui. Est recusandae hic culpa eius tenetur. Tempora laboriosam eum et illum voluptas voluptas. Eius facilis in corrupti molestiae.", 2 },
                    { 3, 6, new DateTime(2023, 5, 21, 4, 57, 16, 179, DateTimeKind.Utc).AddTicks(7585), "Asperiores perspiciatis corporis et libero nisi fugit aut atque. Sunt ipsum ratione libero.", "Molestiae velit consequatur cumque repellat quia. Maiores accusantium molestias libero non sint amet doloribus adipisci nihil. In adipisci nemo et enim eaque vero reiciendis sint voluptatibus. Soluta quas aut nisi aperiam et culpa libero autem.", "https://loremflickr.com/640/480/abstract", 19m, "Quaerat sint nihil delectus vel. Porro porro quia totam modi reiciendis autem nisi amet. Vel aut dolor aspernatur quod cumque rem reiciendis ut. Voluptatibus mollitia totam eveniet enim explicabo neque quia minus. Et eos atque accusantium magnam. Minus omnis et quo. Amet eius ut omnis dolore aut aut dolorum. Minima quasi ullam dolor ipsum. Ipsam molestiae tempora vero dolorem eos quam id sequi velit. Qui ea beatae eos consequuntur. Fugiat architecto neque blanditiis ipsa commodi iste id ut labore. Adipisci aut nisi iure corporis temporibus assumenda modi voluptatem sint. Similique voluptate quos molestiae qui qui voluptatem autem repudiandae tempora.", 3 },
                    { 4, 8, new DateTime(2023, 5, 21, 4, 57, 16, 180, DateTimeKind.Utc).AddTicks(6235), "Voluptas reprehenderit non cupiditate vitae.", "Sit qui qui a.", "https://loremflickr.com/640/480/abstract", 17m, "Non eaque sint voluptatem qui. Repudiandae hic ut sit at labore. Expedita voluptas distinctio nihil eaque neque. Modi minus necessitatibus omnis aperiam voluptatem iusto quia aut. Sunt dicta praesentium itaque facilis distinctio quisquam cupiditate amet sint. Esse aut delectus ut quas et alias. Itaque reiciendis similique dolorem. Molestiae commodi cupiditate qui harum. Tempore est minus cumque minima alias. Ea nobis numquam qui autem necessitatibus. Est sed ea odio dolore est harum sit sed at. Neque quae totam illum itaque minima sed labore harum ut. Voluptatem maiores consequatur at aspernatur sit.", 4 },
                    { 5, 1, new DateTime(2023, 5, 21, 4, 57, 16, 181, DateTimeKind.Utc).AddTicks(7381), "Possimus accusantium et molestiae minus voluptate. Et omnis officiis neque excepturi. Corporis inventore aut id accusamus ratione. Non ducimus quam et eius ut numquam.", "Eum enim eius ipsum et distinctio vel magnam soluta et. Quia numquam enim maiores. Dolorum et ratione mollitia et. Voluptatum dolorum tenetur nostrum.", "https://loremflickr.com/640/480/abstract", 14m, "Sapiente cupiditate et minus dolores hic excepturi asperiores laudantium. Dignissimos quae officiis qui voluptas quia voluptas neque ipsa amet. Quia dicta rerum nemo perferendis blanditiis. Aut nesciunt facere animi quo excepturi corporis iusto nulla dolore. Ut voluptate quidem ducimus eaque voluptatem placeat. Eveniet voluptates animi quaerat odit. Omnis illum laboriosam omnis tempora omnis error. Voluptatibus tempore sapiente qui. Omnis possimus corrupti eius nobis nam aspernatur. Reprehenderit ipsam veritatis veniam. Ut ut ut quo. Rerum quis magnam optio dolor amet eius ex voluptates.", 5 },
                    { 6, 6, new DateTime(2023, 5, 21, 4, 57, 16, 182, DateTimeKind.Utc).AddTicks(5713), "Sunt quibusdam qui aut. In tempora et mollitia inventore dolores.", "Veniam debitis consequatur cupiditate ipsa inventore temporibus vitae non iure.", "https://loremflickr.com/640/480/abstract", 17m, "Nulla iure atque est dolorum itaque quam nulla commodi. Non ipsam molestias dolorum exercitationem sint numquam repellat iste exercitationem. Commodi vitae atque saepe. Eos doloribus magnam vel debitis et dicta. Sequi voluptatem velit porro. Dicta omnis saepe quo voluptatem distinctio eaque assumenda quam. Similique perspiciatis ex aut molestiae iure aut. Et enim qui repellat cupiditate. Sint non qui odio facere aperiam in eum ducimus. Odio repellat autem possimus consequuntur rerum eum natus maxime. Dignissimos eius cupiditate animi qui tenetur facilis.", 6 },
                    { 7, 10, new DateTime(2023, 5, 21, 4, 57, 16, 183, DateTimeKind.Utc).AddTicks(5005), "Sapiente harum fugit ex velit maiores. Quod maxime sit facere eaque ut exercitationem eum dolore.", "Sit provident omnis voluptatem aut neque voluptate. Non voluptatem sit alias vitae. Ut fugiat unde ab perferendis beatae cumque.", "https://loremflickr.com/640/480/abstract", 19m, "Nobis voluptatem a ut. Debitis sit accusantium similique beatae omnis aut quo. Perspiciatis natus odit quia aut molestiae dolores. Perferendis similique voluptas voluptate architecto ipsam. Id dolores et qui numquam ab. Alias voluptatem natus non dolores aut. Nihil sit nihil sed voluptatem aut et. Ullam velit rerum sed placeat. Consectetur et dignissimos a necessitatibus commodi sunt quidem quia. Asperiores dolorem aut ullam. Voluptatum eum nemo vero consequatur. Pariatur alias dolor eaque hic beatae expedita cum magni vel. Ab repudiandae blanditiis assumenda quia.", 7 },
                    { 8, 3, new DateTime(2023, 5, 21, 4, 57, 16, 184, DateTimeKind.Utc).AddTicks(5132), "Iste excepturi quas provident. At quo et aut corrupti quia expedita quibusdam modi. Et et reiciendis modi. Adipisci incidunt eligendi numquam quia.", "Voluptatem assumenda quia deserunt accusamus voluptas fuga maiores sunt eum. Ipsa ullam suscipit perferendis.", "https://loremflickr.com/640/480/abstract", 18m, "Maxime facilis libero architecto quas ut mollitia dicta voluptas est. Magnam voluptatum praesentium ullam accusamus sapiente beatae aperiam molestias corrupti. Sint sit nostrum maxime sed a autem. Ad culpa eum sequi facilis eveniet. Est autem provident ut iusto. Quo quod enim error. Dolorem sequi blanditiis nemo corporis aut. Quo cupiditate exercitationem voluptatibus mollitia earum aut commodi molestias. Voluptatum voluptatibus aut aut illo optio libero consectetur iusto sit. Aut unde aliquam esse commodi quas qui odio. Voluptate maxime maxime hic amet molestias eligendi facilis. Adipisci sed rem consequatur. Inventore dolor qui ipsum culpa sapiente similique.", 8 },
                    { 9, 6, new DateTime(2023, 5, 21, 4, 57, 16, 185, DateTimeKind.Utc).AddTicks(6370), "In qui voluptate molestias architecto recusandae hic quia quia. Voluptas incidunt et dolorem laborum sit nulla quidem laboriosam unde. Distinctio deserunt eligendi fugit. Delectus aut tempora et doloremque.", "Magnam sunt debitis neque. Esse deleniti voluptate deleniti ut dolorem omnis magnam illo placeat. Occaecati velit occaecati et id. Ut eveniet consequatur delectus saepe et.", "https://loremflickr.com/640/480/abstract", 13m, "Laborum minima facere qui repellendus eum beatae placeat sed tenetur. Quisquam doloremque inventore recusandae aperiam. Ea voluptas facilis nisi saepe. Dicta dolor suscipit earum quibusdam ratione. Dolores voluptas voluptas et. Natus dignissimos similique quis dignissimos repellendus accusamus. Animi sed repellendus ex officiis tenetur. Tenetur ipsam molestias sed maxime accusamus laboriosam. Excepturi perferendis harum sit assumenda quo blanditiis. Amet porro quisquam aut nam quibusdam porro voluptate unde asperiores. Vel sint cupiditate provident consequatur aut cum omnis. Aliquam ut nam sed enim magnam. Libero ad blanditiis neque deserunt quis aut ut similique.", 9 },
                    { 10, 5, new DateTime(2023, 5, 21, 4, 57, 16, 186, DateTimeKind.Utc).AddTicks(3656), "Eum reprehenderit dolore sed voluptatum nihil nesciunt voluptas. Debitis et consequuntur eum qui aperiam necessitatibus.", "Blanditiis veniam sit sapiente aut.", "https://loremflickr.com/640/480/abstract", 12m, "Voluptatem suscipit eum sit tempore qui impedit repellat hic. Aliquam fugit iure architecto veniam qui. Aliquam praesentium vel saepe. Repellat minus asperiores sequi perferendis. Architecto et sunt qui consectetur et tempora dolorem eveniet. Alias eos quam quia vel est dolorum praesentium architecto. Dolor aut laborum totam. Reiciendis suscipit asperiores tempora earum. Labore sint id eveniet odio et. Voluptatem quia labore autem odio fugiat autem. Enim asperiores similique autem accusamus at aut rerum corrupti consectetur.", 10 }
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
