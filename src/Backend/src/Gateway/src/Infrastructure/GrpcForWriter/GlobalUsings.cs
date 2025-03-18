﻿global using Ardalis.Result;
global using Grpc.Core;
global using Makc.Dummy.Gateway.DomainUseCases.Auth.Actions.Login;
global using Makc.Dummy.Gateway.DomainUseCases.Auth.DTOs;
global using Makc.Dummy.Gateway.DomainUseCases.Auth.Services;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.Create;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.Delete;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.Get;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.GetList;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Actions.Update;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.DTOs;
global using Makc.Dummy.Gateway.DomainUseCasesForWriter.DummyItem.Services;
global using Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.Auth;
global using Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.Auth.Services;
global using Makc.Dummy.Gateway.Infrastructure.GrpcForWriter.DummyItem.Services;
global using Makc.Dummy.Shared.Core.App;
global using Makc.Dummy.Shared.Core.App.Config.Options.Enums;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections;
global using Makc.Dummy.Shared.Core.Http;
global using Makc.Dummy.Shared.Infrastructure.Grpc;
global using Makc.Dummy.Writer.Infrastructure.Grpc.Auth;
global using Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using AuthGrpcClient = Makc.Dummy.Writer.Infrastructure.Grpc.Auth.Auth.AuthClient;
global using DummyItemGrpcClient = Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem.DummyItem.DummyItemClient;
