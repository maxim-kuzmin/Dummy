﻿global using Google.Protobuf.WellKnownTypes;
global using Grpc.Core;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Create;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Delete;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.GetList;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Actions.Update;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.DTOs;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Queries;
global using Makc.Dummy.Reader.DomainUseCases.DummyItem.Query.Sections;
global using Makc.Dummy.Reader.Infrastructure.Grpc.DummyItem;
global using Makc.Dummy.Shared.DomainUseCases.Query.Sections;
global using Makc.Dummy.Shared.Infrastructure.Grpc;
global using MediatR;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using DummyItemServiceBase = Makc.Dummy.Reader.Infrastructure.Grpc.DummyItem.DummyItem.DummyItemBase;
