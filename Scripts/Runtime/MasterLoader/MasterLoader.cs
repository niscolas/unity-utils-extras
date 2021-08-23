﻿using UnityEngine;
using UnityEngine.SceneManagement;

// TODO move to the correct namespace
namespace BestLostNFound
{
    public static class MasterLoader
    {
        public static bool ShouldLoadAdditiveScenes => !Application.isEditor && !Application.isPlaying;

        private const string ProfilePath = nameof(MasterLoaderProfile);

        private static MasterLoaderProfile _profile;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void RuntimeInit()
        {
            if (!_profile)
            {
                _profile = FindProfile();
            }

            SceneManager.sceneLoaded += SceneManager_OnSceneLoaded;
        }

        public static MasterLoaderProfile FindProfile()
        {
            return Resources.Load<MasterLoaderProfile>(ProfilePath);
        }

        private static void SceneManager_OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            OnSceneLoaded(scene);
        }

        private static void OnSceneLoaded(Scene scene)
        {
            if (!_profile.SceneProfiles.TryGet(scene, out SceneProfile sceneProfile))
            {
                return;
            }

            sceneProfile.OnLoaded();
        }
    }
}