using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Application.CQRS.Categories.Commands.ChangeIcon;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Commands.ChangeLogo;

public sealed record ChangeBrandLogoCommand(
    Guid BrandId,
    string Logo) : ICommand<string?>;
