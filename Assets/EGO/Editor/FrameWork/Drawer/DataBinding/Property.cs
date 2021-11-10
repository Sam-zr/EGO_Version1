using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EGO.FrameWork
{
    [Serializable]
    public class IntProperty : Property<int>
    {
        public int sValue
        {
            get { return base.Value; }
            set { base.Value = value;Debug.Log($"设置sValue={value}"); }
        }
    }

    [Serializable]
    public class Property<T>
    {
        public Property()
        {
        }
        public Property(T value)
        {
            mValue = value;
        }

        private T mValue = default;
        public T Value
        {
            get => mValue;
            set
            {
                if (!value.Equals(mValue))
                {
                    mValue = value;
                    mSetter?.Invoke(mValue);
                }
            }
        }

        /// <summary>
        /// 数据绑定，便于数据的更新
        /// </summary>
        /// <param name="setter"></param>
        public void Bind(Action<T> setter)
        {
            mSetter += setter;
            mBindingActions.Add(setter);
        }

        public void UnBindAll()
        {
            foreach (var bind in mBindingActions)
            {
                mSetter -= bind;
            }
        }

        private List<Action<T>> mBindingActions { get; set; } = new List<Action<T>>();
        private event Action<T> mSetter;
    }
}

