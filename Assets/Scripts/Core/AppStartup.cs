using FeatureSystem.Features;
using FeatureSystem.Systems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AppStartup : MonoBehaviour
    {
        private void Start()
        {
            InitializeFeatures();
            InitializeSystems();
        }

        private void InitializeFeatures()
        {
            foreach (var feature in Features.GetFeatures())
            {
                feature.Initialize();
            }
        }

        private void InitializeSystems()
        {
            foreach (var system in GameSystems.Systems.Values)
            {
                system.Initialize();
            }
        }
    }
}
