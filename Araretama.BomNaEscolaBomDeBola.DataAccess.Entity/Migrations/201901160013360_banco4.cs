namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TB_ALUNO", "Turma_Id", "dbo.TB_TURMA");
            DropForeignKey("dbo.TB_VOLUNTARIO", "Turma_Id", "dbo.TB_TURMA");
            DropIndex("dbo.TB_ALUNO", new[] { "Turma_Id" });
            DropIndex("dbo.TB_VOLUNTARIO", new[] { "Turma_Id" });
            DropColumn("dbo.TB_ALUNO", "Turma_Id");
            DropColumn("dbo.TB_VOLUNTARIO", "Turma_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TB_VOLUNTARIO", "Turma_Id", c => c.Int());
            AddColumn("dbo.TB_ALUNO", "Turma_Id", c => c.Int());
            CreateIndex("dbo.TB_VOLUNTARIO", "Turma_Id");
            CreateIndex("dbo.TB_ALUNO", "Turma_Id");
            AddForeignKey("dbo.TB_VOLUNTARIO", "Turma_Id", "dbo.TB_TURMA", "TUR_ID");
            AddForeignKey("dbo.TB_ALUNO", "Turma_Id", "dbo.TB_TURMA", "TUR_ID");
        }
    }
}
