// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

namespace MarcKing.RuleSystem.Interfaces.Datatypes
{
    /// <summary>
    /// Defines properties that retrieve the value or modifier of an ability score.
    /// </summary>
    public interface IAbilityScore
    {
        #region Public Properties

        /// <summary>
        /// Returns the modifier for this <see cref="IAbilityScore"/> object.
        /// </summary>
        sbyte Modifier { get; }

        /// <summary>
        /// Returns the value for this <see cref="IAbilityScore"/> object.
        /// </summary>
        byte Value { get; }

        #endregion Public Properties
    }
}
