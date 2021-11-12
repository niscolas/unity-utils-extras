﻿using niscolas.UnityUtils.Core;
using UnityAtoms;
using UnityEngine;
using UnityEngine.Events;

namespace niscolas.UnityUtils.Extras
{
    public class MonoAtomFunction<T1, T2> : CachedMonoBehaviour
    {
        [SerializeField]
        private AtomFunction<T1, T2> _function;

        [SerializeField]
        private UnityEvent<T1> _onFunctionCalled;

        public void Call(T2 t2)
        {
            _onFunctionCalled?.Invoke(_function.Call(t2));
        }
    }
}