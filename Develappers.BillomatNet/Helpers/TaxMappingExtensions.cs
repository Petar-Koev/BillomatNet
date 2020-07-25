﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Linq;
using Develappers.BillomatNet.Api;
using Tax = Develappers.BillomatNet.Types.Tax;


namespace Develappers.BillomatNet.Helpers
{
    internal static class TaxMappingExtensions
    {
        internal static Tax ToDomain(this TaxWrapper value)
        {
            return value?.Tax.ToDomain();
        }

        internal static Types.PagedList<Tax> ToDomain(this TaxList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<Tax>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(x => x.ToDomain()).ToList()
            };
        }

        internal static Types.PagedList<Tax> ToDomain(this TaxListWrapper value)
        {
            return value?.Item.ToDomain();
        }

        private static Tax ToDomain(this Api.Tax value)
        {
            if (value == null)
            {
                return null;
            }

            return new Tax
            {
                Id = int.Parse(value.Id, CultureInfo.InvariantCulture),
                Created = Convert.ToDateTime(value.Created, CultureInfo.InvariantCulture),
                Updated = Convert.ToDateTime(value.Updated, CultureInfo.InvariantCulture),
                Name = value.Name,
                Rate = float.Parse(value.Rate),
                IsDefault = value.IsDefault.ToBoolean()
            };
        }

        internal static Api.Tax ToApi(this Tax value)
        {
            if (value == null)
            {
                return null;
            }

            return new Api.Tax
            {
                Name = value.Name,
                Rate = value.Rate.ToString(CultureInfo.InvariantCulture),
                IsDefault = value.IsDefault.ToString()
            };
        }
    }
}
