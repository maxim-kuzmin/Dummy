﻿global using Ardalis.Result;
global using Grpc.Core;
global using Makc.Dummy.Gateway.DomainUseCases.App.Actions.Login;
global using Makc.Dummy.Gateway.DomainUseCases.App.Services;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.DTOs;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Services;
global using Makc.Dummy.Gateway.Infrastructure.Grpc.App.Services;
global using Makc.Dummy.Gateway.Infrastructure.Grpc.DummyItem.Services;
global using Makc.Dummy.Shared.Core.App;
global using Makc.Dummy.Shared.Core.Http;
global using Makc.Dummy.Shared.Infrastructure.Grpc;
global using Makc.Dummy.Writer.Infrastructure.Grpc.App;
global using Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using WriterAppGrpcClient = Makc.Dummy.Writer.Infrastructure.Grpc.App.App.AppClient;
global using WriterDummyItemGrpcClient = Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem.DummyItem.DummyItemClient;
