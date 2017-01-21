namespace Tasklist.DAL.SQL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Name = c.String(maxLength: 255),
                    Description = c.String(),
                    DueDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    ProjectId = c.Long(nullable: false),
                    Name = c.String(maxLength: 255),
                    IsDone = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
