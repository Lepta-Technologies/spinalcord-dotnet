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
    public class UInt16Test
    {
        [Test]
        public void TestClear()
        {
            // Check UInt16Field Clear method
            UInt16Field uInt16Field = new("uInt16Field");
            uInt16Field.Set(0);
            uInt16Field.Clear();
            try
            {
                uInt16Field.Get();
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
            // Check UInt16Field FromBytes and ToBytes methods
            BytesBuffer buffer = new(Resources.uint16);
            UInt16Field uInt16Field = new("uInt16Field");
            // Check min value
            BytesBuffer minBuffer = new(buffer.Read(3));
            uInt16Field.FromBytes(minBuffer);
            Assert.AreEqual(0, uInt16Field.Get());
            Assert.AreEqual(minBuffer.Get(), uInt16Field.ToBytes().Get());
            // Check max value
            BytesBuffer maxBuffer = new(buffer.Read(3));
            uInt16Field.FromBytes(maxBuffer);
            Assert.AreEqual(65535, uInt16Field.Get());
            Assert.AreEqual(maxBuffer.Get(), uInt16Field.ToBytes().Get());
        }

        [Test]
        public void TestGetBytesLength()
        {
            // Check UInt16Field GetBytesLength method
            UInt16Field uInt16Field = new("uInt16Field");
            Assert.AreEqual(1, uInt16Field.GetBytesLength());
            uInt16Field.Set(0);
            Assert.AreEqual(3, uInt16Field.GetBytesLength());
        }

        [Test]
        public void TestGetColumnName()
        {
            // Check UInt16Field GetColumnName method
            UInt16Field uInt16Field = new("uInt16Field");
            Assert.AreEqual("uInt16Field", uInt16Field.GetColumnName());
        }

        [Test]
        public void TestGetSet()
        {
            // Check UInt16Field Get and Set methods
            UInt16Field uInt16Field = new("uInt16Field");
            // Check an exception is thrown when attempting to call get before set
            try
            {
                uInt16Field.Get();
                Assert.Fail();
            }
            catch (FieldNotSetException)
            {
            }
            // Set and check value
            uInt16Field.Set(0);
            try
            {
                Assert.AreEqual(0, uInt16Field.Get());
            }
            catch (FieldNotSetException)
            {
                Assert.Fail();
            }
        }
    }
}
