namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_ALUNO", "ALU_DATANASC", c => c.String(maxLength: 100));
            AlterColumn("dbo.TB_ALUNO", "ALU_ESCOLA", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_ALUNO", "ALU_ESCOLA", c => c.String());
            AlterColumn("dbo.TB_ALUNO", "ALU_DATANASC", c => c.String());
        }
    }
}
