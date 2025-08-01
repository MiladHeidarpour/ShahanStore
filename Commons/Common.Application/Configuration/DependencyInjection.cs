﻿using System.Reflection;
using Common.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonApplication(this IServiceCollection services,
        Assembly applicationAssembly)
    {
        services.AddValidatorsFromAssembly(applicationAssembly);
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(applicationAssembly); });
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}