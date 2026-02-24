using EverWave.Data;

using Microsoft.EntityFrameworkCore;

namespace EverWave.Tests.Common;

public class DatabaseFixture : IDisposable
{
    public EverWaveContext Context { get; }

    public DatabaseFixture()
    {
        Context = CreateContext();
        MigrateDatabase();
    }

    EverWaveContext CreateContext()
    {
        return new EverWaveContext(new DbContextOptionsBuilder()
            .UseNpgsql("Server=localhost;Port=5432;Database=EverWaveTest;User Id=postgres;Password=postgres;").Options);
    }

    public void MigrateDatabase()
    {
        Context.Database.Migrate();
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
    }
}