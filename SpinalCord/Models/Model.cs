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

using SpinalCord.Fields;
using SpinalCord.Utils;

namespace SpinalCord.Models
{
    public abstract class Model : IModel
    {
        public void Clear()
        {
            // Clear fields
            foreach (IField field in GetFields())
            {
                field.Clear();
            }
        }

        public void FromBytes(BytesBuffer buffer)
        {
            // Set fields
            foreach (IField field in GetFields())
            {
                field.FromBytes(buffer);
            }
        }

        public int GetBytesLength()
        {
            var n = 0;
            // Sum fields
            foreach (IField field in GetFields())
            {
                n += field.GetBytesLength();
            }

            return n;
        }

        public BytesBuffer ToBytes()
        {
            BytesBuffer buffer = new();
            // Append fields
            foreach (IField field in GetFields())
            {
                buffer.Append(field.ToBytes());
            }

            return buffer;
        }

        public abstract IField[] GetFields();
    }
}
