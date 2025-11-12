
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IDal, DalNoSql>();

services.AddSingleton<IRandom, RandomTen>();

services.AddSingleton<BllGet>();

services.AddSingleton<BllRem>();

var provider = services.BuildServiceProvider();

var bllGetService = provider.GetRequiredService<BllGet>();

var bllRemService = provider.GetRequiredService<BllRem>();

bllGetService.Get("People");

bllRemService.Remove("Accounts");