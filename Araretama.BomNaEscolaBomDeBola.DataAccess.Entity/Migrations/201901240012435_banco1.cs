namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TB_ALUTUR", newName: "TurmaAlunoes");
            RenameColumn(table: "dbo.TurmaAlunoes", name: "AlunoId", newName: "Aluno_Id");
            RenameColumn(table: "dbo.TurmaAlunoes", name: "CursoId", newName: "Turma_Id");
            RenameIndex(table: "dbo.TurmaAlunoes", name: "IX_CursoId", newName: "IX_Turma_Id");
            RenameIndex(table: "dbo.TurmaAlunoes", name: "IX_AlunoId", newName: "IX_Aluno_Id");
            DropPrimaryKey("dbo.TurmaAlunoes");
            CreateTable(
                "dbo.TB_ALUTUR",
                c => new
                    {
                        TUR_ID = c.Int(nullable: false),
                        ALU_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TUR_ID, t.ALU_ID });
            
            AddPrimaryKey("dbo.TurmaAlunoes", new[] { "Turma_Id", "Aluno_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TurmaAlunoes");
            DropTable("dbo.TB_ALUTUR");
            AddPrimaryKey("dbo.TurmaAlunoes", new[] { "AlunoId", "CursoId" });
            RenameIndex(table: "dbo.TurmaAlunoes", name: "IX_Aluno_Id", newName: "IX_AlunoId");
            RenameIndex(table: "dbo.TurmaAlunoes", name: "IX_Turma_Id", newName: "IX_CursoId");
            RenameColumn(table: "dbo.TurmaAlunoes", name: "Turma_Id", newName: "CursoId");
            RenameColumn(table: "dbo.TurmaAlunoes", name: "Aluno_Id", newName: "AlunoId");
            RenameTable(name: "dbo.TurmaAlunoes", newName: "TB_ALUTUR");
        }
    }
}
