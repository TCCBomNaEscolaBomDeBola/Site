namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_ALUNO",
                c => new
                    {
                        ALU_ID = c.Int(nullable: false, identity: true),
                        TUR_ID = c.Int(nullable: false),
                        ALU_NOME = c.String(nullable: false, maxLength: 200),
                        ALU_DATANASC = c.String(),
                        ALU_ESCOLA = c.String(),
                        ALU_SERIE = c.String(),
                        ALU_RESPONSAVEL = c.String(),
                        ALU_CONTATO = c.String(),
                        ALU_LOGRADOURO = c.String(),
                        ALU_NUMERO = c.String(),
                        ALU_CEP = c.String(),
                        ALU_BAIRRO = c.String(),
                        ALU_CIDADE = c.String(),
                        ALU_ESTADO = c.String(),
                        ALU_COMPLEMENTO = c.String(),
                        ALU_OBSERVACAO = c.String(),
                        Turma_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ALU_ID)
                .ForeignKey("dbo.TB_TURMA", t => t.Turma_Id)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "dbo.TB_TURMA",
                c => new
                    {
                        TUR_ID = c.Int(nullable: false, identity: true),
                        TUR_NOME = c.String(nullable: false, maxLength: 100),
                        TUR_IDADEMINIMA = c.Int(nullable: true),
                        TUR_IDADEMAXIMA = c.Int(nullable: true),
                        TUR_HORARIOINICIAL = c.DateTime(nullable: true),
                        TUR_HOORARIOFINAL = c.DateTime(nullable: true),
                        TUR_DIASEMANA = c.String(),
                    })
                .PrimaryKey(t => t.TUR_ID);
            
            CreateTable(
                "dbo.TB_VOLUNTARIO",
                c => new
                    {
                        VOL_ID = c.Int(nullable: false, identity: true),
                        TUR_ID = c.Int(nullable: false),
                        VOL_NOME = c.String(nullable: false, maxLength: 200),
                        VOL_SENHA = c.String(nullable: false),
                        VOL_EMAIL = c.String(nullable: false),
                        VOL_CONTATO = c.String(),
                        Turma_Id = c.Int(),
                    })
                .PrimaryKey(t => t.VOL_ID)
                .ForeignKey("dbo.TB_TURMA", t => t.Turma_Id)
                .Index(t => t.Turma_Id);
            
            CreateTable(
                "dbo.TB_PRESENCA",
                c => new
                    {
                        PRE_ID = c.Int(nullable: false, identity: true),
                        ALU_ID = c.Int(nullable: false),
                        PRE_PRESENCA = c.Boolean(nullable: false),
                        AUL_ID = c.Int(nullable: false),
                        Aula_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PRE_ID)
                .ForeignKey("dbo.TB_AULA", t => t.Aula_Id)
                .Index(t => t.Aula_Id);
            
            CreateTable(
                "dbo.TB_AULA",
                c => new
                    {
                        AUL_ID = c.Int(nullable: false, identity: true),
                        AUL_DATAAULA = c.DateTime(),
                        AUL_DATAENVIO = c.DateTime(nullable: true),
                        AUL_HORARIO = c.DateTime(),
                        TUR_ID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.AUL_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_PRESENCA", "Aula_Id", "dbo.TB_AULA");
            DropForeignKey("dbo.TB_VOLUNTARIO", "Turma_Id", "dbo.TB_TURMA");
            DropForeignKey("dbo.TB_ALUNO", "Turma_Id", "dbo.TB_TURMA");
            DropIndex("dbo.TB_PRESENCA", new[] { "Aula_Id" });
            DropIndex("dbo.TB_VOLUNTARIO", new[] { "Turma_Id" });
            DropIndex("dbo.TB_ALUNO", new[] { "Turma_Id" });
            DropTable("dbo.TB_AULA");
            DropTable("dbo.TB_PRESENCA");
            DropTable("dbo.TB_VOLUNTARIO");
            DropTable("dbo.TB_TURMA");
            DropTable("dbo.TB_ALUNO");
        }
    }
}
