using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTicketsPlugin.Server.Migrations
{
    public partial class newclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "986d9757-a9f2-40c6-9225-439c7f36e9e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "cfa6bed6-dd3d-4523-9d2e-b72b820098d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "716ae255-d3e2-4812-90ec-29f39d666175", "AQAAAAEAACcQAAAAEDADBSRmW2lgbzVt7tdM+KL0GuKAohlobCM7HnRzvDj9U1kdwan+5heCMfb3LfPk1Q==", "aef9ab95-6993-4335-b64c-cd159687564d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3c68f8e-e36c-4184-9b5d-b7b28bc9a79f", "AQAAAAEAACcQAAAAEMO1Wb/NypSJpSSlsJNBmLdtP3599zfvt0ryC3DyksZUwOEzjScOPGId2YOzJ0fRFQ==", "e9a8f3b6-87e8-467a-9931-ce5ba9a7ccd3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "339c6b16-aea6-48ee-86a0-505884853ae5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "92d80ff4-ae77-490f-a25b-5a56a6c34fcd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81c63a01-d91d-48fd-9a56-12c9384bd44e", "AQAAAAEAACcQAAAAEODcb0h02Z/PNSDCttTopjn/ho6NBq1jH8T0T9IAnNq4JgeUpCI4Bc9cAZ4Z6lZdRg==", "30e8fb78-c995-4c7e-b823-3d4791b33d20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4fefc49-c87a-4c80-82a2-d3c9d86e63c3", "AQAAAAEAACcQAAAAEMhd9X3HrSEE4GxePvaylfhyR8WfibNZwWRDnBbL/3L0ivf/EEFti/83rtKHoa3DBQ==", "378de3e0-9f6d-4cf4-8706-d81d16536af6" });
        }
    }
}
