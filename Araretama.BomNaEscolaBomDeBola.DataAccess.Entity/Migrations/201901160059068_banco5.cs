namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_VOL_TUR",
                c => new
                    {
                        VOL_ID = c.Int(nullable: false),
                        TUR_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VOL_ID, t.TUR_ID })
                .ForeignKey("dbo.TB_VOLUNTARIO", t => t.VOL_ID, cascadeDelete: true)
                .ForeignKey("dbo.TB_TURMA", t => t.TUR_ID, cascadeDelete: true)
                .Index(t => t.VOL_ID)
                .Index(t => t.TUR_ID);
            
            CreateTable(
                "dbo.TB_ALU_TUR",
                c => new
                    {
                        ALU_ID = c.Int(nullable: false),
                        TUR_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ALU_ID, t.TUR_ID })
                .ForeignKey("dbo.TB_ALUNO", t => t.ALU_ID, cascadeDelete: true)
                .ForeignKey("dbo.TB_TURMA", t => t.TUR_ID, cascadeDelete: true)
                .Index(t => t.ALU_ID)
                .Index(t => t.TUR_ID);
            
            AddColumn("dbo.TB_VOLUNTARIO", "Voluntario_Id", c => c.Int());
            CreateIndex("dbo.TB_VOLUNTARIO", "Voluntario_Id");
            AddForeignKey("dbo.TB_VOLUNTARIO", "Voluntario_Id", "dbo.TB_VOLUNTARIO", "VOL_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_ALU_TUR", "TUR_ID", "dbo.TB_TURMA");
            DropForeignKey("dbo.TB_ALU_TUR", "ALU_ID", "dbo.TB_ALUNO");
            DropForeignKey("dbo.TB_VOLUNTARIO", "Voluntario_Id", "dbo.TB_VOLUNTARIO");
            DropForeignKey("dbo.TB_VOL_TUR", "TUR_ID", "dbo.TB_TURMA");
            DropForeignKey("dbo.TB_VOL_TUR", "VOL_ID", "dbo.TB_VOLUNTARIO");
            DropIndex("dbo.TB_ALU_TUR", new[] { "TUR_ID" });
            DropIndex("dbo.TB_ALU_TUR", new[] { "ALU_ID" });
            DropIndex("dbo.TB_VOL_TUR", new[] { "TUR_ID" });
            DropIndex("dbo.TB_VOL_TUR", new[] { "VOL_ID" });
            DropIndex("dbo.TB_VOLUNTARIO", new[] { "Voluntario_Id" });
            DropColumn("dbo.TB_VOLUNTARIO", "Voluntario_Id");
            DropTable("dbo.TB_ALU_TUR");
            DropTable("dbo.TB_VOL_TUR");
        }
    }
}
