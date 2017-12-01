namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        pointA_x = c.Double(nullable: false),
                        pointA_y = c.Double(nullable: false),
                        pointB_x = c.Double(nullable: false),
                        pointB_y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Route");
        }
    }
}
