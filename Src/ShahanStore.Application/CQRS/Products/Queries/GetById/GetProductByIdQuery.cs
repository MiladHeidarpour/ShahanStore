using Common.Application.Abstractions.Messaging.Queries;
using ShahanStore.Application.CQRS.Products.DTOs.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahanStore.Application.CQRS.Products.Queries.GetById;
public sealed record GetProductByIdQuery(Guid ProductId):IQuery<ProductDto?>;
