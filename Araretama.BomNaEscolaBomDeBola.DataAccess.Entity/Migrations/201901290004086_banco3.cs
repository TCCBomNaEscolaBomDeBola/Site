namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_AULA", "Turma_Id", "dbo.TB_TURMA");
            DropIndex("dbo.TB_AULA", new[] { "Turma_Id" });
            RenameColumn(table: "dbo.TB_AULA", name: "Turma_Id", newName: "TUR_ID");
            AlterColumn("dbo.TB_AULA", "TUR_ID", c => c.Int());
            CreateIndex("dbo.TB_AULA", "TUR_ID");
            AddForeignKey("dbo.TB_AULA", "TUR_ID", "dbo.TB_TURMA", "TUR_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_AULA", "TUR_ID", "dbo.TB_TURMA");
            DropIndex("dbo.TB_AULA", new[] { "TUR_ID" });
            AlterColumn("dbo.TB_AULA", "TUR_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TB_AULA", name: "TUR_ID", newName: "Turma_Id");
            CreateIndex("dbo.TB_AULA", "Turma_Id");
            AddForeignKey("dbo.TB_AULA", "Turma_Id", "dbo.TB_TURMA", "TUR_ID", cascadeDelete: true);
        }
    }
}
