    using System;
    using System.Collections.Generic;

    public static class ServiceBucket
    {
        public static readonly List<IService> AllServices = new List<IService>();

        public static void Add<T>()
            where T : IService, new()
        {
            if (AllServices.Contains(Service<T>.Instance))
            {
                throw new InvalidOperationException("This service has already been added");
            }
            else
            {
                T service = new T();
                service.Init();
                Service<T>.Instance = service;
                AllServices.Add(service);
            }
        }

        public static T Get<T>()
            where T : IService
        {
            if (Service<T>.Instance != null)
            {
                return Service<T>.Instance;
            }
            else throw new Exception("No such service exists");
        }

        public static void ResetAllServices()
        {
            if (AllServices != null)
            {
                for (int i = 0; i < AllServices.Count; i++)
                {
                    AllServices[i] = null;
                }
                AllServices.Clear();
            }
        }
    }

    internal struct Service<T>
        where T : IService
    {
        public static T Instance = default(T);
    }

    public interface IService
    {
        void Init();
    }