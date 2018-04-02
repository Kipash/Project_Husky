using UnityEngine;
using System.Collections;
using Zenject;
using AppBackend;

namespace PROJECT_HUSKY
{
    public class AppManager : IInitializable
    {
        string dataPath = Application.persistentDataPath + "/userdata";
        readonly ChangeSceneSignal changeScene;

        public AppManager(ChangeSceneSignal changeScene)
        {
            this.changeScene = changeScene;
        }

        public void Initialize()
        {
            InitializeBackend();

            changeScene.Fire(Scene.Game);
        }

        void InitializeBackend()
        {
            Debug.Log($"Loading data ...");
            DataStorage.Load(dataPath);
        }
    }
}