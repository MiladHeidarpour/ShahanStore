using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Brands.Commands.Delete;

public sealed record DeleteBrandCommand(Guid BrandId) : ICommand;
