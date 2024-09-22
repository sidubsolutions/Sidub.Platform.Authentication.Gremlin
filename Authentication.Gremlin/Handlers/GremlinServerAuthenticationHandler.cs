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

#region Imports

using Gremlin.Net.Driver;
using Sidub.Platform.Authentication.Credentials;
using Sidub.Platform.Core;
using Sidub.Platform.Core.Services;

#endregion

namespace Sidub.Platform.Authentication.Handlers
{

    /// <summary>
    /// Handles authentication for GremlinServer.
    /// </summary>
    public class GremlinServerAuthenticationHandler : IAuthenticationHandler<GremlinServer>
    {

        #region Member variables

        private readonly IServiceRegistry _serviceRegistry;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GremlinServerAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="serviceRegistry">The service registry.</param>
        public GremlinServerAuthenticationHandler(IServiceRegistry serviceRegistry)
        {
            _serviceRegistry = serviceRegistry;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Handles the authentication for GremlinServer.
        /// </summary>
        /// <param name="ServiceReferenceContext">The service reference context.</param>
        /// <param name="request">The GremlinServer request.</param>
        /// <returns>The authenticated GremlinServer.</returns>
        public GremlinServer Handle(ServiceReference ServiceReferenceContext, GremlinServer request)
        {
            // check if authentication exists for given ServiceReference... we should only have one credential association...
            var credential = _serviceRegistry.GetMetadata<IClientCredential>(ServiceReferenceContext).SingleOrDefault();

            // if no credentials exist, exit...
            if (credential is null)
                return request;

            // handle credentials based on type...
            if (credential is GremlinPasswordCredential gremlinCredential)
            {
                var passwordCredential = gremlinCredential.Password; // null hint...
                var authenticatedServer = new GremlinServer(request.Uri.Host, request.Uri.Port, request.Uri.Scheme == "wss", request.Username, passwordCredential);

                return authenticatedServer;
            }

            throw new Exception($"Unhandled credential type '{credential.GetType().Name}' encountered in authentication handler.");
        }

        #endregion

    }

}
