using UnityEngine;
using Zenject;

public class WarriorMoveLogicInstaller : MonoInstaller
{
    [SerializeField] private WarriorMoveLogic warriorMoveLogic;

    public override void InstallBindings()
    {
        Container.Bind<WarriorMoveLogic>().FromInstance(warriorMoveLogic).AsSingle().NonLazy();
    }
}