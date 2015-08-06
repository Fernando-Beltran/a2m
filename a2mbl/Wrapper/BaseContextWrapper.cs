using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Entity.Core.Objects;

namespace a2mbl.Wrapper
{
    public class BaseContextWrapper<T> : IDisposable where T: ObjectContext, new()
    {
        public BaseContextWrapper() : this(false) { }

        public BaseContextWrapper(bool shared)
        {
            if (shared)
            {
                if (_sharedContext == null)
                    _sharedContext = new T();

                _numSharedInstances++;
            }
            else
            {
                if (_sharedContext == null)
                {
                    _privateContext = new T();
                    _numSharedInstances = 0;
                }
                else
                    _numSharedInstances++;
            }
        }

        #region Private members

        //para evitar colisiones de nombres cuando usamos varios ObjectContext, concatenamos el tipo a la clave
        private string NumSharedInstancesKey 
        {
            get { return string.Format("NumSharedInstances_{0}",typeof(T).Name); }
        }

        private string SharedContextKey
        {
            get { return string.Format("SharedContext_{0}", typeof(T).Name); }
        }

        private byte _numSharedInstances
        {
            get
            {
                if (HttpContext.Current.Items[NumSharedInstancesKey] == null)
                    return 0;
                else
                    return (byte)HttpContext.Current.Items[NumSharedInstancesKey];
            }
            set
            {
                HttpContext.Current.Items[NumSharedInstancesKey] = value;
            }
        }

        private T _privateContext;

        private T _sharedContext
        {
            get
            {
                return HttpContext.Current.Items[SharedContextKey] as T;
            }
            set
            {
                HttpContext.Current.Items[SharedContextKey] = value;
            }
        }

        #endregion

        public T Current
        {
            get
            {
                if (_sharedContext != null)
                    return _sharedContext;
                else
                    return _privateContext;
            }
        }

        public void Dispose()
        {
            if (_numSharedInstances>0)
            {
                _numSharedInstances--;

                if (_numSharedInstances == 0)
                {
                    _sharedContext.Dispose();
                    HttpContext.Current.Items.Remove(SharedContextKey);
                }
            }
            else
                _privateContext.Dispose();
        }

    }
}
