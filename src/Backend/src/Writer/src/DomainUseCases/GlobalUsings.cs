﻿global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text.Json;
global using Ardalis.Result;
global using Ardalis.SharedKernel;
global using Makc.Dummy.Shared.Core.App;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections;
global using Makc.Dummy.Shared.Core.App.Enums;
global using Makc.Dummy.Shared.Core.Message;
global using Makc.Dummy.Shared.DomainModel.Entity;
global using Makc.Dummy.Shared.DomainUseCases.Db;
global using Makc.Dummy.Shared.DomainUseCases.Db.Contexts;
global using Makc.Dummy.Shared.DomainUseCases.DTOs;
global using Makc.Dummy.Shared.DomainUseCases.Query;
global using Makc.Dummy.Writer.DomainModel.AppEvent;
global using Makc.Dummy.Writer.DomainModel.AppEventPayload;
global using Makc.Dummy.Writer.DomainModel.DummyItem;
global using Makc.Dummy.Writer.DomainUseCases.App.Db.Contexts;
global using Makc.Dummy.Writer.DomainUseCases.App.Message;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList.Query;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList.Query;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;
global using Makc.Dummy.Writer.DomainUseCases.AppOutbox.Actions.Save;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList.Query;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.DTOs;
global using MediatR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
