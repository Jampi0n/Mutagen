﻿using Mutagen.Bethesda.Environments.DI;

namespace Mutagen.Bethesda.Plugins.Order.DI;

public interface IPluginListingsProvider : IListingsProvider
{
}
    
public sealed class PluginListingsProvider : IPluginListingsProvider
{
    private readonly IGameReleaseContext _gameReleaseContext;
    private readonly ITimestampedPluginListingsProvider _timestampedPluginsProvider;
    private readonly IEnabledPluginListingsProvider _enabledPluginListingsProvider;

    public PluginListingsProvider(
        IGameReleaseContext gameReleaseContext,
        ITimestampedPluginListingsProvider timestampedPluginsProvider,
        IEnabledPluginListingsProvider enabledPluginListingsProvider)
    {
        _gameReleaseContext = gameReleaseContext;
        _timestampedPluginsProvider = timestampedPluginsProvider;
        _enabledPluginListingsProvider = enabledPluginListingsProvider;
    }
        
    public IEnumerable<ILoadOrderListingGetter> Get()
    {
        switch (_gameReleaseContext.Release)
        {
            case GameRelease.Oblivion:
                return _timestampedPluginsProvider.Get();
            case GameRelease.SkyrimLE:
            case GameRelease.SkyrimSE:
            case GameRelease.SkyrimVR:
            case GameRelease.EnderalLE:
            case GameRelease.EnderalSE:
            case GameRelease.Fallout4:
                return _enabledPluginListingsProvider.Get();
            default:
                throw new NotImplementedException();
        }
    }
}