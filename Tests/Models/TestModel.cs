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
using SpinalCord.Models;

namespace Tests.Models
{
    public class TestModel : Model
    {
        public readonly DoubleField DoubleField = new("doubleField");
        public readonly Int32Field Int32Field = new("int32Field");
        public readonly UInt16Field UInt16Field = new("uInt16Field");

        public override IField[] GetFields()
        {
            return new IField[] { DoubleField, Int32Field, UInt16Field };
        }
    }
}
