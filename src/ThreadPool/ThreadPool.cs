using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    // TODO check name
    public class ParametrizeThreadPool<T>
    {
        private uint threadNumber;
        private Thread[] threads;
        private Queue<ITask<T>> queue;
        public List<T> results;

        public ParametrizeThreadPool(uint threadNumber)
        {
            this.threadNumber = threadNumber;
            this.queue = new Queue<ITask<T>>();
            this.threads = new Thread[this.threadNumber];
            this.results = new List<T>();

            for (uint i = 0; i < this.threadNumber; i++)
            {
                threads[i] = new Thread(new ThreadStart(this.Work));
                threads[i].Start();
            }
        }

        public void Execute(ITask<T> task)
        {
            lock (this.queue)
            {
                // Add task
                this.queue.Enqueue(task);
                // Notify Workers
                Monitor.Pulse(this.queue);
            }
        }

        public void Interrupt()
        {
            for (uint i = 0; i < this.threadNumber; i++)
                threads[i].Interrupt();
        }

        private void Work()
        {
            while (true)
            {
                ITask<T> task;

                lock (this.queue)
                {
                    while (this.queue.Count == 0)
                        // Wait while queue get task
                        Monitor.Wait(this.queue);
                    // Get task
                    this.queue.TryDequeue(out task);
                }
                // Execute task
                T result = task.Run();
                lock (this.results)
                {
                    this.results.Add(result);
                    Monitor.Pulse(this.results);
                }
            }
        }
    }

    public interface ITask<T>
    {
        public T Run();
    }
}
