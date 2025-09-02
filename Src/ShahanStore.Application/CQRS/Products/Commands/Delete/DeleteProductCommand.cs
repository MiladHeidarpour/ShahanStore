using Common.Application.Abstractions.Messaging.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Products.Commands.Delete;
public sealed record DeleteProductCommand(Guid ProductId):ICommand;
