using Common.Application.Abstractions.Messaging.Commands;
using ShahanStore.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Products.Commands.ChangeMainImg;
public sealed record ChangeProductMainImgCommand(
    Guid ProductId,
    string MainImg): ICommand<string?>;
