namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TB_ALUNO", "TUR_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_ALUNO", "TUR_ID", c => c.Int(nullable: false));
        }
    }
}
