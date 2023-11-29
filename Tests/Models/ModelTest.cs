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

namespace Tests.Models
{
    public class ModelTest
    {
        [Test]
        public void TestClear()
        {
            // Check Model Clear method
            TestModel model = new();
            model.DoubleField.Set(0.0);
            model.Clear();
            try
            {
                model.DoubleField.Get();
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
            // Check Model FromBytes method
            BytesBuffer buffer = new(Resources.testmodel);
            TestModel model = new();
            model.FromBytes(buffer);
            // Check field values
            Assert.AreEqual(0.0, model.DoubleField.Get());
            Assert.AreEqual(0, model.Int32Field.Get());
            Assert.AreEqual((ushort)0, model.UInt16Field.Get());
            // Check Model ToBytes method
            Assert.AreEqual(buffer.Get(), model.ToBytes().Get());
        }

        [Test]
        public void TestGetBytesLength()
        {
            // Check Model GetBytesLength method
            BytesBuffer buffer = new(Resources.testmodel);
            TestModel model = new();
            model.FromBytes(buffer);
            Assert.AreEqual(17, model.GetBytesLength());
        }

        [Test]
        public void TestGetFields()
        {
            // Check Model GetFields method
            IField[] referenceFields = {
                new DoubleField(""), new Int32Field(""), new UInt16Field("")
            };
            TestModel model = new();
            IField[] modelFields = model.GetFields();
            for (var i = 0; i < modelFields.Length; i++)
            {
                Assert.IsInstanceOf(referenceFields[i].GetType(), modelFields[i]);
            }
        }
    }
}
