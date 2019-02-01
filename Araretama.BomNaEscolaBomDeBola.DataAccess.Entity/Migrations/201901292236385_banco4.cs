namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TB_TURMA", "TUR_HORARIOINICIAL", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.TB_TURMA", "TUR_HOORARIOFINAL", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TB_TURMA", "TUR_HOORARIOFINAL", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TB_TURMA", "TUR_HORARIOINICIAL", c => c.DateTime(nullable: false));
        }
    }
}
