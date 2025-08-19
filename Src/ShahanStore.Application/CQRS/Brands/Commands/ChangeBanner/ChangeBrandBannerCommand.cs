using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Application.CQRS.Categories.Commands.ChangeBanner;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Commands.ChangeBanner;

public sealed record ChangeBrandBannerCommand(
    Guid BrandId,
    string BannerImg) : ICommand<string?>;
