    using System.Collections.Generic;
    using UnityEngine;

    public class ServiceStarter : MonoBehaviour
    {
        private static ServiceStarter instance;
        private static bool instanceExisted;
        
        private void setAllServices()
        {
            
            ServiceBucket.Add<SampleService>();
            
        }
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            else
            {
                instance = this;
                if (instanceExisted)
                {
                    ServiceBucket.ResetAllServices();
                }
                else
                {
                    instanceExisted = true;
                }
            }
            setAllServices();
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }