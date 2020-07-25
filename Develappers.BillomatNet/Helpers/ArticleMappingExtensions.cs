﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Linq;
using Develappers.BillomatNet.Api;
using Article = Develappers.BillomatNet.Types.Article;

namespace Develappers.BillomatNet.Helpers
{

    internal static class ArticleMappingExtensions
    {
        internal static Types.PagedList<Article> ToDomain(this ArticleListWrapper value)
        {
            return value?.Item.ToDomain();
        }

        internal static Types.PagedList<Article> ToDomain(this ArticleList value)
        {
            if (value == null)
            {
                return null;
            }

            return new Types.PagedList<Article>
            {
                Page = value.Page,
                ItemsPerPage = value.PerPage,
                TotalItems = value.Total,
                List = value.List?.Select(x => x.ToDomain()).ToList()
            };
        }

        internal static Article ToDomain(this ArticleWrapper value)
        {
            return value?.Article.ToDomain();
        }

        private static Article ToDomain(this Api.Article value)
        {
            if (value == null)
            {
                return null;
            }

            return new Article
            {
                Id = int.Parse(value.Id, CultureInfo.InvariantCulture),
                Created = DateTime.Parse(value.Created, CultureInfo.InvariantCulture),
                Updated = DateTime.Parse(value.Updated, CultureInfo.InvariantCulture),
                ArticleNumber = value.ArticleNumber,
                CurrencyCode = value.CurrencyCode,
                Description = value.Description,
                Number = int.Parse(value.Number),
                NumberLength = int.Parse(value.NumberLength),
                NumberPre = value.NumberPre,
                PurchasePrice = value.PurchasePrice.ToOptionalFloat(),
                PurchasePriceNetGross = value.PurchasePriceNetGross.ToNetGrossType(),
                SalesPrice = value.SalesPrice.ToOptionalFloat(),
                SalesPrice2 = value.SalesPrice2.ToOptionalFloat(),
                SalesPrice3 = value.SalesPrice3.ToOptionalFloat(),
                SalesPrice4 = value.SalesPrice4.ToOptionalFloat(),
                SalesPrice5 = value.SalesPrice5.ToOptionalFloat(),
                SupplierId = value.SupplierId.ToOptionalInt(),
                TaxId = value.TaxId.ToOptionalInt(),
                Title = value.Title,
                UnitId = value.UnitId.ToOptionalInt()

            };
        }

        internal static Api.Article ToApi(this Article value)
        {
            if (value == null)
            {
                return null;
            }
            return new Api.Article
            {
                Id = value.Id.ToString(),
                Created = value.Created.ToApiDate(),
                ArticleNumber = value.ArticleNumber,
                CurrencyCode = value.CurrencyCode,
                Description = value.Description,
                Number = value.Number.ToString(),
                NumberLength = value.NumberLength.ToString(),
                NumberPre = value.NumberPre,
                PurchasePrice = value.PurchasePrice.ToInvariantString(),
                PurchasePriceNetGross = value.PurchasePriceNetGross.ToApiValue(),
                SalesPrice = value.SalesPrice.ToInvariantString(),
                SalesPrice2 = value.SalesPrice2.ToInvariantString(),
                SalesPrice3 = value.SalesPrice3.ToInvariantString(),
                SalesPrice4 = value.SalesPrice4.ToInvariantString(),
                SalesPrice5 = value.SalesPrice5.ToInvariantString(),
                SupplierId = value.SupplierId.ToString(),
                TaxId = value.TaxId.ToString(),
                Title = value.Title,
                UnitId = value.UnitId.ToString()
            };
        }
    }
}
