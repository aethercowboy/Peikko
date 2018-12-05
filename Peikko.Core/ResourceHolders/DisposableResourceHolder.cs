using System;

namespace Peikko.Core.ResourceHolders
{
    public abstract class DisposableResourceHolder : IDisposable
    {
        private bool disposed = false;

        ~DisposableResourceHolder()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeResources() { }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
                DisposeResources();

            disposed = true;
        }
    }
}
