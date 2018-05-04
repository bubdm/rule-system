// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MarcKing.RuleSystem
{
    /// <summary>
    /// Allows for easy serialization testing of classes/structs that implement ISerializable.
    /// </summary>
    internal static class SerializationTester
    {
        #region Public Methods

        /// <summary>
        /// Creates a clone of the specified object through serialization.
        /// </summary>
        /// <typeparam name="T">
        /// Type of specified object.
        /// </typeparam>
        /// <param name="serializable">
        /// The serializable object to clone.
        /// </param>
        /// <returns>
        /// A clone of the specified object.
        /// </returns>
        public static T Clone<T>(T serializable) where T : ISerializable
        {
            return Deserialize<T>(Serialize(serializable));
        }

        /// <summary>
        /// Deserializes an object using a binary formatter.
        /// </summary>
        /// <typeparam name="T">
        /// Type of object to deserialize.
        /// </typeparam>
        /// <param name="stream">
        /// Stream that contains the serialized object.
        /// </param>
        /// <returns>
        /// The deserialized object.
        /// </returns>
        public static T Deserialize<T>(Stream stream) where T : ISerializable
        {
            IFormatter formatter = new BinaryFormatter();

            stream.Position = default;

            return (T)formatter.Deserialize(stream);
        }

        /// <summary>
        /// Serializes an object using a binary formatter.
        /// </summary>
        /// <typeparam name="T">
        /// Type of object to serialize.
        /// </typeparam>
        /// <param name="serializable">
        /// Object to serialize.
        /// </param>
        /// <returns>
        /// Stream containing the serialized object.
        /// </returns>
        public static Stream Serialize<T>(T serializable) where T : ISerializable
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            formatter.Serialize(stream, serializable);

            return stream;
        }

        #endregion Public Methods
    }
}
