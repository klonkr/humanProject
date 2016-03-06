namespace ProjectHuman.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethinghaschanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Human", "Pnr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Human", "Pnr");
        }
    }
}
