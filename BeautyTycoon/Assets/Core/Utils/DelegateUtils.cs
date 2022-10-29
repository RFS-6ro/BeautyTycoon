using System;

using JetBrains.Annotations;

using UnityEngine;

namespace BT.Core.Utils
{
    public static class DelegateUtils
    {
        public static void SafeInvoke([CanBeNull] this Action value)
        {
            if (value == null) return;

            try { value(); }
            catch (Exception e)
            {
#if DEBUG
                Debug.LogException(e);
#endif
            }
        }

        public static void SafeInvoke<T1>
            ([CanBeNull] this Action<T1> value, T1 t1)
        {
            if (value == null) return;

            try { value(t1); }
            catch (Exception e)
            {
#if DEBUG
                Debug.LogException(e);
#endif
            }
        }

        public static void SafeInvoke<T1, T2>
            ([CanBeNull] this Action<T1, T2> value, T1 t1, T2 t2)
        {
            if (value == null) return;

            try { value(t1, t2); }
            catch (Exception e)
            {
#if DEBUG
                Debug.LogException(e);
#endif
            }
        }

        public static void SafeInvoke<T1, T2, T3>
            ([CanBeNull] this Action<T1, T2, T3> value, T1 t1, T2 t2, T3 t3)
        {
            if (value == null) return;

            try { value(t1, t2, t3); }
            catch (Exception e)
            {
#if DEBUG
                Debug.LogException(e);
#endif
            }
        }

        [CanBeNull]
        [Pure]
        public static TResult SafeInvoke<TResult>
        (
            [CanBeNull] this Func<TResult> evaluator, TResult defaultValue,
            string                         specifyingError
        )
        {
            if (evaluator == null) return defaultValue;
            try { return evaluator(); }
            catch (Exception e)
            {
#if DEBUG
                Debug.LogException(e);
#endif
                return defaultValue;
            }
        }
    }
}