// Copyright 2023 Lepta Technologies
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using SpinalCord.Utils;

namespace SpinalCord.Fields
{
    public abstract class BaseField<T> : IField
    {
        private readonly string _columnName;
        private bool _isSet;

        protected BaseField(string columnName)
        {
            _columnName = columnName;
        }

        public virtual int GetBytesLength()
        {
            return 1;
        }

        public string GetColumnName()
        {
            return _columnName;
        }

        public bool IsSet()
        {
            return _isSet;
        }

        public void ToggleIsSet()
        {
            _isSet = !_isSet;
        }

        public abstract void Clear();
        public abstract void FromBytes(BytesBuffer buffer);
        public abstract T Get();
        public abstract void Set(T value);
        public abstract BytesBuffer ToBytes();
    }
}
