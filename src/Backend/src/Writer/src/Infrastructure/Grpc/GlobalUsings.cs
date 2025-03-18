﻿global using Google.Protobuf.WellKnownTypes;
global using Grpc.Core;
global using Makc.Dummy.Shared.Infrastructure.Grpc;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Delete;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Queries;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Delete;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Queries;
global using Makc.Dummy.Writer.DomainUseCases.Auth.Actions.Login;
global using Makc.Dummy.Writer.DomainUseCases.Auth.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Queries;
global using Makc.Dummy.Writer.Infrastructure.Grpc.AppEvent;
global using Makc.Dummy.Writer.Infrastructure.Grpc.AppEventPayload;
global using Makc.Dummy.Writer.Infrastructure.Grpc.Auth;
global using Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem;
global using MediatR;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using AppEventPayloadServiceBase = Makc.Dummy.Writer.Infrastructure.Grpc.AppEventPayload.AppEventPayload.AppEventPayloadBase;
global using AppEventServiceBase = Makc.Dummy.Writer.Infrastructure.Grpc.AppEvent.AppEvent.AppEventBase;
global using AuthServiceBase = Makc.Dummy.Writer.Infrastructure.Grpc.Auth.Auth.AuthBase;
global using DummyItemServiceBase = Makc.Dummy.Writer.Infrastructure.Grpc.DummyItem.DummyItem.DummyItemBase;
