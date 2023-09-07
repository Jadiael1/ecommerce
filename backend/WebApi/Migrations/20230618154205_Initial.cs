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
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    login = table.Column<string>(type: "varchar(255)", nullable: false)
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
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_photos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    new_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_photos", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_photos_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 1, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 4, 281, DateTimeKind.Utc).AddTicks(3420), "Sierra82@gmail.com", "Kiera.Feeney", "Deanna", "$2a$11$Kg.kcir4TiFfItPZdlCR5.wx0F2/E/ijWUOgaXo1iI9Oug8TFbRFu", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 2, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 4, 405, DateTimeKind.Utc).AddTicks(6288), "Devon.Beier7@gmail.com", true, "Caleb.Ratke32", "Deanna", "$2a$11$E8V2SWZDDV5uMkFNBr2nbehp03O0I5MeT0SGKGvyM9haSmcb2/T3m", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 3, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 4, 528, DateTimeKind.Utc).AddTicks(8490), "Ed_Kovacek@gmail.com", "Eli_Crist93", "Deanna", "$2a$11$u3FZrOHOfCDSt8PGlK7oy.aNgf1cTfeV7OC6btWpinSyvF63mJCJq", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" },
                    { 4, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 4, 651, DateTimeKind.Utc).AddTicks(8466), "Verna_Bashirian@gmail.com", "Marilyne86", "Deanna", "$2a$11$PteAWWpenxK6ZO71eAvkheTlAMClhAehSdofhkl9zblbFFYNaZIQy", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" },
                    { 5, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 4, 775, DateTimeKind.Utc).AddTicks(566), "Amelie84@yahoo.com", "Sabryna.Terry20", "Deanna", "$2a$11$ZDA3D1eOO31I3ut3a8HexeyUr0N3Ox/4RyjU1l/XxxoM2R3zYqyqC", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[,]
                {
                    { 6, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 4, 898, DateTimeKind.Utc).AddTicks(6700), "Buddy9@hotmail.com", true, true, "Micah.Ruecker", "Deanna", "$2a$11$CCXm2vpIorP144O4l.CYBuWftXfwP4U1fnKEWAGFXzPQ0UY1l5Aai", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" },
                    { 7, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 5, 21, DateTimeKind.Utc).AddTicks(6628), "Marge38@hotmail.com", true, true, "Helen61", "Deanna", "$2a$11$28rHnV9biA3VC35Ij5va2uk8kiHvvbnimxhL4LQAwwwjIk5li5PQ6", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 8, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 5, 145, DateTimeKind.Utc).AddTicks(3673), "Elenora.Klocko96@gmail.com", "Jerome_Walsh94", "Deanna", "$2a$11$RjXi5Nn7GUliRcII2gSBZuak.z6.ZR9AjtXoGuhOChb8r71RRvAf2", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_active", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 9, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 5, 269, DateTimeKind.Utc).AddTicks(1530), "Filiberto.Schulist@hotmail.com", true, true, "Bernice_Abshire", "Deanna", "$2a$11$p3jxvhp13hdfNTBuAkRgWeSyZAIS7Oan4Xes1Aeffqo4FJRNBEslO", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "birth_date", "created_at", "email", "is_admin", "login", "name", "password", "phone", "photo", "surname" },
                values: new object[] { 10, new DateTime(1975, 4, 8, 8, 5, 23, 350, DateTimeKind.Local).AddTicks(4729), new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(928), "Aylin96@yahoo.com", true, "Stacy77", "Deanna", "$2a$11$6zjERp..iATU9.4m.Z0YnOXbxf5y3yZurvpl4G7sIRwgz5JPZ7iSS", "201.616.1610 x9326", "https://placeimg.com/640/480/any", "Mann" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "amount", "created_at", "description", "name", "price", "technical_information", "user_id" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6434), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Deanna", 1.988099522783361m, "Earum ea aliquid deleniti accusamus sequi ut illo similique. Et atque fugiat quia totam dolore et perferendis aut. Qui voluptatibus libero saepe architecto corrupti voluptas. Nostrum magni nemo vitae qui est accusantium porro illum. Est qui qui velit molestiae.", 1 },
                    { 2, 2, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6459), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Deanna", 1.177022583861148m, "fuga", 2 },
                    { 3, 5, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6482), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", "Deanna", 1.676165948677159m, "Fuga illum atque sit ea.", 3 },
                    { 4, 5, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6508), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Deanna", 1.376438184279359m, "Rerum voluptatem quae est ut voluptas.", 4 },
                    { 5, 5, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6538), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Deanna", 1.443971368225496m, "Voluptatem aspernatur corrupti aut ipsum iste dicta.", 5 },
                    { 6, 4, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6549), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "Deanna", 1.429145013612126m, "sequi", 6 },
                    { 7, 2, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6574), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "Deanna", 1.654643618590128m, "Eos dolorum et dolore et.", 7 },
                    { 8, 3, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6716), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "Deanna", 1.779066940390644m, "Eveniet similique eos perferendis dignissimos aperiam dolorem. Fugiat maiores aliquam rerum distinctio. Placeat sequi suscipit. Cupiditate libero aliquam numquam vero quo maxime facere et necessitatibus. Excepturi facilis aut quasi ducimus. Unde voluptas ex est delectus.", 8 },
                    { 9, 4, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6725), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "Deanna", 1.547114873070443m, "nihil", 9 },
                    { 10, 3, new DateTime(2023, 6, 18, 15, 42, 5, 393, DateTimeKind.Utc).AddTicks(6904), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "Deanna", 1.771536607941811m, "Molestias autem consectetur aut sunt libero quam alias. Repudiandae voluptas velit aut. Voluptates architecto qui. Tenetur harum molestiae quas eum neque sapiente.", 10 }
                });

            migrationBuilder.InsertData(
                table: "product_photos",
                columns: new[] { "id", "created_at", "name", "new_name", "path", "product_id" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(3578), "Mandatory.jpg", "real-time.gif", "/platforms", 1 },
                    { 2, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(3669), "bus.png", "orange.png", "/parsing/syndicate/luxembourg", 2 },
                    { 3, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(4373), "program.png", "Avon.png", "/integrate", 3 },
                    { 4, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(4734), "Unbranded Granite Fish.png", "Unions.gif", "/well/deposit", 4 },
                    { 5, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(4784), "envisioneer.jpg", "Rustic Soft Tuna.gif", "/burgs", 5 },
                    { 6, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(5582), "RAM.png", "one-to-one.jpg", "/consultant/internal/gorgeous", 6 },
                    { 7, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(5685), "withdrawal.jpg", "Grocery & Health.png", "/hacking/e-business/front-line", 7 },
                    { 8, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(5753), "synthesizing.png", "recontextualize.jpg", "/specialist", 8 },
                    { 9, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(5785), "panel.png", "sensor.jpg", "/initiative", 9 },
                    { 10, new DateTime(2023, 6, 18, 15, 42, 5, 394, DateTimeKind.Utc).AddTicks(5832), "B2B.png", "Product.jpg", "/union/panama", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_photos_product_id",
                table: "product_photos",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_user_id",
                table: "products",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                table: "users",
                column: "login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_photos");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
