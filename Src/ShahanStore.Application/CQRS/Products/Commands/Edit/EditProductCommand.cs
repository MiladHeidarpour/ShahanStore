using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Products.Commands.Edit;
public sealed record  EditProductCommand(
    Guid ProductId,
    string FaName,
    string EnName,
    string Slug,
    string? ShortDescription,
    string? ExpertReview,
    bool IsAvailable,
    Guid CategoryId,
    Guid BrandId) :ICommand;
