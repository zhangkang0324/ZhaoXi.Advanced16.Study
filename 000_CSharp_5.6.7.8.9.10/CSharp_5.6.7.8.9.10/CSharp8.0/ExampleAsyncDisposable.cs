using System.Text.Json;

namespace CSharp_5._6._7._8._9._10.CSharp8._0
{
    public class ExampleAsyncDisposable : IAsyncDisposable, IDisposable
    {
        private Utf8JsonWriter? _jsonWriter = new(new MemoryStream());

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _jsonWriter?.Dispose();
                _jsonWriter = null;
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_jsonWriter is not null)
            {
                await _jsonWriter.DisposeAsync().ConfigureAwait(false);
            }
            _jsonWriter = null;
        }
    }
}
