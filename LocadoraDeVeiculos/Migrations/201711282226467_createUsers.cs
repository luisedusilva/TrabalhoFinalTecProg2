namespace LocadoraDeVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class createUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6a7148a4-0595-4c03-8031-74df3f24419b', N'luis.edu2609@gmail.com', 0, N'AOn67srEDVJ7NzW2YgDgj2GhQGM8+xGvQ+ifJFyXt4mOfQWvHeJFL4a2ydy8DGfRmg==', N'a5924bcc-79d7-441c-8b76-9cd728ccd85a', NULL, 0, 0, NULL, 1, 0, N'luis.edu2609@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f0822a59-7366-4b99-b347-e72ff08891c1', N'luis98.silva@catolicasc.org.br', 0, N'ACckwpXB0q4O6nnLDs206rFb2TaSqaHc8kgs7miIdEUSSPcsI2dEQeyBNKejZdUgcQ==', N'8a120c1f-e134-42c1-b6df-c2f9702470c2', NULL, 0, 0, NULL, 1, 0, N'luis98.silva@catolicasc.org.br')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'011cea56-4d0c-462c-a312-129072d5402c', N'StoreAdmin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f0822a59-7366-4b99-b347-e72ff08891c1', N'011cea56-4d0c-462c-a312-129072d5402c')

");
        }



        public override void Down()
        {

        }
    }
}
