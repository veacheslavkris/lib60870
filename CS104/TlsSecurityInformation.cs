﻿/*
 *  Copyright 2016-2018 MZ Automation GmbH
 *
 *  This file is part of lib60870.NET
 *
 *  lib60870.NET is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  lib60870.NET is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with lib60870.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  See COPYING file for the complete license text.
 */

using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace lib60870.CS104
{
    public class TlsSecurityInformation
    {
        private X509Certificate2 ownCertificate;

        private List<X509Certificate2> otherCertificates;

        private List<X509Certificate2> caCertificates;

        private string targetHostName = null;

        // Check certificate chain validity with registered CAs
        private bool chainValidation = true;

        private bool allowOnlySpecificCertificates = false;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="lib60870.TlsSecurityInformation"/> performs a X509 chain validation
        /// against the registered CA certificates
        /// </summary>
        /// <value><c>true</c> if chain validation; otherwise, <c>false</c>.</value>
        public bool ChainValidation
        {
            get
            {
                return this.chainValidation;
            }
            set
            {
                chainValidation = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="lib60870.TlsSecurityInformation"/> allow only specific certificates.
        /// </summary>
        /// <value><c>true</c> if allow only specific certificates; otherwise, <c>false</c>.</value>
        public bool AllowOnlySpecificCertificates
        {
            get
            {
                return this.allowOnlySpecificCertificates;
            }
            set
            {
                allowOnlySpecificCertificates = value;
            }
        }

        public TlsSecurityInformation(string targetHostName, X509Certificate2 ownCertificate)
        {

            this.targetHostName = targetHostName;
            this.ownCertificate = ownCertificate;

            otherCertificates = new List<X509Certificate2>();
            caCertificates = new List<X509Certificate2>();
        }


        public TlsSecurityInformation(X509Certificate2 ownCertificate)
        {
            this.ownCertificate = ownCertificate;

            otherCertificates = new List<X509Certificate2>();
            caCertificates = new List<X509Certificate2>();
        }

        public X509Certificate2 OwnCertificate
        {
            get
            {
                return this.ownCertificate;
            }
            set
            {
                ownCertificate = value;
            }
        }

        public List<X509Certificate2> AllowedCertificates
        {
            get
            {
                return this.otherCertificates;
            }
            set
            {
                otherCertificates = value;
            }
        }

        public List<X509Certificate2> CaCertificates
        {
            get
            {
                return this.caCertificates;
            }
        }

        public string TargetHostName
        {
            get
            {
                return this.targetHostName;
            }
        }

        public void AddAllowedCertificate(X509Certificate2 allowedCertificate)
        {
            otherCertificates.Add(allowedCertificate);
        }

        public void AddCA(X509Certificate2 caCertificate)
        {
            caCertificates.Add(caCertificate);
        }
    }
}

