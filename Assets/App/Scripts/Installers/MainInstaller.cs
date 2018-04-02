using UnityEngine;
using Zenject;
using PROJECT_HUSKY;
public class MainInstaller : MonoInstaller<MainInstaller>
{
    public override void InstallBindings()
    {
        InstallSignals();
        BindInterfaces();
    }
    void InstallSignals()
    {
        Container.DeclareSignal<OnChangeSceneSignal>();
        Container.DeclareSignal<ChangeSceneSignal>();

        Container.BindSignal<Scene, ChangeSceneSignal>()
            .To<SceneManager>(x => x.ChangeScene).AsSingle();

        //Container.BindSignal<Scene, OnChangeSceneSignal>()
        //    .To<Test>(x => x.Test_OnChangeScene).AsSingle();
    }
    void BindInterfaces()
    {
        Container.BindInterfacesTo<SceneManager>().AsSingle().NonLazy();
        Container.BindInterfacesTo<AppManager>().AsSingle().NonLazy();
    }
}