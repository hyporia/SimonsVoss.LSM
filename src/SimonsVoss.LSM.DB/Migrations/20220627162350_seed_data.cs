using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimonsVoss.LSM.DB.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "public",
                table: "buildings",
                columns: new[] { "id", "description", "name", "short_cut" },
                values: new object[,]
                {
                    { new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), "Head Office, Feringastraße 4, 85774 Unterföhring", "Head Office", "HOFF" },
                    { new Guid("3116849e-e18d-4afd-8058-156d8d96b593"), "Logistikzentrum, 81677 München", "Logistikzentrum I", "LOG-1" },
                    { new Guid("9605186f-7eb4-4f40-967e-2885d9a8b3c4"), "Produktionsstätte, Lindauer Str. 6, 06721 Osterfeld", "Produktionsstätte", "PROD" },
                    { new Guid("9a168210-ae8b-4cbe-b5f9-aa8b36dd5e70"), "Logistikzentrum, 81335 München", "Logistikzentrum II", "LOG-2" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "groups",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), null, "Qualitätskontrolle" },
                    { new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), null, "Vertriebdienst" },
                    { new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), null, "Project Management" },
                    { new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"), null, "Einkauf" },
                    { new Guid("70c886f5-b74e-49f4-8d9f-cf2d6645d4d6"), "Default group where all transponders", "<default>" },
                    { new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), null, "Hardware Entwicklung" },
                    { new Guid("a8fb8533-15dd-4a12-bd52-977b59caf77d"), null, "Reinigungsdienst" },
                    { new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), null, "Mechanik & Mechatronik" },
                    { new Guid("abf2f0f5-ca6c-47c6-a018-dffd3e59d3ea"), "CEO, CFO, CTO, etc.", "Vorstand" },
                    { new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), null, "Support" },
                    { new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"), null, "Buchhaltung" },
                    { new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"), null, "Marketing" },
                    { new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), null, "Software Entwicklung" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "lock_type",
                columns: new[] { "id", "value" },
                values: new object[,]
                {
                    { 1, "Cylinder" },
                    { 2, "SmartHandle" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "medium_type",
                columns: new[] { "id", "value" },
                values: new object[,]
                {
                    { 1, "Card" },
                    { 2, "Transponder" },
                    { 3, "TransponderWithCardInlay" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "locks",
                columns: new[] { "id", "building_id", "description", "floor", "lock_type_id", "name", "room_number", "serial_number" },
                values: new object[,]
                {
                    { new Guid("060da4ab-dd20-4539-ac2e-8c47fd0bca50"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "EG", 1, "Schulungsraum", "S01", "UID-5DE29561" },
                    { new Guid("0a1e6f38-6076-4da8-8d6c-87356f975baf"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Gästezimmer 4.OG", "454", "UID-A89F98F3" },
                    { new Guid("0b7c9077-f149-4b2d-aaa1-bba4b6fe7599"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Bednar/Maggio/Morar", "339", "UID-B4E3BF8F" },
                    { new Guid("0c3d0cd4-a24e-45e9-85dd-80ad7a91ba79"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Besprechungsraum 4.OG groß", "408", "UID-41302C30" },
                    { new Guid("11a3bc84-2db4-4a9f-a97b-b734eed94b98"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Blick", "322", "UID-0CA0DC80" },
                    { new Guid("12fb5bd1-4f9a-44fc-a9ec-a1b3649e81ec"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "WC Damen 3.OG west", "WC.DR", "UID-B681BB56" },
                    { new Guid("14cfce07-160c-4454-83c2-c7ba29f51796"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "1.OG", 1, "Besprechungsraum 1.OG", "117", "UID-9590FAD2" },
                    { new Guid("19bc0a7e-c8ec-4fb6-be47-194885de46a8"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Purdy/Heller", "329", "UID-BDEA281D" },
                    { new Guid("20f8de01-f753-4309-b468-4c33333efd7b"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 2, "Werkstatt 2", "465", "UID-B9547400" },
                    { new Guid("22270680-ce59-4e52-bb0d-f2e43ba20952"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Lang/Denesik", "321", "UID-EBD15B0B" },
                    { new Guid("2b9e8a1f-3bf8-433b-8344-3e059b052178"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "Gottlieb/Moen/Dach", "431", "UID-46CCEB12" },
                    { new Guid("2f4632c2-c980-47c4-9c86-226e4493aba5"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Besprechungsraum 4.OG klein", "402", "UID-234FFA7D" },
                    { new Guid("31a998da-f4a4-42fa-951c-9af6c29a1766"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Ziemann/Nitzsche", "343", "UID-FA22D6F8" },
                    { new Guid("40c8a9ef-e533-470e-b127-4f09b791cb88"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Besprechungsraum 3.OG", "332", "UID-F5CC4F99" },
                    { new Guid("41c5952e-5812-44b8-87c2-cf120ea72cc0"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "Wilderman/Kohler/Hettinger", "430", "UID-52427309" },
                    { new Guid("41eec2b2-506c-4078-be1a-808e11f9e05c"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "Harber/Lubowitz/Mueller", "434", "UID-7495C44A" },
                    { new Guid("4f055142-fdaa-4dde-866a-ef72311ba52f"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 2, "Werkstatt 3", "468", "UID-64C2AD85" },
                    { new Guid("5f7d7f12-8fd7-4775-a76e-82c26f44582c"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Harvey", "344", "UID-453C0F28" },
                    { new Guid("6e2998a5-bab1-4692-b954-3aab4cc95d0c"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Veum/Wilderman", "439", "UID-7C487BC3" },
                    { new Guid("75696d97-2323-4647-b3a0-d59907273467"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "WC Herren 3.OG west", "WC.HR", "UID-82CE310A" },
                    { new Guid("767d6f18-7d58-4a5e-aad4-94ddf8f83f63"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Turner/Welch", "442", "UID-32E78952" },
                    { new Guid("76c06d7e-b2c6-4480-8d26-6e169fb71ee7"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 2, "Werkstatt 1", "460", "UID-049E18CE" },
                    { new Guid("7d282924-932b-46e6-9023-b54f41bfb592"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Lowe", "346", "UID-2E1DB976" },
                    { new Guid("86dd6259-5330-4ba4-8d12-0f2b4d9bd3b0"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Towne/Schmitt", "345", "UID-7E0EF358" },
                    { new Guid("8ad642cb-ca75-42d8-89c6-622a4739b06e"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Sipes/Fay", "441", "UID-5F28F488" },
                    { new Guid("8dc4171b-706f-48d2-817b-4e2f3a40090c"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Wisozk/Lang", "328", "UID-2D103CA2" },
                    { new Guid("9b663369-3840-402e-b18a-ccabf20d6f7d"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Lemke", "341", "UID-E7A26961" },
                    { new Guid("9c719fe0-a6b0-4e66-b8c0-613850125a88"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "Swift/Bednar/Cassin", "432", "UID-8C16902B" },
                    { new Guid("9d644819-543b-4d78-8e63-5976514f0d15"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Berge/Schoen", "340", "UID-722217E0" },
                    { new Guid("a28a9ac9-7c40-4254-af06-fff3d4b39b10"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "McLaughlin", "436", "UID-0F8AE86A" },
                    { new Guid("ac052437-7009-484b-a206-1198b798212d"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "McKenzie/Steuber/Lang", "437", "UID-E37B8571" },
                    { new Guid("b386ba3d-aac7-410a-9fa5-9a2b3a989527"), new Guid("9605186f-7eb4-4f40-967e-2885d9a8b3c4"), null, null, 1, "Besprechungsraum Osterfeld klein", "B.01", "UID-43C3F2C8" },
                    { new Guid("b8866ca5-7f5c-4565-8165-80682853b98f"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Kerluke/Bradtke", "326", "UID-CBDD200B" },
                    { new Guid("baef89d5-a427-4004-8286-6f048485c77d"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Berge", "325", "UID-58AFDCAB" },
                    { new Guid("bbe275af-73f6-4357-8478-3b17d966e30d"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Crona/Pacocha", "327", "UID-06D6CE73" },
                    { new Guid("be3d6d9e-3e30-4294-af60-bf24afacbefe"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "WC Damen 3.OG süd", "WC.DL", "UID-F40C9966" },
                    { new Guid("bec4b51f-47e8-4105-9278-95bb1cf5ee63"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Carroll/Ebert", "342", "UID-E51A2150" },
                    { new Guid("c1545d5b-46b3-4e3c-8a45-4cd077da7136"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Leannon/Donnelly", "440", "UID-B440946B" },
                    { new Guid("ccf2aa27-187c-4b4b-92b9-251b96192713"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "Mohr", "428", "UID-19EAB8A6" },
                    { new Guid("d1053e40-c2e8-4805-886c-56a1affe01cc"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "Schoen/Hermiston/Kuphal", "433", "UID-CA37EE93" },
                    { new Guid("d4f144db-cdb8-4b85-ae9c-e4603aa6482e"), new Guid("9605186f-7eb4-4f40-967e-2885d9a8b3c4"), null, null, 1, "Besprechungsraum Osterfeld groß", "B.02", "UID-21BC2485" },
                    { new Guid("df307bab-5362-4f2b-a7ac-14e9d577d348"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Zieme", "443", "UID-0DD11BFD" },
                    { new Guid("e04f23cd-bf5e-4a49-96ae-5c8b6b15fc94"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Kertzmann", "323", "UID-C05F8889" },
                    { new Guid("e4130030-aa93-4847-b0ff-81a86fac3de8"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Flatley/Parker", "320", "UID-27BF2D3B" },
                    { new Guid("e657a28e-d744-4f62-b5d8-a64123c2400f"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "WC Herren 3.OG süd", "WC.HL", "UID-C043133A" },
                    { new Guid("ea4c369b-38ec-4deb-ba65-bb9cdc756e83"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 1, "Harris/Bechtelar", "438", "UID-62C8D526" },
                    { new Guid("f07f4996-b027-457d-9fe7-3dd0a2ee5ba2"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "4.OG", 2, "McCullough/Tillman/Halvorson", "429", "UID-B4D3673E" },
                    { new Guid("fab80eca-b474-4b2e-b591-72f1dbbf9737"), new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"), null, "3.OG", 1, "Kling/Hauck", "324", "UID-F7F462B3" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "media",
                columns: new[] { "id", "description", "group_id", "medium_type_id", "owner", "serial_number" },
                values: new object[,]
                {
                    { new Guid("00891798-227b-4a49-9715-195539aec196"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Domenica Fritsch", "UID-DBFD732E" },
                    { new Guid("0600111a-06d7-45b5-9163-872cf21def9c"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Joel VonRueden V", "UID-E9002630" },
                    { new Guid("0681a85c-476d-446b-9210-f8e7a04aa6af"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Julianne Upton", "UID-744990A6" },
                    { new Guid("08d95d37-c85d-4b90-8814-1a90776f9842"), null, new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), 3, "Queenie Von", "UID-49BB6B9E" },
                    { new Guid("0b7e5913-a851-4340-8947-82277866daf2"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Margaretta Hyatt V", "UID-7E8AF5C9" },
                    { new Guid("0baae33b-bd14-40c1-aee1-ca2e3e111c4e"), null, new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"), 2, "Tierra Schneider", "UID-79EC88B2" },
                    { new Guid("0d8aaf21-b58a-46f8-9236-fc23793b5342"), null, new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), 3, "Emelie Rosenbaum IV", "UID-02D80F53" },
                    { new Guid("0e3a1cb3-a0ea-4e51-bda5-95637c854a1d"), null, new Guid("abf2f0f5-ca6c-47c6-a018-dffd3e59d3ea"), 3, "Mrs. Quinton Stanton", "UID-B28837DB" },
                    { new Guid("1461edc8-4f52-489b-9286-f462ee131515"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Mya Hills", "UID-87091016" },
                    { new Guid("16a1e212-5ba1-4b2d-81b8-ac49143fef57"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Pearlie Von I", "UID-5F4F0141" },
                    { new Guid("1720ff8f-8416-4124-8b1b-2f80c16d9ac0"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Marcella Schinner", "UID-EB92C0A9" },
                    { new Guid("1a3648e2-1641-47f5-b9e3-dec74bb0fe56"), null, new Guid("70c886f5-b74e-49f4-8d9f-cf2d6645d4d6"), 1, "Gast 2", "UID-B1196558" },
                    { new Guid("1bc23ee7-8629-4619-8283-cc7715d76fd0"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Kelley Erdman", "UID-C986DB58" },
                    { new Guid("1ed42246-b53a-4fce-939f-431768ed1698"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Brendon Ruecker", "UID-2693607D" },
                    { new Guid("1f2bf796-b185-4f08-bcec-8277e301c785"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Terrence O'Hara", "UID-1AC9C2D8" },
                    { new Guid("1f47f6c1-a770-4eeb-8f5a-1b606239bea0"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Jakayla Ullrich", "UID-6EC98F3F" },
                    { new Guid("1fc0aa9c-fa20-4576-92c8-77b28c0be3ac"), null, new Guid("abf2f0f5-ca6c-47c6-a018-dffd3e59d3ea"), 3, "Shirley Walter", "UID-45DF73F0" },
                    { new Guid("27e66bbd-b499-47e9-9d0c-5a6e421fc021"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Karelle Durgan", "UID-A15A2AEC" },
                    { new Guid("291834ee-c525-4533-9e63-2490dc374801"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Dr. Marta Heller", "UID-8F35CFFC" },
                    { new Guid("2c2ec98f-137a-4c49-a47a-814ae18a3364"), null, new Guid("70c886f5-b74e-49f4-8d9f-cf2d6645d4d6"), 1, "Gast 1", "UID-378D17F6" },
                    { new Guid("330ddafc-70b4-4a17-b6c5-91288a2384ec"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Dino McKenzie", "UID-B6DDA47E" },
                    { new Guid("3572be2e-f7a3-4d7d-bad7-32a11053c7dc"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Kelli Swift", "UID-FC2133D5" },
                    { new Guid("3cd8799b-9127-4b86-b235-1a5571fe98fe"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Ora Hermiston", "UID-E4FC2BC9" },
                    { new Guid("3ef9ec9e-b5a5-4532-ada2-ee7c2e5370de"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Pablo Bahringer", "UID-0A1F56B6" },
                    { new Guid("3f6bce56-66db-4543-9fac-83a3c48fcb8a"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Queenie Mraz Sr.", "UID-01C9773F" },
                    { new Guid("3ff0d521-14af-4e40-8b30-6b8f10783e72"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Concepcion Zieme", "UID-EBB3BCA7" },
                    { new Guid("40753f05-39fa-4711-942a-86abd73ab048"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Emmie Kirlin", "UID-D3D747CD" },
                    { new Guid("4187350f-ec37-4dfd-a5cb-b6a6e0f0328a"), null, new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"), 2, "Ms. Arden Kreiger", "UID-DA3A3B3B" },
                    { new Guid("467741f3-3700-4f17-9497-c8fd7bf37e39"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Camden Marquardt", "UID-21F04AF7" },
                    { new Guid("478c3c11-36ba-47f2-8c59-b112530fb391"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Otilia Shanahan", "UID-B4703B1D" },
                    { new Guid("4b583d96-3541-4172-8dba-78a4efe2ba6c"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Faye Greenholt I", "UID-D69797CC" },
                    { new Guid("4de2b510-2f48-4721-812d-60cd8868df64"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Mr. Talon Dickens", "UID-E7263924" },
                    { new Guid("55f8731c-97d5-4ccb-a990-48cb28fdab09"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Ayden Legros", "UID-5A5DA1AD" },
                    { new Guid("563c312f-7d47-4122-b321-5976921bd4be"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Derek Weber", "UID-2CE66793" },
                    { new Guid("57273b58-2288-4274-b6d7-476831c52f99"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Miss Arnaldo Jenkins", "UID-A43A67C6" },
                    { new Guid("5b93c27c-8bcb-4337-94ca-bafee7e6b49e"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Raquel Raynor", "UID-B75354DC" },
                    { new Guid("6002e8cb-92cf-49aa-be33-adce8e72f75d"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Morgan Erdman", "UID-D62A7212" },
                    { new Guid("60bb1716-6eec-4ec6-9d8c-81c72e8b2b50"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Noemie Ullrich", "UID-5C56C7EC" },
                    { new Guid("66f7f003-5129-4a3d-92ca-57e4ff81bb1d"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Gabrielle Kilback", "UID-F3A4AAE7" },
                    { new Guid("69928e33-bae7-48a9-a35f-e5cd4d0ace80"), null, new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"), 2, "Zula Cruickshank Sr.", "UID-7603ECFF" },
                    { new Guid("6a4e8e6a-d319-4cc4-9ac4-8853310ada2e"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Vincent Lakin", "UID-CF16E63E" },
                    { new Guid("6b14e836-86fe-4e3e-858d-c1690d6146c4"), null, new Guid("abf2f0f5-ca6c-47c6-a018-dffd3e59d3ea"), 3, "Modesto Bradtke", "UID-ADB2C586" },
                    { new Guid("6d38f072-4a3d-43c8-ab35-34e9764825a3"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Dr. Stella Donnelly", "UID-F17CDF2E" },
                    { new Guid("6fb7fce4-d922-4a63-a7e5-cac8e5bebc12"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Cody Hessel", "UID-6AD74FC8" },
                    { new Guid("742fb688-9d30-4fce-b153-ca6f29873377"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Michaela Huels", "UID-2B6244E5" },
                    { new Guid("7585060f-d86e-41bc-b9a9-e18c7bf750b2"), null, new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"), 2, "Haylie Bins V", "UID-9450378C" },
                    { new Guid("77d85d14-3bbf-4c83-bc01-7919af95f3fa"), null, new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"), 2, "Leslie Treutel", "UID-5D6080D2" },
                    { new Guid("7bb72be8-d967-459b-80af-fe6022485f43"), null, new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"), 2, "Jordan Cremin DDS", "UID-E992DE06" },
                    { new Guid("7e78daee-1e8b-4357-9c01-c89746ecbe4b"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Lysanne Ritchie", "UID-DB553815" },
                    { new Guid("7f255c19-7948-4ee3-8369-af5e266e9e43"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Hoyt Batz", "UID-6978F9BB" },
                    { new Guid("81222132-93c6-49c2-bcf5-93ec995f104c"), null, new Guid("a8fb8533-15dd-4a12-bd52-977b59caf77d"), 2, "Derick Ryan", "UID-F670F88B" },
                    { new Guid("81b2c428-a301-4f5c-9650-221f41b71c6d"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Hallie Rice", "UID-EAC6D3D4" },
                    { new Guid("8467c189-9b2c-4af8-97f4-1f698f5fb7d3"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Abigail Bogan", "UID-070E9E88" },
                    { new Guid("8474188c-0ee3-4f97-a616-724d31c874ba"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Mr. Luther Terry", "UID-DCC4A18B" },
                    { new Guid("89261aba-dad0-4a5e-bc17-72759c67cccb"), null, new Guid("a8fb8533-15dd-4a12-bd52-977b59caf77d"), 2, "Joey Murray", "UID-4DB71AF6" },
                    { new Guid("893fd59f-5792-4b4a-ae3e-afb0ea9fc603"), null, new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"), 2, "Golden Mraz", "UID-825D6F25" },
                    { new Guid("8b12f270-b96c-46ee-ae58-d751092dbee6"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Nedra Hartmann V", "UID-AB27F9C4" },
                    { new Guid("8e034ce4-d272-4a2a-aaa1-1d0e39ebf219"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Mrs. Isidro Goyette", "UID-313B4CB8" },
                    { new Guid("8e303b10-0fd9-4899-b6f3-1f9870092566"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Walton Wilkinson IV", "UID-57E11796" },
                    { new Guid("928d547e-09f4-4585-bd40-72e75c5bda84"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Jeramy Leffler", "UID-D452E4BD" },
                    { new Guid("931e1032-4916-4911-af3c-6ee49f0c548a"), null, new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), 3, "Clementine Heathcote", "UID-51C69E60" },
                    { new Guid("9b57b2da-b167-4cb1-89cf-23522a8c1bf6"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Effie Barton IV", "UID-7F67408F" },
                    { new Guid("9caeef90-ddbf-4830-8be9-832153b334ba"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Casimer Doyle", "UID-D58D998E" },
                    { new Guid("a2ac53c1-01c2-435d-9ed6-1c25e16c94f9"), null, new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"), 2, "Jack Macejkovic", "UID-F0DB00F1" },
                    { new Guid("a6c8bf5f-1f31-4526-bab3-35751b02745d"), null, new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"), 2, "Rick Bayer DVM", "UID-A72D5E72" },
                    { new Guid("a7481455-6045-4ecc-80dd-0d0416dcd185"), null, new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), 3, "Germaine Hermann", "UID-B1B0B358" },
                    { new Guid("a95296d4-282e-4b04-9f95-070d68ca0766"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Clement Dare", "UID-A3F8600C" },
                    { new Guid("a9754910-e6a0-4d28-9e36-59b08cdbfc08"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Emely Berge Sr.", "UID-A1607C57" },
                    { new Guid("aaa46326-6736-4d41-b6fb-f510c9b349df"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Lamar Abbott", "UID-1E0334B0" },
                    { new Guid("ab977feb-557c-49c4-9b41-e0b4c0b4da1f"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Myrl Kutch", "UID-0102E627" },
                    { new Guid("af28fd46-b690-4788-ae9c-565ed190ba31"), null, new Guid("a8fb8533-15dd-4a12-bd52-977b59caf77d"), 2, "Verda Reichert", "UID-9AABD45B" },
                    { new Guid("b01d3dda-fdb2-493d-8946-7d93e7cb8458"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Breanne Christiansen", "UID-65FFCA2C" },
                    { new Guid("b1760599-9f20-4bfc-812b-34c68f86d741"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Gladyce Hane", "UID-0238753A" },
                    { new Guid("b5482e40-fafd-4a10-84f5-b14128c16be1"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Danielle Stark Sr.", "UID-6A3B4B84" },
                    { new Guid("b8663068-8fa9-44ea-8b7f-5efa16f8a529"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Camryn Kessler", "UID-94D8BE2F" },
                    { new Guid("b8928763-e550-481e-a98c-3927d0c81506"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Laverna Skiles", "UID-80C35FDC" },
                    { new Guid("ba54b45a-4a8c-4367-99d1-aca848c8cab3"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Zola Stroman", "UID-1781AECE" },
                    { new Guid("baaffc45-63e6-4e97-83f9-1560382508c8"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Mr. Rene Harber", "UID-76DEAEBB" },
                    { new Guid("c09ebd30-d695-4053-9f9c-177a692f40e2"), null, new Guid("70c886f5-b74e-49f4-8d9f-cf2d6645d4d6"), 1, "Gast 3", "UID-7A45B6FD" },
                    { new Guid("c1890072-2753-4d91-8fd7-39dad7e7c161"), null, new Guid("abf2f0f5-ca6c-47c6-a018-dffd3e59d3ea"), 3, "Helen Pollich", "UID-92E308C4" },
                    { new Guid("c2c0257b-3612-4182-8070-ba17155aa6a6"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Nathanael Brakus", "UID-73379682" },
                    { new Guid("c3d2d121-145b-4970-9e17-630983c8dc98"), null, new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), 3, "Treva Muller", "UID-0CB36E1D" },
                    { new Guid("c4f69136-50ca-496a-bd72-8d1fc356af81"), null, new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"), 2, "Berneice Parisian", "UID-4F9B678C" },
                    { new Guid("c6a900d5-9463-45e1-968e-7cabf5492449"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Hailey Reichert III", "UID-D153E307" },
                    { new Guid("cf977696-64ee-4c0a-bb69-b0dd6dad9005"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Dr. Reymundo Fay", "UID-95211B5E" },
                    { new Guid("d2a97338-56d4-4b70-9516-8a350dca6716"), null, new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"), 2, "Bell Gulgowski", "UID-4C73E472" },
                    { new Guid("d7b3215e-0e8f-4c9e-a26d-890be545d465"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Mr. Celestino Schaden", "UID-B8AD5996" },
                    { new Guid("ddca7fb5-32f1-4855-8359-174efa22fccb"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Ms. Pink Hessel", "UID-EE577D31" },
                    { new Guid("df1ee00c-63e2-464e-b44a-72dba5553a3d"), null, new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"), 2, "Helen Beier", "UID-15B2DF92" },
                    { new Guid("e05eebae-757c-472b-9134-e412edac118e"), null, new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"), 2, "Elyssa Lakin", "UID-5DD0D401" },
                    { new Guid("e9688b67-d427-44ae-9042-496e0a0f4793"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Miss Aurelio Rodriguez", "UID-8D05FDA9" },
                    { new Guid("e9bbdceb-e901-456e-b129-f0c0b676b660"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Trystan Doyle DDS", "UID-E288BEDD" },
                    { new Guid("e9c918ae-ae3a-4690-856e-4d12e7311149"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Rosalia Hermiston", "UID-4D7406A9" },
                    { new Guid("eb427ccf-8ed2-4c60-b360-a224e45b0532"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Corene Effertz", "UID-8A62B48E" },
                    { new Guid("ebacd990-d439-4177-b3bf-fad155fd3ff1"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Mrs. Fanny Connelly", "UID-17FC1E14" },
                    { new Guid("eff349b8-28e7-4dc0-8364-148a049b0de4"), null, new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"), 2, "Ofelia Sporer DVM", "UID-DA01B45C" },
                    { new Guid("f107b8dc-c2ee-49b3-8f11-5a1128a51c51"), null, new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"), 2, "Lester McDermott", "UID-CE8317D8" },
                    { new Guid("f1cedc21-c83b-48ee-a68e-8c82bbdb26c5"), null, new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"), 3, "Clay Cremin", "UID-443A12B4" },
                    { new Guid("f28bb34e-fbac-4c07-ad19-6f50e48c4060"), null, new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"), 2, "Isabell Nicolas", "UID-281DA06B" },
                    { new Guid("f351956e-f3c2-45c2-bad7-1271e4a8c323"), null, new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"), 2, "Vita Corwin", "UID-62089CF8" },
                    { new Guid("f3d6a54a-0600-4a29-95fe-fc3e52bed6d6"), null, new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"), 3, "Meda Feeney", "UID-D81E3137" },
                    { new Guid("f6bcdf47-fd49-4bba-9960-af63e555ce21"), null, new Guid("a8fb8533-15dd-4a12-bd52-977b59caf77d"), 2, "Rebecca Barrows", "UID-08889EC2" },
                    { new Guid("f7a1663a-ba3f-434e-b676-9796e35a7670"), null, new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"), 2, "Eula Metz", "UID-E1CE6282" },
                    { new Guid("fa442e23-3afe-4150-9dde-13a036d5b2f9"), null, new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"), 2, "Larue Rice", "UID-38A3630C" },
                    { new Guid("fd00be74-47ec-4fdb-98db-a34e2ddc0a21"), null, new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"), 2, "Lulu Kreiger", "UID-4D447883" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "buildings",
                keyColumn: "id",
                keyValue: new Guid("3116849e-e18d-4afd-8058-156d8d96b593"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "buildings",
                keyColumn: "id",
                keyValue: new Guid("9a168210-ae8b-4cbe-b5f9-aa8b36dd5e70"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("060da4ab-dd20-4539-ac2e-8c47fd0bca50"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("0a1e6f38-6076-4da8-8d6c-87356f975baf"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("0b7c9077-f149-4b2d-aaa1-bba4b6fe7599"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("0c3d0cd4-a24e-45e9-85dd-80ad7a91ba79"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("11a3bc84-2db4-4a9f-a97b-b734eed94b98"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("12fb5bd1-4f9a-44fc-a9ec-a1b3649e81ec"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("14cfce07-160c-4454-83c2-c7ba29f51796"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("19bc0a7e-c8ec-4fb6-be47-194885de46a8"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("20f8de01-f753-4309-b468-4c33333efd7b"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("22270680-ce59-4e52-bb0d-f2e43ba20952"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("2b9e8a1f-3bf8-433b-8344-3e059b052178"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("2f4632c2-c980-47c4-9c86-226e4493aba5"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("31a998da-f4a4-42fa-951c-9af6c29a1766"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("40c8a9ef-e533-470e-b127-4f09b791cb88"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("41c5952e-5812-44b8-87c2-cf120ea72cc0"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("41eec2b2-506c-4078-be1a-808e11f9e05c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("4f055142-fdaa-4dde-866a-ef72311ba52f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("5f7d7f12-8fd7-4775-a76e-82c26f44582c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("6e2998a5-bab1-4692-b954-3aab4cc95d0c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("75696d97-2323-4647-b3a0-d59907273467"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("767d6f18-7d58-4a5e-aad4-94ddf8f83f63"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("76c06d7e-b2c6-4480-8d26-6e169fb71ee7"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("7d282924-932b-46e6-9023-b54f41bfb592"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("86dd6259-5330-4ba4-8d12-0f2b4d9bd3b0"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("8ad642cb-ca75-42d8-89c6-622a4739b06e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("8dc4171b-706f-48d2-817b-4e2f3a40090c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("9b663369-3840-402e-b18a-ccabf20d6f7d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("9c719fe0-a6b0-4e66-b8c0-613850125a88"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("9d644819-543b-4d78-8e63-5976514f0d15"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("a28a9ac9-7c40-4254-af06-fff3d4b39b10"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("ac052437-7009-484b-a206-1198b798212d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("b386ba3d-aac7-410a-9fa5-9a2b3a989527"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("b8866ca5-7f5c-4565-8165-80682853b98f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("baef89d5-a427-4004-8286-6f048485c77d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("bbe275af-73f6-4357-8478-3b17d966e30d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("be3d6d9e-3e30-4294-af60-bf24afacbefe"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("bec4b51f-47e8-4105-9278-95bb1cf5ee63"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("c1545d5b-46b3-4e3c-8a45-4cd077da7136"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("ccf2aa27-187c-4b4b-92b9-251b96192713"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("d1053e40-c2e8-4805-886c-56a1affe01cc"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("d4f144db-cdb8-4b85-ae9c-e4603aa6482e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("df307bab-5362-4f2b-a7ac-14e9d577d348"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("e04f23cd-bf5e-4a49-96ae-5c8b6b15fc94"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("e4130030-aa93-4847-b0ff-81a86fac3de8"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("e657a28e-d744-4f62-b5d8-a64123c2400f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("ea4c369b-38ec-4deb-ba65-bb9cdc756e83"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("f07f4996-b027-457d-9fe7-3dd0a2ee5ba2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "locks",
                keyColumn: "id",
                keyValue: new Guid("fab80eca-b474-4b2e-b591-72f1dbbf9737"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("00891798-227b-4a49-9715-195539aec196"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("0600111a-06d7-45b5-9163-872cf21def9c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("0681a85c-476d-446b-9210-f8e7a04aa6af"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("08d95d37-c85d-4b90-8814-1a90776f9842"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("0b7e5913-a851-4340-8947-82277866daf2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("0baae33b-bd14-40c1-aee1-ca2e3e111c4e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("0d8aaf21-b58a-46f8-9236-fc23793b5342"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("0e3a1cb3-a0ea-4e51-bda5-95637c854a1d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1461edc8-4f52-489b-9286-f462ee131515"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("16a1e212-5ba1-4b2d-81b8-ac49143fef57"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1720ff8f-8416-4124-8b1b-2f80c16d9ac0"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1a3648e2-1641-47f5-b9e3-dec74bb0fe56"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1bc23ee7-8629-4619-8283-cc7715d76fd0"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1ed42246-b53a-4fce-939f-431768ed1698"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1f2bf796-b185-4f08-bcec-8277e301c785"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1f47f6c1-a770-4eeb-8f5a-1b606239bea0"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("1fc0aa9c-fa20-4576-92c8-77b28c0be3ac"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("27e66bbd-b499-47e9-9d0c-5a6e421fc021"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("291834ee-c525-4533-9e63-2490dc374801"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("2c2ec98f-137a-4c49-a47a-814ae18a3364"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("330ddafc-70b4-4a17-b6c5-91288a2384ec"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("3572be2e-f7a3-4d7d-bad7-32a11053c7dc"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("3cd8799b-9127-4b86-b235-1a5571fe98fe"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("3ef9ec9e-b5a5-4532-ada2-ee7c2e5370de"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("3f6bce56-66db-4543-9fac-83a3c48fcb8a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("3ff0d521-14af-4e40-8b30-6b8f10783e72"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("40753f05-39fa-4711-942a-86abd73ab048"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("4187350f-ec37-4dfd-a5cb-b6a6e0f0328a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("467741f3-3700-4f17-9497-c8fd7bf37e39"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("478c3c11-36ba-47f2-8c59-b112530fb391"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("4b583d96-3541-4172-8dba-78a4efe2ba6c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("4de2b510-2f48-4721-812d-60cd8868df64"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("55f8731c-97d5-4ccb-a990-48cb28fdab09"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("563c312f-7d47-4122-b321-5976921bd4be"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("57273b58-2288-4274-b6d7-476831c52f99"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("5b93c27c-8bcb-4337-94ca-bafee7e6b49e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("6002e8cb-92cf-49aa-be33-adce8e72f75d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("60bb1716-6eec-4ec6-9d8c-81c72e8b2b50"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("66f7f003-5129-4a3d-92ca-57e4ff81bb1d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("69928e33-bae7-48a9-a35f-e5cd4d0ace80"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("6a4e8e6a-d319-4cc4-9ac4-8853310ada2e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("6b14e836-86fe-4e3e-858d-c1690d6146c4"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("6d38f072-4a3d-43c8-ab35-34e9764825a3"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("6fb7fce4-d922-4a63-a7e5-cac8e5bebc12"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("742fb688-9d30-4fce-b153-ca6f29873377"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("7585060f-d86e-41bc-b9a9-e18c7bf750b2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("77d85d14-3bbf-4c83-bc01-7919af95f3fa"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("7bb72be8-d967-459b-80af-fe6022485f43"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("7e78daee-1e8b-4357-9c01-c89746ecbe4b"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("7f255c19-7948-4ee3-8369-af5e266e9e43"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("81222132-93c6-49c2-bcf5-93ec995f104c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("81b2c428-a301-4f5c-9650-221f41b71c6d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("8467c189-9b2c-4af8-97f4-1f698f5fb7d3"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("8474188c-0ee3-4f97-a616-724d31c874ba"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("89261aba-dad0-4a5e-bc17-72759c67cccb"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("893fd59f-5792-4b4a-ae3e-afb0ea9fc603"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("8b12f270-b96c-46ee-ae58-d751092dbee6"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("8e034ce4-d272-4a2a-aaa1-1d0e39ebf219"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("8e303b10-0fd9-4899-b6f3-1f9870092566"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("928d547e-09f4-4585-bd40-72e75c5bda84"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("931e1032-4916-4911-af3c-6ee49f0c548a"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("9b57b2da-b167-4cb1-89cf-23522a8c1bf6"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("9caeef90-ddbf-4830-8be9-832153b334ba"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("a2ac53c1-01c2-435d-9ed6-1c25e16c94f9"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("a6c8bf5f-1f31-4526-bab3-35751b02745d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("a7481455-6045-4ecc-80dd-0d0416dcd185"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("a95296d4-282e-4b04-9f95-070d68ca0766"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("a9754910-e6a0-4d28-9e36-59b08cdbfc08"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("aaa46326-6736-4d41-b6fb-f510c9b349df"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("ab977feb-557c-49c4-9b41-e0b4c0b4da1f"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("af28fd46-b690-4788-ae9c-565ed190ba31"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("b01d3dda-fdb2-493d-8946-7d93e7cb8458"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("b1760599-9f20-4bfc-812b-34c68f86d741"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("b5482e40-fafd-4a10-84f5-b14128c16be1"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("b8663068-8fa9-44ea-8b7f-5efa16f8a529"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("b8928763-e550-481e-a98c-3927d0c81506"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("ba54b45a-4a8c-4367-99d1-aca848c8cab3"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("baaffc45-63e6-4e97-83f9-1560382508c8"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("c09ebd30-d695-4053-9f9c-177a692f40e2"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("c1890072-2753-4d91-8fd7-39dad7e7c161"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("c2c0257b-3612-4182-8070-ba17155aa6a6"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("c3d2d121-145b-4970-9e17-630983c8dc98"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("c4f69136-50ca-496a-bd72-8d1fc356af81"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("c6a900d5-9463-45e1-968e-7cabf5492449"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("cf977696-64ee-4c0a-bb69-b0dd6dad9005"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("d2a97338-56d4-4b70-9516-8a350dca6716"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("d7b3215e-0e8f-4c9e-a26d-890be545d465"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("ddca7fb5-32f1-4855-8359-174efa22fccb"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("df1ee00c-63e2-464e-b44a-72dba5553a3d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("e05eebae-757c-472b-9134-e412edac118e"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("e9688b67-d427-44ae-9042-496e0a0f4793"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("e9bbdceb-e901-456e-b129-f0c0b676b660"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("e9c918ae-ae3a-4690-856e-4d12e7311149"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("eb427ccf-8ed2-4c60-b360-a224e45b0532"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("ebacd990-d439-4177-b3bf-fad155fd3ff1"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("eff349b8-28e7-4dc0-8364-148a049b0de4"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f107b8dc-c2ee-49b3-8f11-5a1128a51c51"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f1cedc21-c83b-48ee-a68e-8c82bbdb26c5"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f28bb34e-fbac-4c07-ad19-6f50e48c4060"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f351956e-f3c2-45c2-bad7-1271e4a8c323"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f3d6a54a-0600-4a29-95fe-fc3e52bed6d6"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f6bcdf47-fd49-4bba-9960-af63e555ce21"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("f7a1663a-ba3f-434e-b676-9796e35a7670"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("fa442e23-3afe-4150-9dde-13a036d5b2f9"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "media",
                keyColumn: "id",
                keyValue: new Guid("fd00be74-47ec-4fdb-98db-a34e2ddc0a21"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "buildings",
                keyColumn: "id",
                keyValue: new Guid("0cccab2b-bc8d-44c5-b248-8a9ca6d7e899"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "buildings",
                keyColumn: "id",
                keyValue: new Guid("9605186f-7eb4-4f40-967e-2885d9a8b3c4"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("20645cff-16ec-4ba2-9089-65595d07c6e4"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("39408213-bbd6-45f9-8833-1c50531dfdf1"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("3a2dc9f1-9f72-4fbf-8b44-56324e999e53"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("66857cbd-780e-4ac7-b2b4-4e27697e0f67"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("70c886f5-b74e-49f4-8d9f-cf2d6645d4d6"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("a802c953-4219-4b63-81bf-2a121a5c543c"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("a8fb8533-15dd-4a12-bd52-977b59caf77d"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("a9d4ac7b-754e-4a1f-b76e-34be75995d32"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("abf2f0f5-ca6c-47c6-a018-dffd3e59d3ea"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("ad457a8e-876e-4063-88e0-2ce10b9ab334"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("c33bc82c-b5d9-4f17-ae03-b8190e496bf3"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("dc4acc1a-2242-432a-8281-7e257c52e677"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "groups",
                keyColumn: "id",
                keyValue: new Guid("f445bec2-ccb5-4cb6-aff2-dec53f10d292"));

            migrationBuilder.DeleteData(
                schema: "public",
                table: "lock_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "lock_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "medium_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "medium_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "medium_type",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
