﻿global using Ardalis.Result;
global using Google.Protobuf.Collections;
global using Google.Protobuf.WellKnownTypes;
global using Grpc.Core;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Command.Sections;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Commands;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.DTOs;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEvent.Queries;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Command.Sections;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Commands;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.DTOs;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.AppOutgoingEventPayload.Queries;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.Auth.Commands;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.Auth.DTOs;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.Command.Sections;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.Commands;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.DTOs;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCases.DummyItem.Queries;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEvent.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.AppOutgoingEventPayload.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.Auth.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Domain.UseCasesForClient.DummyItem.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.AppOutgoingEvent;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.AppOutgoingEventPayload;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.Auth;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.DummyItem;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.AppOutgoingEvent.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.AppOutgoingEventPayload.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.Auth.Services;
global using Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.GrpcClient.DummyItem.Services;
global using Makc.Dummy.Shared.Core.App;
global using Makc.Dummy.Shared.Core.App.Config.Options.Enums;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Domain;
global using Makc.Dummy.Shared.Core.Http;
global using Makc.Dummy.Shared.Infrastructure.Grpc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using AppOutgoingEventGrpcClient = Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.AppOutgoingEvent.AppOutgoingEvent.AppOutgoingEventClient;
global using AppOutgoingEventPayloadGrpcClient = Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.AppOutgoingEventPayload.AppOutgoingEventPayload.AppOutgoingEventPayloadClient;
global using AuthGrpcClient = Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.Auth.Auth.AuthClient;
global using DummyItemGrpcClient = Makc.Dummy.Integration.MicroserviceWriterViaSQL.Infrastructure.Grpc.DummyItem.DummyItem.DummyItemClient;
