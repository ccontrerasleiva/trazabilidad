namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carro",
                c => new
                    {
                        IdCarro = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Patente = c.Int(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdCarro);
            
            CreateTable(
                "dbo.Trazabilidad_Mov_Carro",
                c => new
                    {
                        IdTrazabilidadMovCarro = c.Int(nullable: false, identity: true),
                        IdTrazabilidad = c.Int(nullable: false),
                        IdCarro = c.Int(nullable: false),
                        IdContenedor = c.Int(nullable: false),
                        IdStatu = c.Int(nullable: false),
                        IdTag = c.Int(nullable: false),
                        CodigoSello = c.String(),
                        PesoNeto = c.Int(),
                        PesoBruto = c.Int(),
                        PesoTara = c.Int(),
                        Sello = c.Int(),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdTrazabilidadMovCarro)
                .ForeignKey("dbo.Carro", t => t.IdCarro)
                .ForeignKey("dbo.Contenedor", t => t.IdContenedor)
                .ForeignKey("dbo.Statu", t => t.IdStatu)
                .ForeignKey("dbo.Tag", t => t.IdTag)
                .ForeignKey("dbo.Trazabilidad", t => t.IdTrazabilidad)
                .Index(t => t.IdTrazabilidad)
                .Index(t => t.IdCarro)
                .Index(t => t.IdContenedor)
                .Index(t => t.IdStatu)
                .Index(t => t.IdTag);
            
            CreateTable(
                "dbo.Contenedor",
                c => new
                    {
                        IdContenedor = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        PesoTara = c.Int(nullable: false),
                        Patente = c.Int(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdContenedor);
            
            CreateTable(
                "dbo.Statu",
                c => new
                    {
                        IdStatu = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdStatu);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        IdTag = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdTag);
            
            CreateTable(
                "dbo.Trazabilidad",
                c => new
                    {
                        IdTrazabilidad = c.Int(nullable: false, identity: true),
                        IdRuta = c.Int(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(),
                        FechaInicio = c.DateTime(),
                        FechaCierre = c.DateTime(),
                        IdConductor = c.Int(nullable: false),
                        Observacion = c.String(),
                        IdBase = c.Int(),
                        IdBascula = c.Int(),
                        IdCV = c.String(),
                        IdEtruck = c.Int(),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdTrazabilidad)
                .ForeignKey("dbo.Cliente", t => t.IdCliente)
                .ForeignKey("dbo.Conductor", t => t.IdConductor)
                .ForeignKey("dbo.Ruta", t => t.IdRuta)
                .Index(t => t.IdRuta)
                .Index(t => t.IdCliente)
                .Index(t => t.IdConductor);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Celular = c.String(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Conductor",
                c => new
                    {
                        IdConductor = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(),
                        Celular = c.String(),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdConductor);
            
            CreateTable(
                "dbo.Ruta",
                c => new
                    {
                        IdRuta = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        FechaHoraInicio = c.DateTime(nullable: false),
                        FechaHoraTermino = c.DateTime(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdRuta);
            
            CreateTable(
                "dbo.Trazabilidad_Mov_Locomotora",
                c => new
                    {
                        IdTrazabilidadMovLocomotora = c.Int(nullable: false, identity: true),
                        IdTrazabilidad = c.Int(nullable: false),
                        IdLocomotora = c.Int(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdTrazabilidadMovLocomotora)
                .ForeignKey("dbo.Locomotora", t => t.IdLocomotora)
                .ForeignKey("dbo.Trazabilidad", t => t.IdTrazabilidad)
                .Index(t => t.IdTrazabilidad)
                .Index(t => t.IdLocomotora);
            
            CreateTable(
                "dbo.Locomotora",
                c => new
                    {
                        IdLocomotora = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false),
                        Patente = c.String(nullable: false),
                        PesoTara = c.Int(nullable: false),
                        fecha_creacion = c.DateTime(nullable: false),
                        fecha_modificacion = c.DateTime(nullable: false),
                        Deshabilitado = c.Boolean(),
                    })
                .PrimaryKey(t => t.IdLocomotora);
            
            CreateTable(
                "dbo.CacheTokenUsuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_usuario_web = c.String(),
                        bits_cache = c.Binary(),
                        ultima_escritura = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trazabilidad_Mov_Carro", "IdTrazabilidad", "dbo.Trazabilidad");
            DropForeignKey("dbo.Trazabilidad_Mov_Locomotora", "IdTrazabilidad", "dbo.Trazabilidad");
            DropForeignKey("dbo.Trazabilidad_Mov_Locomotora", "IdLocomotora", "dbo.Locomotora");
            DropForeignKey("dbo.Trazabilidad", "IdRuta", "dbo.Ruta");
            DropForeignKey("dbo.Trazabilidad", "IdConductor", "dbo.Conductor");
            DropForeignKey("dbo.Trazabilidad", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Trazabilidad_Mov_Carro", "IdTag", "dbo.Tag");
            DropForeignKey("dbo.Trazabilidad_Mov_Carro", "IdStatu", "dbo.Statu");
            DropForeignKey("dbo.Trazabilidad_Mov_Carro", "IdContenedor", "dbo.Contenedor");
            DropForeignKey("dbo.Trazabilidad_Mov_Carro", "IdCarro", "dbo.Carro");
            DropIndex("dbo.Trazabilidad_Mov_Locomotora", new[] { "IdLocomotora" });
            DropIndex("dbo.Trazabilidad_Mov_Locomotora", new[] { "IdTrazabilidad" });
            DropIndex("dbo.Trazabilidad", new[] { "IdConductor" });
            DropIndex("dbo.Trazabilidad", new[] { "IdCliente" });
            DropIndex("dbo.Trazabilidad", new[] { "IdRuta" });
            DropIndex("dbo.Trazabilidad_Mov_Carro", new[] { "IdTag" });
            DropIndex("dbo.Trazabilidad_Mov_Carro", new[] { "IdStatu" });
            DropIndex("dbo.Trazabilidad_Mov_Carro", new[] { "IdContenedor" });
            DropIndex("dbo.Trazabilidad_Mov_Carro", new[] { "IdCarro" });
            DropIndex("dbo.Trazabilidad_Mov_Carro", new[] { "IdTrazabilidad" });
            DropTable("dbo.CacheTokenUsuarios");
            DropTable("dbo.Locomotora");
            DropTable("dbo.Trazabilidad_Mov_Locomotora");
            DropTable("dbo.Ruta");
            DropTable("dbo.Conductor");
            DropTable("dbo.Cliente");
            DropTable("dbo.Trazabilidad");
            DropTable("dbo.Tag");
            DropTable("dbo.Statu");
            DropTable("dbo.Contenedor");
            DropTable("dbo.Trazabilidad_Mov_Carro");
            DropTable("dbo.Carro");
        }
    }
}
