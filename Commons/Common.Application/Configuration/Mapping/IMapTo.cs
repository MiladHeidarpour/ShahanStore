using Mapster;

namespace Common.Application.Configuration.Mapping;

public interface IMapTo<T> : IRegister
{
    void IRegister.Register(TypeAdapterConfig config)
    {
        config.NewConfig(GetType(), typeof(T));
    }
}