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

using SpinalCord.Exceptions;
using SpinalCord.Fields;
using SpinalCord.Utils;

namespace Tests.Fields
{
    public class Int32FieldTest
    {
        [Test]
        public void TestClear()
        {
            // Check Int32Field Clear method
            Int32Field int32Field = new("int32Field");
            int32Field.Set(0);
            int32Field.Clear();
            try
            {
                int32Field.Get();
                Assert.Fail();
            }
            catch (FieldNotSetException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void TestFromToBytes()
        {
            // Check Int32Field FromBytes and ToBytes methods
            BytesBuffer buffer = new(Resources.int32);
            Int32Field int32Field = new("int32Field");
            // Check min value
            BytesBuffer minBuffer = new(buffer.Read(5));
            int32Field.FromBytes(minBuffer);
            Assert.AreEqual(-2147483648, int32Field.Get());
            Assert.AreEqual(minBuffer.Get(), int32Field.ToBytes().Get());
            // Check max value
            BytesBuffer maxBuffer = new(buffer.Read(5));
            int32Field.FromBytes(maxBuffer);
            Assert.AreEqual(2147483647, int32Field.Get());
            Assert.AreEqual(maxBuffer.Get(), int32Field.ToBytes().Get());
        }

        [Test]
        public void TestGetBytesLength()
        {
            // Check Int32Field GetBytesLength method
            Int32Field int32Field = new("int32Field");
            Assert.AreEqual(1, int32Field.GetBytesLength());
            int32Field.Set(0);
            Assert.AreEqual(5, int32Field.GetBytesLength());
        }

        [Test]
        public void TestGetColumnName()
        {
            // Check Int32Field GetColumnName method
            Int32Field int32Field = new("int32Field");
            Assert.AreEqual("int32Field", int32Field.GetColumnName());
        }

        [Test]
        public void TestGetSet()
        {
            // Check Int32Field Get and Set methods
            Int32Field int32Field = new("int32Field");
            // Check an exception is thrown when attempting to call get before set
            try
            {
                int32Field.Get();
                Assert.Fail();
            }
            catch (FieldNotSetException)
            {
            }
            // Set and check value
            int32Field.Set(0);
            try
            {
                Assert.AreEqual(0, int32Field.Get());
            }
            catch (FieldNotSetException)
            {
                Assert.Fail();
            }
        }
    }
}
