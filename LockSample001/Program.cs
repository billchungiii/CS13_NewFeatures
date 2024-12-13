namespace LockSample001
{
    internal class Program
    {
        /// <summary>
        /// C# 13.0, .NET 9.0
        /// new Lock class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 以前你會這樣 lock
            var obj = new object();
            lock (obj)
            {
                // do something
            }

            // 現在你應該這樣 lock
            var locker = new Lock();

            lock (locker)
            {
                // do something, 相當於使用 EnterScope method
            }

            locker.Enter();
            try
            {
                // do something
            }
            finally
            {
                locker.Exit();
            }

            // 或者這樣 lock

            using (locker.EnterScope())
            {
                // do something
            }

            // 如果需要逾時處理, 0 -- 不等候, -1 -- 無限等候, 其他數字 -- 等候秒數
            if (locker.TryEnter(TimeSpan.FromSeconds(1)))
            {
                try
                {
                    // do something
                }
                finally
                {
                    locker.Exit();
                }
            }
            else
            {
                // 處理逾時
            }
        }
    }
}
