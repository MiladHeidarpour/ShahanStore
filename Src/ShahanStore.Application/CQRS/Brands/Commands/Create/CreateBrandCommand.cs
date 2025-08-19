using Common.Application.Abstractions.Messaging.Commands;
using Common.Domain.ValueObjects;
using ShahanStore.Application.CQRS.Categories.Commands.Create;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Commands.Create;

public sealed record CreateBrandCommand(
    string Name,
    string Slug,
    string? BannerImg,
    string? Logo,
    string? Description,
    SeoData SeoData) :ICommand;
