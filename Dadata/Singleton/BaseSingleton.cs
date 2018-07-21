namespace DaData.Singleton
{
    public abstract class BaseSingleton
    {
        public abstract class QSingleton<T> where T : class 
        {
            protected static T Instance;
            
            static object MLock = new object();

            protected QSingleton()
            {
            }

            public static T Instance
            {
                get 
                {
                    lock (MLock) 
                    {
                        if (Instance == null) 
                        {
                            Instance = QSingletonCreator.CreateSingleton<T> ();
                        }
                    }

                    return mInstance;
                }
            }

            public virtual void Dispose()
            {
                mInstance = null;
            }

            public virtual void OnSingletonInit()
            {
            }
        }
    }
}