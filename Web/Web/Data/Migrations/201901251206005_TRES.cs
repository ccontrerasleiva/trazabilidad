namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TRES : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ruta", "Orden", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ruta", "Orden");
        }
    }
}
