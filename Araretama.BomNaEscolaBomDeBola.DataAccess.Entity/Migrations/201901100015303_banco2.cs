namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TB_AULA", "AUL_HORARIO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_AULA", "AUL_HORARIO", c => c.DateTime());
        }
    }
}
