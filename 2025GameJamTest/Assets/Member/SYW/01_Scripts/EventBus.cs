using UnityEngine;
using System;
using System.Collections.Generic;

namespace Member.SYW._01_Scripts
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, Delegate> Handlers = new Dictionary<Type, Delegate>();
        private static readonly object Lock = new object();
        
        public static IDisposable Subscribe<T>(Action<T> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            lock (Lock)
            {
                if (Handlers.TryGetValue(typeof(T), out var del))
                {
                    Handlers[typeof(T)] = Delegate.Combine(del, handler);
                }
                else
                {
                    Handlers[typeof(T)] = handler;
                }
            }
            return new Subscription(() => Unsubscribe(handler));
    }
        
    public static void Unsubscribe<T>(Action<T> handler)
    {
        if (handler == null) return;
        lock (Lock)
        {
            if (!Handlers.TryGetValue(typeof(T), out var del)) return;
            var current = Delegate.Remove(del, handler);
            if (current == null)
                Handlers.Remove(typeof(T));
            else
                Handlers[typeof(T)] = current;
        }
    }
    
    public static void Publish<T>(T payload)
    {
        Delegate del;
        lock (Lock)
        {
            Handlers.TryGetValue(typeof(T), out del);
        }
        var callback = del as Action<T>;
        callback?.Invoke(payload);
    }
    
    public static IDisposable Subscribe(Action handler)
    {
        if (handler == null) throw new ArgumentNullException(nameof(handler));
        lock (Lock)
        {
            if (Handlers.TryGetValue(typeof(VoidType), out var del))
            {
                Handlers[typeof(VoidType)] = Delegate.Combine(del, handler);
            }
            else
            {
                Handlers[typeof(VoidType)] = handler;
            }
        }
        return new Subscription(() => Unsubscribe(handler));
    }

    public static void Unsubscribe(Action handler)
    {
        if (handler == null) return;
        lock (Lock)
        {
            if (!Handlers.TryGetValue(typeof(VoidType), out var del)) return;
            var current = Delegate.Remove(del, handler);
            if (current == null)
                Handlers.Remove(typeof(VoidType));
            else
                Handlers[typeof(VoidType)] = current;
        }
    }

    public static void Publish()
    {
        Delegate del;
        lock (Lock)
        {
            Handlers.TryGetValue(typeof(VoidType), out del);
        }
        var callback = del as Action;
        callback?.Invoke();
    }
    
    private class Subscription : IDisposable
    {
        private Action _dispose;
        private bool _disposed;

        public Subscription(Action dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _dispose?.Invoke();
            _disposed = true;
            _dispose = null;
        }
    }
    
    private class VoidType { }
    }
}