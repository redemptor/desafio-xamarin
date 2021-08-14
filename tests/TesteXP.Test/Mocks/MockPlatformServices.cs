using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace TesteXP.Test.Mocks
{
    internal class MockPlatformServices : IPlatformServices
    {
        public TimeSpan FixedInterval { get; set; }

        Action<Action> _invokeOnMainThread;
        Func<Uri, CancellationToken, Task<Stream>> _getStreamAsync;
        public MockPlatformServices(Action<Action> invokeOnMainThread = null, Action<Uri> openUriAction = null, Func<Uri, CancellationToken, Task<Stream>> getStreamAsync = null)
        {
            _invokeOnMainThread = invokeOnMainThread;
            _getStreamAsync = getStreamAsync;
        }

        public bool IsInvokeRequired => throw new NotImplementedException();

        public OSAppTheme RequestedTheme => throw new NotImplementedException();

        public string RuntimePlatform => throw new NotImplementedException();

        public void BeginInvokeOnMainThread(Action action)
        {
            if (_invokeOnMainThread == null)
                action();
            else
                _invokeOnMainThread(action);
        }

        public Ticker CreateTicker()
        {
            throw new NotImplementedException();
        }

        public Assembly[] GetAssemblies()
        {
            return new Assembly[0];
        }

        public string GetHash(string input)
        {
            throw new NotImplementedException();
        }

        public string GetMD5Hash(string input)
        {
            throw new NotImplementedException();
        }

        public Color GetNamedColor(string name)
        {
            throw new NotImplementedException();
        }

        public double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes)
        {
            throw new NotImplementedException();
        }

        public SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IIsolatedStorageFile GetUserStoreForApplication()
        {
            throw new NotImplementedException();
        }

        public void OpenUriAction(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void QuitApplication()
        {
            throw new NotImplementedException();
        }

        public void StartTimer(TimeSpan interval, Func<bool> callback)
        {
            if (interval != TimeSpan.Zero)
            {
                interval = FixedInterval;
            }

            Timer timer = null;
            TimerCallback onTimeout = o => BeginInvokeOnMainThread(() =>
            {
                if (callback())
                    return;

                timer.Dispose();
            });
            timer = new Timer(onTimeout, null, interval, interval);
        }
    }
}
