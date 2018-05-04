// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarcKing.RuleSystem.Datatypes.UnitTests
{
    [TestClass]
    public class AbilityScoreTests
    {
        private AbilityScore _testAbilityScore01;
        private AbilityScore _testAbilityScore02;
        private AbilityScore _testAbilityScore03;
        private AbilityScore _testAbilityScore04;
        private AbilityScore _testAbilityScore05;
        private AbilityScore _testAbilityScore06;
        private AbilityScore _testAbilityScore07;
        private AbilityScore _testAbilityScore08;
        private AbilityScore _testAbilityScore09;
        private AbilityScore _testAbilityScore10A;
        private AbilityScore _testAbilityScore10B;
        private AbilityScore _testAbilityScore11;
        private AbilityScore _testAbilityScore12;
        private AbilityScore _testAbilityScore13;
        private AbilityScore _testAbilityScore14;
        private AbilityScore _testAbilityScore15;
        private AbilityScore _testAbilityScore16;
        private AbilityScore _testAbilityScore17;
        private AbilityScore _testAbilityScore18;
        private AbilityScore _testAbilityScore19;
        private AbilityScore _testAbilityScore20;
        private AbilityScore _testAbilityScore21;
        private AbilityScore _testAbilityScore22;
        private AbilityScore _testAbilityScore23;
        private AbilityScore _testAbilityScore24;
        private AbilityScore _testAbilityScore25;
        private AbilityScore _testAbilityScore26;
        private AbilityScore _testAbilityScore27;
        private AbilityScore _testAbilityScore28;
        private AbilityScore _testAbilityScore29;
        private AbilityScore _testAbilityScore30;

        [TestInitialize]
        public void _Initialize()
        {
            _testAbilityScore01 = new AbilityScore(1);
            _testAbilityScore02 = new AbilityScore(2);
            _testAbilityScore03 = new AbilityScore(3);
            _testAbilityScore04 = new AbilityScore(4);
            _testAbilityScore05 = new AbilityScore(5);
            _testAbilityScore06 = new AbilityScore(6);
            _testAbilityScore07 = new AbilityScore(7);
            _testAbilityScore08 = new AbilityScore(8);
            _testAbilityScore09 = new AbilityScore(9);
            _testAbilityScore10A = new AbilityScore(10);
            _testAbilityScore10B = new AbilityScore(10);
            _testAbilityScore11 = new AbilityScore(11);
            _testAbilityScore12 = new AbilityScore(12);
            _testAbilityScore13 = new AbilityScore(13);
            _testAbilityScore14 = new AbilityScore(14);
            _testAbilityScore15 = new AbilityScore(15);
            _testAbilityScore16 = new AbilityScore(16);
            _testAbilityScore17 = new AbilityScore(17);
            _testAbilityScore18 = new AbilityScore(18);
            _testAbilityScore19 = new AbilityScore(19);
            _testAbilityScore20 = new AbilityScore(20);
            _testAbilityScore21 = new AbilityScore(21);
            _testAbilityScore22 = new AbilityScore(22);
            _testAbilityScore23 = new AbilityScore(23);
            _testAbilityScore24 = new AbilityScore(24);
            _testAbilityScore25 = new AbilityScore(25);
            _testAbilityScore26 = new AbilityScore(26);
            _testAbilityScore27 = new AbilityScore(27);
            _testAbilityScore28 = new AbilityScore(28);
            _testAbilityScore29 = new AbilityScore(29);
            _testAbilityScore30 = new AbilityScore(30);
        }

        [TestMethod]
        public void CompareTo_ProvidedAbilityScore_ReturnsCorrentInt()
        {
            Assert.IsTrue(_testAbilityScore10A.CompareTo(_testAbilityScore10B) == 0, "Equal ability score not considered equal.");
            Assert.IsTrue(_testAbilityScore10A.CompareTo(_testAbilityScore30) < 0, "Less than ability score not considered less than.");
            Assert.IsTrue(_testAbilityScore10A.CompareTo(_testAbilityScore01) > 0, "Greater than ability score not considered greater than.");
        }

        [TestMethod]
        public void CompareTo_ProvidedObject_ReturnsCorrectInt()
        {
            IComparable testComparable = _testAbilityScore10A;

            Assert.IsTrue(testComparable.CompareTo(_testAbilityScore10B) == 0, "Equal ability score not considered equal.");
            Assert.IsTrue(testComparable.CompareTo(_testAbilityScore30) < 0, "Less than ability score not considered less than.");
            Assert.IsTrue(testComparable.CompareTo(_testAbilityScore01) > 0, "Greater than ability score not considered greater than.");
            Assert.IsTrue(testComparable.CompareTo(null) > 0, "Null value not considered greater than.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Did not throw exception when comparing ability score to non-ability score object.")]
        public void CompareTo_ProvidedWrongObject_ThrowException()
        {
            IComparable testComparable = _testAbilityScore10A;

            testComparable.CompareTo(new object());
        }

        [TestMethod]
        public void Constructor_ParameterValueToolarge_ClampToMaximumValue()
        {
            var testAbilityScore = new AbilityScore(31);

            Assert.AreEqual(30, testAbilityScore.Value, "Ability score value is above maximum.");
        }

        [TestMethod]
        public void Constructor_ParameterValueTooSmall_ClampToMinimumValue()
        {
            var testAbilityScore = new AbilityScore(0);

            Assert.AreEqual(1, testAbilityScore.Value, "Ability score value is below minimum.");
        }

        [TestMethod]
        public void Constructor_Serialization_SerializeAndUnserializeCorrectly()
        {
            var testSerializable = SerializationTester.Clone(_testAbilityScore13);
            Assert.IsTrue(_testAbilityScore13 == testSerializable, "Deserialized ability score is not equal to the serialized ability score.");
        }

        [TestMethod]
        public void Equals_ProvidedAbilityScore_ReturnsCorrectBoolean()
        {
            Assert.IsTrue(_testAbilityScore10A.Equals(_testAbilityScore10B), "Equal ability scores not considered equal.");
            Assert.IsFalse(_testAbilityScore10A.Equals(_testAbilityScore01), "Nonequal ability scores considered equal.");
        }

        [TestMethod]
        public void Equals_ProvidedObject_ReturnsCorrectBoolean()
        {
            Assert.IsTrue(_testAbilityScore10A.Equals((object)_testAbilityScore10B), "Equal ability score and object not considered equal.");
            Assert.IsFalse(_testAbilityScore10A.Equals((object)_testAbilityScore01), "Nonequal ability score and object considered equal.");
            Assert.IsFalse(_testAbilityScore10A.Equals(null), "Ability score considered equal to null.");
            Assert.IsFalse(_testAbilityScore10A.Equals(new object()), "Ability score considered equal to object that is not an ability score.");
        }

        [TestMethod]
        public void GetHashCode_EqualAbilityScores_ReturnSameHash()
        {
            byte testByte = 10;

            Assert.AreEqual(testByte.GetHashCode(), _testAbilityScore10A.GetHashCode(), "Ability score hash code does not match byte hash code.");
            Assert.AreEqual(_testAbilityScore10A.GetHashCode(), _testAbilityScore10B.GetHashCode(), "Ability scores with same values have mismatched hash codes.");
        }

        [TestMethod]
        public void ImplicitCastFromByte_CastFromByte_NewByteWithAbilityScoreValue()
        {
            byte testByte = 10;
            AbilityScore testAbilityScore = testByte;

            Assert.AreEqual(testByte, testAbilityScore.Value, "Implicit cast to AbilityScore from byte failed.");
        }

        [TestMethod]
        public void ImplicitCastToByte_CastToByte_NewAbilityScoreWithByteValue()
        {
            byte testByte = _testAbilityScore10A;

            Assert.AreEqual(_testAbilityScore10A.Value, testByte, "Implicit cast to byte from AbilityScore failed.");
        }

        [TestMethod]
        public void ModifierProperty_Get_ReturnCorrectModifierForValue()
        {
            Assert.AreEqual(-5, _testAbilityScore01.Modifier, "Incorrect modifier for ability score value of 1.");
            Assert.AreEqual(-4, _testAbilityScore02.Modifier, "Incorrect modifier for ability score value of 2.");
            Assert.AreEqual(-4, _testAbilityScore03.Modifier, "Incorrect modifier for ability score value of 3.");
            Assert.AreEqual(-3, _testAbilityScore04.Modifier, "Incorrect modifier for ability score value of 4.");
            Assert.AreEqual(-3, _testAbilityScore05.Modifier, "Incorrect modifier for ability score value of 5.");
            Assert.AreEqual(-2, _testAbilityScore06.Modifier, "Incorrect modifier for ability score value of 6.");
            Assert.AreEqual(-2, _testAbilityScore07.Modifier, "Incorrect modifier for ability score value of 7.");
            Assert.AreEqual(-1, _testAbilityScore08.Modifier, "Incorrect modifier for ability score value of 8.");
            Assert.AreEqual(-1, _testAbilityScore09.Modifier, "Incorrect modifier for ability score value of 9.");
            Assert.AreEqual(0, _testAbilityScore10A.Modifier, "Incorrect modifier for ability score value of 10.");
            Assert.AreEqual(0, _testAbilityScore11.Modifier, "Incorrect modifier for ability score value of 11.");
            Assert.AreEqual(1, _testAbilityScore12.Modifier, "Incorrect modifier for ability score value of 12.");
            Assert.AreEqual(1, _testAbilityScore13.Modifier, "Incorrect modifier for ability score value of 13.");
            Assert.AreEqual(2, _testAbilityScore14.Modifier, "Incorrect modifier for ability score value of 14.");
            Assert.AreEqual(2, _testAbilityScore15.Modifier, "Incorrect modifier for ability score value of 15.");
            Assert.AreEqual(3, _testAbilityScore16.Modifier, "Incorrect modifier for ability score value of 16.");
            Assert.AreEqual(3, _testAbilityScore17.Modifier, "Incorrect modifier for ability score value of 17.");
            Assert.AreEqual(4, _testAbilityScore18.Modifier, "Incorrect modifier for ability score value of 18.");
            Assert.AreEqual(4, _testAbilityScore19.Modifier, "Incorrect modifier for ability score value of 19.");
            Assert.AreEqual(5, _testAbilityScore20.Modifier, "Incorrect modifier for ability score value of 20.");
            Assert.AreEqual(5, _testAbilityScore21.Modifier, "Incorrect modifier for ability score value of 21.");
            Assert.AreEqual(6, _testAbilityScore22.Modifier, "Incorrect modifier for ability score value of 22.");
            Assert.AreEqual(6, _testAbilityScore23.Modifier, "Incorrect modifier for ability score value of 23.");
            Assert.AreEqual(7, _testAbilityScore24.Modifier, "Incorrect modifier for ability score value of 24.");
            Assert.AreEqual(7, _testAbilityScore25.Modifier, "Incorrect modifier for ability score value of 25.");
            Assert.AreEqual(8, _testAbilityScore26.Modifier, "Incorrect modifier for ability score value of 26.");
            Assert.AreEqual(8, _testAbilityScore27.Modifier, "Incorrect modifier for ability score value of 27.");
            Assert.AreEqual(9, _testAbilityScore28.Modifier, "Incorrect modifier for ability score value of 28.");
            Assert.AreEqual(9, _testAbilityScore29.Modifier, "Incorrect modifier for ability score value of 29.");
            Assert.AreEqual(10, _testAbilityScore30.Modifier, "Incorrect modifier for ability score value of 30.");
        }

        [TestMethod]
        public void OperatorEqual_CompareAbilityScores_ReturnsCorrectBoolean()
        {
            Assert.IsTrue(_testAbilityScore10A == _testAbilityScore10B, "Equal ability scores not considered equal.");
            Assert.IsFalse(_testAbilityScore10A == _testAbilityScore01, "Nonequal ability scores considered equal.");
        }

        [TestMethod]
        public void OperatorGreaterThan_CompareAbilityScores_ReturnsCorrectBoolean()
        {
            Assert.IsFalse(_testAbilityScore10A > _testAbilityScore10B, "Equal ability score considered greater than.");
            Assert.IsFalse(_testAbilityScore10A > _testAbilityScore30, "Less than ability score considered greater than.");
            Assert.IsTrue(_testAbilityScore10A > _testAbilityScore01, "Greater than ability score not considered greater than.");
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqual_CompareAbilityScores_ReturnsCorrectBoolean()
        {
            Assert.IsTrue(_testAbilityScore10A >= _testAbilityScore10B, "Equal ability score not considered equal.");
            Assert.IsFalse(_testAbilityScore10A >= _testAbilityScore30, "Less than ability score considered greater than.");
            Assert.IsTrue(_testAbilityScore10A >= _testAbilityScore01, "Greater than ability score not considered greater than.");
        }

        [TestMethod]
        public void OperatorLessThan_CompareAbilityScores_ReturnsCorrectBoolean()
        {
            Assert.IsFalse(_testAbilityScore10A < _testAbilityScore10B, "Equal ability score considered less than.");
            Assert.IsTrue(_testAbilityScore10A < _testAbilityScore30, "Less than ability score not considered less than.");
            Assert.IsFalse(_testAbilityScore10A < _testAbilityScore01, "Greater than ability score considered less than.");
        }

        [TestMethod]
        public void OperatorLessThanOrEqual_CompareAbilityScores_ReturnsCorrectBoolean()
        {
            Assert.IsTrue(_testAbilityScore10A <= _testAbilityScore10B, "Equal ability scores not considered equal.");
            Assert.IsTrue(_testAbilityScore10A <= _testAbilityScore30, "Less than ability score not considered less than.");
            Assert.IsFalse(_testAbilityScore10A <= _testAbilityScore01, "Greater than ability score considered less than.");
        }

        [TestMethod]
        public void OperatorNotEqual_CompareAbilityScores_ReturnsCorrectBoolean()
        {
            Assert.IsFalse(_testAbilityScore10A != _testAbilityScore10B, "Equal ability scores not considered equal.");
            Assert.IsTrue(_testAbilityScore10A != _testAbilityScore01, "Nonequal ability scores considered equal.");
        }

        [TestMethod]
        public void ToString_WhenCalled_ReturnsFormattedString()
        {
            Assert.AreEqual("13", _testAbilityScore13.ToString(), "Value not convert to string properly.");

            Assert.AreEqual("1 (-5)", _testAbilityScore01.ToString("M"), "Negative modifier not converted to string properly.");
            Assert.AreEqual("10 (0)", _testAbilityScore10A.ToString("M"), "Zero modifier not converted to string properly.");
            Assert.AreEqual("30 (+10)", _testAbilityScore30.ToString("M"), "Positive modifier not converted to string properly.");

            Assert.AreEqual("1  (-5)", _testAbilityScore01.ToString("L"), "Left aligned negative modifier not converted to string properly.");
            Assert.AreEqual("10 (0)", _testAbilityScore10A.ToString("L"), "Left aligned zero modifier not converted to string properly.");
            Assert.AreEqual("30 (+10)", _testAbilityScore30.ToString("L"), "Left aligned positive modifier not converted to string properly.");

            Assert.AreEqual(" 1  (-5)", _testAbilityScore01.ToString("R"), "Right aligned negative modifier not converted to string properly.");
            Assert.AreEqual("10   (0)", _testAbilityScore10A.ToString("R"), "Right aligned zero modifier not converted to string properly.");
            Assert.AreEqual("30 (+10)", _testAbilityScore30.ToString("R"), "Right aligned positive modifier not converted to string properly.");

            Assert.AreEqual(" 1 (-5)", _testAbilityScore01.ToString("C"), "Center aligned negative modifier not converted to string properly.");
            Assert.AreEqual("10 (0)", _testAbilityScore10A.ToString("C"), "Center aligned zero modifier not converted to string properly.");
            Assert.AreEqual("30 (+10)", _testAbilityScore30.ToString("C"), "Center aligned positive modifier not converted to string properly.");
        }
    }
}
