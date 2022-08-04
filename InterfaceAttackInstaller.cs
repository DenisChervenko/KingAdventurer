using UnityEngine;
using Zenject;

public class InterfaceAttackInstaller : MonoInstaller
{
    [SerializeField] private InterfaceAttack interfaceAttack;

    public override void InstallBindings()
    {
        Container.Bind<InterfaceAttack>().FromInstance(interfaceAttack).AsSingle().NonLazy();
    }
}