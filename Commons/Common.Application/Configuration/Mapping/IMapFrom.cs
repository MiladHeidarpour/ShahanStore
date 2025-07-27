using Mapster;

namespace Common.Application.Configuration.Mapping;

public interface IMapFrom<T> : IRegister
{
    void IRegister.Register(TypeAdapterConfig config)
    {
        config.NewConfig(typeof(T), GetType());
    }
}