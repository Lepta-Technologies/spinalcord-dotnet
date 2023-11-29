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
    public class BytesConverter
    {
        public static byte[] FromBoolean(Boolean value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] FromDouble(double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] FromInt32(int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] FromUInt16(ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        public static bool ToBoolean(byte[] bytes)
        {
            return BitConverter.ToBoolean(bytes);
        }

        public static double ToDouble(byte[] bytes)
        {
            return BitConverter.ToDouble(bytes);
        }

        public static int ToInt32(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes);
        }

        public static ushort ToUInt16(byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes);
        }
    }
}
