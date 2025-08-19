using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Commands.Edit;

public sealed record EditBrandCommand(
    Guid Id,
    string Name,
    string Slug,
    string? Description,
    bool IsAvailable,
    SeoData SeoData) :ICommand;
