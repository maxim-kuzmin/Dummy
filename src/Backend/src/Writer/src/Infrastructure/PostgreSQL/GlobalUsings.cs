﻿global using Makc.Dummy.Shared.DomainUseCases.Db.SQL;
global using Makc.Dummy.Shared.DomainUseCases.Query.Sections;
global using Makc.Dummy.Writer.DomainModel.AppEvent.Entity;
global using Makc.Dummy.Writer.DomainModel.AppEventPayload.Entity;
global using Makc.Dummy.Writer.DomainModel.DummyItem.Entity;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;
global using Makc.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem;
global using Makc.Dummy.Writer.DomainUseCases.DummyItem.Queries;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.App.Db;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.App.Db.Settings;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Actions.Get;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Actions.GetList;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEvent.Entity.Db;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Actions.Get;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Actions.GetList;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.AppEventPayload.Entity.Db;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem;
global using Makc.Dummy.Writer.Infrastructure.PostgreSQL.DummyItem.Entity.Db;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using AppDbSettingsBase = Makc.Dummy.Writer.DomainModel.App.Db.AppDbSettings;
global using AppDbSettingsEntitiesBase = Makc.Dummy.Writer.DomainModel.App.Db.Settings.AppDbSettingsEntities;
global using AppEventEntityDbSettingsBase = Makc.Dummy.Writer.DomainModel.AppEvent.Entity.Db.AppEventEntityDbSettings;
global using AppEventPayloadEntityDbSettingsBase = Makc.Dummy.Writer.DomainModel.AppEventPayload.Entity.Db.AppEventPayloadEntityDbSettings;
global using DummyItemEntityDbSettingsBase = Makc.Dummy.Writer.DomainModel.DummyItem.Entity.Db.DummyItemEntityDbSettings;
