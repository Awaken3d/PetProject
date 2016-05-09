namespace PetProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Duration", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
