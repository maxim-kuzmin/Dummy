namespace Makc.Dummy.Writer.Infrastructure.EntityFramework.App.Db;

/// <summary>
/// Контекст базы данных приложения. При старте приложения перед регистрацией класса в контейнере DI нужно обязательно
/// вызвать статический метод Init.
/// </summary>
/// <param name="options">Параметры.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  private static readonly Lock _initLock = new();

  private static AppDbSQLSettings? _appDbSettings = null; 

  /// <summary>
  /// Событие приложения.
  /// </summary>
  public DbSet<AppOutgoingEventEntity> AppOutgoingEvent => base.Set<AppOutgoingEventEntity>();

  /// <summary>
  /// Полезная нагрузка исходящего события приложения.
  /// </summary>
  public DbSet<AppOutgoingEventPayloadEntity> AppOutgoingEventPayload => base.Set<AppOutgoingEventPayloadEntity>();

  /// <summary>
  /// Фиктивный предмет.
  /// </summary>
  public DbSet<DummyItemEntity> DummyItem => base.Set<DummyItemEntity>();

  /// <summary>
  /// Получить настройки базы данных приложения.
  /// </summary>
  /// <returns>Настройки базы данных приложения.</returns>
  public static AppDbSQLSettings GetAppDbSettings()
  {
    return Guard.Against.Null(_appDbSettings, parameterName: nameof(_appDbSettings));
  }

  /// <summary>
  /// Инициализировать.
  /// Необходимо вызвать этот метод один раз при старте приложения перед регистрацией класса в контейнере DI.
  /// </summary>
  /// <param name="appDbSettings">Настройки базы данных приложения.</param>
  public static void Init(AppDbSQLSettings appDbSettings)
  {
    lock (_initLock)
    {
      _appDbSettings = appDbSettings;
    }
  }

  /// <inheritdoc/>
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}
