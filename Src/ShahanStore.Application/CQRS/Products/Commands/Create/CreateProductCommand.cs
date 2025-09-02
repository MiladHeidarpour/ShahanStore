using Common.Application.Abstractions.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Products.Commands.Create;

public sealed record CreateProductCommand(
    string FaName,
    string EnName,
    string Slug,
    string ProductCode,
    string? ShortDescription,
    string? ExpertReview,
    string MainImg,
    Guid CategoryId,
    Guid BrandId) : ICommand;