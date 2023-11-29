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

using System.Reflection;
using System.Resources;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using SpinalCord.Exceptions;
using SpinalCord.Fields;
using SpinalCord.Utils;

namespace Tests.Fields
{
    public class DoubleFieldTest
    {
        [Test]
        public void TestClear()
        {
            // Check DoubleField Clear method
            DoubleField doubleField = new("doubleField");
            doubleField.Set(0.0);
            doubleField.Clear();
            try
            {
                doubleField.Get();
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
            // Check DoubleField FromBytes and ToBytes methods
            BytesBuffer buffer = new(Resources._double);
            DoubleField doubleField = new("doubleField");
            // Check min value
            BytesBuffer minBuffer = new(buffer.Read(9));
            doubleField.FromBytes(minBuffer);
            Assert.AreEqual(1.7e-308, doubleField.Get());
            Assert.AreEqual(minBuffer.Get(), doubleField.ToBytes().Get());
            // Check max value
            BytesBuffer maxBuffer = new(buffer.Read(9));
            doubleField.FromBytes(maxBuffer);
            Assert.AreEqual(1.7e+308, doubleField.Get());
            Assert.AreEqual(maxBuffer.Get(), doubleField.ToBytes().Get());
        }

        [Test]
        public void TestGetBytesLength()
        {
            // Check DoubleField GetBytesLength method
            DoubleField doubleField = new("doubleField");
            Assert.AreEqual(1, doubleField.GetBytesLength());
            doubleField.Set(0.0);
            Assert.AreEqual(9, doubleField.GetBytesLength());
        }

        [Test]
        public void TestGetColumnName()
        {
            // Check DoubleField GetColumnName method
            DoubleField doubleField = new("doubleField");
            Assert.AreEqual("doubleField", doubleField.GetColumnName());
        }

        [Test]
        public void TestGetSet()
        {
            // Check DoubleField Get and Set methods
            DoubleField doubleField = new("doubleField");
            // Check an exception is thrown when attempting to call get before set
            try
            {
                doubleField.Get();
                Assert.Fail();
            }
            catch (FieldNotSetException)
            {
            }
            // Set and check value
            doubleField.Set(0.0);
            try
            {
                Assert.AreEqual(0.0, doubleField.Get());
            }
            catch (FieldNotSetException)
            {
                Assert.Fail();
            }
        }
    }
}
