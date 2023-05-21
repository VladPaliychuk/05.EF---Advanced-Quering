using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _05.EF___Advanced_Quering.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgeRestriction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Copies = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EditionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.CategoryId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookCategories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("1bf56aab-9c8e-436d-84e2-35c17f96adbe"), "Jazmin", "Satterfield" },
                    { new Guid("1bfc89c9-0119-418b-b8f0-c4977582fc7d"), "Taryn", "Gulgowski" },
                    { new Guid("574bcdb1-063b-4731-bfc8-51fe2f80cc7f"), "Marcos", "Emard" },
                    { new Guid("5a11bd36-f79b-4b81-b996-4309a0634305"), "Dallas", "Grant" },
                    { new Guid("5f0a7a2d-64a6-4a15-94d0-e56eab85b15d"), "Suzanne", "Halvorson" },
                    { new Guid("6320f78b-a0c9-4c1e-844b-0c1a495016b3"), "Keyshawn", "Kilback" },
                    { new Guid("69486502-9aee-40e2-a1c6-191bcf18fcd3"), "Jakayla", "Bergstrom" },
                    { new Guid("84cd49e2-219d-46b4-9369-5e21c7aaaef1"), "Jack", "Quigley" },
                    { new Guid("90847da7-59ed-4645-a440-a3795df3a1cf"), "Ignatius", "Grant" },
                    { new Guid("9424871e-e103-4727-a381-144525ca2b5a"), "Anthony", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("11f00845-9aad-4958-a80e-412f81411e90"), "Toys & Music" },
                    { new Guid("24a4ce83-37a7-4dd0-81b9-4ec14fb6dd61"), "Garden" },
                    { new Guid("3a1d58e2-53cd-49c0-a91a-aef760eacb9f"), "Computers, Automotive & Outdoors" },
                    { new Guid("401c8ca8-e9b6-4712-839e-68c83516438f"), "Books, Kids & Toys" },
                    { new Guid("46b8c0da-be8b-4906-8bc3-4b0ee49f9388"), "Kids & Grocery" },
                    { new Guid("59b911be-01b8-4ce2-b437-92d3f5ad2360"), "Sports, Outdoors & Grocery" },
                    { new Guid("797cbd01-2db7-4d17-9492-9fc61b837844"), "Health" },
                    { new Guid("94566ec9-f6ac-4ca1-bbc7-69d92416ff06"), "Outdoors & Books" },
                    { new Guid("d45fbe55-736e-4a9c-840d-9c5909995dee"), "Movies & Music" },
                    { new Guid("dcf58143-618c-46f0-b302-51fd94388aab"), "Electronics, Health & Games" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AgeRestriction", "AuthorId", "Copies", "Description", "EditionType", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("03d0c700-3531-4ccd-95a7-0ff72a5a7714"), "Minor", new Guid("5a11bd36-f79b-4b81-b996-4309a0634305"), 665, "Sint vel reprehenderit. Eos distinctio et doloremque qui velit necessitatibus sed corporis hic. Minus tenetur et eligendi. Necessitatibus sit sit non minus nihil quia dolores aspernatur nobis. Et alias ullam rerum dolorem est atque. Reiciendis excepturi quod fuga similique laborum nihil omnis tempora qui.", "Normal", 629.305273226878687m, new DateTime(2020, 12, 11, 14, 29, 4, 490, DateTimeKind.Local).AddTicks(2627), "sit" },
                    { new Guid("2af78f69-474b-48ee-bfcd-9a059402f97c"), "Adult", new Guid("574bcdb1-063b-4731-bfc8-51fe2f80cc7f"), 613, "Perferendis blanditiis quo ipsa voluptates eum dolor sequi. Ut omnis libero qui non. Nemo quasi quia id voluptates. Consequatur quidem veniam repellat vel omnis. Aperiam qui provident consequatur rem molestiae in.", "Promo", 998.072641505949832m, new DateTime(2018, 8, 24, 22, 34, 52, 670, DateTimeKind.Local).AddTicks(8169), "numquam" },
                    { new Guid("43d1ee8c-e71d-48b4-bef7-7d6c2ed2d0e7"), "Adult", new Guid("5f0a7a2d-64a6-4a15-94d0-e56eab85b15d"), 597, "Repellat molestiae voluptatem. Vitae autem animi possimus aliquid sed. Maxime aliquam quia aspernatur delectus.", "Gold", 861.637086633975805m, new DateTime(2018, 5, 27, 6, 14, 56, 414, DateTimeKind.Local).AddTicks(1136), "asperiores" },
                    { new Guid("60e9c698-9e78-470f-a03e-5e41c5d65625"), "Adult", new Guid("574bcdb1-063b-4731-bfc8-51fe2f80cc7f"), 854, "Impedit officiis quia deleniti. Non delectus fuga. Ut illo labore ut laborum nam aut. At doloribus natus necessitatibus voluptatem ipsa aut iusto iure. Nostrum rerum nostrum ut.", "Promo", 39.1068610539912487m, new DateTime(2015, 6, 7, 3, 25, 6, 117, DateTimeKind.Local).AddTicks(4560), "et" },
                    { new Guid("6cb2809e-5134-4b97-89e4-0eb7f8509bae"), "Adult", new Guid("6320f78b-a0c9-4c1e-844b-0c1a495016b3"), 223, "Ea quod ea. Molestias recusandae sed a ipsa odit maxime illum. Doloremque ut omnis ad inventore nesciunt qui sapiente veritatis.", "Normal", 815.053236594884416m, new DateTime(2008, 9, 23, 18, 35, 20, 210, DateTimeKind.Local).AddTicks(558), "fuga" },
                    { new Guid("6cc7242a-4a69-4de9-8501-7b99bfaa053a"), "Adult", new Guid("84cd49e2-219d-46b4-9369-5e21c7aaaef1"), 193, "Incidunt beatae molestiae ut qui maiores laborum iusto incidunt. Unde quis reiciendis voluptatem ea. Minus voluptas est temporibus culpa tempore praesentium possimus praesentium. Dolorem eum harum saepe excepturi nobis perferendis.", "Promo", 672.068155881059164m, new DateTime(2012, 7, 25, 5, 46, 29, 274, DateTimeKind.Local).AddTicks(8723), "ut" },
                    { new Guid("98b6b3d1-b33a-4f01-aa97-4d0544429329"), "Adult", new Guid("6320f78b-a0c9-4c1e-844b-0c1a495016b3"), 449, "Consequuntur in cumque occaecati ab dolor velit repudiandae. Vero ullam ipsa quod dicta. Earum et et nesciunt reprehenderit eius ipsa. Reprehenderit occaecati cum reprehenderit. Itaque a dolores ratione vitae beatae labore. Illo iste dignissimos veritatis quae error.", "Gold", 978.164478027357994m, new DateTime(2011, 2, 23, 4, 30, 28, 89, DateTimeKind.Local).AddTicks(2182), "tempore" },
                    { new Guid("ac0fe20b-adee-46ec-b57d-10c9efdd81f8"), "Minor", new Guid("5a11bd36-f79b-4b81-b996-4309a0634305"), 972, "Sed est nihil est. Rerum velit aspernatur optio veritatis porro veniam porro. Amet et illo fuga.", "Normal", 863.488115600206726m, new DateTime(2013, 4, 22, 18, 52, 14, 194, DateTimeKind.Local).AddTicks(5440), "et" },
                    { new Guid("b50e0c6b-2b30-4f1e-bbaf-da545471b49f"), "Teen", new Guid("1bfc89c9-0119-418b-b8f0-c4977582fc7d"), 226, "Quia labore quis ipsam occaecati praesentium repudiandae reprehenderit ipsum. Doloribus similique tempore nemo non eligendi sint assumenda perspiciatis. Sint ipsam delectus aut id cumque excepturi. Omnis non deleniti qui ipsam consequuntur mollitia. Neque iste dolores illo quia.", "Gold", 625.843149533216632m, new DateTime(2016, 11, 28, 11, 26, 15, 217, DateTimeKind.Local).AddTicks(5136), "harum" },
                    { new Guid("eff61165-5ba3-4a7b-b9a2-cae2a96de3eb"), "Minor", new Guid("6320f78b-a0c9-4c1e-844b-0c1a495016b3"), 916, "Qui officia reiciendis fugit. Excepturi harum possimus pariatur harum veniam sint quam sint nam. Voluptates reiciendis qui sit amet sunt quis ad sunt.", "Normal", 666.179217504366067m, new DateTime(2008, 12, 6, 19, 15, 22, 468, DateTimeKind.Local).AddTicks(5059), "sed" }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("eff61165-5ba3-4a7b-b9a2-cae2a96de3eb"), new Guid("24a4ce83-37a7-4dd0-81b9-4ec14fb6dd61") },
                    { new Guid("2af78f69-474b-48ee-bfcd-9a059402f97c"), new Guid("3a1d58e2-53cd-49c0-a91a-aef760eacb9f") },
                    { new Guid("ac0fe20b-adee-46ec-b57d-10c9efdd81f8"), new Guid("3a1d58e2-53cd-49c0-a91a-aef760eacb9f") },
                    { new Guid("2af78f69-474b-48ee-bfcd-9a059402f97c"), new Guid("94566ec9-f6ac-4ca1-bbc7-69d92416ff06") },
                    { new Guid("43d1ee8c-e71d-48b4-bef7-7d6c2ed2d0e7"), new Guid("94566ec9-f6ac-4ca1-bbc7-69d92416ff06") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
