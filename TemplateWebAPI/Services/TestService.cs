using TemplateWebAPI.Services.Interfaces;

namespace TemplateWebAPI.Services;

public class TestService : ISingletonService, IScopedService, ITransientService
{
    public string ServiceUniqueId { get; } = Guid.NewGuid().ToString();
}