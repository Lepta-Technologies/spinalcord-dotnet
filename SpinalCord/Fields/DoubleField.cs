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

using System;
using SpinalCord.Exceptions;
using SpinalCord.Utils;

namespace SpinalCord.Fields
{
    public class DoubleField : BaseField<Double>
    {
        private double _value;

        public DoubleField(string columnName) : base(columnName)
        {
        }

        public override void Clear()
        {
            if (IsSet())
            {
                ToggleIsSet();
            }
        }

        public override void FromBytes(BytesBuffer buffer)
        {
            if (BytesConverter.ToBoolean(buffer.Read(1)))
            {
                Set(BytesConverter.ToDouble(buffer.Read(8)));
            }
        }

        public override double Get()
        {
            if (!IsSet())
            {
                throw new FieldNotSetException();
            }

            return _value;
        }

        public new int GetBytesLength()
        {
            if (IsSet())
            {
                return base.GetBytesLength() + 8;
            }

            return base.GetBytesLength();
        }

        public override void Set(double value)
        {
            _value = value;
            if (!IsSet())
            {
                ToggleIsSet();
            }
        }

        public override BytesBuffer ToBytes()
        {
            BytesBuffer buffer = new();
            buffer.Append(BytesConverter.FromBoolean(IsSet()));
            try
            {
                buffer.Append(BytesConverter.FromDouble(Get()));
            }
            catch (FieldNotSetException)
            {
            }

            return buffer;
        }
    }
}
