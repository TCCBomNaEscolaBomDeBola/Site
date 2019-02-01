namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TB_AULA", "Turma_Id", c => c.Int(nullable: false));
            AddColumn("dbo.TB_PRESENCA", "Aluno_Id", c => c.Int());
            CreateIndex("dbo.TB_AULA", "Turma_Id");
            CreateIndex("dbo.TB_PRESENCA", "Aluno_Id");
            AddForeignKey("dbo.TB_PRESENCA", "Aluno_Id", "dbo.TB_ALUNO", "ALU_ID");
            AddForeignKey("dbo.TB_AULA", "Turma_Id", "dbo.TB_TURMA", "TUR_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_AULA", "Turma_Id", "dbo.TB_TURMA");
            DropForeignKey("dbo.TB_PRESENCA", "Aluno_Id", "dbo.TB_ALUNO");
            DropIndex("dbo.TB_PRESENCA", new[] { "Aluno_Id" });
            DropIndex("dbo.TB_AULA", new[] { "Turma_Id" });
            DropColumn("dbo.TB_PRESENCA", "Aluno_Id");
            DropColumn("dbo.TB_AULA", "Turma_Id");
        }
    }
}
