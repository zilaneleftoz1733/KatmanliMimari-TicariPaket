﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Ticari.Entities.Entities.Abstract;
using Ticari.Entities.Entities.Concrete;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Ticari.Entities.CompiledModels
{
    internal partial class ProductEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Ticari.Entities.Entities.Concrete.Product",
                typeof(Product),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(int),
                propertyInfo: typeof(BaseEntity).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(BaseEntity).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw,
                sentinel: 0);
            id.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                keyComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v));
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var amount = runtimeEntityType.AddProperty(
                "Amount",
                typeof(decimal),
                propertyInfo: typeof(Product).GetProperty("Amount", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Amount>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0m);
            amount.TypeMapping = SqlServerDecimalTypeMapping.Default.Clone(
                comparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                keyComparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                providerValueComparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v));
            amount.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var createDate = runtimeEntityType.AddProperty(
                "CreateDate",
                typeof(DateTime),
                propertyInfo: typeof(BaseEntity).GetProperty("CreateDate", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(BaseEntity).GetField("<CreateDate>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            createDate.TypeMapping = SqlServerDateTimeTypeMapping.Default.Clone(
                comparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                keyComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v),
                providerValueComparer: new ValueComparer<DateTime>(
                    (DateTime v1, DateTime v2) => v1.Equals(v2),
                    (DateTime v) => v.GetHashCode(),
                    (DateTime v) => v));
            createDate.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var productCode = runtimeEntityType.AddProperty(
                "ProductCode",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("ProductCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductCode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 100);
            productCode.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(100)",
                    size: 100,
                    unicode: true,
                    dbType: System.Data.DbType.String));
            productCode.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var productDescription = runtimeEntityType.AddProperty(
                "ProductDescription",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("ProductDescription", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductDescription>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                maxLength: 500);
            productDescription.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(500)",
                    size: 500,
                    unicode: true,
                    dbType: System.Data.DbType.String));
            productDescription.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var productName = runtimeEntityType.AddProperty(
                "ProductName",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("ProductName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<ProductName>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 100);
            productName.TypeMapping = SqlServerStringTypeMapping.Default.Clone(
                comparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                keyComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                providerValueComparer: new ValueComparer<string>(
                    (string v1, string v2) => v1 == v2,
                    (string v) => v.GetHashCode(),
                    (string v) => v),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "nvarchar(100)",
                    size: 100,
                    unicode: true,
                    dbType: System.Data.DbType.String));
            productName.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var unitPrice = runtimeEntityType.AddProperty(
                "UnitPrice",
                typeof(decimal),
                propertyInfo: typeof(Product).GetProperty("UnitPrice", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<UnitPrice>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                sentinel: 0m);
            unitPrice.TypeMapping = SqlServerDecimalTypeMapping.Default.Clone(
                comparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                keyComparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v),
                providerValueComparer: new ValueComparer<decimal>(
                    (decimal v1, decimal v2) => v1 == v2,
                    (decimal v) => v.GetHashCode(),
                    (decimal v) => v));
            unitPrice.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { id });

            var index0 = runtimeEntityType.AddIndex(
                new[] { productCode },
                unique: true);

            var index1 = runtimeEntityType.AddIndex(
                new[] { productName },
                unique: true);

            return runtimeEntityType;
        }

        public static RuntimeSkipNavigation CreateSkipNavigation1(RuntimeEntityType declaringEntityType, RuntimeEntityType targetEntityType, RuntimeEntityType joinEntityType)
        {
            var skipNavigation = declaringEntityType.AddSkipNavigation(
                "Categories",
                targetEntityType,
                joinEntityType.FindForeignKey(
                    new[] { joinEntityType.FindProperty("ProductsId") },
                    declaringEntityType.FindKey(new[] { declaringEntityType.FindProperty("Id") }),
                    declaringEntityType),
                true,
                false,
                typeof(ICollection<Category>),
                propertyInfo: typeof(Product).GetProperty("Categories", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Categories>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var inverse = targetEntityType.FindSkipNavigation("Products");
            if (inverse != null)
            {
                skipNavigation.Inverse = inverse;
                inverse.Inverse = skipNavigation;
            }

            return skipNavigation;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Products");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
