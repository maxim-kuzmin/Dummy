﻿global using System.Globalization;
global using System.Text;
global using Ardalis.GuardClauses;
global using Ardalis.Result.AspNetCore;
global using FastEndpoints;
global using FastEndpoints.Swagger;
global using Makc.Dummy.Shared.Apps.WebApp.App.Middlewares;
global using Makc.Dummy.Shared.Core.App;
global using Makc.Dummy.Shared.Core.App.Config.Options;
global using Makc.Dummy.Shared.Core.App.Config.Options.Enums;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Db.MSSQLServer;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections.Db.PostgreSQL;
global using Makc.Dummy.Shared.DomainUseCases.Query;
global using Makc.Dummy.Shared.Infrastructure.Core.App;
global using Makc.Dummy.Shared.Infrastructure.Core.App.Logger.Funcs;
global using Makc.Dummy.Shared.Infrastructure.CoreForOpenTelemetry.App;
global using Makc.Dummy.Writer.Apps.WebApp.App;
global using Makc.Dummy.Writer.Apps.WebApp.App.Config;
global using Makc.Dummy.Writer.DomainModel.App;
global using Makc.Dummy.Writer.DomainModel.App.Db;
global using Makc.Dummy.Writer.DomainUseCases.App;
global using Makc.Dummy.Writer.DomainUseCases.App.Actions.Login;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Delete;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList.Query;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Delete;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList.Query;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList.Query;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.DTOs;
global using Makc.Dummy.Writer.Infrastructure.Core.App;
global using Makc.Dummy.Writer.Infrastructure.Dapper.App;
global using Makc.Dummy.Writer.Infrastructure.DapperForMSSQLServer.App;
global using Makc.Dummy.Writer.Infrastructure.DapperForPostgreSQL.App;
global using Makc.Dummy.Writer.Infrastructure.EntityFramework.App;
global using Makc.Dummy.Writer.Infrastructure.EntityFrameworkForMSSQLServer.App;
global using Makc.Dummy.Writer.Infrastructure.EntityFrameworkForPostgreSQL.App;
global using Makc.Dummy.Writer.Infrastructure.Grpc.App;
global using Makc.Dummy.Writer.Infrastructure.MSSQLServer.App;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.App;
global using Makc.Dummy.Writer.Infrastructure.RabbitMQ.App;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Logging;
global using Microsoft.IdentityModel.Tokens;
global using Makc.Dummy.Shared.Infrastructure.CoreForOpenTelemetryInWeb.App;
