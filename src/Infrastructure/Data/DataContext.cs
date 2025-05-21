using Core.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDB.Bson.Serialization.Conventions;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            ConventionRegistry.Register("camelCase", new ConventionPack {
                new CamelCaseElementNameConvention()
            }, _ => true);

            ConventionRegistry.Register("EnumStringConvention", new ConventionPack {
                new EnumRepresentationConvention(BsonType.String)
            }, _ => true);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToCollection("Users");
        }
    }
}