namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Route", "date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Route", "date");
        }
    }
}
