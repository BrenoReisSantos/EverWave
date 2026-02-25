using Bogus;

namespace EverWave.Tests.Common;

public class BaseUnitTest
{
    protected Faker Faker { get; } = new Faker("pt_BR");
}