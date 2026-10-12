global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading;
global using System.Threading.Tasks;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using MaquetteMarket.Ordering.API.Application.Commands;
global using MaquetteMarket.Ordering.API.Application.Models;
global using MaquetteMarket.Ordering.API.Infrastructure.Services;
global using MaquetteMarket.Ordering.Domain.AggregatesModel.BuyerAggregate;
global using MaquetteMarket.Ordering.Domain.Events;
global using MaquetteMarket.Ordering.Domain.Exceptions;
global using MaquetteMarket.Ordering.Domain.SeedWork;
global using MaquetteMarket.Ordering.Infrastructure.Idempotency;
global using Microsoft.Extensions.Logging;
global using NSubstitute;
global using MaquetteMarket.Ordering.UnitTests;
global using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
