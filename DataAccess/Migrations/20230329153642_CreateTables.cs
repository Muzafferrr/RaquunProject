using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaquunProject.DataAccess.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surface = table.Column<int>(type: "int", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PlateCode = table.Column<int>(type: "int", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: true),
                    Surface = table.Column<int>(type: "int", nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mayor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Description", "Capital", "PhoneCode", "Surface", "Population" },
                values: new object[,]
                {
                    { 1, "Türkiye", "Türkiye veya resmî adıyla Türkiye Cumhuriyeti, topraklarının büyük bölümü Anadolu'da, küçük bir bölümü ise Balkan Yarımadası'nın güneydoğu uzantısı olan Trakya'da yer alan kıtalararası bir ülkedir.", "Ankara", "+90", 783562, 84780000 },
                    { 2, "Fransa", "Fransa ya da resmî adıyla Fransa Cumhuriyeti veya Fransız Cumhuriyeti, ana kara toprakları Batı Avrupa'da bulunan ve dünyanın pek çok bölgesinde denizaşırı toprakları olan bir ülkedir.", "Paris", "+33", 640679 , 67750000 },
                    { 3, "İtalya", "İtalya ya da resmî olarak İtalyan Cumhuriyeti ya da bazen İtalya Cumhuriyeti, Güney Avrupa'da, büyük ölçüde İtalya Yarımadası üzerinde yer alan bir ülke.", "Roma", "+39", 301338, 59110000 },
                    { 4, "Azerbaycan", "Azerbaycan, resmî adıyla Azerbaycan Cumhuriyeti, Batı Asya ile Doğu Avrupa'nın kesişim noktası olan Kafkasya'da yer alan bir ülkedir.", "Bakü", "+994", 86600, 10140000 },
                    { 5, "Birleşik Krallık", "Büyük Britanya ve Kuzey İrlanda Birleşik Krallığı veya yaygın adıyla Birleşik Krallık; Avrupa anakarasının kuzeybatı kıyılarında, kuzeybatı Avrupa'da egemen bir ülkedir.", "Londra", "+44", 243610, 67330000 },
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "Description", "PlateCode", "Population", "Surface", "PhoneCode", "Mayor", "CountryId" },
                values: new object[,]
                {
                    { 1, "Manisa", "Türkiye'nin Ege Bölgesi'nde bir şehir ve büyük İzmir şehrinin yaklaşık 40 km kuzeydoğusunda yer alan Manisa ilinin idari merkezidir.", 45, 1429643, 13339, "236", "Cengiz Ergün", 1 },
                    { 2, "Marsilya", "Marsilya, Fransa'nın güneydoğu'sunda bulunan, Bouches-du-Rhône ilinin ve Provence-Alpes-Côte d'Azur bölgesinin merkez şehridir.", 4, 869815, 24062, "04", "Benoît Payan", 2 },
                    { 3, "Milano", "Milano, kuzey İtalya'da bulunan Lombardiya bölgesinde kendi ismini taşıyan Milano ili'nde bulunan bir şehir ve bir komündür.", 785, 1352000, 1818, "785", "Giuliano Pisapia", 3 },
                    { 4, "Kusar", "Kusar Azerbaycan'ın Kusar Rayonu'nun başkentidir. Kusar, Büyük Kafkasya'nın eteklerinde, Kuşçay Nehri üzerinde, Hudat tren istasyonunun 35 kilometre güneybatısında yer alır ve Bakü'ye 180 km uzaklıktadır.", 13, 17400, 1569, "994 2338", "Şair Alhasov", 4 },
                    { 5, "Manchester", "Manchester, Birleşik Krallık'a bağlı İngiltere ülkesinin Kuzey-Batı bölgesinde bulunan bir şehir.", 27, 553230, 1156000, "0161", "Naeem ul Hassan", 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
