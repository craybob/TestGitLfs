using UnityEngine;
using Zenject;

public class NewGameInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    public override void InstallBindings()
    {
        //Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle().NonLazy();
        //Container.BindInterfacesAndSelfTo<Player>().AsSingle();
        //Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
        //Container.BindInterfacesAndSelfTo<Player>().FromInstance(player);

        Container.Bind<MovementHandler>().AsSingle();
    }
}