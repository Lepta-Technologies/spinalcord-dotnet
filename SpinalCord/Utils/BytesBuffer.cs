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

namespace SpinalCord.Utils
{
    public class BytesBuffer
    {
        private byte[] _bytes = Array.Empty<byte>();
        private int _cursorI = 0;

        public BytesBuffer()
        {
        }

        public BytesBuffer(byte[] bytes)
        {
            _bytes = bytes;
        }

        public void Append(byte[] bytes)
        {
            byte[] newBytes = new byte[_bytes.Length + bytes.Length];
            if (_bytes.Length > 0)
            {
                _bytes.CopyTo(newBytes, 0);
            }
            bytes.CopyTo(newBytes, _bytes.Length);
            _bytes = newBytes;
        }

        public void Append(BytesBuffer buffer)
        {
            Append(buffer.Get());
        }

        public byte[] Get()
        {
            return _bytes;
        }

        public byte[] Read(int n)
        {
            byte[] bytes = new byte[n];
            for (var i = 0; i < n; i++)
            {
                bytes[i] = _bytes[_cursorI];
                _cursorI++;
            }

            return bytes;
        }
    }
}
