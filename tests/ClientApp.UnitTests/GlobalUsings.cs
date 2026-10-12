global using MaquetteMarket.ClientApp.Services;
global using MaquetteMarket.ClientApp.Services.AppEnvironment;
global using MaquetteMarket.ClientApp.Services.Basket;
global using MaquetteMarket.ClientApp.Services.Catalog;
global using MaquetteMarket.ClientApp.Services.Order;
global using MaquetteMarket.ClientApp.Services.Settings;
global using MaquetteMarket.ClientApp.ViewModels;
global using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
