using EverWave.Data;

using Microsoft.EntityFrameworkCore;

namespace EverWave.Tests.Common;

public class BasicDatabaseFixture : BaseUnitTest
{
    public EverWaveContext Context { get; }

    public BasicDatabaseFixture()
    {
        Context = CreateContext();
        CreateDatabase();
    }

    EverWaveContext CreateContext()
    {
        return new EverWaveContext(new DbContextOptionsBuilder()
            .UseNpgsql("Server=localhost;Port=5432;Database=EverWaveTest;User Id=postgres;Password=postgres;").Options);
    }

    public void CreateDatabase()
    {
        Context.ChangeTracker.Clear();
        Context.Database.EnsureDeleted();
        Context.Database.Migrate();
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
    }
}