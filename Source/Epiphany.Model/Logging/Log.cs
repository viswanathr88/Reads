using System;

namespace Epiphany.Logging
{
    public static class Log
    {
        public static ILogger instance;
 
        public static void SetLogger(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger cannot be null");
            }

            Instance = logger;
        }

        public static ILogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DummyLogger();
                }

                return instance;
            }

            private set
            {
                if (instance != value)
                {
                    instance = value;
                }
            }
        }
    }
}
