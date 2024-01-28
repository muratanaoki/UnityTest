using Zenject;

public class MyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IDatabaseManager>().To<DatabaseManager>().AsSingle()
            .WithArguments("Assets/StreamingAssets/db.db");
        //Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
    }
}