using System;

namespace Mirror.Core
{
    /// <summary>Pooled NetworkReader, automatically returned to pool when using 'using'</summary>
    public sealed class NetworkReaderPooled : NetworkReader, IDisposable
    {
        internal NetworkReaderPooled(byte[] bytes) : base(bytes) {}
        internal NetworkReaderPooled(ArraySegment<byte> segment) : base(segment) {}
        public void Dispose() => NetworkReaderPool.Return(this);
    }
}
