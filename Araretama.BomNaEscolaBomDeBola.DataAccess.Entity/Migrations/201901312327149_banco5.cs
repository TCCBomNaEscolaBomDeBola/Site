namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_VOLUNTARIO", "Voluntario_Id", "dbo.TB_VOLUNTARIO");
            DropIndex("dbo.TB_VOLUNTARIO", new[] { "Voluntario_Id" });
            DropColumn("dbo.TB_VOLUNTARIO", "Voluntario_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_VOLUNTARIO", "Voluntario_Id", c => c.Int());
            CreateIndex("dbo.TB_VOLUNTARIO", "Voluntario_Id");
            AddForeignKey("dbo.TB_VOLUNTARIO", "Voluntario_Id", "dbo.TB_VOLUNTARIO", "VOL_ID");
        }
    }
}
