using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    public override void InstallBindings()
    {
        
        //Container.Bind<MovementHandler>().AsSingle();
        //Player player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(_playerPrefab).AsSingle();

        //Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle().NonLazy();
        //Container.Bind<MovementHandler>()
        //    .WithArguments(_playerPrefab.transform);

        // Внедряем зависимости в MovementHandler

    }

}
