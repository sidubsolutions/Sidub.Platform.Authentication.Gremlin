/*
 * Sidub Platform - Authentication - Gremlin
 * Copyright (C) 2024 Sidub Inc.
 * All rights reserved.
 *
 * This file is part of Sidub Platform - Authentication - Gremlin (the "Product").
 *
 * The Product is dual-licensed under:
 * 1. The GNU Affero General Public License version 3 (AGPLv3)
 * 2. Sidub Inc.'s Proprietary Software License Agreement (PSLA)
 *
 * You may choose to use, redistribute, and/or modify the Product under
 * the terms of either license.
 *
 * The Product is provided "AS IS" and "AS AVAILABLE," without any
 * warranties or conditions of any kind, either express or implied, including
 * but not limited to implied warranties or conditions of merchantability and
 * fitness for a particular purpose. See the applicable license for more
 * details.
 *
 * See the LICENSE.txt file for detailed license terms and conditions or
 * visit https://sidub.ca/licensing for a copy of the license texts.
 */

namespace Sidub.Platform.Authentication.Credentials
{

    /// <summary>
    /// Represents a Gremlin password credential used for authentication.
    /// </summary>
    public class GremlinPasswordCredential : IClientCredential
    {

        #region Public properties

        /// <summary>
        /// Gets the password associated with the credential.
        /// </summary>
        internal string Password { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GremlinPasswordCredential"/> class with the specified password.
        /// </summary>
        /// <param name="password">The password to be associated with the credential.</param>
        public GremlinPasswordCredential(string password)
        {
            Password = password;
        }

        #endregion

    }

}
