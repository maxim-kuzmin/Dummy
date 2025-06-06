﻿global using Ardalis.Result.AspNetCore;
global using FastEndpoints;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Delete;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Get;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.GetList;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.GetPage;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Actions.Save;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Commands;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.DTOs;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEvent.Queries;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.Delete;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.Get;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.GetList;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.GetPage;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Actions.Save;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Commands;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.DTOs;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.AppIncomingEventPayload.Queries;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.Delete;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.GetList;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.GetPage;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Actions.Save;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Commands;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.DTOs;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Domain.UseCases.DummyItem.Queries;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.App;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.Create;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.Delete;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.Get;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.GetList;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.GetPage;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEvent.Endpoints.Update;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Create;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Delete;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Get;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.GetList;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.GetPage;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.AppIncomingEventPayload.Endpoints.Update;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.Create;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.Delete;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.Get;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.GetList;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.GetPage;
global using Makc.Dummy.Integration.MicroserviceReaderViaNoSQL.Infrastructure.HttpServer.DummyItem.Endpoints.Update;
global using Makc.Dummy.Shared.Core.App.Event.Payloads;
global using MediatR;
