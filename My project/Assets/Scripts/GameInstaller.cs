using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(_playerPrefab).AsSingle();
    }

}