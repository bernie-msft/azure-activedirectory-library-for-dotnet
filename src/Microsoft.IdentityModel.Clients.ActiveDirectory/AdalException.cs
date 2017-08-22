﻿//----------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.IdentityModel.Clients.ActiveDirectory
{
    /// <summary>
    /// The exception type thrown when an error occurs during token acquisition.
    /// </summary>
    public class AdalException : Exception
    {
        internal enum ErrorFormat
        {
            Json,
            Other
        }

        /// <summary>
        ///  Initializes a new instance of the exception class.
        /// </summary>
        public AdalException()
            : base(AdalErrorMessage.Unknown)
        {
            this.ErrorCode = AdalError.Unknown;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        public AdalException(string errorCode)
            : base(GetErrorMessage(errorCode))
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code and error message.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public AdalException(string errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code and a reference to the inner exception that is the cause of
        ///  this exception.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified. It may especially contain the actual error message returned by the service.</param>
        public AdalException(string errorCode, Exception innerException)
            : base(GetErrorMessage(errorCode), innerException)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///  Initializes a new instance of the exception class with a specified
        ///  error code, error message and a reference to the inner exception that is the cause of
        ///  this exception.
        /// </summary>
        /// <param name="errorCode">The error code returned by the service or generated by client. This is the code you can rely on for exception handling.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified. It may especially contain the actual error message returned by the service.</param>
        public AdalException(string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets the protocol error code returned by the service or generated by client. This is the code you can rely on for exception handling.
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>A string representation of the current exception.</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format(CultureInfo.CurrentCulture, "\n\tErrorCode: {0}", this.ErrorCode);
        }

        internal static string GetErrorMessage(string errorCode)
        {
            string message;
            switch (errorCode)
            {
                case AdalError.InvalidCredentialType: 
                    message = AdalErrorMessage.InvalidCredentialType;
                    break;

                case AdalError.IdentityProtocolLoginUrlNull:
                    message = AdalErrorMessage.IdentityProtocolLoginUrlNull;
                    break;

                case AdalError.IdentityProtocolMismatch:
                    message = AdalErrorMessage.IdentityProtocolMismatch;
                    break;

                case AdalError.EmailAddressSuffixMismatch:
                    message = AdalErrorMessage.EmailAddressSuffixMismatch;
                    break;

                case AdalError.IdentityProviderRequestFailed:
                    message = AdalErrorMessage.IdentityProviderRequestFailed;
                    break;

                case AdalError.StsTokenRequestFailed:
                    message = AdalErrorMessage.StsTokenRequestFailed;
                    break;

                case AdalError.EncodedTokenTooLong:
                    message = AdalErrorMessage.EncodedTokenTooLong;
                    break;

                case AdalError.StsMetadataRequestFailed:
                    message = AdalErrorMessage.StsMetadataRequestFailed;
                    break;

                case AdalError.AuthorityNotInValidList:
                    message = AdalErrorMessage.AuthorityNotInValidList;
                    break;

                case AdalError.UnknownUserType:
                    message = AdalErrorMessage.UnknownUserType;
                    break;

                case AdalError.UnknownUser:
                    message = AdalErrorMessage.UnknownUser;
                    break;

                case AdalError.UserRealmDiscoveryFailed:
                    message = AdalErrorMessage.UserRealmDiscoveryFailed;
                    break;

                case AdalError.AccessingWsMetadataExchangeFailed:
                    message = AdalErrorMessage.AccessingMetadataDocumentFailed;
                    break;

                case AdalError.ParsingWsMetadataExchangeFailed:
                    message = AdalErrorMessage.ParsingMetadataDocumentFailed;
                    break;

                case AdalError.WsTrustEndpointNotFoundInMetadataDocument:
                    message = AdalErrorMessage.WsTrustEndpointNotFoundInMetadataDocument;
                    break;

                case AdalError.ParsingWsTrustResponseFailed:
                    message = AdalErrorMessage.ParsingWsTrustResponseFailed;
                    break;

                case AdalError.AuthenticationCanceled:
                    message = AdalErrorMessage.AuthenticationCanceled;
                    break;

                case AdalError.NetworkNotAvailable:
                    message = AdalErrorMessage.NetworkIsNotAvailable;
                    break;

                case AdalError.AuthenticationUiFailed:
                    message = AdalErrorMessage.AuthenticationUiFailed;
                    break;

                case AdalError.UserInteractionRequired:
                    message = AdalErrorMessage.UserInteractionRequired;
                    break;

                case AdalError.MissingFederationMetadataUrl:
                    message = AdalErrorMessage.MissingFederationMetadataUrl;
                    break;

                case AdalError.IntegratedAuthFailed:
                    message = AdalErrorMessage.IntegratedAuthFailed;
                    break;

                case AdalError.UnauthorizedResponseExpected:
                    message = AdalErrorMessage.UnauthorizedResponseExpected;
                    break;

                case AdalError.MultipleTokensMatched:
                    message = AdalErrorMessage.MultipleTokensMatched;
                    break;

                case AdalError.PasswordRequiredForManagedUserError:
                    message = AdalErrorMessage.PasswordRequiredForManagedUserError;
                    break;

                case AdalError.GetUserNameFailed:
                    message = AdalErrorMessage.GetUserNameFailed;
                    break;

                case AdalError.InteractionRequired:
                    message = AdalErrorMessage.InteractionRequired;
                    break;

                default:
                    message = AdalErrorMessage.Unknown;
                    break;
            }

            return String.Format(CultureInfo.InvariantCulture, "{0}: {1}", errorCode, message);
        }
    }
}