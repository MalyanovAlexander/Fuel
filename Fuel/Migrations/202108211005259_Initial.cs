namespace Fuel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        MileageMorning = c.Int(nullable: false),
                        FuelMorning = c.Double(nullable: false),
                        Refueling = c.Int(nullable: false),
                        MileagePerDay = c.Int(nullable: false),
                        MileageEvening = c.Int(nullable: false),
                        FuelEvening = c.Double(nullable: false),
                        DailyConsumption = c.Double(nullable: false),
                        IdleHours = c.Int(nullable: false),
                        IdleConsumption = c.Double(nullable: false),
                        TotalConsumption = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trips");
        }
    }
}
