﻿global using System.Reflection;
global using System.Text.Json.Serialization;
global using Ardalis.GuardClauses;
global using Ardalis.Result;
global using Ardalis.SharedKernel;
global using Makc.Dummy.Gateway.DomainUseCases.App.Action.Command;
global using Makc.Dummy.Gateway.DomainUseCases.App.Actions.Login;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Action.Command;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Action.Query;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList.Query;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;
global using Makc.Dummy.Gateway.DomainUseCases.DummyItem.DTOs;
global using Makc.Dummy.Shared.Core.App.Config.Options.Enums;
global using Makc.Dummy.Shared.Core.App.Config.Options.Sections;
global using Makc.Dummy.Shared.Core.Http;
global using Makc.Dummy.Shared.DomainUseCases.DTOs;
global using Makc.Dummy.Shared.DomainUseCases.Query;
global using MediatR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
