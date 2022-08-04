using UnityEngine;
using Zenject;

public class PlayerHealthInstaller : MonoInstaller
{
    [SerializeField] private PlayerHealth playerHealth;

    public override void InstallBindings()
    {
        Container.Bind<PlayerHealth>().FromInstance(playerHealth).AsSingle().NonLazy();
    }
}